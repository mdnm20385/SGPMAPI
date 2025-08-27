using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Models.Facturacao;
using Model.Models.SGPM;
using Model.Models.SJM;
using Newtonsoft.Json;
using SGPMAPI.Procura;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SGPMAPI.Interfaces
{
    public class Userservice : InterUsers
    {
        public readonly SGPMContext ApIcontext;
        private readonly IGenericRepository<Usuario> _usuarRepository;
        private readonly InterfaceProcura procura;
        public SGPMContext _dbContext;
        private readonly IConfiguration _configuration;
        public Userservice(SGPMContext nomeAPi, 
            IGenericRepository<Usuario> usuarRepository, 
            InterfaceProcura _procura,
            IConfiguration configuration)
        {
            _usuarRepository = usuarRepository;
            ApIcontext = nomeAPi;
            _dbContext = nomeAPi;
            procura = _procura;
            _configuration = configuration;
        }
        readonly Cryptografia _objCrypto = new();
                        public async Task<Token> ValidarCredenciais(string login, string senha)
        {
            Token serviceResponse = new Token();
            var cript = _objCrypto.Crypto(senha.Trim(), true);

            // Busca tentativas
            var tentativa = await ApIcontext.UsuarioLoginTentativa
                .FirstOrDefaultAsync(t => t.Login == login);

            // Verifica bloqueio
            if (tentativa != null && tentativa.Bloqueado && tentativa.BloqueadoAte > DateTime.UtcNow)
            {
                serviceResponse.Mensagem = "Usuário bloqueado por múltiplas tentativas. Tente novamente mais tarde.";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            try
            {
                var dt = await ApIcontext.Usuario.
                    Include(z=>z.UsuarioMenu)
                    .Where(x => x.Senha != null && x.Login.ToLower() == login.ToLower()
                                && x.Senha == cript && x.Activopa)
                    .FirstOrDefaultAsync();

                if (dt == null || string.IsNullOrEmpty(dt.Login))
                {
                    // Logging e controle de tentativas
                    if (tentativa == null)
                    {
                        tentativa = new UsuarioLoginTentativa
                        {
                            Login = login,
                            Tentativas = 1,
                            UltimaTentativa = DateTime.UtcNow,
                            Bloqueado = false
                        };
                        ApIcontext.UsuarioLoginTentativa.Add(tentativa);
                    }
                    else
                    {
                        tentativa.Tentativas++;
                        tentativa.UltimaTentativa = DateTime.UtcNow;
                        if (tentativa.Tentativas >= 5) // Exemplo: bloqueia após 5 tentativas
                        {
                            tentativa.Bloqueado = true;
                            tentativa.BloqueadoAte = DateTime.UtcNow.AddMinutes(15); // Bloqueia por 15 minutos
                        }
                    }
                    await ApIcontext.SaveChangesAsync();
                    await Task.Delay(1000);
                    serviceResponse.Mensagem = "Credenciais inválidas";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                // Login bem-sucedido: reseta tentativas
                if (tentativa != null)
                {
                    tentativa.Tentativas = 0;
                    tentativa.Bloqueado = false;
                    tentativa.BloqueadoAte = null;
                    await ApIcontext.SaveChangesAsync();
                }

                // Claims do usuário
                if (dt.PaStamp != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, dt.Login ?? ""),
                        new Claim("UsuarioId", dt.PaStamp),
                        new Claim(ClaimTypes.Name, dt.Nome ?? ""),
                        new Claim(ClaimTypes.Email, dt.Email ?? "")
                    };

                    var secretKey = _configuration["JWT:Secret"];
                    var validIssuers = _configuration.GetSection("JWT:ValidIssuer").Get<string[]>();
                    var validAudiences = _configuration.GetSection("JWT:ValidAudience").Get<string[]>();
                    var issuer = validIssuers.First();
                    var audience = validAudiences.First();

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var tokenDescriptor = new JwtSecurityToken(
                        issuer: issuer,
                        audience: audience,
                        claims: claims,
                        expires: DateTime.UtcNow.AddHours(2),
                        signingCredentials: creds
                    );

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var accessToken = tokenHandler.WriteToken(tokenDescriptor);

                    serviceResponse.Mensagem = string.Empty;
                    serviceResponse.Sucesso = true;
                    serviceResponse.access_token = accessToken;
                }
                dt.Path1 = "";
                dt.CodUsuario =  2;
                dt.EdaSic = false;
                serviceResponse.refresh_token = null;
                object? menu = new
                {
                    menu = new object[] {
                        new {
                            route = "dashboard",
                            name = "dashboard",
                            type = "link",
                            icon = "dashboard"
                        },
                        new {
                            route = "juntas",
                            name = "juntas",
                            type = "sub",
                            icon = "book",
                            children = new[] {
                                new { route = "listaProcesso", name = "listaProcesso", type = "link" },
                                new { route = "vendas", name = "vendas", type = "link" },
                                new { route = "menu", name = "menu", type = "link" }
                            }
                        }
                    }
                };
                var registros = _dbContext.Menuusr.Where(x => dt.PaStamp != null && x.Userstamp.ToLower() == dt.PaStamp.ToLower());
                if (registros.Any())
                {
                    var menuusr = registros.FirstOrDefault();
                    if (menuusr != null && !string.IsNullOrEmpty(menuusr.Menu))
                    {
                        menu = new
                        {
                            menu = JsonConvert.DeserializeObject<object[]>(menuusr.Menu) // Fix: Use JsonConvert from Newtonsoft.Json
                        };
                        
                    }
                }
                serviceResponse.Menuusr = menu;
                serviceResponse.Any = serviceResponse.Usuario = dt;
                return serviceResponse;
            }
            catch (Exception)
            {
                await Task.Delay(1000);
                serviceResponse.Mensagem = "Credenciais inválidas";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }
        }
    }
}
