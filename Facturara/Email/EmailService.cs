using System.Data.SqlClient;
using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Model.Models.Gene;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Email
{
    public class EmailService: InteEmail
    {

        public SGPMContext _dbContext;
        public EmailService( SGPMContext dbContext)
        {
            
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<RecPassword>> verificaPass(string email, string number)
        {
            ServiceResponse<RecPassword> ServiceResponse = new ServiceResponse<RecPassword>();
            if (email.IsNullOrEmpty() || number.IsNullOrEmpty())
            {

                ServiceResponse.Sucesso = false;
                ServiceResponse.Mensagem = " Email invalido";
                ServiceResponse.Dados = null;
            }

            else
            {
                var Email = email;
                var Number = number;
                var data = new RecPassword();
                var emailVerificado = "";
                try
                {
                    var hhh = SQL.GetGenDt($"select * from aspnetusers where email ='{Email}'");
                    var codigo = "";
                    if (hhh.HasRows())
                    {
                        emailVerificado = Email;
                        Random random = new Random();
                            var ddd = random.Next(1000, 9999);
                            codigo = ddd.ToString();
                            data.Email = emailVerificado;
                            data.Codigo = codigo;
                        await SendEmail(codigo, emailVerificado);
                        ServiceResponse.Dados = data;
                        ServiceResponse.Mensagem = "Sucesso";
                        ServiceResponse.Sucesso = true;
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

        public async Task SendEmail(string body, string DDDD)
        {
            var mensagem = "";
                var UsrEmail = DDDD;
                try
                {
                    var email = new MimeMessage();
                    email.From.Add(MailboxAddress.Parse("dmzsoftware79@gmail.com"));
                    email.To.Add(MailboxAddress.Parse(UsrEmail));
                    email.Subject = "Código de Recuperação de senha";
                    email.Body = new TextPart(TextFormat.Text) { Text = body };
                    using var smtp = new SmtpClient();
                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate("dmzsoftware79@gmail.com", "oekc qdwz catm qcwj");
                    smtp.Send(email);
                    smtp.Disconnect(true);

                }
                catch (Exception ex)
                {
                    mensagem = ex.Message;
                }
                return ;
            }

        public async Task<ServiceResponse<DadosRecuperacao>> RecuperarEmail(string usuario, string senha, string confirmarSenha)
        {
            ServiceResponse<DadosRecuperacao> ServiceResponse = new ServiceResponse<DadosRecuperacao>();

            return ServiceResponse;
        }

        [Obsolete("Obsolete")]
        public async Task<ServiceResponse<int>> Getreferece(string campo, string tabela, string condicao)
        {
            ServiceResponse<int> serviceResponse = new ServiceResponse<int>();
            if (!campo.IsNullOrEmpty() && !tabela.IsNullOrEmpty())
            {
                try
                {
                    string connectionString = SqlConstring.GetSqlConstring();
                    string sql = "SELECT COUNT(*) FROM Pe";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        var command = new SqlCommand(sql, connection);

                        try
                        {
                            connection.Open();
                            int count = (int)command.ExecuteScalar();
                            if (count > 0)
                            {
                                serviceResponse.Dados = count + 1;
                                serviceResponse.Sucesso = true;
                                serviceResponse.Mensagem = "Tem Dados";
                            }
                        }
                        catch (Exception ex)
                        {
                            serviceResponse.Sucesso = false;
                            serviceResponse.Mensagem = "sem Dados";
                        }
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
        
    }




}


