

using DAL.BL;
using System.Collections;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text.RegularExpressions;

namespace DAL.Classes
{

    public class EnviarEmail
    {
        public class EnviaEmail
        {
            /// <summary>
            /// Transmite uma mensagem de email sem anexos
            /// </summary>
            /// <param name="Destinatario">Destinatario (Recipient)</param>
            /// <param name="Remetente">Remetente (Sender)</param>
            /// <param name="Assunto">Assunto da mensagem (Subject)</param>
            /// <param name="enviaMensagem">Corpo da mensagem(Body)</param>
            /// <returns>Status da mensagem</returns>
            public static string EnviaMensagemEmail(string Destinatario, string Remetente,
                string Assunto, string enviaMensagem)
            {
                try
                {
                    // valida o email
                    bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

                    // Se o email não é validao retorna uma mensagem
                    if (bValidaEmail == false)
                        return "Email do destinatário inválido: " + Destinatario;

                    // cria uma mensagem
                    MailMessage mensagemEmail = new MailMessage(Remetente, Destinatario, Assunto, enviaMensagem);

                    //----------------------------------------------------------------------------------------------------------------------------------
                    //obtem os valores smtp do arquivo de configuração . Não vou usar estes valores estou apenas mostrando como obtê-los
                    //Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration(null);
                    //MailSettingsSectionGroup mailSettings = configurationFile.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
                    //if (mailSettings != null)
                    //{
                    //     string host = mailSettings.Smtp.Network.Host;
                    //     string password = mailSettings.Smtp.Network.Password;
                    //     string username = mailSettings.Smtp.Network.UserName;
                    //     int port = mailSettings.Smtp.Network.Port;
                    //}
                    //----------------------------------------------------------------------------------------------------------------------------------

                    SmtpClient client = new SmtpClient(Pbl.Smtpserver, Pbl.Smtpport);

                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;

                    client.Credentials = new NetworkCredential($"{Pbl.Outgoingemail1}", $"{Pbl.Outgoingpassword1}");

                    // inclui as credenciais
                    //client.UseDefaultCredentials = true;

                    // envia a mensagem
                    client.Send(mensagemEmail);

                    return "Mensagem enviada para  " + Destinatario + " às " + DateTime.Now + ".";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            /// <summary>
            /// Transmite uma mensagem de email com um anexo
            /// </summary>
            /// <param name="Destinatario">Destinatario (Recipient)</param>
            /// <param name="Remetente">Remetente (Sender)</param>
            /// <param name="Assunto">Assunto da mensagem (Subject)</param>
            /// <param name="enviaMensagem">Corpo da mensagem(Body)</param>
            /// <param name="anexos">Um array de strings apontando para a localização de cada anexo</param>
            /// <returns>Status da mensagem</returns>
            #region Comentado Envio de Email

            public static string EnviaMensagemComAnexos(string destinatario,
            string assunto, string enviaMensagem, ArrayList anexos)
            {
                var mensagemEmail = new MailMessage(Pbl.Outgoingemail, destinatario,
                    assunto,
                    enviaMensagem);
                try
                {
                    // valida o email
                    var bValidaEmail = ValidaEnderecoEmail(destinatario);

                    if (bValidaEmail == false)
                        return "Email do destinatário inválido:" + destinatario;



                    // Cria uma mensagem
                    foreach (string anexo in anexos)
                    {
                        var anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        var ane = anexado.Name;
                        mensagemEmail.Attachments.Add(anexado);
                    }
                    using (var client = new SmtpClient())
                    {
                        client.EnableSsl = true;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential($"{Pbl.Outgoingemail1}", $"{Pbl.Outgoingpassword1}");
                        client.Host = Pbl.Smtpserver!;
                        client.Port = Pbl.Smtpport;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        client.Send(mensagemEmail);
                    }

                    return "Mensagem enviada para " + destinatario + " às " + DateTime.Now + ".";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }



            /// <summary>
            /// Confirma a validade de um email
            /// </summary>
            /// <param name="enderecoEmail">Email a ser validado</param>
            /// <returns>Retorna True se o email for valido</returns>
            public static bool ValidaEnderecoEmail(string enderecoEmail)
            {
                //define a expressão regulara para validar o email
                var texto_Validar = enderecoEmail;
                var expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                // testa o email com a expressão
                if (expressaoRegex.IsMatch(texto_Validar))
                {
                    // o email é valido
                    return true;
                }
                // o email é inválido
                return false;
            }







            #endregion
















        }
    }
}
