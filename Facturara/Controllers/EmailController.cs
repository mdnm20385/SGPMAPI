using System.Text.RegularExpressions;
using DAL.BL;
using DAL.Classes;
using Microsoft.AspNetCore.Mvc;
using Model.Models.SJM;
using SGPMAPI.Interfaces;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly InteEmailEnviar _verficaEmail;

        public EmailController(InteEmailEnviar verifica)
        {
            _verficaEmail = verifica;
        }
        [HttpGet]
        [Route("EnviarSms")]
        public async Task<IActionResult> EnviarSms(string numerotelemovel)
        {

            string apiUrl = "https://api.labsmobile.com/json/send";
            string apiKey = "SUA_API_KEY";  // Substitua pela sua chave de API
            string phoneNumber = "5511999999999";  // Número de destino com código do país
            string message = "Olá! Esta é uma mensagem de teste enviada via LabsMobile.";

            using (HttpClient client = new HttpClient())
            {
                var requestData = new
                {
                    username = "SEU_USUÁRIO",
                    password = "SUA_SENHA",
                    message = message,
                    msisdn = phoneNumber
                };
                var response = await client.PostAsJsonAsync(apiUrl, requestData);
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Resposta da API:");
                Console.WriteLine(responseBody);
            }
            return Ok();
        }

        [HttpPost]
        [Route("PasseRecover")]
        public async Task<IActionResult> PasseRecover([FromBody] DAL.Classes.Email emal)
        {

            return Ok(await _verficaEmail.verificaPass(emal.codigo, emal.email));

        }


        [HttpPost]
        [Route("AlterarSenha")]
        public async Task<IActionResult> RecuperarEmail([FromBody] DadosRecuperacao data)
        {
            var cript = Pbl.Decrypta(data.senha);
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            var email = Regex.IsMatch(data.usuario, pattern);
            var query = $"select * from Usuario where Login='{data.usuario}' and  Senha='{cript}'";
            if (email)
            {
                query = $"select * from Usuario where  Email='{data.usuario}' and  Senha='{cript}'";
            }
            if (query.ToLower().Contains("drop") | query.ToLower().Contains("delete") || query.ToLower().Contains("update") || query.ToLower().Contains("insert")
                || query.ToLower().Contains("--") || query.ToLower().Contains("truncate"))
            {
                CampoSessoes rrs = new CampoSessoes();
                return Ok("");
            }

            var existeaspnetiser = SQL.GetGenDt(query).DtToList<Usuario>();
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
                    Usuario.Senha = Pbl.Encrypta(data.senha);
                    SQL.SqlCmd($"Update Usuario set senha = '{Pbl.Encrypta(data.senha)}' where Email='{Usuario.Login}'");
                }
                catch (Exception)
                {
                    //
                }


            }


            return Ok("");
        }

        [HttpPost]
        [Route("UpdatePerfil")]

        public async Task<IActionResult> TiposUsuarios([FromBody] Usuario Perfil)
        {
            return Ok(await _verficaEmail.TiposUsuarios(Perfil.Nome, Perfil.PaStamp, Perfil.TipoPerfil));
        }

        [HttpGet]
        [Route("GetUsers")]

        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _verficaEmail.GetUsers());
        }
        [HttpGet]
        [Route("GetUsersFromUsrTb")]

        public async Task<IActionResult> GetUsersFromUsrTb()
        {
            return Ok(await _verficaEmail.GetUsersFromUsrTb());
        }


        [HttpGet]
        [Route("GetReference")]

        public async Task<IActionResult> Getreferece(string campo, string tabela, string? condicao)
        {

            return Ok(await _verficaEmail.Getreferece(campo, tabela, condicao));
        }

        [HttpPost]
        [Route("FirstLogin")]

        public async Task<IActionResult> FirstLogin([FromBody] FirstLogin primeiro)
        {

            return Ok(await _verficaEmail.FirstLogin(primeiro));
        }

        [HttpPost]
        [Route("CheckexistLog")]

        public async Task<IActionResult> CheckexistLog([FromBody] LoginModel logado)
        {

            return Ok(await _verficaEmail.CheckexistLog(logado));
        }


    }


}
