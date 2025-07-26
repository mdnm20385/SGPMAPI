using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Models.Facturacao;
using Model.Models.Gene;
using Newtonsoft.Json;
using SGPMAPI.Interfaces;
using SGPMAPI.Procura;
using SGPMAPI.SharedClasses;
using Param = Model.Models.Facturacao.Param;

namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaAlunoController : ControllerBase
    {
        private readonly InterfaceProcura _procService;

        private readonly IntermatriculaAluno _usrService;


        private readonly SGPMContext _dbContext;
        public MatriculaAlunoController(SGPMContext dbContext, IntermatriculaAluno usrService,
            InterfaceProcura procService)
        {
            _dbContext = dbContext;
            _usrService = usrService;
            _procService = procService;
            EF._dbContext = _dbContext;
        }





        [HttpPost]
        [Route("CheckExist")]
        public async Task<IActionResult> CheckExist([FromBody] Selects item)
        {
            ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();
            var tabela = item.Chave;
            var campo = item.Descricao;
            var condicao = item.Ordem;
            var txt = SQL.CheckExist(campo, tabela, condicao);
            serviceResponse.Dados = txt;
            serviceResponse.Mensagem = "";
            serviceResponse.Sucesso = txt;
            return Ok(serviceResponse);
        }



        [HttpGet]
        [Route("GetPlanopamentoestudante")]
        public async Task<ActionResult<ServiceResponse<Dmzviewgrelha>>> GetPlanopamentoestudante(string clstamp)
        {
            var txt = await _usrService.GetPlanopamentoestudante(clstamp);
            return Ok(txt);
        }

        [HttpPost]
        [Route("GetTdocMatri")]
        public async Task<ActionResult<ServiceResponse<Dmzviewgrelha>>> GetTdocMatri([FromBody] Selects item)
        {
            var campos = item.Descricao;
            var tabela = item.Ordem;
            var condicoes = item.Chave;
            var txt = await _usrService.Comboboxesdmz(campos, tabela, condicoes);

            var data = txt.Dados;

            return Ok(txt);
        }

        [HttpPost]
        [Route("GetAnybyquery")]
        public async Task<ActionResult<ServiceResponse<Dmzviewgrelha>>> GetAnybyquery([FromBody] Selects item)
        {
            var campos = item.Descricao;
            var txt = await _usrService.GetAnybyquery(campos, item.Ordem, item.Chave);
            return Ok(txt);
        }

        [HttpPost]
        [Route("Iniciatileany")]
        public async Task<ActionResult<ServiceResponse<object>>> Iniciatileany([FromBody] Selects item)
        {
            var txt = await _usrService.Iniciatileany(item);
            return Ok(txt);
        }
        [HttpPost]
        [Route("GetQualquerObjectDt")]
        public async Task<ActionResult<ServiceResponse<object>>> GetQualquerObjectDt([FromBody] Selects item)
        {
            var txt = await _usrService.GetQualquerObjectDt(item);
            return Ok(txt);
        }


        [HttpGet]
        [Route("GetDados")]
        public async Task<ActionResult<ServiceResponse<Dmzviewgrelha>>> GetDados(string turmastamp, string tabela)
        {
            var txt = await _usrService.GetDados(turmastamp, tabela);
            return Ok(txt);
        }
        [HttpGet]
        [Route("GetTdocsingle")]
        public async Task<ActionResult<ServiceResponse<TdocMat>>> GetTdocsingle(string tdocstamp)
        {
            var txt = await _usrService.GetTdoc(tdocstamp);
            return Ok(txt);
        }

        [HttpPost]
        [Route("MetodoGenerico")]
        public async Task<ActionResult<ServiceResponse<object>>> MetodoGenerico([FromBody] Selects ite)
        {
            var tdoc = ite.Chave;
            var s = ite.Descricao;
            var ss = ite.Ordem;

            var txt = await _usrService.MetodoGenerico(ite);
            return Ok(txt);
        }



        [HttpPost]
        [Route("GetGenerico")]
        public async Task<ActionResult<ServiceResponse<Dmzviewgrelha>>> GetGenerico([FromBody] Selects ite)
        {

            var txt = await _usrService.GetGenerico(ite);
            return Ok(txt);
        }
        [HttpGet]
        [Route("GettRclsingleq")]
        public async Task<ActionResult<ServiceResponse<TdocMat>>> GettRclsingleq(string tdocstamp)
        {
            var txt = await _usrService.GettRclsingleq(tdocstamp);
            return Ok(txt);
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(string id)
        {
            ServiceResponse<bool> rsp = new ServiceResponse<bool>();
            try
            {
                rsp.Sucesso = true;
                ServiceResponse<bool> response = rsp;
                response.Dados = await _usrService.Eliminar(id);
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult actionResult = Ok(rsp);
            rsp = null;
            return actionResult;
        }
        [HttpDelete]
        [Route("EliminarGeral")]
        public async Task<IActionResult> EliminarGeral(string id, string tabela, string nomecampochave)
        {
            ServiceResponse<bool> rsp = new ServiceResponse<bool>();
            try
            {
                ServiceResponse<bool> response = rsp;
                var ffff = await _usrService.Eliminargradel(id, tabela, nomecampochave);
                response.Dados = ffff;
                rsp.Sucesso = ffff;
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult actionResult = Ok(rsp);
            rsp = null;
            return actionResult;
        }

        [HttpPost]
        [Route("EliminarGeralPost")]
        public async Task<IActionResult> EliminarGeralPost([FromBody] Camposeliminar set)
        {
            var id = set.Id; var tabela = set.Tabela;
            var nomecampochave = set.Nomecampochave;
            ServiceResponse<bool> rsp = new ServiceResponse<bool>();
            try
            {
                ServiceResponse<bool> response = rsp;
                var ffff = await _usrService.Eliminargradel(id, tabela, nomecampochave);
                response.Dados = ffff;
                rsp.Sucesso = ffff;
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult actionResult = Ok(rsp);
            rsp = null;
            return actionResult;
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] MatriculaAluno pe)
        {
            ServiceResponse<bool> rsp = new ServiceResponse<bool>();
            try
            {
                rsp.Sucesso = true;
                ServiceResponse<bool> response = rsp;
                SQL.SetDefaultSave(pe);
                Utilities.AllTrim(pe);
                var cl = pe;
                var pkValue = Utilities.PkeyValue(cl, "");
                var existe = SQL.CheckExist($@"select {cl.GetType().Name}stamp from {cl.GetType().Name} where {cl.GetType().Name}stamp='{pkValue}'");
                if (!existe)
                {
                    if (cl != null)
                    {
                        await _usrService.Criar(cl, true);
                    }
                }
                else
                {
                    if (cl != null)
                    {
                        await _usrService.Criar(cl, false);
                    }
                }
                response.Dados = true;
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult actionResult = Ok(rsp);
            return actionResult;
        }
        [Route("AnularMatriculaAluno")]
        [HttpPost]
        public async Task<IActionResult> AnularMatriculaAluno(IFormCollection formdata)
        {
            bool retorno = false;
            EF._dbContext = _dbContext;
            var resultsss = JsonConvert.DeserializeObject<MatriculaAluno>(formdata["MatriculaAluno"]);
            if (resultsss != null)
            {
                var resultss = resultsss;
                try
                {
                    var cl = resultss;
                    if (cl.Activo)
                    {
                        cl.Sitcao = "Inactivo";
                    }
                    if (!cl.Activo)
                    {
                        cl.Sitcao = "Activo";
                    }
                    SQL.SqlCmd($"update matriculaAluno set activo={!cl.Activo},motivo='{cl.Motivo}',Sitcao='{cl.Sitcao}' " +
                               $"where Clstamp='{cl.Clstamp.Trim()}' ");
                    SQL.SqlCmd($"update Turmal set activo={!cl.Activo},motivo='{cl.Motivo}' where Clstamp='{cl.Clstamp.Trim()}'");

                    SQL.SqlCmd($"update Turmanota set activo={cl.Activo},motivo='{cl.Motivo}' where Alunostamp='{cl.Clstamp.Trim()}'");

                    SQL.SqlCmd($"update DisciplinaTumra set activo={cl.Activo},motivo='{cl.Motivo}',Sitcao='{cl.Sitcao}' " +
                               $"where Clstamp='{cl.Clstamp.Trim()}' and ");
                    return Ok(true);

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error {ex.Message}");
                }
            }
            return Ok(retorno);
        }

        [Route("AnularDisciplinaAluno")]
        [HttpPost]
        public async Task<IActionResult> AnularDisciplinaAluno(IFormCollection formdata)
        {
            bool retorno = false;
            EF._dbContext = _dbContext;
            var resultsss = JsonConvert.DeserializeObject<MatriculaAluno>(formdata["MatriculaAluno"]);
            if (resultsss != null)
            {
                var resultss = resultsss;
                try
                {
                    var cl = resultss;
                    var Motivo = "";
                    foreach (var disc in cl.DisciplinaTumra)
                    {
                        var sit = string.Empty;
                        var activo = 0;
                        var trmsatmp = disc.Turmastamp;
                        if (!Convert.ToBoolean(disc.Activo))
                        {
                            sit = "Inactivo";
                            activo = 0;
                        }
                        else
                        {
                            Motivo = "";
                            sit = "Activo";
                            activo = 1;
                        }
                        SQL.SqlCmd($"update Turmanota set activo={activo},motivo='{Motivo}'" +
                                   $" where Alunostamp='{cl.Clstamp.Trim()}'" +
                                   $" and Turmastamp='{trmsatmp.Trim()}' and " +
                                   $"Coddis='{disc.Ststamp.Trim()}'");
                        var gddd = disc.DisciplinaTumrastamp;
                        gddd = $" DisciplinaTumrastamp = '{gddd}'";
                        SQL.SqlCmd($"update DisciplinaTumra set activo={activo}," +
                                   $"Motivo='{Motivo}',Sitcao='{sit}' where {gddd}");

                    }
                    return Ok(true);

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error {ex.Message}");
                }
            }
            return Ok(retorno);
        }

        [Route("AnularDisciplinaAlunoespecifica")]
        [HttpPost]
        public async Task<IActionResult> AnularDisciplinaAlunoespecifica(IFormCollection formdata)
        {
            bool retorno = false;
            var resultsss = JsonConvert.DeserializeObject<DisciplinaTumra>(formdata["MatriculaAluno"]);
            if (resultsss != null)
            {
                var resultss = resultsss;
                try
                {
                    var cl = resultss;
                    var Motivo = "";
                    var sit = string.Empty;
                    var activo = 0;
                    var trmsatmp = resultsss.Turmastamp;
                    if (!Convert.ToBoolean(cl.Activo))
                    {
                        sit = "Inactivo";
                        activo = 0;
                    }
                    else
                    {
                        Motivo = "";
                        sit = "Activo";
                        activo = 1;
                    }
                    SQL.SqlCmd($"update Turmanota set activo={activo},motivo='{Motivo}'" +
                               $" where Alunostamp='{cl.Clstamp.Trim()}'" +
                               $" and Turmastamp='{trmsatmp.Trim()}' and " +
                               $"Coddis='{cl.Ststamp.Trim()}'");
                    var gddd = cl.DisciplinaTumrastamp;
                    gddd = $" DisciplinaTumrastamp = '{gddd}'";
                    SQL.SqlCmd($"update DisciplinaTumra set activo={activo}," +
                               $"Motivo='{Motivo}',Sitcao='{sit}' where {gddd}");
                    return Ok(true);

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error {ex.Message}");
                }
            }
            return Ok(retorno);
        }


        [Route("GerarCcAluno")]
        [HttpPost]
        public async Task<IActionResult> GerarCcAluno(IFormCollection formdata)
        {
            bool retorno = false;
            if (Pbl.Usr == null)
            {
                Pbl.Usr = SQL.GetRowToEnt<Usr>("usrstamp='635D20197DMZ4121045'");
            }
            Pbl.MoedaBase = "MZN";
            Pbl.Moeda = "MZN";
            if (Pbl.Param == null)
            {
                Pbl.Param = SQL.GetRowToEnt<Param>("");
            }
            EF._dbContext = _dbContext;
            var resultsss = JsonConvert.DeserializeObject<MatriculaAluno>(formdata["MatriculaAluno"]);
            if (resultsss != null)
            {
                var resultss = resultsss;
                var ct = SQL.GetGenDt($"select Codcurso from Curso where cursostamp='{resultss.Cursostamp}'");
                if (ct.HasRows())
                {
                    resultss.Codcurso = ct.Rows[0]["Codcurso"].ToString();
                }
                try
                {

                    var cl = resultss;
                    if (cl != null)
                    {
                        bool inserindo = false;
                        var sq = SQL.CheckExist($"select MatriculaAlunostamp from MatriculaAluno where " +
                                                $"MatriculaAlunostamp='{cl.MatriculaAlunostamp}'");
                        if (sq)
                        {
                            EF._dbContext = _dbContext;
                            SQL.AfterSave(cl, _dbContext);
                        }
                    }

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error {ex.Message}");
                }
            }
            return Ok(retorno);
        }

        [Route("UploadFile")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFile(IFormCollection formdata)
        {
            bool retorno = false;
            if (Pbl.Usr == null)
            {

                Pbl.Usr = SQL.GetRowToEnt<Usr>("usrstamp='635D20197DMZ4121045'");
            }
            Pbl.MoedaBase = "MZN";
            Pbl.Moeda = "MZN";
            if (Pbl.Param == null)
            {

                Pbl.Param = SQL.GetRowToEnt<Param>("");
            }
            if (Pbl.Empresa == null)
            {

                Pbl.Empresa = SQL.GetRowToEnt<Empresa>("");
            }

            EF._dbContext = _dbContext;
            var resultsss = JsonConvert.DeserializeObject<MatriculaAluno>(formdata["MatriculaAluno"]);
            if (resultsss != null)
            {
                resultsss.Activo = true;
                var resultss = resultsss;
                var ct = SQL.GetGenDt($"select Codcurso from Curso where cursostamp='{resultss.Cursostamp}'");
                if (ct.HasRows())
                {
                    resultss.Codcurso = ct.Rows[0]["Codcurso"].ToString();
                }

                try
                {
                    resultss.MatriculaTurmaAlunol = null;
                    resultss.DisciplinaTumra = null;
                    resultss.Matdisc = null;
                    var cl = resultss;
                    if (cl != null)
                    {
                        bool inserindo = false;
                        var sq = SQL.CheckExist($"select MatriculaAlunostamp from MatriculaAluno where " +
                                                $"MatriculaAlunostamp='{cl.MatriculaAlunostamp}'");
                        var rrr = await EF.Save(cl);
                        if (rrr.ret > 0)
                        {
                            if (!sq)
                            {
                                var cst = SQL.GetGenDt($"select Codcurso from Curso where cursostamp='{cl.Cursostamp}'");
                                if (cst.HasRows())
                                {
                                    resultss.Codcurso = cst.Rows[0]["Codcurso"].ToString();
                                }
                                try
                                {
                                    EF._dbContext = _dbContext;
                                    SQL.AfterSave(cl, _dbContext);

                                }
                                catch (Exception ex)
                                {
                                    //
                                }
                            }
                            var rturma = JsonConvert.DeserializeObject<MatriculaAluno>(formdata["MatriculaAluno"]);

                            try
                            {
                                if (rturma != null)

                                    foreach (var tumrl in rturma.MatriculaTurmaAlunol)
                                    {
                                        EF._dbContext = _dbContext;
                                        var tr = await EF.Save(tumrl);
                                    }
                            }
                            catch (Exception)
                            {
                                //
                            }

                            if (rturma != null)
                            {

                                try
                                {
                                    foreach (var tumrl in rturma.Matdisc)
                                    {
                                        EF._dbContext = _dbContext;
                                        var tr = await EF.Save(tumrl);
                                    }
                                    //string cllinsdg;
                                    //cllinsdg = JsonConvert.SerializeObject(rturma.Matdisc);
                                    //var dt = JsonConvert.DeserializeObject<DataTable>(cllinsdg);
                                    //SQL.Save(dt, "Matdisc", false, rturma.Clstamp, "MatriculaAluno");
                                }
                                catch (Exception)
                                {
                                    //
                                }
                            }

                            try
                            {
                                if (rturma != null)
                                {
                                    foreach (var tumrl in rturma.DisciplinaTumra)
                                    {
                                        EF._dbContext = _dbContext;
                                        var tr = await EF.Save(tumrl);
                                    }
                                    //string cllinsdg;
                                    //cllinsdg = JsonConvert.SerializeObject(rturma.DisciplinaTumra);
                                    //var dt = JsonConvert.DeserializeObject<DataTable>(cllinsdg);
                                    //SQL.Save(dt, "DisciplinaTumra", false, rturma.Clstamp, "MatriculaAluno");
                                }

                            }
                            catch (Exception ex)
                            {
                                //
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                    return StatusCode(500, $"Error {ex.Message}");
                }

            }
            return Ok(retorno);
        }


        [HttpPost]
        [Route("Procurar")]
        public async Task<IActionResult> Procurar([FromBody] SharedClasses.Procura pro)
        {

            PaginationResponseBl<List<SharedClasses.Procura>> rsp = null;
            try
            {
                rsp = await _procService.Procurar(pro.Tabela, pro.Campo, pro.Campo1,
                    pro.Campo, pro.Valorprocurado,
                    pro.CurrentNumber, pro.Pagesize, pro.Rhstamp);
                rsp.Status = true;
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            IActionResult manc = Ok(rsp);
            rsp = null;
            return manc;
        }
    }


}
