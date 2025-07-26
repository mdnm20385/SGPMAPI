using DAL.BL;
using DAL.Conexao;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Gene;
using SGPMAPI.Interfaces;
using SGPMAPI.Procura;
using SGPMAPI.SharedClasses;
using EF = DAL.BL.EF;
namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaProcessoController : ControllerBase
    {
        public InterfBusca UsrService { get; }
        public InterfaceProcura InterfaceProcura { get; }
        public SGPMContext _dbContext;
        private readonly IWebHostEnvironment _webHost;

        public EntradaProcessoController(InterfBusca usrService, SGPMContext dbContext, IWebHostEnvironment webHost,
             InterfaceProcura interfaceProcura)
        {
            UsrService = usrService;
            InterfaceProcura = interfaceProcura;
            _webHost = webHost;
            _dbContext = dbContext;
            EF._dbContext = _dbContext;
        }

        #region Upload De Ficheiros


        [Route("SqlCmd")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> SqlCmd([FromBody] Selects set)
        {
            try
            {
                ServiceResponse<Selects> rsp = new ServiceResponse<Selects>();
                var rett = SQL.SqlCmd(set.Descricao);
                if (rett > 0)
                {
                    rsp.Sucesso = true;
                    rsp.Mensagem = "";
                }
                else
                {
                    rsp.Sucesso = false;
                    rsp.Mensagem = "Erro ao executar a operação";
                }
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao executar a operação, Código do erro {ex.Message}");
            }
        }
        #endregion
    }
}
