using System.Net;
using System.Text;

namespace SGPMAPI.Interfaces
{
    public class Smssender
    {
        public async static void SendOTP()
        {
            // Crie um OTP aleatório de 5 dígitos
            string otp = string.Format("{0:D5}", new Random().Next(0, 99999));

            // Crie a mensagem com o OTP
            string message = "Seu codigo OTP e: " + otp;

            // Configuração dos parâmetros da API
            string appId = "000000"; // ID da sua aplicação registrada no MozeSMS
            string toPhoneNumber = "258847770906"; // Número do destinatário
            string apiUrl = "http://api.mozesms.com/otp"; // URL da API MozeSMS
            // Configuração do cabeçalho de autorização
            string bearerToken = "Bearer 2442:BOrkYk-om4OYB-8m1sZ4-K7GNGu"; // Substitua pelo seu token de autorização
            bearerToken = " Bearer 2442:BOrkYk-om4OYB-8m1sZ4-K7GNGu";
            // Cria o objeto com os parâmetros necessários
            var parameters = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new("AppID", appId),
                new("to", toPhoneNumber),
                new("message", message)
            });
            // Cria o cliente HttpClient
            using (var httpClient = new HttpClient())
            {
                // Configura o cabeçalho de autorização
                httpClient.DefaultRequestHeaders.Add("Authorization", bearerToken);

                // Faz a solicitação HTTP POST para a API MozeSMS
                var response = await httpClient.PostAsync(apiUrl, parameters);

                // Verifica a resposta da API
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"OTP enviado com sucesso para {toPhoneNumber}. Verifique seu telefone.");
                    Console.WriteLine("Resposta da API:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine(
                        $"Ocorreu um erro ao enviar o OTP: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
        }

        public async static void BuilkSms()
        {
            // Defina os números de telefone e as mensagens que deseja enviar
            string tell1 = "+258847770906"; // Substitua "NUMERO1" pelo número de telefone 1
            string tell2 = "NUMERO2"; // Substitua "NUMERO2" pelo número de telefone 2
            string tell3 = "NUMERO3"; // Substitua "NUMERO3" pelo número de telefone 3

            //string messages = "[\n" +
            //        "    {\n" +
            //        "        \"number\": \"" + tell1 + "\",\n" +
            //        "        \"text\": \"This is your message\"\n" +
            //        "    },\n" +
            //        "    {\n" +
            //        "        \"number\": \"" + tell2 + "\",\n" +
            //        "        \"text\": \"This is another message\"\n" +
            //        "    },\n" +
            //        "    {\n" +
            //        "        \"number\": \"" + tell3 + "\",\n" +
            //        "        \"text\": \"This is another message\"\n" +
            //        "    }\n" +
            //        "]";
            
            string messages = "[\n" +
                                           "     {\n" +
                                           "        \"number\": \"" + tell1 + "\",\n" +
                                           "        \"text\": \"This is another message\"\n" +
                                           "    }\n" +
                                           "]";

            string apiUrl = "http://api.mozesms.com/bulk_json/v2/";
            string bearerToken = "Bearer 2442:BOrkYk-om4OYB-8m1sZ4-K7GNGu"; // Substitua pelo seu token de autorização

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(apiUrl);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.Headers.Add("Authorization", bearerToken);

                // Envia os dados JSON no corpo da solicitação
                byte[] data = Encoding.UTF8.GetBytes(messages);
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    int statusCode = (int)response.StatusCode;
                    if (statusCode == 200)
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            string result = reader.ReadToEnd();

                            // Exibe a resposta da API
                            Console.WriteLine("Resposta da API:");
                            Console.WriteLine(result);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Ocorreu um erro ao enviar as mensagens. Código de resposta: {statusCode}");
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação HTTP: {ex.Message}");
            }
        }
        public async void SendeSms()
        {
            string apiUrl = "https://api.mozesms.com/message/v2";
            string bearerToken = "Bearer 2442:BOrkYk-om4OYB-8m1sZ4-K7GNGu"; // Substitua "YOUR TOKEN" pelo seu token de autorização


            string from = "Sender_ID"; // ID do remetente (Sender ID)
            string to = "+258877653992"; // Número de telefone do destinatário
            string message = "Hello from MozeSMS API"; // Mensagem que deseja enviar

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", bearerToken);
            var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new("from", from),
                new("to", to),
                new("message", message)
            });

            try
            {
                var response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Resposta da API:");
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Ocorreu um erro na solicitação: {ex.Message}");
            }
        }

    }
}
