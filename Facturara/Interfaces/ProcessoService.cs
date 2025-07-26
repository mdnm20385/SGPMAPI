using DAL.BL;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using Model.Models.Gene;
using Model.Models.SJM;
using Newtonsoft.Json;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{
    public class ProcessoService:InterfProcesso
    {
        public readonly SGPMContext ApIcontext;
        private readonly IGenericRepository<Processo> _peRepository;
        public ProcessoService(SGPMContext descricaoAPi, IGenericRepository<Processo> peRepository)
        {
            ApIcontext = descricaoAPi;
            _peRepository = peRepository;
        }
        public async Task<PaginationResponseBl<List<Processo>>> GetGrades(ModeloPaginacao model)
        {
            PaginationResponseBl<List<Processo>> paginationpeviw;
            var nimdescricao = model.nimdescricao;
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
        private async Task<PaginationResponseBl<List<Processo>>> ConvertToPaginationpeviw(
            PaginationResponseBl<List<Processo>> professor)
        {
            return new PaginationResponseBl<List<Processo>>(professor.TotalCount, GetConvertTovie(professor.Data),
                professor.CurrentPageNumber, professor.PageSize);
        }
        private List<Processo> GetConvertTovie(List<Processo> professorData)
        {
            foreach (Processo professor1 in professorData)
            { GetGrades(professor1);
            }
            return professorData;
        }
        private void GetGrades(Processo data)
        {
            //if (data != null)
            //{
            //    data.Pa = GetPessoa(data.paStamp);
            //    data.EntradaProcesso = GetListEntrada(data.processoStamp);
            //}
        }
      
        private Pa GetPessoa(string professorPaStamp)
        {
            return SQL.GetRowToEnt<Pa>($"Pastamp='{professorPaStamp}'");
        }
        public async Task<bool> Editar(Processo modelo1)
        {
            var fff = JsonConvert.SerializeObject(modelo1);
            var modelo = JsonConvert.DeserializeObject<Processo>(fff);
            if (modelo == null)
                throw new TaskCanceledException("Processo não existe");
            int num = await _peRepository.Editar(modelo) ? 1 : 0;
            if (num == 0)
                throw new TaskCanceledException("Nao foi possivel eliminar Processo");
            var flag = num != 0;
            return flag;
        }
        public async Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave)
        {
            try
            {

                var modelo = new Processo();
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

                var modelo = new Processo();
                var dt = await _peRepository.GetDataTable($"select * from AnoSem where Processostamp='{id}'");
                if (dt.HasRows())
                {
                    modelo = dt.Rows[0].DrToEntity<Processo>();
                }
                if (modelo == null)
                    throw new TaskCanceledException("Processo não existe");
                int num = await _peRepository.Eliminar(modelo) ? 1 : 0;
                if (num == 0)
                    throw new TaskCanceledException("Nao foi possivel eliminar Processo");
                flag = num != 0;
            }
            catch
            {
                throw;
            }
            return flag;
        }
        public async Task<Processo> Criar(Processo modelo2, bool inserindo)
        {

            Processo prof;
            try
            {
                if (inserindo)
                {
                    using (IDbContextTransaction dbtransaction = _peRepository.ReturnDataBaseContext().BeginTransaction())
                    {
                        try
                        {
                            var manceboCriado = await _peRepository.Criar(modelo2);
                            if (string.IsNullOrEmpty(manceboCriado.ProcessoStamp))
                                throw new TaskCanceledException("Não foi possivel criar o Ano Lectivo");
                            modelo2 = (await _peRepository.Consultar(u => u.ProcessoStamp.ToLower() == manceboCriado.ProcessoStamp.ToLower())).First();
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
    }
}
