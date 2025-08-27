
using System.Data;
using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model.Models.Facturacao;
using Model.Models.Gene;
using Model.Models.SJM;
using SGPMAPI.Interfaces;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Procura
{

    public class ProcuraServico : InterfaceProcura
    {

        public readonly SGPMContext ApIcontext;
        public readonly IGenericRepository<SharedClasses.Procura> _peRepository;
        public readonly IGenericRepository<object> _peRepositoryObject;
        public ProcuraServico(SGPMContext descricaoAPi, IGenericRepository<SharedClasses.Procura> peRepository,
            IGenericRepository<object> peRepositoryObject
        )
        {
            ApIcontext = descricaoAPi;
            _peRepository = peRepository;
            _peRepositoryObject = peRepositoryObject;
        }
        public async Task<Fact> GetFactWithChildrenAsync(string factstamp)
        {
            using (var connection = new SqlConnection(SqlConstring.GetSqlConstring()))
            {
                connection.Open();
                // Query main Fact
                var fact = connection.QueryFirstOrDefault<Fact>(
                    "SELECT * FROM Fact WHERE Factstamp = @factstamp", new { factstamp });
                if (fact == null)
                    return null;
                // Query related collections
                fact.Factl = connection.Query<Factl>(
                    "SELECT * FROM Factl WHERE Factstamp = @factstamp", new { factstamp }).ToList();

                fact.Factprest = connection.Query<Factprest>(
                    "SELECT * FROM Factprest WHERE Factstamp = @factstamp", new { factstamp }).ToList();

                fact.Factreg = connection.Query<Factreg>(
                    "SELECT * FROM Factreg WHERE Factstamp = @factstamp", new { factstamp }).ToList();

                fact.Formasp = connection.Query<Formasp>(
                    "SELECT * FROM Formasp WHERE Factstamp = @factstamp", new { factstamp }).ToList();

                return fact;
            }
        }
        public async Task<bool> DeleteFactAsync(string factstamp)
        {
            var fact = await ApIcontext.Armazem.FirstOrDefaultAsync(f => f.armazemStamp == factstamp);
            if (fact == null)
            {
                return false;
            }
            ApIcontext.Armazem.Remove(fact);
            await ApIcontext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Fact>> GetFactsAsync()
        {

            var dtlista = SQL.GetGenDt($"select * from fact").DtToList<Fact>();
            return dtlista;
        }
        public Task<ServiceResponse<Selectview>> Comboboxes(string tabela, string campo1, string campo2, string condicao, string  Campochave )
        {
            if (condicao.ToLower().Equals("vazio"))
            {
                condicao = "";
            }
            if (!condicao.IsNullOrEmpty())
            {
                condicao = $" where {condicao}";
            }
            var chave = Campochave;
            ServiceResponse<Selectview> serviceResponse = new ServiceResponse<Selectview>();
            var dt = SQL.GetGenDt($" select '' Chave,''Descricao,''Ordem union all " +
                                                      $" select {Campochave} Chave, convert(nvarchar(max), {campo1}) Descricao, convert(nvarchar(max), {campo2})  " +
                                                      $"Ordem from {tabela} {condicao} order by Ordem asc");
            var sss = dt.DtToList<Selects>();



            List<Selects?> estudanteList = sss;
            var e = new Selectview();
            e.Selects = estudanteList;
            serviceResponse.Dados = e;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return Task.FromResult(serviceResponse);
        }
        public async Task<ServiceResponse<Selectview>> Comboboxes17(string tabela, string campo1, string campo2, string condicao, string Campochave)
        {
            if (condicao.ToLower().Equals("numtabela=2"))
            {

            }
            if (condicao.ToLower().Equals("vazio"))
            {
                condicao = "";
            }
            if (!condicao.IsNullOrEmpty())
            {
                condicao = $" where {condicao}";
            }
            ServiceResponse<Selectview> serviceResponse = new ServiceResponse<Selectview>();
            var quer =
                $" select {Campochave} Chave, convert(nvarchar(max), {campo1}) Descricao, convert(nvarchar(max), {campo2})  " +
                $"Ordem from {tabela} {condicao} order by Ordem asc";
        

            var dt = SQL.GetGenDt(quer);
            var sss = dt.DtToList<Selects>();

          

            List<Selects?> estudanteList = sss;
            var e = new Selectview();
            e.Selects = estudanteList;
            serviceResponse.Dados = e;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }

        public string _ctabela;
        public string _campo1;
        public string _campo2;
        public string _type = string.Empty;
        public bool Multidocumento { get; set; }
        public bool Sonumero { get; set; }
        public string Campo1Capition { get; set; }
        public string Campo2Capition { get; set; }

        //public string _type2;
        public string Campo { get; set; }
        public string Condicao1 { get; set; }
        public string DataNome { get; set; } = "data";
        public string OrderByCampos { get; set; }
        public decimal OldYear { get; set; }
        public bool TodosCentros { get; set; } = false;
        #region Load

        public void Proc_Load()
        {
            DataNome = "data";
            _type = SQL.GetTipo(_ctabela, Campo).Trim();
            //_type2 = SQL.GetTipo(_ctabela, DataNome).Trim();
            switch (_type)
            {
                case "text":
                case "nvarchar":
                case "char":
                    // valorprocurado = string.Empty;
                    //tbProc.Focus();
                    break;
                case "datetime":
                    //tbProc.Visible = false;
                    break;
                case "bit":
                    //cbProc.Visible = true;
                    //cbProc.Checked = true;
                    //tbProc. = true;
                    break;
                case "numeric":
                case "decimal":
                    //tbProc.WatermarkText = @"Digita apenas números";
                    //tbProc.Focus();
                    break;
            }

        }
        #endregion

        #region Método de Procurar

        public string Condicao2 { get; set; }
        public async Task<PaginationResponseBl<List<SharedClasses.Procura>>> Procurar(string tabela, string campo, string campo1, string chave, string valorprocurado, 
            int currentNumber, int pagesize,string condicaodata="")
        {
            _ctabela = tabela;
            Campo = campo;
            Proc_Load();
            PaginationResponseBl<List<SharedClasses.Procura>> paginationpeviw;
            int num3 = pagesize;
            int num2 = (currentNumber - 1) * pagesize;
            try
            {
                int num1 = 50;
                pagesize = pagesize < num1 ? pagesize : num1;
                Condicao2 = condicaodata;
                switch (Pbl.Usuario.Inseriu?.ToLower())
                {
                    case "entrada":
                        _ctabela = "EntradaProcesso";
                        if (Condicao2.IsNullOrEmpty())
                        {
                           // Condicao2 = $" OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        else
                        {
                            //Condicao2 = $" and OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        break;
                    case "saida":
                        _ctabela = "SaidaProcesso";
                        if (Condicao2.IsNullOrEmpty())
                        {
                            //Condicao2 = $" OrgaoorigemNaSaida='{Pbl.Usuario.Orgao}' and DirecaoOrigemNaSaida='{Pbl.Usuario.Direcao}'";
                        }//
                        else
                        {
                            //Condicao2 = $" and OrgaoorigemNaSaida='{Pbl.Usuario.Orgao}' and DirecaoOrigemNaSaida='{Pbl.Usuario.Direcao}'";
                        }
                        break;
                    case "pendente":
                        _ctabela = "SaidaProcesso";
                        if (Condicao2.IsNullOrEmpty())
                        {
                            //Condicao2 = $" OrgaoDest='{Pbl.Usuario.Orgao}' and DirecDest='{Pbl.Usuario.Direcao}'";
                        }
                        else
                        {
                            //Condicao2 = $" and OrgaoDest='{Pbl.Usuario.Orgao}' and DirecDest='{Pbl.Usuario.Direcao}'";
                        }
                        break;

                }
                var buildCond = Utilities.BuildCond(valorprocurado, Campo, _type, Condicao2, true);
                if (string.IsNullOrEmpty(OrderByCampos))
                {
                    OrderByCampos = $"{campo},{campo1}";
                }
                var sql = $@"  select count(*) from {_ctabela} where {buildCond}  
select {chave} as Chave,{campo} as Campo,{campo1} as Campo1,convert(bit,0)marcar,Valorprocurado='{valorprocurado}',
CurrentNumber={currentNumber},pagesize={pagesize} from {_ctabela} where {buildCond} order by {OrderByCampos}  
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";

                paginationpeviw = await ConvertToPaginationpeviw(await _peRepository.
                    GetObjectPaginationf(currentNumber, pagesize, sql));
            }
            catch
            {
                throw;
            }
            return paginationpeviw;
        }


      


        public async Task<PaginationResponseBl<List<SharedClasses.Procura>>> ConvertToPaginationpeviw(
            PaginationResponseBl<List<SharedClasses.Procura>> professor)
        {
            return new PaginationResponseBl<List<SharedClasses.Procura>>(professor.TotalCount, GetConvertTovie(professor.Data),
                professor.CurrentPageNumber, professor.PageSize);
        }
        public List<SharedClasses.Procura> GetConvertTovie(List<SharedClasses.Procura> professorData)
        {
            return professorData;
        }

        public async Task<ServiceResponse<Mdnviewgrelha>> ComboboxesMdn(string campos, string tabela, string condicoes)
        {
            ServiceResponse<Mdnviewgrelha> serviceResponse = new ServiceResponse<Mdnviewgrelha>();
            var dt = new DataTable();
            var fd = new Mdnview();
            var dtvie = fd.ToDataTable();
            dtvie.TableName = "Mdn";
            var dts = SQL.FillDataEnt(dt, dtvie);
            var sss = dts.DtToList<Mdnview>();
            List<Mdnview?> estudanteList = sss;
            var e = new Mdnviewgrelha();
            serviceResponse.Dados = e;
            serviceResponse.Dados.Mdnview = estudanteList;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }
        
        public async Task<PaginationResponseBl<object>> MetodoGenerico(string tabela, string campo, string campo1,
            string chave, string valorprocurado,
            int currentNumber, int pagesize, Usuario usuario, string condicaodata = "", string orderby = "", string entradastamp = "")
        {
            _ctabela = tabela;
            Campo = campo;
            Proc_Load();
            PaginationResponseBl<object> paginationpeviw;
            int num3 = pagesize;
            int num2 = (currentNumber - 1) * pagesize;
            int num1 = 50;
            pagesize = pagesize < num1 ? pagesize : num1;
            Condicao2 = condicaodata;
            var cond = "";
            if (usuario!=null)
            {
                Pbl.Usuario = usuario;
                switch (Pbl.Usuario.Inseriu?.ToLower())
                {
                    case "entrada":
                        //_ctabela = "EntradaProcesso";
                        if (Condicao2.IsNullOrEmpty())
                        {
                            //Condicao2 = $" OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        else
                        {
                            //Condicao2 += $" and OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        //Condicao2 += $" and Recebido=1";
                        break;
                    case "saida":
                        _ctabela = "SaidaProcesso";
                        if (Condicao2.IsNullOrEmpty())
                        {
                            //Condicao2 = $" OrgaoorigemNaSaida='{Pbl.Usuario.Orgao}' and DirecaoOrigemNaSaida='{Pbl.Usuario.Direcao}'";
                        }
                        else
                        {
                            //Condicao2 += $" and OrgaoorigemNaSaida='{Pbl.Usuario.Orgao}' and DirecaoOrigemNaSaida='{Pbl.Usuario.Direcao}'";
                        }
                        break;
                    case "pendente":
                        _ctabela = "EntradaProcesso";
                        if (Condicao2.IsNullOrEmpty())
                        {
                            //Condicao2 = $" OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        else
                        {
                            //Condicao2 += $" and OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        //Condicao2 += $" and Recebido=0 and saidastamp is not null";
                        break;
                    case "arquivo":
                        _ctabela = "Arquivo";
                        if (Condicao2.IsNullOrEmpty())
                        {
                            //Condicao2 = $" OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        else
                        {
                            //Condicao2 += $" and OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        }
                        break;
                    case "usuario":
                        _ctabela = "usuario";
                        if (Pbl.Usuario.TipoPerfil != null && Pbl.Usuario.TipoPerfil.ToLower().Equals("ADMINISTRADOR".ToLower()))
                        {
                            cond = $" 1=1";
                        }
                        else if (Pbl.Usuario.TipoPerfil != null && Pbl.Usuario.TipoPerfil.ToLower().Equals("GESTOR".ToLower()))
                        {
                            //cond = $"  Orgaostamp='{Pbl.Usuario.Orgaostamp}'";
                        }
                        else
                        {
                            if (!Pbl.Usuario.Direcaostamp.IsNullOrEmpty())
                            {
                                //cond += $"  Orgaostamp='{Pbl.Usuario.Orgaostamp}' and Direcaostamp='{Pbl.Usuario.Direcaostamp}'";
                                if (!Pbl.Usuario.Departamentostamp.IsNullOrEmpty())
                                {
                                    //cond += $" and Departamentostamp='{Pbl.Usuario.Departamentostamp}'";
                                }
                            }
                            else if (Pbl.Usuario.Direcao.IsNullOrEmpty())
                            {
                                //cond = $" 1=0";
                            }
                        }
                        break;
                    case "busca":
                        _ctabela = "busca";
                        if (Condicao2.IsNullOrEmpty())
                        {
                            //Condicao2 = entradastamp;
                        }
                        else
                        {
                            //Condicao2 += $" and {entradastamp}";
                        }
                        break;

                }
            }
            var buildCond = Utilities.BuildCond(valorprocurado, Campo, _type, Condicao2, true);
            if (Pbl.Usuario.Inseriu != null && !Pbl.Usuario.Inseriu.ToLower().Equals("entrada"))
            {
                if (string.IsNullOrEmpty(OrderByCampos))
                {
                    OrderByCampos = $"{campo},{campo1}";
                }
            }
            if (Pbl.Usuario.Inseriu != null && Pbl.Usuario.Inseriu.ToLower().Equals("entrada"))
            {
                OrderByCampos = $"{orderby}";
            }

            if (_ctabela.Equals("vBi", StringComparison.OrdinalIgnoreCase))
            {
                buildCond = Condicao2;
            }
            var sql = $@"  select count(*) from {_ctabela} where {buildCond}  
select  {chave}  from {_ctabela} where {buildCond} order by {OrderByCampos}  
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
            if (!cond.IsNullOrEmpty())
            {
                cond += $" and nome<>'' and login<>''";
                sql = $@"  select count(*) from (select * from {_ctabela} where {cond})temp where {buildCond}   
select {chave} from (select {chave} from {_ctabela} where {cond})temp where {buildCond} order by {OrderByCampos}   
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
            }
            else
            {
                switch (_ctabela.ToLower())
                {
                    case "busca":
                        if (!entradastamp.IsNullOrEmpty())
                        {
                            sql = $@"  select count(*) from (select * from {_ctabela} where {entradastamp})temp where {buildCond}   
select {chave} from (select {chave} from {_ctabela} where {entradastamp})temp where {buildCond} order by {OrderByCampos}   
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                        }
                        break;
                    case "pa":
                      
                        _ctabela = $"vPacientes";

                        if (!entradastamp.IsNullOrEmpty())
                        {

                            var inseriu = $"='{entradastamp}'";
                            if (entradastamp.ToLower().Contains($@"not in("))
                            {
                                inseriu = entradastamp;
                            }
                            sql = $@"  select count(*) from (select * from {_ctabela} where inseriu {inseriu})temp where {buildCond}   
select  {chave} from (select {chave} from {_ctabela} where inseriu {inseriu})temp where {buildCond} order by {OrderByCampos}   
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                        }
                        else
                        {
                            sql = $@"  select count(*) from {_ctabela} where {buildCond}  
select  {chave}  from {_ctabela} where {buildCond} order by {OrderByCampos}  
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                        }
                        break;

                    case "processo":

                        if (!entradastamp.IsNullOrEmpty())
                        {
                            var inseriu = $"='{entradastamp}'";
                            if (entradastamp.ToLower().Contains($@"not in("))
                            {
                                inseriu = entradastamp;
                            }
                            sql = $@"  select count(*) from (select * from {_ctabela} where pastamp {inseriu})temp where {buildCond}   
select     {chave} from (select {chave} from {_ctabela} where pastamp {inseriu})temp where {buildCond} order by convert(datetime,inseriudatahora) desc    
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                        }
                        else
                        {
                            sql = $@"  select count(*) from {_ctabela} where {buildCond}  
select  {chave}  from {_ctabela} where {buildCond}  order by convert(datetime,inseriudatahora) desc   
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                        }
                        break;
                     default:
                        if (!entradastamp.IsNullOrEmpty())
                        {
                           
                            sql = $@"  select count(*) from (select * from {_ctabela} where  {entradastamp})temp where {buildCond}   
select  {chave} from (select {chave} from {_ctabela} where  {entradastamp})temp where {buildCond} order by {OrderByCampos}   
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                        }
                        else
                        {
                            sql = $@"  select count(*) from {_ctabela} where {buildCond}  
select  {chave}  from {_ctabela} where {buildCond} order by {OrderByCampos}  
OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
                        }
                        break;
                }
            }
            
            using (SqlConnection cnn = new SqlConnection
                       (ApIcontext.Database.GetDbConnection().ConnectionString))
            {
                cnn.Open();
                SqlMapper.GridReader gridReader = cnn.QueryMultiple(sql, commandTimeout: 2000);
                PaginationResponseBl<object> RespostaPaginacao = new PaginationResponseBl<object>
                    (gridReader.Read<int>().FirstOrDefault(), gridReader.Read<object>().ToList<object>(), currentNumber, pagesize);
                cnn.Close();
                paginationpeviw = RespostaPaginacao;
            }
            return paginationpeviw;
        }
        #endregion

    }


}
