using System.Data;
using System.Globalization;
using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using Microsoft.EntityFrameworkCore.Storage;
using Model.Models.Facturacao;
using Model.Models.Gene;
using SGPMAPI.SharedClasses;
using HelperFact = DAL.Classes.HelperFact;

namespace SGPMAPI.Interfaces
{

    public class MatriculaAlunoServicos : IntermatriculaAluno
    {
        public readonly SGPMContext ApIcontext;
        private readonly IGenericRepository<MatriculaAluno> _peRepository;
        private readonly IGenericRepository<Planopag> _planoRepository;
        private readonly IGenericRepository<Turmal> _turmalRepository;
        private readonly IGenericRepository<Turmadisc> _turmadiscRepository;
        private readonly IGenericRepository<Turmanota> _turmanotaRepository;
        private readonly IGenericRepository<Fact> _factRepository;
        // private readonly IGenericRepository<MatriculaAluno> _peRepository;
        public MatriculaAlunoServicos(SGPMContext descricaoAPi, IGenericRepository<MatriculaAluno> peRepository,
            IGenericRepository<MatriculaAluno> horarioRepository, IGenericRepository<Planopag> planoRepository, IGenericRepository<Turmal> turmalRepository
            , IGenericRepository<Turmadisc> turmadisRepository, IGenericRepository<Turmanota> turmanotaRepository, IGenericRepository<Fact> ftRepository)
        {
            ApIcontext = descricaoAPi;
            _peRepository = peRepository;
            _planoRepository = planoRepository;
            _turmalRepository = turmalRepository;
            _turmadiscRepository = turmadisRepository;
            _turmanotaRepository = turmanotaRepository;
            _factRepository = ftRepository;

        }
        #region Professores

        public async Task<ServiceResponse<Dmzviewgrelha>> GetDados(string MatriculaAlunostamp, string tabela)
        {
            var str = $@"select Nome,disciplina=(select descricao from st where st.Ststamp=Turmadiscp.Ststamp),pestamp,
                                        MatriculaAlunostamp from Turmadiscp join Turmadisc
                                        on Turmadisc.Turmadiscstamp = Turmadiscp.Turmadiscstamp where MatriculaAlunostamp = '{MatriculaAlunostamp.Trim()}' order by nome ";

            switch (tabela)
            {
                case "turmadiscp":
                    str = $@"select Nome,disciplina=(select descricao from st where st.Ststamp=Turmadiscp.Ststamp),pestamp,
                                        MatriculaAlunostamp from Turmadiscp join Turmadisc
                                        on Turmadisc.Turmadiscstamp = Turmadiscp.Turmadiscstamp where 
MatriculaAlunostamp = '{MatriculaAlunostamp.Trim()}' order by nome ";
                    break;

            }
            ServiceResponse<Dmzviewgrelha> serviceResponse = new ServiceResponse<Dmzviewgrelha>();
            var dt = await _peRepository.GetDataTable(str);
            var fd = new Dmzview();
            var dtvie = fd.ToDataTable();
            dtvie.TableName = "DMZ";
            var dts = SQL.FillDataEnt(dt, dtvie);
            var sss = dts.DtToList<Dmzview>();
            List<Dmzview?> estudanteList = sss;
            var e = new Dmzviewgrelha();
            serviceResponse.Dados = e;
            serviceResponse.Dados.Dmzview = estudanteList;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }


        #endregion


        public async Task<ServiceResponse<CamposDashbord>> Pecadastroview(string MatriculaAlunostamp)
        {

            var interpolatedStringHandler = $@"select count(*) from Pe where lTrim(rTrim(Pestamp)) ='{MatriculaAlunostamp.Trim()}'
select [Pestamp]
      ,[No]
      ,[Nome]
      ,[Nacional]
      ,[Datanasc]
      ,[Ecivil]
      ,[Pai]
      ,[Mae]
      ,[Sexo]
      ,[Codsit]
      ,[Situacao]
      ,[Nuit]
      ,[ProvNasc]
      ,[DistNasc]
      ,[PadNasc]
      ,[Bairro]
      ,[ProvMorada]
      ,[DistMorada]
      ,[PadMorada]
      ,[CodCateg]
      ,[RelPonto]
      ,[ValBasico]
      ,[NrDepend]
      ,[Dcasa]
      ,[Pais]
      ,[CodNivel]
      ,[Nivel]
      ,[Categ]
      ,[Codprof]
      ,[Prof]
      ,[Codep]
      ,[Depart]
      ,[Codrep]
      ,[Repart]
      ,[Nrinss]
      ,[Obs]
      ,[Codccu]
      ,[CCusto]
      ,[HorasSemana]
      ,[SalHora]
      ,[TabIrps]
      ,[CodRepFinancas]
      ,[DescRepFinancas]
      ,[Horasdia]
      ,[Codtipo]
      ,[Tipo]
      ,[Diasmes]
      ,[Apolice]
      ,[Seguradora]
      ,[DataAdmissao]
      ,[DataFimContrato]
      ,[DataDemissao]
      ,[NaoInss]
      ,[NaoIRPS]
      ,[Moeda]
      ,[BalcaoInss]
      ,[DataInss]
      ,[DataApoliceIn]
      ,[DataApoliceTer]
      ,[Bi]
      ,[Tirpsstamp]
      ,[Locali]
      ,[Ccustamp]
      ,[Ntabelado]
      ,[Pontonome]
      ,[Formapag]
      ,[Codformp]
      ,[Dataadm]
      ,[ReDataadm]
      ,[Basedia]
      ,[Pedagogico]
      ,[Coordenador] from Pe where lTrim(rTrim(Pestamp)) = '{MatriculaAlunostamp.Trim()}' 
order by nome ";
            ServiceResponse<CamposDashbord> serviceResponse = new ServiceResponse<CamposDashbord>();
            var dt = await _peRepository.GetDataTable(interpolatedStringHandler);
            var sss = dt.DtToList<Pe>();
            var pes = sss;
            foreach (var p in pes)
            {

                var dd = GetConvertTovie(p);
            }

            var camposs = new CamposDashbord();
            camposs.Pecadastroview = pes;
            serviceResponse.Dados = camposs;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }

        public async Task<ServiceResponse<Selects>> GetMax(string tabela, string campo, string condicao)
        {
            if (Pbl.Param == null)
            {

                Pbl.Param = SQL.GetRowToEnt<Param>("");
            }
            switch (tabela.ToLower())
            {
                case "matriculaaluno":
                    condicao = $" {condicao} and year(data) = {Pbl.Param.Anoref}";
                    break;
                case "rcl":
                    condicao = $" {condicao} and year(data) = {Pbl.Param.Anoref}";
                    break;
            }
            var desc = SQL.Maximo(tabela, campo, condicao).ToString(CultureInfo.InvariantCulture);
            ServiceResponse<Selects> serviceResponse = new ServiceResponse<Selects>();
            var camposs = new Selects();
            camposs.Chave = desc;
            camposs.Descricao = desc;
            camposs.Ordem = desc;
            serviceResponse.Dados = camposs;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;

        }
        private Pe GetConvertTovie(Pe professorData)
        {
            GetProfessor(professorData);
            return professorData;
        }
        private void GetProfessor(Pe professor)
        {
            var data = professor;
            if (data != null)
            {
                data.Pedoc = GetMancdoc(professor.Pestamp);
                data.Peling = GetLingua(professor.Pestamp);
                data.Pefam = Getfam(professor.Pestamp);
                data.Pedisc = Getprofdis(professor.Pestamp);
            }
        }
        private List<Pedoc?> GetMancdoc(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from Pedoc where pestamp='{pestamp.Trim()}'").DtToList<Pedoc>();
            return dt;
        }
        private List<Pedisc?>? Getprofdis(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from Pedisc where pestamp='{pestamp.Trim()}'").DtToList<Pedisc>();
            return dt;
        }
        private List<Pefam?> Getfam(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from Pefam where pestamp='{pestamp.Trim()}'").DtToList<Pefam>();
            return dt;
        }
        private List<Peling?> GetLingua(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from Peling where pestamp='{pestamp.Trim()}'").DtToList<Peling>();
            return dt;
        }

        public async Task<PaginationResponseBl<List<MatriculaAluno>>> GetGrades(string nimdescricao, int currentNumber, int pagesize)
        {
            if (Pbl.Param == null)
            {
                Pbl.Param = SQL.GetRowToEnt<Param>("");
            }
            Pbl.SqlDate = $"{Pbl.Param.Anoref}-01-01".ToDateTimeValue();
            PaginationResponseBl<List<MatriculaAluno>> paginationpeviw;
            int num3 = pagesize;
            int num2 = (currentNumber - 1) * pagesize;
            int num1 = 50;
            pagesize = pagesize < num1 ? pagesize : num1;
            var interpolatedStringHandler = $@"select count(*) from MatriculaAluno where 
lTrim(rTrim(nome)) like '%{nimdescricao.Trim()}%'  and year(data) = {Pbl.SqlDate.Year}
select * from MatriculaAluno where lTrim(rTrim(nome)) like '%{nimdescricao.Trim()}%' and year(data) = {Pbl.SqlDate.Year}
order by nome OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
            paginationpeviw = await ConvertToPaginationpeviw(await _peRepository.
                GetObjectPaginationf(currentNumber, pagesize, interpolatedStringHandler));
            return paginationpeviw;
        }


        private async Task<PaginationResponseBl<List<MatriculaAluno>>> ConvertToPaginationpeviw(
            PaginationResponseBl<List<MatriculaAluno>> professor)
        {
            return new PaginationResponseBl<List<MatriculaAluno>>(professor.TotalCount, GetConvertTovie(professor.Data),
                professor.CurrentPageNumber, professor.PageSize);
        }
        private List<MatriculaAluno> GetConvertTovie(List<MatriculaAluno> professorData)
        {
            List<MatriculaAluno> convertToProfessorview = professorData;
            foreach (MatriculaAluno professor1 in professorData)
            {
                GetGrades(professor1);
            }
            return convertToProfessorview;
        }
        private void GetGrades(MatriculaAluno professor)
        {
            professor.MatriculaTurmaAlunol = GetMatricula(professor.MatriculaAlunostamp);
            professor.DisciplinaTumra = Getdisciplinasturmas(professor.MatriculaAlunostamp);
            professor.Matdisc = Getmatdisc(professor.MatriculaAlunostamp);
        }
        private List<Matdisc> Getmatdisc(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from Matdisc where MatriculaAlunostamp='{pestamp.Trim()}'").DtToList<Matdisc>();
            return dt;
        }
        private List<DisciplinaTumra> Getdisciplinasturmas(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from DisciplinaTumra where MatriculaAlunostamp='{pestamp.Trim()}'").DtToList<DisciplinaTumra>();
            return dt;
        }
        private List<MatriculaTurmaAlunol> GetMatricula(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from MatriculaTurmaAlunol where MatriculaAlunostamp='{pestamp.Trim()}'").DtToList<MatriculaTurmaAlunol>();
            return dt;
        }
        public async Task<bool> Editar(MatriculaAluno modelo1)
        {

            var modelo = modelo1;
            if (modelo == null)
                throw new TaskCanceledException("Turma não existe");
            int num = await _peRepository.Editar(modelo) ? 1 : 0;
            if (num == 0)
                throw new TaskCanceledException("Nao foi possivel eliminar Turma");
            var flag = num != 0;
            return flag;
        }

        public async Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave)
        {
            try
            {
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

                var modelo = new MatriculaAluno();
                var dt = await _peRepository.GetDataTable($"select * from MatriculaAluno where MatriculaAlunostamp='{id}'");
                if (dt.HasRows())
                {
                    modelo = dt.Rows[0].DrToEntity<MatriculaAluno>();
                }
                if (modelo == null)
                    throw new TaskCanceledException("Matricula não existe");
                int num = await _peRepository.Eliminar(modelo) ? 1 : 0;
                if (num == 0)
                    throw new TaskCanceledException("Nao foi possivel eliminar Matricula");
                flag = num != 0;
            }
            catch
            {
                throw;
            }
            return flag;
        }

        public async Task<MatriculaAluno> Criar(MatriculaAluno modelo2, bool inserindo)
        {

            MatriculaAluno prof;
            try
            {
                AfterSave(modelo2);
                prof = modelo2;

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return prof;
        }

        public DataRowView DtPlanovView { get; set; }
        private DataTable _falctl { get; set; }
        public DataTable DtTurmanota { get; set; }
        private TdocMat TmpTdocMat;
        public async void AfterSave(MatriculaAluno mtAluno)
        {
            DataTable dtpar;

            TmpTdocMat = SQL.GetRowToEnt<TdocMat>($"TdocMatstamp='{mtAluno.Refonecedor}'");
            if (TmpTdocMat.Inscricao)
            {
                var quer = $@"select getdate() Data,sts.Preco ValorTotal,Parecela=1 ,Descricao,st.Ststamp Planopagstamp
from st inner join  stprecos sts on st.ststamp=sts.ststamp  
where TipoProduto=1 and Descricao like '%{TmpTdocMat.Descricao.Trim()}%'";
                dtpar = await _peRepository.GetDataTable(quer);
            }
            else
            {
                if (TmpTdocMat.Matricula)
                {

                    var niv = 1;
                    var qyrmulta = "";




                    var quer = $@"select Planopagstamp,Descricao,descanosem,Cursostamp,AnoSemstamp,DataFim,Datapartida  
from Planopag where descanosem='{mtAluno.AnoSem}'";
                    var dtplano = await _peRepository.GetDataTable(quer);
                    if (dtplano.HasRows())
                    {
                        if (mtAluno.Curso.ToLower().Contains("lic"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%lic%'");
                        }
                        else if (mtAluno.Curso.ToLower().Contains("mestr"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%mestr%'");

                        }
                        else if (mtAluno.Curso.ToLower().Contains("pos"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%pos%'");

                        }
                        else if (mtAluno.Curso.ToLower().Contains("dou"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%dou%'");

                        }

                        if (dtplano.HasRows())
                        {
                            var dr = dtplano.Rows[0];
                            DtPlanovView = dr.Table.DefaultView[dtplano.Rows.IndexOf(dr)];
                        }
                    }

                    if (DtPlanovView != null)
                    {
                        var fim = DtPlanovView["DataFim"].ToDateTimeValue();
                        if (fim < DateTime.Now)
                        {
                            if (mtAluno.Curso.ToLower().Contains("licenciatura"))
                            {
                                niv = 1;
                            }
                            if (mtAluno.Curso.ToLower().Contains("mestrado"))
                            {
                                niv = 2;
                            }
                            qyrmulta = $@" union all select distinct Data=GETDATE(),stp.Preco ValorTotal,Parcela=10,
st.Descricao,st.Ststamp Planopagpstamp from st inner join StPrecos stp 
on st.Ststamp=stp.Ststamp where Servico=1 and TipoProduto=1 and Multa=1 and st.tara={niv}";
                        }
                    }
                    var qry = $@"select Data,ValorTotal,
                                       Parecela,descricao,
                                       Planopagpstamp from Planopagp where 
                                       Planopagstamp='{mtAluno.Planopagstamp}' 
                                            {qyrmulta}
                                       order by Parecela";
                    dtpar = await _peRepository.GetDataTable(qry);
                }
                else
                {
                    dtpar = await _peRepository.GetDataTable($@"select Data,ValorTotal,
                                       Parecela,descricao,
                                       Planopagpstamp from Planopagp where 
                                       Planopagstamp='{mtAluno.Planopagstamp}' 
                                       order by Parecela");
                }
            }
            if (dtpar.HasRows())
            {
                var TmpTdoc = SQL.GetRowToEnt<Tdoc>("ft=1");
                var _turmap = SQL.GetRowToEnt<Turma>($"turmastamp='{mtAluno.Turmastamp}'");
                if (_turmap != null)
                {
                    var dt = _turmap.ToDataTable();
                    var campos = new[]
                    {
                       "Turmastamp", "Codigo","Descanoaem", "Descurso", "Cursostamp","Etapa"
                   };
                    if (dt.HasRows())
                    {
                        dt = dt.DefaultView.
                            ToTable(true, campos);
                    }

                    if (dt.HasRows())
                    {
                        var dr = dt.Rows[0];
                        Dtv = dr.Table.DefaultView[dt.Rows.IndexOf(dr)];
                    }
                }
                var entidade = await _peRepository.GetDataTable($"select * from contas where Contasstamp='{mtAluno.Codfac}'");

                if (entidade.HasRows())
                {
                    var dr = entidade.Rows[0];
                    DtEntidade = dr.Table.DefaultView[entidade.Rows.IndexOf(dr)];
                }

                if (mtAluno.Inscricao || mtAluno.Matricula)
                {
                    Numinterno = mtAluno.Planopagstamp;
                }
                else
                {
                    Numinterno = $@"Exameespecial_{DateTime.Now.ToShortDateString()}";
                }
                foreach (var item in dtpar.AsEnumerable())
                {
                    if (item != null)
                    {
                        var ckexist = SQL.CheckExist($@"
select fact.factstamp from fact inner join factl
on fact.Factstamp=factl.Factstamp
where
Turmastamp='{mtAluno.Turmastamp.Trim()}'
and clstamp='{mtAluno.Clstamp}'
and Anosem='{mtAluno.AnoSem}'
and factl.descricao='{item["descricao"]}'");
                        if (!ckexist)
                        {

                            var ft = Utilities.DoAddline<Fact>();

                            var Cl = SQL.GetRowToEnt<Cl>($"Clstamp='{mtAluno.Clstamp}'");
                            HelperFact.FillFactura(ft, Cl, item["Data"].ToDateTimeValue(), TmpTdoc,
                                DtEntidade, Dtv, Numinterno);
                            ft.Ft = true;
                            ft.Movcc = true;
                            var ftl = SQL.Initialize("factl");
                            var dr = ftl.NewRow().Inicialize();
                            HelperFact.FillFactl(item, dr, ft.Factstamp);
                            ftl.Rows.Add(dr);
                            HelperFact.TotaisFt(ft, ftl);
                            ft.MatriculaAluno = mtAluno.Matricula;
                            ft.Inscricao = mtAluno.Inscricao;
                            ft.Nomedoc = TmpTdoc.Descricao;
                            EF._dbContext = ApIcontext;
                            var ddd = await EF.Save(ft);
                            if (ddd.ret > 0)
                            {

                                SQL.Save(ftl, "factl", true, ft.Factstamp, "fact");
                            }





                        }
                    }
                }
            }
            var dtturmas = mtAluno.MatriculaTurmaAlunol.ToList().ParaDataTable();
            var camposs = new[]
            {
                "MatriculaTurmaAlunolstamp", "Turmastamp"
            };
            if (dtturmas.HasRows())
            {
                dtturmas = dtturmas.DefaultView.
                    ToTable(true, camposs);
                dtturmas.Columns.Add("Clstamp", typeof(string));
                dtturmas.Columns.Add("Nome", typeof(string));
                dtturmas.Columns.Add("No", typeof(string));
                dtturmas.Columns["MatriculaTurmaAlunolstamp"].ColumnName = "Turmalstamp";
                dtturmas.AcceptChanges();
                var dd = dtturmas.DtToList<Turmal>();
                foreach (var tml in dd)
                {
                    var ddss = await _peRepository.GetDataTable($@"select Turmalstamp from Turmal where Turmalstamp='{tml.Turmalstamp.Trim()}'");
                    if (!ddss.HasRows())
                    {
                        tml.Clstamp = tml.Clstamp;
                        tml.No = tml.No;
                        tml.Nome = tml.Nome;
                        using (IDbContextTransaction dbtransaction = _turmalRepository.ReturnDataBaseContext().BeginTransaction())
                        {
                            try
                            {
                                var manceboCriado = await _turmalRepository.Criar(tml);
                                if (string.IsNullOrEmpty(manceboCriado.Turmalstamp))
                                    throw new TaskCanceledException("Não foi possivel criar");
                                var modelo2 = (await _turmalRepository.Consultar(u => u.Turmalstamp.ToLower() ==
                                    manceboCriado.Turmalstamp.ToLower())).First();
                                dbtransaction.Commit();


                            }
                            catch (Exception ex)
                            {
                                dbtransaction.Rollback();
                                throw new TaskCanceledException("Erro: " + ex.Message);
                            }
                        }
                    }
                }

                var dtturmass = mtAluno.MatriculaTurmaAlunol;
                foreach (var tml in dtturmass)
                {
                    //Inserção na tabela de disciplinas da turma
                    dtturmas = mtAluno.Matdisc.ToList().ParaDataTable();
                    try
                    {
                        dtturmas.Columns["DisciplinaTumrastamp"].ColumnName = "Turmadiscstamp";
                    }
                    catch (Exception)
                    {
                        //
                    }
                    dtturmas.AcceptChanges();

                    var ddsc = dtturmas.DtToList<Turmadisc>();
                    DtTurmanota = SQL.Initialize("Turmanota");
                    foreach (var tmsl in ddsc)
                    {
                        var dl = await _peRepository.GetDataTable($@"select Turmadiscstamp 
from Turmadisc where Turmadiscstamp='{tmsl.Turmadiscstamp.Trim()}'");
                        if (!dl.HasRows())
                        {
                            using (IDbContextTransaction dbtransaction = _turmadiscRepository.ReturnDataBaseContext().BeginTransaction())
                            {
                                try
                                {
                                    var manceboCriado = await _turmadiscRepository.Criar(tmsl);
                                    if (string.IsNullOrEmpty(manceboCriado.Turmadiscstamp))
                                        throw new TaskCanceledException("Não foi possivel criar");
                                    var modelo2 = (await _turmadiscRepository.Consultar(u => u.Turmadiscstamp.ToLower() ==
                                        manceboCriado.Turmadiscstamp.ToLower())).First();
                                    dbtransaction.Commit();


                                }
                                catch (Exception ex)
                                {
                                    dbtransaction.Rollback();
                                    throw new TaskCanceledException("Erro: " + ex.Message);
                                }
                            }

                        }
                        //Adicionar Este aluno na tabela de lançamento de notas
                        var rw = DtTurmanota.NewRow().Inicialize();
                        rw["Turmastamp"] = tml.Turmastamp;
                        rw["Alunostamp"] = mtAluno.Clstamp;
                        rw["AlunoNome"] = mtAluno.Nome;
                        rw["No"] = mtAluno.No;
                        rw["Coddis"] = tmsl.Ststamp;
                        rw["Disciplina"] = tmsl.Disciplina;
                        rw["Anosem"] = tml.Descanoaem;
                        rw["Sem"] = tml.Etapa;
                        rw["Cursostamp"] = mtAluno.Codcurso;
                        var professor = await _peRepository.GetDataTable($"select Pestamp,Nome from Turmadiscp " +
                                                                         $"where Ststamp='{tmsl.Ststamp.Trim()}'");
                        if (professor.HasRows())
                        {
                            rw["Pestamp"] = professor.Rows[0]["Pestamp"];
                            rw["Profnome"] = professor.Rows[0]["Nome"];
                        }
                        if (professor.Rows.Count == 2)
                        {
                            rw["Pestamp2"] = professor.Rows[1]["Pestamp"];
                            rw["Profnome2"] = professor.Rows[1]["Nome"];
                        }
                        DtTurmanota.Rows.Add(rw);
                    }
                }
            }

            if (DtTurmanota.HasRows())
            {

                foreach (var item in DtTurmanota.DtToList<Turmanota>())
                {
                    var qry = $"select Turmanotastamp from Turmanota where " +
                        $" Cursostamp='{item.Cursostamp}' and Turmastamp ='{item.Turmastamp}' and " +
                        $"Anosem='{item.Anosem}' and Coddis='{item.Coddis}' and alunostamp='{item.Alunostamp}'";

                    var dl = await _peRepository.GetDataTable(qry);
                    //var ss = SQL.ConvertToInsertIntoSql(item);
                    if (!dl.HasRows())
                    {
                        using (IDbContextTransaction dbtransaction = _turmanotaRepository.ReturnDataBaseContext().BeginTransaction())
                        {
                            try
                            {
                                var manceboCriado = await _turmanotaRepository.Criar(item);
                                if (string.IsNullOrEmpty(manceboCriado.Turmanotastamp))
                                    throw new TaskCanceledException("Não foi possivel criar");
                                var modelo2 = (await _turmanotaRepository.Consultar(u => u.Turmanotastamp.ToLower() ==
                                    manceboCriado.Turmanotastamp.ToLower())).First();
                                dbtransaction.Commit();


                            }
                            catch (Exception ex)
                            {
                                dbtransaction.Rollback();
                                throw new TaskCanceledException("Erro: " + ex.Message);
                            }
                        }
                    }
                }
            }


            InicializaLinhasdeFactura(mtAluno);
        }

        public DataRowView DtEntidade { get; set; }
        public DataRowView Dtv { get; set; }
        public string Numinterno { get; set; }
        private Fact _fact;

        private Tdoc TmpTdoc;
        private async void InicializaLinhasdeFactura(MatriculaAluno Cls)
        {
            if (Cls != null)
            {
                if (TmpTdoc == null)
                {
                    TmpTdoc = SQL.GetRowToEnt<Tdoc>("ft=1");
                }
                //o problema estava aqui
                _fact = null;
                var fact = await _peRepository.GetDataTable($@"select f.* from ClCCF() c inner join factl f
on c.ccstamp=f.Factstamp
where Clstamp='{Cls.Clstamp}'
order by f.ref");
                if (fact.HasRows())
                {
                    _fact =
                        fact.DtToList<Fact>().FirstOrDefault();//SQL.GetRowToEnt<Fact>(
                }                               //$"clstamp='{Cl.Clstamp.Trim()}'");
                if (_fact != null)
                {
                    _fact.Obs = _fact.Referencia;


                    _falctl = await _peRepository.GetDataTable($"select fl.* from factl fl inner join ClCCF() f " +
                                                               $"on fl.Factstamp=f.ccstamp" +
                                                               $" where clstamp='{Cls.Clstamp.Trim()}'" +
                                                               $" order by fl.ref" +
                                                               $" ");//ate aqui

                    if (_falctl.HasRows())
                    {
                        foreach (DataRow row in _falctl.Rows)
                        {
                            row["Armazemstamp"] = _fact.Entidadebanc;
                            row["Obs"] = _fact.Referencia;
                            //row["descricao"] = "Matrícula";
                        }
                    }
                }
            }
        }
        // ComboBox cb
        public async Task<ServiceResponse<Dmzviewgrelha>> Comboboxesdmz(string campos, string tabela, string condicoes)
        {
            string campossele = "";
            string camposnulos = "";
            var camposangula = campos.Split(',');
            foreach (var str in camposangula)
            {

                if (camposnulos.IsNullOrEmpty())
                {

                    if (str.Contains("CONVERT(bit"))
                    {

                        campossele = $"{str}";
                        camposnulos = $"{str}";
                    }
                    else
                    {
                        campossele = $"Convert(nvarchar(max),{str}){str}";
                        camposnulos = $"''{str}";
                    }


                }
                else
                {


                    if (!str.Contains(",0)"))
                    {
                        if (!str.Contains("CONVERT(bit") && !str.Contains("0) marcar"))
                        {
                            campossele += $",CONVERT(nvarchar(max),{str}){str}";
                        }
                        else if (str.Contains("CONVERT(bit"))
                        {
                            campossele += $",CONVERT(bit,0)marcar";
                        }
                        if (!str.Contains("CONVERT(bit") && !str.Contains("0) marcar"))
                        {
                            camposnulos += $",''{str}";
                        }
                        else if (str.Contains("CONVERT(bit"))
                        {
                            camposnulos += $",CONVERT(bit,0)marcar";
                        }


                    }
                    //else if (str.Contains("CONVERT(bit"))
                    //{
                    //    campossele += $",CONVERT(bit,0)marcar";
                    //}
                    //if (!str.Contains(",0)"))
                    //{
                    //    camposnulos += $",''{str}";
                    //}

                }

            }

            camposnulos = camposnulos.Replace(",''0) marcar", "");
            //campossele = campossele.Replace(",CONVERT(bit,0)marcar", "");
            if (!condicoes.IsNullOrEmpty())
            {
                condicoes = $" where {condicoes}";
            }
            ServiceResponse<Dmzviewgrelha> serviceResponse = new ServiceResponse<Dmzviewgrelha>();
            var dt = await _peRepository.GetDataTable($" select {camposnulos} union all " +
                                                      $" select {campossele} from {tabela} {condicoes}");

            //var dd = new DataTable("DMZ");
            var fd = new Dmzview();
            var dtvie = fd.ToDataTable();
            dtvie.TableName = "DMZ";
            var dts = SQL.FillDataEnt(dt, dtvie);
            var sss = dts.DtToList<Dmzview>();

            List<Dmzview?> estudanteList = sss;
            var e = new Dmzviewgrelha();
            serviceResponse.Dados = e;
            serviceResponse.Dados.Dmzview = estudanteList;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }

        public async Task<ServiceResponse<Dmzviewgrelha>> GetAnybyquery(string campos, string tabelas, string clstamp)
        {
            ServiceResponse<Dmzviewgrelha> serviceResponse = new ServiceResponse<Dmzviewgrelha>();
            var dt = await _peRepository.GetDataTable(campos);

            if (tabelas.ToLower().Equals("disciplina"))
            {
                var exceptostampPreceNegativas = "'nao1'";
                if (dt.HasRows())
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        if (item["Prec"].ToBool())
                        {
                            var todasPrece = await _peRepository.GetDataTable($"select oristamp from stl where Ststamp='{item["Ststamp"]}'");
                            if (todasPrece.HasRows())
                            {
                                foreach (DataRow iteml in todasPrece.Rows)
                                {
                                    var dt2 = await _peRepository.GetDataTable($"select top 1 Mediafinal from Turmanota where Coddis='{iteml["oristamp"]}' and alunostamp='{clstamp}' order by Sem desc");
                                    if (dt2.HasRows())
                                    {
                                        var notfina = dt2.RowZero("Mediafinal").ToDecimal();
                                        if (notfina < 9.5.ToDecimal())
                                        {
                                            exceptostampPreceNegativas += $",'{item["Ststamp"]}'";
                                        }
                                    }
                                }
                            }
                        }
                    }
                    exceptostampPreceNegativas = exceptostampPreceNegativas.Replace("'nao1',", "");
                    dt = dt.GetTable($"Ststamp not in ({exceptostampPreceNegativas})");
                    var campos1 = new[]
                    {
                        "Ststamp", "Disciplina","ok","Turmastamp","Mediafina","Fecho","Referenc","Sitcao"
                    };
                    if (dt.HasRows())
                    {
                        dt = dt.DefaultView.
                            ToTable(true, campos1);

                    }

                }

            }

            //var dd = new DataTable("DMZ");
            var fd = new Dmzview();
            var dtvie = fd.ToDataTable();
            dtvie.TableName = "DMZ";
            var dts = SQL.FillDataEnt(dt, dtvie);
            var sss = dts.DtToList<Dmzview>();

            List<Dmzview?> estudanteList = sss;
            var e = new Dmzviewgrelha();
            serviceResponse.Dados = e;
            serviceResponse.Dados.Dmzview = estudanteList;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }




        public async Task<ServiceResponse<object?>> Iniciatileany(Selects itemt)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var campos = $"select top 1 * from {itemt.Chave} where 1=0";
            var dt = await _peRepository.GetDataTable(campos);
            serviceResponse.Dados = dt;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }
        public async Task<ServiceResponse<object?>> GetQualquerObjectDt(Selects itemt)
        {
            if (itemt.Chave.Equals("GetContas()"))
            {

            }

            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var campos = $"select * from {itemt.Chave}";
            var dt = await _peRepository.GetDataTable(campos);
            serviceResponse.Dados = dt;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }

        public async Task<ServiceResponse<Dmzviewgrelha>> GetGenerico(Selects itemt)
        {
            ServiceResponse<Dmzviewgrelha> serviceResponse = new ServiceResponse<Dmzviewgrelha>();
            var tabela = itemt.Chave;
            var campo = itemt.Descricao;
            var condicao = itemt.Ordem;
            var str = $"select {campo} from {tabela} {condicao} ";
            var dt = await _peRepository.GetDataTable(str);
            var fd = new Dmzview();
            var dtvie = fd.ToDataTable();
            dtvie.TableName = "DMZ";
            var dts = SQL.FillDataEnt(dt, dtvie);
            var sss = dts.DtToList<Dmzview>();
            List<Dmzview?> estudanteList = sss;
            var e = new Dmzviewgrelha();
            serviceResponse.Dados = e;
            serviceResponse.Dados.Dmzview = estudanteList;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }
        public async Task<ServiceResponse<object?>> MetodoGenerico(Selects itemt)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            var tabela = itemt.Chave;
            var campo = itemt.Descricao;
            var condicao = itemt.Ordem;
            var dt = SQL.GetGenDt($"select {campo} from {tabela} {condicao} ");
            serviceResponse.Dados = dt;
            if (!dt.HasRows())
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Sem Dados";
                return serviceResponse;
            }
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "sucesso";
            return serviceResponse;
        }



        public async Task<ServiceResponse<Dmzviewgrelha>> GetPlanopamentoestudante(string clstamp)
        {
            var xx = $@"select descricao,valorreg,ccstamp,Fact.data,Fact.Dataven,tmp1.Referencia,fact.Numero,tmp1.Entidadebanc from (
                                select* from ClCCF() 
where Clstamp = '{clstamp.Trim()}')tmp1 join 
fact on tmp1.ccstamp = fact.Factstamp order by Numero";
            ServiceResponse<Dmzviewgrelha> serviceResponse = new ServiceResponse<Dmzviewgrelha>();
            var dt = await _peRepository.GetDataTable(xx);
            var fd = new Dmzview();
            var dtvie = fd.ToDataTable();
            dtvie.TableName = "DMZ";
            var dts = SQL.FillDataEnt(dt, dtvie);
            var sss = dts.DtToList<Dmzview>();
            var ff = sss.Count;
            List<Dmzview?> estudanteList = sss;
            var e = new Dmzviewgrelha();
            serviceResponse.Dados = e;
            serviceResponse.Dados.Dmzview = estudanteList;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }




        public async Task<ServiceResponse<TRcl>> GettRclsingleq(string tdocstamp)
        {
            ServiceResponse<TRcl> serviceResponse = new ServiceResponse<TRcl>();
            var dt = await _peRepository.GetDataTable($@"SELECT [TRclstamp]
      ,[Numdoc]
      ,[Descricao]
      ,[Sigla]
      ,[Descmovcc]
      ,[Codmovcc]
      ,[Contastesoura]
      ,[Codtz]
      ,[Titulo]
      ,[Ccusto]
      ,[Obs]
      ,[Entida]
      ,[activo]
      ,[Defa]
      ,[Alteranum]
      ,[Usaemail]
      ,[Usaanexo]
      ,[Integra]
      ,[Nodiario]
      ,[Diario]
      ,[NdocCont]
      ,[DescDocCont]
      ,[Codmovtz]
      ,[Descmovtz]
      ,[Nomfile]
      ,[Especial]
      ,[Nomfile2]
      ,[Rcladiant]
      ,''
      ,''
      ,''
      ,''
      ,[NomfilePOS]
  FROM [dbo].[TRcl] where TRclstamp='{tdocstamp}'");
            var fd = new TRcl();
            if (dt.HasRows())
            {
                fd = dt.Rows[0].DrToEntity<TRcl>();
            }
            serviceResponse.Dados = fd;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }

        public async Task<ServiceResponse<TdocMat>> GetTdoc(string tdocstamp)
        {
            ServiceResponse<TdocMat> serviceResponse = new ServiceResponse<TdocMat>();
            var dt = await _peRepository.GetDataTable($"select * from TdocMat where TdocMatstamp='{tdocstamp}'" +
                                                      $" or descricao='{tdocstamp}'");
            var fd = new TdocMat();
            if (dt.HasRows())
            {
                fd = dt.Rows[0].DrToEntity<TdocMat>();
            }
            serviceResponse.Dados = fd;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Dados encontrados";
            return serviceResponse;
        }




        #region Plano de pagamento
        public async Task<PaginationResponseBl<List<Planopag>>> GetHorariofromplanopagamento(
            string nimdescricao, int currentNumber, int pagesize)
        {
            Pbl.Param = SQL.GetRowToEnt<Param>("");
            var cond = "";
            if (!nimdescricao.IsNullOrEmpty())
            {
                if (nimdescricao.ToLower().Contains("licenc"))
                {
                    cond = "licenc";
                }
                if (nimdescricao.ToLower().Contains("mestrad"))
                {
                    cond = "mestrad";
                }
                if (nimdescricao.ToLower().Contains("bacharelato"))
                {

                    cond = "bacharelato";
                }
            }
            var quer = $@"select * 
from Planopag where descanosem= '{Pbl.Param.AnoSem}' and Descdistrato like '%{cond.Trim()}%'";

            PaginationResponseBl<List<Planopag>> paginationpeviw;
            int num3 = pagesize;
            int num2 = (currentNumber - 1) * pagesize;
            int num1 = 50;
            pagesize = pagesize < num1 ? pagesize : num1;
            var interpolatedStringHandler = $@"select count(*) from Planopag where 
 descanosem= '{Pbl.Param.AnoSem}' and Descdistrato like '%{cond.Trim()}%'

{quer}
order by descricao OFFSET {Convert.ToInt32(num2)} rows FETCH NEXT {Convert.ToInt32(num3)} rows only";
            paginationpeviw = await ConvertToPaginationplano(await _planoRepository.
                GetObjectPaginationf(currentNumber, pagesize, interpolatedStringHandler));
            return paginationpeviw;
        }
        private async Task<PaginationResponseBl<List<Planopag>>> ConvertToPaginationplano(
            PaginationResponseBl<List<Planopag>> professor)
        {
            return new PaginationResponseBl<List<Planopag>>(professor.TotalCount,
                GetConvertTovie(professor.Data),
                professor.CurrentPageNumber, professor.PageSize);
        }

        private List<Planopag> GetConvertTovie(List<Planopag> professorData)
        {
            foreach (Planopag professor1 in professorData)
            {
                GetFilhospg(professor1);
            }
            return professorData;
        }
        private void GetFilhospg(Planopag professor)
        {
            var data = professor;
            if (data != null)
            {
                data.Planopagp = GetPlanopagp(professor.Planopagstamp);
                data.Planopagt = GetPlanopagt(professor.Planopagstamp);
            }
        }
        private List<Planopagp> GetPlanopagp(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from Planopagp where Planopagstamp='{pestamp.Trim()}'").DtToList<Planopagp>();
            return dt;
        }
        private List<Planopagt> GetPlanopagt(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from Planopagt where Planopagstamp='{pestamp.Trim()}'").DtToList<Planopagt>();
            return dt;
        }

        private async Task<PaginationResponseBl<List<MatriculaAluno>>> ConvertToPaginationpeviwgr(
            PaginationResponseBl<List<MatriculaAluno>> professor)
        {
            return new PaginationResponseBl<List<MatriculaAluno>>(professor.TotalCount, GetConvertTovie(professor.Data),
                professor.CurrentPageNumber, professor.PageSize);
        }

        private MatriculaAluno GetHorariol(MatriculaAluno professor)
        {
            var data = professor;
            if (data != null)
            {

                data.MatriculaTurmaAlunol = GetHorariol(professor.MatriculaAlunostamp);
                return data;
            }
            return null!;
        }
        private List<MatriculaTurmaAlunol> GetHorariol(string pestamp)
        {
            var dt = SQL.GetGenDt($"select * from MatriculaTurmaAlunol where MatriculaAlunostamp='{pestamp.Trim()}'").DtToList<MatriculaTurmaAlunol>();
            return dt;
        }
        #endregion
    }

}
