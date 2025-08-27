using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models.Facturacao;
using Model.Models.Gene;
using Model.Models.SGPM;
using Model.Models.SJM;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SGPMAPI.Interfaces;
using SGPMAPI.SharedClasses;
using System.Reflection;
using System.Text.Json;
using static DAL.BL.EF;
using EF = DAL.BL.EF;

namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveController : ControllerBase
    {
        public SGPMContext _dbContext;
        private readonly IWebHostEnvironment _webHost;
        private readonly InterGeral _repository;

        public SaveController(SGPMContext dbContext, IWebHostEnvironment webHost, InterGeral repository)
        {
            _dbContext = dbContext;
            EF._dbContext = _dbContext;
            _webHost = webHost;
            _repository = repository;
        }



        [HttpPost("{tipo}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> InserirAlterarObjecto(string tipo, [FromBody] object objk)
        {
            string json = JsonConvert.SerializeObject(objk);
            using JsonDocument doc = JsonDocument.Parse(json);
            var assembly = typeof(Exemplo).Assembly;
            Type? type = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(tipo, StringComparison.OrdinalIgnoreCase));
            if (type == null)
                return BadRequest(new { error = "Tipo não encontrado." });
            var entidade = JsonConvert.DeserializeObject(json, type);
            if (entidade == null)
                return BadRequest(new { error = "Objeto inválido." });
            var resultado = await _repository.AddOrUpdateAsync(entidade);
            return Ok(resultado);
        }   

        [Route("InserirAlterarObjectos")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> InserirAlterarObjectos([FromBody] object obj)
        {
            try
            {
                ServiceResponse<object> rsp = new ServiceResponse<object>();
                var ddd = JsonConvert.SerializeObject(obj);
                JObject jObject = JObject.Parse(ddd);
                string tabela = jObject["tabela"]?.ToString();
                switch (tabela.ToLower())
                {
                    case "busca":

                        try
                        {
                            var busca = JsonConvert.DeserializeObject<Busca>(jObject["dados"]?.ToString());
                            if (busca.buscaStamp.IsNullOrEmpty())
                            {
                                busca.buscaStamp = Pbl.Stamp();
                            }
                            if (!SQL.CheckExist($"select buscaStamp from busca where buscaStamp='{busca.buscaStamp}'"))
                            {
                                busca.codBusca = SQL.Maximo("busca", "codBusca", $" numtabela={busca.numTabela}");
                            }
                            var retst = await Save(busca);
                            rsp.Dados = busca;
                             rsp.Mensagem = "";
                            rsp.Sucesso = true;
                        }
                        catch (Exception ex)
                        {
                            rsp.Dados = ddd;
                            rsp.Mensagem = ex.Message;
                            rsp.Sucesso = false;
                        }
                        break;
                    case "unidade":
                        try
                        {
                            var unidade = JsonConvert.DeserializeObject<Unidade>(jObject["dados"]?.ToString());
                            if (unidade.unidadeStamp.IsNullOrEmpty())
                            {
                                unidade.unidadeStamp = Pbl.Stamp();
                            }
                            if (!SQL.CheckExist($"select unidadeStamp from Unidade where unidadeStamp='{unidade.unidadeStamp}'"))
                            {
                                unidade.codUnidade = SQL.Maximo("Unidade", "codUnidade", $" orgaoStamp='{unidade.orgaoStamp}'");
                            }
                            var retsst = await Save(unidade);

                            rsp.Dados = unidade;
                            rsp.Mensagem = "";
                            rsp.Sucesso = true;
                        }
                        catch (Exception ex)
                        {
                            rsp.Dados = ddd;
                            rsp.Mensagem = ex.Message;
                            rsp.Sucesso = false;
                        }
                        break;
                    case "orgao":
                        try
                        {
                            var Orgao = JsonConvert.DeserializeObject<Orgao>(jObject["dados"]?.ToString());// = JsonConvert.DeserializeObject<Orgao>(ddd);
                            if (Orgao.orgaoStamp.IsNullOrEmpty())
                            {
                                Orgao.orgaoStamp = Pbl.Stamp();
                            }
                            if (!SQL.CheckExist($"select codOrgao from Orgao where orgaoStamp='{Orgao.orgaoStamp}'"))
                            {
                                Orgao.codOrgao = SQL.Maximo("Orgao", "codOrgao");
                            }
                            var rsetsst = await Save(Orgao);
                            rsp.Dados = Orgao;
                            rsp.Mensagem = "";
                            rsp.Sucesso = true;
                        }
                        catch (Exception ex)
                        {
                            rsp.Dados = ddd;
                            rsp.Mensagem = ex.Message;
                            rsp.Sucesso = false;
                        }
                        break;
                    case "provincia":
                        break;
                    case "distrito":
                        break;
                    case "entradaprocesso":
                        break;
                    case "saidaprocesso":
                        break;
                    case "arquivo":
                        break;

                    case "pa":

                        break;

                    case "processo":
                        try
                        {

                            var unidade = JsonConvert.DeserializeObject<Processo>(jObject["dados"]?.ToString());
                            if (unidade.ProcessoStamp.IsNullOrEmpty())
                            {
                                unidade.ProcessoStamp = Pbl.Stamp();
                            }
                            var retsst = await Save(unidade);

                            rsp.Dados = unidade;
                            rsp.Mensagem = "";
                            rsp.Sucesso = true;
                        }
                        catch (Exception ex)
                        {
                            rsp.Dados = ddd;
                            rsp.Mensagem = ex.Message;
                            rsp.Sucesso = false;
                        }
                        break;
                }


                return Ok(rsp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao executar a operação, Código do erro {ex.Message}");
            }
        }

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
        [HttpPost("SaveWithChildren")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> SaveWithChildren([FromBody] object obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                using JsonDocument doc = JsonDocument.Parse(json);
                string? tipo = doc.RootElement.GetProperty("tipo").GetString();

                if (string.IsNullOrEmpty(tipo))
                    return BadRequest(new { error = "Tipo não informado." });

                Type? type = EntityTypeFactory.GetTypeByName(tipo);
                if (type == null)
                    return BadRequest(new
                    {
                        error = $"Tipo '{tipo}' não é suportado.",
                        availableTypes = EntityTypeFactory.GetAvailableTypes()
                    });


                // Verificar se o tipo está registrado no contexto
                var entityType = _dbContext.Model.FindEntityType(type);
                if (entityType == null)
                    return BadRequest(new { error = $"Tipo '{tipo}' não está registrado no contexto do Entity Framework." });

                var entidade = JsonConvert.DeserializeObject(json, type);
                if (entidade == null)
                    return BadRequest(new { error = "Objeto inválido." });

                // Usar reflexão para chamar o método genérico
                var saveMethod = typeof(EF).GetMethod(nameof(EntitySaveHelper.SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
                    ?.MakeGenericMethod(type);

                if (saveMethod == null)
                    return BadRequest(new { error = "Método de salvamento não encontrado." });

                await ((Task)saveMethod.Invoke(null, new[] { _dbContext, entidade, null })!)!;

                return Ok(new { success = true, message = "Objeto e filhos salvos com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar: {ex.Message}");
            }
        }

        //[HttpPost("SaveWithChildren")]
        //[DisableRequestSizeLimit]
        //public async Task<IActionResult> SaveWithChildren([FromBody] object obj)
        //{
        //    try
        //    {
        //        string json = JsonConvert.SerializeObject(obj);
        //        using JsonDocument doc = JsonDocument.Parse(json);
        //        var assembly = typeof(Exemplo).Assembly;
        //        string? tipo = doc.RootElement.GetProperty("tipo").GetString();
        //        if (string.IsNullOrEmpty(tipo))
        //            return BadRequest(new { error = "Tipo não informado." });
        //        Type? type = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(tipo, StringComparison.OrdinalIgnoreCase));
        //        if (type == null)
        //            return BadRequest(new { error = "Tipo não encontrado." });

        //        var entidade = JsonConvert.DeserializeObject(json, type);
        //        var unidade = JsonConvert.DeserializeObject<Mil>(json);
        //        if (entidade == null)
        //            return BadRequest(new { error = "Objeto inválido." });


        //        await EF.SaveEntityWithChildrenAsync(_dbContext, unidade);

        //        return Ok(new { success = true, message = "Objeto e filhos salvos com sucesso." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Erro ao salvar: {ex.Message}");
        //    }
        //}

        [HttpDelete("{tipo}/{id}")]
        public async Task<IActionResult> ApagarObjecto(string tipo, string id)
        {
            var assembly = typeof(Exemplo).Assembly;
            Type? type = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(tipo,
                StringComparison.OrdinalIgnoreCase));
            if (type == null)
                return BadRequest(new { error = "Tipo não encontrado." });

            // Find the key property
            var keyProp = type.GetProperties()
                .FirstOrDefault(p => Attribute.IsDefined(p,
                    typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));
            if (keyProp == null)
                return BadRequest(new { error = "Chave primária não encontrada para o tipo informado." });

            // Convert id to the correct type
            object keyValue;
            try
            {
                keyValue = Convert.ChangeType(id, keyProp.PropertyType);
            }
            catch
            {
                return BadRequest(new { error = "Tipo de chave incompatível." });
            }

            // Find the entity in the database
            // Get the generic Set<T>() method
            var setMethod = typeof(SGPMContext).GetMethod("Set", Type.EmptyTypes)?.MakeGenericMethod(type);
            if (setMethod == null)
                return StatusCode(500, "Não foi possível obter o DbSet para o tipo informado.");

            dynamic dbSet = setMethod.Invoke(_dbContext, null);
            var entity = await dbSet.FindAsync(keyValue);
            if (entity == null)
                return NotFound(new { error = "Objeto não encontrado." });

            dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();

            return Ok(new { success = true, message = "Objeto apagado com sucesso." });
        }
    }
}
