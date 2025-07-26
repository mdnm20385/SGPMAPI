using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.EntityFrameworkCore;
using Model.Models.Facturacao;
using Model.Models.SJM;
using SGPMAPI.Procura;

namespace SGPMAPI.Interfaces
{
    public class Userservice:InterUsers
    {
        public readonly SGPMContext ApIcontext;
        private readonly IGenericRepository<Usuario> _usuarRepository;
        private readonly InterfaceProcura procura;
        public SGPMContext _dbContext;
        public Userservice(SGPMContext nomeAPi, 
            IGenericRepository<Usuario> usuarRepository, InterfaceProcura _procura)
        {
            _usuarRepository = usuarRepository;
            ApIcontext = nomeAPi;
            _dbContext = nomeAPi;
            procura = _procura;
        }
        readonly Cryptografia _objCrypto = new();
        public async Task<Token> ValidarCredenciais(string login, string senha)
        {
            Token serviceResponse = new Token();
            var cript = _objCrypto.Crypto(senha.Trim(), true);
            decimal totalprofesso = 0;
            decimal totalalunos = 0;
            decimal totalRh = 0;
            decimal totalcurso = 0;
            decimal TotalTurmas = 0;
            try
            {
               // var dtS = await ApIcontext.Usuario.Find()
                var dt =await ApIcontext.Usuario.Where(x =>
                    x.Senha != null && x.Login.ToLower().Equals(login.ToLower()) &&
                    x.Senha.Equals(cript) && x.Activopa).FirstOrDefaultAsync();

                if (dt==null || dt.Login.IsNullOrEmpty())
                {
                    serviceResponse.Mensagem = "Usuário ou senha inválido";
                    serviceResponse.Sucesso = false;
                    serviceResponse.access_token = serviceResponse.refresh_token = null;
                    serviceResponse.Usuario = null;
                    return await Task.FromResult(serviceResponse);
                }
                dt.Path1 = "";
                dt.UsuarioMenu = new List<UsuarioMenu>();
                serviceResponse.Any = dt;
                var parm = SQL.GetRowToEnt<Param>("");
                dt.CodUsuario = parm != null ? parm.Aredondamento.ToInt() : 2;
                dt.EdaSic = parm != null ? parm.Ivaposdesconto: false;
                serviceResponse.Usuario = dt;
                return await Task.FromResult(serviceResponse);
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = "Usuário ou senha inválido";
                serviceResponse.Sucesso = false;
                serviceResponse.access_token = serviceResponse.refresh_token = null;
                serviceResponse.Usuario = new Usuario();
                return await Task.FromResult(serviceResponse);
            }
        }


      


        


    }
}
