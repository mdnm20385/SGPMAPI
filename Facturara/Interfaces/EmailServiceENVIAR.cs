using System.Globalization;
using System.Text.RegularExpressions;
using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Model.Models.Gene;
using Model.Models.SJM;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{

    public class EmailServiceEnviar : InteEmailEnviar
    {
        public SGPMContext DbContext;
        public EmailServiceEnviar(SGPMContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task<ServiceResponse<RecPassword>> verificaPass(string email, string nome)
        {
            ServiceResponse<RecPassword> ServiceResponse = new ServiceResponse<RecPassword>();
            if (email.IsNullOrEmpty() )
            {
                ServiceResponse.Sucesso = false;
                ServiceResponse.Mensagem = @" Email invalido";
                ServiceResponse.Dados = null;
            }
            else
            {
                var Email = email;
                var data = new RecPassword();
                var emailVerificado = "";
                try
                {
                    var hhh = SQL.GetGenDt($"select email from Usuario where email ='{Email}'");
                    var codigo = "";
                    if (hhh.HasRows())
                    {
                        emailVerificado = Email;
                        Random random = new Random();
                        var ddd = random.Next(1000, 9999);
                        codigo = ddd.ToString();

                        data.Email = emailVerificado;
                        data.Codigo = codigo;
                        var tempo = DateTime.Now.AddMinutes(15).ToString(CultureInfo.InvariantCulture);
                        var dt=await SendEmail(codigo, emailVerificado, nome, tempo);
                        if (dt)
                        {
                            data.Tipoperfil = tempo;
                            ServiceResponse.Dados = data;
                            ServiceResponse.Mensagem = "Sucesso";
                            ServiceResponse.Sucesso = true;
                        }
                        else
                        {
                            ServiceResponse.Sucesso = false;
                            ServiceResponse.Mensagem = "Erro";
                            ServiceResponse.Dados = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ServiceResponse.Sucesso = false;
                    ServiceResponse.Mensagem = ex.Message;
                    ServiceResponse.Dados = null;

                }
            }
            return ServiceResponse;
        }

        readonly Cryptografia _objCrypto = new();
        public async Task<bool> SendEmail(string codigo, string DDDD,string nome,string tempo)
        {
            var mensagem = "";
            try
            {
                var style = $"style=\"color: #FF0000; font-size: 16px;\"";
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("email.valido@gmail.com"));
                email.To.Add(MailboxAddress.Parse(DDDD));
                email.Subject = "Código de Recuperação de senha";
                var builder = new BodyBuilder();
                builder.HtmlBody = $"<p>Olá <strong>{nome}</strong>,</p>" +
                                   $"<p>A sua nova senha de entrada é: <strong>{codigo}</strong></p>" +
                                   $"<p {style}>NB: <strong>USE DENTRO DENTRO DE 15 MINUTOS E É OBRIGATÓRIO TROCA-LA</strong></p>" +
                                   $"<p>Clica no link abaixo para entrar:</p>" +
                                   "<a href='http://34.10.20.94:3895/#/auth/login'>LOGIN</a>";
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("email.valido@gmail.com", "infy bpvh 5kjg ijlh");
               var envi= smtp.Send(email);
               smtp.Disconnect(true);
               var cript = _objCrypto.Crypto(codigo.Trim(), true);
                SQL.SqlCmd($"update usuario set senha ='{cript}',priEntrada=1,passwordexperaem='{tempo}' where email='{DDDD}'");
            }
            catch (Exception ex)
            {
               // mensagem = ex.Message;
               return false;
            }
            return true;
        }

        public async Task<ServiceResponse<DadosRecuperacao>> RecuperarEmail(string usuario, string senha, string confirmarSenha)
        {
            ServiceResponse<DadosRecuperacao> ServiceResponse = new ServiceResponse<DadosRecuperacao>();
            var existeaspnetiser = SQL.GetGenDt($"select * from Usuario where login = '{usuario}'").DtToList<Usuario>();
            if (existeaspnetiser != null
                && existeaspnetiser.Count > 0)
            {
                var utu = existeaspnetiser.FirstOrDefault();
                try
                {
                    var ddd = utu;
                    var Usuario = ddd;
                    Usuario.PaStamp = ddd.PaStamp;
                    var properties = typeof(Usuario).GetProperties();
                    SQL.RetorProprieties(properties, Usuario);
                    var rr = Usuario.Senha;
                    Usuario.Senha = Pbl.Encrypta(senha);
                    var result = EF.Save(Usuario);
                }
                catch (Exception)
                {
                    //
                }
            }
            return ServiceResponse;
        }

        

        public async Task<ServiceResponse<Usuario>> TiposUsuarios(string usuario, string id, string Tipoperfil)
        {
            ServiceResponse<Usuario> serviceresponse = new ServiceResponse<Usuario>();
            var Tipo = Tipoperfil.Trim();
            var Pastamp = id;
            var existeaspnetiser = SQL.GetGenDt($"select * from Usuario where  Pastamp='{Pastamp}' ").DtToList<Usuario>();
            if (existeaspnetiser != null && existeaspnetiser.Count > 0)
            {
                var utu = existeaspnetiser.FirstOrDefault();
                try
                {
                    var ddd = utu;
                    var Usuario = ddd;
                    Usuario.PaStamp = ddd.PaStamp;
                    var properties = typeof(Usuario).GetProperties();
                    SQL.RetorProprieties(properties, Usuario);
                    SQL.SqlCmd($"Update Usuario set TipoPerfil = '{Tipo}' where Pastamp='{Pastamp}'");
                    serviceresponse.Dados = ddd;
                    serviceresponse.Mensagem = "Usuario actualizado";
                    serviceresponse.Sucesso = true;
                }
                catch (Exception erro)
                {
                    serviceresponse.Dados = null;
                    serviceresponse.Mensagem = erro.Message;
                    serviceresponse.Sucesso = false;
                }
            }
            return serviceresponse;
        }

        public async Task<ServiceResponse<List<Usuario>>> GetUsers()
        {
            ServiceResponse<List<Usuario>> serviceresponse = new ServiceResponse<List<Usuario>>();
            try
            {
                var Data = SQL.GetGenDt($"select * from Usuario where Clstamp='' and PeStam=''").DtToList<Usuario>();
                serviceresponse.Dados = Data;
                serviceresponse.Mensagem = "Dados obtidos com sucesso";
                serviceresponse.Sucesso = false;
            }
            catch (Exception ex)
            {
                serviceresponse.Dados = null;
                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }
            return serviceresponse;
        }
        public Task<ServiceResponse<List<Usuario>>> GetUsersFromUsrTb()
        {
            ServiceResponse<List<Usuario>> serviceresponse = new ServiceResponse<List<Usuario>>();
            try
            {
                var Data = SQL.GetGenDt($"select * from Usuario where Pastamp<>''").DtToList<Usuario>();
                var Usuario = Data;
                serviceresponse.Dados = Usuario;
                serviceresponse.Mensagem = "Dados obtidos com sucesso";
                serviceresponse.Sucesso = false;
            }
            catch (Exception ex)
            {
                serviceresponse.Dados = null;
                serviceresponse.Mensagem = ex.Message;
                serviceresponse.Sucesso = false;
            }
            return Task.FromResult(serviceresponse);
        }

        public async Task<ServiceResponse<int>> Getreferece(string campo, string tabela, string condicao)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            if (!campo.IsNullOrEmpty() && !tabela.IsNullOrEmpty())
            {
                try
                {
                    string sql = "SELECT COUNT(*) FROM Usuario";
                    var sss = SQL.GetGenDt(sql).Rows.Count;
                    try
                    {
                        int count = sss;
                        if (count > 0)
                        {
                            serviceResponse.Dados = count + 1;
                            serviceResponse.Sucesso = true;
                            serviceResponse.Mensagem = "Tem Dados";
                        }
                        else
                        {
                            serviceResponse.Dados = 0;
                            serviceResponse.Sucesso = false;
                            serviceResponse.Mensagem = "sem Dados";
                        }
                    }
                    catch (Exception ex)
                    {
                        serviceResponse.Sucesso = false;
                        serviceResponse.Mensagem = "sem Dados";
                    }
                }
                catch (Exception err)
                {
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = err.Message;
                }
            }


            return serviceResponse;

        }

        public async Task<ServiceResponse<Usuario>> FirstLogin([FromBody] FirstLogin primeiro)
        {
            ServiceResponse<Usuario> serviceResponse = new ServiceResponse<Usuario>();

            if (!primeiro.Email.IsNullOrEmpty() && !primeiro.Senha.IsNullOrEmpty() && !primeiro.User.IsNullOrEmpty())
            {
                var pass = Pbl.Encrypta(primeiro.Senha);
                try
                {
                    var Get = SQL.GetGenDt($"select * from Usuario where email='{primeiro.Email.ToLower()}'").DtToList<Usuario>();

                    if (Get.Count > 0)
                    {
                        var dddd = Get.FirstOrDefault();
                        if (dddd != null)
                        {
                            var Querry = $"update Usuario set Login='{primeiro.User.ToLower()}', Senha='{pass}' where PaStamp='{dddd.PaStamp}'";
                            var exec = SQL.SqlCmd(Querry);

                            serviceResponse.Sucesso = true;
                            serviceResponse.Mensagem = "Dados alterados com sucesso";


                        }


                    }

                }
                catch (Exception ex)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = ex.Message;
                    serviceResponse.Sucesso = false;
                }




            }
            else
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Campos vazios";
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<Usuario>> CheckexistLog([FromBody] LoginModel logado)
        {
            ServiceResponse<Usuario> serviceResponse = new ServiceResponse<Usuario>();
            if (!logado.Login.IsNullOrEmpty() && !logado.PasswordHash.IsNullOrEmpty())
            {
                try
                {
                    string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                    var cript = Pbl.Encrypta(logado.PasswordHash);
                    var email = Regex.IsMatch(logado.Login.ToLower(), pattern);
                    var query = $"select * from Usuario where Login='{logado.Login.ToLower()}' and  PasswordHash='{cript}'";
                    if (email)
                    {
                        query = $"select * from Usuario where  Email='{logado.Login.ToLower()}' and  PasswordHash='{cript}'";
                    }
                    if (query.ToLower().Contains("drop") | query.ToLower().Contains("delete") || query.ToLower().Contains("update") || query.ToLower().Contains("insert")
                        || query.ToLower().Contains("--") || query.ToLower().Contains("truncate"))
                    {
                        serviceResponse.Dados = null;
                        serviceResponse.Sucesso = false;
                        serviceResponse.Mensagem = "Você é mau";
                    }

                    //var querry = $"select * from Usuario where login='{logado.Login.ToLower()}' or Email='{logado.Login.ToLower()}' and PasswordHash='{logado.PasswordHash}'";
                    var gndt = SQL.GetGenDt(query).DtToList<Usuario>();
                    if (gndt.Count > 0)
                    {
                        var data = gndt.FirstOrDefault();
                        serviceResponse.Dados = data;
                        serviceResponse.Sucesso = true;
                        serviceResponse.Mensagem = "Dados obtidos com sucesso";
                    }
                }
                catch (Exception err)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = err.Message;
                }

            }

            return serviceResponse;
        }
    }

}
