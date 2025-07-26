using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Gene;
using Model.Models.SJM;

namespace SGPMAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SaidaProcessoController : ControllerBase
    {
        public SGPMContext _dbContext;
        private readonly IWebHostEnvironment _webHost;
        public SaidaProcessoController(SGPMContext dbContext, IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            _dbContext = dbContext;
            EF._dbContext = _dbContext;
        }
        #region Upload De Ficheiros

      
        #endregion




        #region Iserir Usuários

        [Route("InserirUsuario")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> InserirUsuario([FromBody] Usuario set)
        {
            try
            {
                ServiceResponse<Usuario> rsp = new ServiceResponse<Usuario>();

                var prt = $"{_webHost.ContentRootPath}";
                var pt1 = Path.Combine(prt, "Ficheiros");
                if (!Directory.Exists(pt1))
                {
                    Directory.CreateDirectory(pt1);
                }

                if (set.Path1.ToLower().Equals("Novatosigex".ToLower()))
                {
                    set.Path1 = "";
                }

                var _objCrypto = new Cryptografia();
                var cond = "";// $" Orgao='{set.Orgao}'";
                if (!set.Direcao.IsNullOrEmpty())
                {
                    //cond += $" and Direcao='{set.Direcao}'";
                }
                if (!SQL.CheckExist($"select PaStamp from Usuario where PaStamp='{set.PaStamp}'"))
                {
                    set.CodUsuario = SQL.Maximo("Usuario", "CodUsuario", $"  {cond}");
                }
                if (set.PaStamp.IsNullOrEmpty())
                {
                    set.PaStamp = Pbl.Stamp();
                }
                if (!set.Path1.IsNullOrEmpty())
                {
                    byte[] newBytes = Convert.FromBase64String(set.Path1);
                    var pathToSave = pt1;
                    set.PathPdf = $"{SQL.WriteFilenamepdf(newBytes, pathToSave, set.TdocAniva)}";
                }

                try
                {
                    var senha = _objCrypto.Crypto(set.Senha.Trim(), false);
                    set.Senha = senha;
                }
                catch (Exception)
                {
                    var senha = _objCrypto.Crypto(set.Senha.Trim(), true);
                    set.Senha = senha;
                }
                var rett = await EF.Save(set);
                if (rett.ret == 0)
                {
                    try
                    {
                        var pr = Path.Combine(pt1, set.PathPdf);
                        System.IO.File.Delete(pr);
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                }
                rsp.Sucesso = true;
                rsp.Mensagem = "Sucesso";
                rsp.Dados = set;

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
