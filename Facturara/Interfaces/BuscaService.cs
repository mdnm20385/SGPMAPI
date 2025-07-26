using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using Model.Models.Gene;
using Model.Models.SJM;
using Newtonsoft.Json;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{
    public class BuscaService : InterfBusca
    {
        public readonly SGPMContext ApIcontext;
        private readonly IGenericRepository<Busca> _peRepository;
        public BuscaService(SGPMContext descricaoAPi, IGenericRepository<Busca> peRepository)
        {
            ApIcontext = descricaoAPi;
            _peRepository = peRepository;
        }
        public async Task<PaginationResponseBl<List<Busca>>> GetGrades(ModeloPaginacao model)
        {
            PaginationResponseBl<List<Busca>> paginationpeviw; 
            var nimdescricao = model.nimdescricao;
            if (nimdescricao == "vazioxvt")
            {
                nimdescricao = "";
            }
            int currentNumber = model.currentNumber;
            int pagesize = model.pagesize;
            var tabela = model.Tabela;
            var camposel = model.Camposelecao;
            var camposOrderbCamposOrby = model.CamposOrdyby;
            int num3 = pagesize;
            int num2 = (currentNumber - 1) * pagesize;
            try
            {
                int num1 = 50;
                pagesize = pagesize < num1 ? pagesize : num1;
                var interpolatedStringHandler = $@"select count(*) from {tabela} where 
lTrim(rTrim({camposel})) like '%{nimdescricao.Trim()}%'
select * from {tabela} where lTrim(rTrim({camposel})) like '%{nimdescricao.Trim()}%' 
order by {camposOrderbCamposOrby} OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                paginationpeviw = await ConvertToPaginationpeviw(await _peRepository.
                    GetObjectPaginationf(currentNumber, pagesize, interpolatedStringHandler));
            }
            catch
            {
                throw;
            }
            return paginationpeviw;
        }
        private async Task<PaginationResponseBl<List<Busca>>> ConvertToPaginationpeviw(PaginationResponseBl<List<Busca>> professor)
        {
            return new PaginationResponseBl<List<Busca>>(professor.TotalCount, professor.Data,
                professor.CurrentPageNumber, professor.PageSize);
        }
        public async Task<bool> Editar(Busca modelo1)
        {
            var fff = JsonConvert.SerializeObject(modelo1);
            var modelo = JsonConvert.DeserializeObject<Busca>(fff);
            if (modelo == null)
                throw new TaskCanceledException("Busca não existe");
            int num = await _peRepository.Editar(modelo) ? 1 : 0;
            if (num == 0)
                throw new TaskCanceledException("Nao foi possivel eliminar Busca");
            var flag = num != 0;
            return flag;
        }
        public async Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave)
        {
            try
            {

                var modelo = new Busca();
                var dt = await _peRepository.GetDataTable($"select {nomecolunachave} from {tabela} where {nomecolunachave}='{id}'");
                if (dt.HasRows())
                {

                    bool num = SQL.SqlCmd($"delete {tabela} where {nomecolunachave}='{id}'") > 0;
                    return num;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
        public async Task<bool> Eliminar(string id)
        {
            bool flag;
            try
            {

                var modelo = new Busca();
                var dt = await _peRepository.GetDataTable($"select * from Busca where buscaStamp='{id}'");
                if (dt.HasRows())
                {
                    modelo = dt.Rows[0].DrToEntity<Busca>();
                }
                if (modelo == null)
                    throw new TaskCanceledException("Busca não existe");
                int num = await _peRepository.Eliminar(modelo) ? 1 : 0;
                if (num == 0)
                    throw new TaskCanceledException("Nao foi possivel eliminar Busca");
                flag = num != 0;
            }
            catch
            {
                throw;
            }
            return flag;
        }
        public async Task<Busca> Criar(Busca modelo2, bool inserindo)
        {
            Busca prof;
            try
            {
                if (inserindo)
                {

                    using (IDbContextTransaction dbtransaction = _peRepository.ReturnDataBaseContext().BeginTransaction())
                    {
                        try
                        {
                            var manceboCriado = await _peRepository.Criar(modelo2);
                            if (string.IsNullOrEmpty(manceboCriado.buscaStamp))
                                throw new TaskCanceledException("Não foi possivel criar o Ano Lectivo");
                            modelo2 = (await _peRepository.Consultar(u => u.buscaStamp.ToLower() ==
                                                                          manceboCriado.buscaStamp.ToLower())).First();
                            dbtransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbtransaction.Rollback();
                            throw new TaskCanceledException("Erro: " + ex.Message);
                        }
                    }
                }
                else
                {
                    if (modelo2 == null)
                        throw new TaskCanceledException("Ano Lectivo não existe");
                    int num = await _peRepository.Editar(modelo2) ? 1 : 0;
                    if (num == 0)
                        throw new TaskCanceledException("Nao foi possivel editar Ano Lectivo");
                }
                prof = modelo2;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }



            return prof;
        }

        public async Task<ServiceResponse<Selectview>> Comboboxes(string tabela, string campo1, string campo2, string condicao = "")
        {
            if (condicao.ToLower().Equals("vazio"))
            {
                condicao = "";
            }
            if (!condicao.IsNullOrEmpty())
            {
                condicao = $" where {condicao}";
            }

            var chave = tabela;
            if (tabela.Equals("Paise"))
            {
                tabela = $"Paises";
            }
            if (tabela.ToLower().Equals("status"))
            {
                chave = $"Statu";
            }
            ServiceResponse<Selectview> serviceResponse = new ServiceResponse<Selectview>();

            var dt = await _peRepository.GetDataTable($" select '' Chave,''Descricao,''Ordem union all " +
                                                      $" select {chave}stamp Chave, convert(nvarchar(max), {campo1}) Descricao, convert(nvarchar(max), {campo2})  " +
                                                      $"Ordem from {tabela} {condicao} order by Ordem asc");
            var sss = dt.DtToList<Selects>();
            List<Selects?> estudanteList = sss;
            var e = new Selectview();
            e.Selects = estudanteList;
            serviceResponse.Dados = e;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }

    }
}
