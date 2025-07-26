using DAL.Conexao;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Gene;
using Model.Models.SJM;
using SGPMAPI.Interfaces;

namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InterUsers _usrService;
        private readonly InterGeral _intergeral;
        public SGPMContext _dbContext;
        public UsersController(InterUsers usrService, InterGeral estudanteService,
            SGPMContext dbContext)
        {
            _usrService = usrService;
            _intergeral = estudanteService;
            _dbContext = dbContext;
        }


        [HttpPost]
        [Route("IniciarSessao1")]
        public async Task<ActionResult<Token>> IniciarSessao1([FromBody] LoginPrt login)
        {

            var txt = await _usrService.ValidarCredenciais(login.Login, login.PasswordHash);
            return Ok(txt);
        }
        [HttpPost]
        [Route("xxxxxx")]//Trocar Senha
        public async Task<ActionResult<ServiceResponse<Usuario>>> Xxxxxx([FromBody] Busca login)
        {
            var txt = await _intergeral.TrocarSenha(login);
            return Ok(txt);
        }
        [HttpPost]
        [Route("Criar")]//Trocar Senha
        public async Task<ActionResult<ServiceResponse<Utilizador>>> Criar([FromBody] Utilizador login)
        {
            var txt = await _intergeral.Criar(login);
            if (txt == null)
            {
                txt = new Utilizador();
                txt.Nome = "0";
            }
            return Ok(txt);
        }
    }
}