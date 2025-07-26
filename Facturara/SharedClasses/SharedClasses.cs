using System.Data;
using Model.Models.Facturacao;
using Model.Models.SJM;

namespace SGPMAPI.SharedClasses
{
    public class FirstLogin
    {
        public string Email { get; set; }
        public string User { get; set; }
        public string Senha { get; set; }
    }
    public class DadosRecuperacao
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public string confirmarSenha { get; set; }


    }
    public class RecPassword
    {
        public string Email { get; set; }
        public string Codigo { get; set; }
        public string Tipoperfil { get; set; }
    }
    
    public class ISelectsProcura
    {
        public decimal Amount { get; set; }
        public ProgressValue Progress { get; set; } = new();
        public string Chave { get; set; }
        public string Descricao { get; set; }
        public string Ordem { get; set; }
        public string StampLocal { get; set; }
        public string StampSexcepcao { get; set; }
        public string Color { get; set; }
        public string Title { get; set; }
    }
    public class CamposDashbord
    {
        public List<Pe> Pe { get; set; } = new List<Pe>();

        public List<Pe> Pecadastroview { get; set; } = new();
        public List<Clsession> Cl { get; set; } = new List<Clsession>();

        public List<Fnc> Fnc { get; set; } = new List<Fnc>();
        public decimal Origem { get; set; } = 0;//Se 1==Importar aluno, se 2==importar professor,se 3== Importar RH
    }

    public class Clsession
    {
        public string Clstamp { get; set; } = "";
        public string No { get; set; } = "";
        public string Nome { get; set; } = "";
        public string Morada { get; set; } = "";
        public decimal Codprov { get; set; } = 0;
        public decimal Coddist { get; set; } = 0;
        public decimal Codpad { get; set; } = 0;
        public string Localidade { get; set; } = "";
        public string Distrito { get; set; } = "";
        public string Provincia { get; set; } = "";
        public string Telefone { get; set; } = "";
        public string Celular { get; set; } = "";
        public string Fax { get; set; } = "";
        public string Email { get; set; } = "";
        public decimal Nuit { get; set; } = 0;
        public decimal Saldo { get; set; } = 0;
        public string Moeda { get; set; } = "";
        public string Status { get; set; } = "";
        public string Datacl { get; set; } = "";
        public string Obs { get; set; } = "";
        public string CodigoQr { get; set; } = "";
        public bool Prontopag { get; set; } = false;
        public string Tipo { get; set; } = "";
        public bool Pos { get; set; } = false;
        public string Pais { get; set; } = "";
        public string Codcurso { get; set; } = "";
        public string Curso { get; set; } = "";
        public string Gradestamp { get; set; } = "";
        public string Descgrelha { get; set; } = "";
        public string Anoingresso { get; set; } = "";
        public bool Bolseiro { get; set; } = false;
        public string Coddep { get; set; } = "";
        public string Departamento { get; set; } = "";
        public string Codfac { get; set; } = "";
        public string Faculdade { get; set; } = "";
        //Dados do cliente fornecedor 
        public string Nofnc { get; set; } = "";
        public string Fnc { get; set; } = "";

        public string Datanasc { get; set; } = "";
        public string Sexo { get; set; } = "";
        public string Areafiscal { get; set; } = "";//Direcao da area fiscal caso mozlec 
        public bool Aluno { get; set; } = false;
        public string Estadocivil { get; set; } = "";
        public string Religiao { get; set; } = "";
        public string Nivelac { get; set; } = "";
        public string Codaluno { get; set; } = "";
        public string Codesc { get; set; } = "";
        public string Escola { get; set; } = "";
        public bool Planosaude { get; set; } = false;
        public string Medico { get; set; } = "";
        public string Hospital { get; set; } = "";
        public string Instplanosaude { get; set; } = "";
        public string Transp { get; set; } = "";
        public bool Sozinho { get; set; } = false;
        public bool Acompanhado { get; set; } = false;
        public decimal Codccu { get; set; } = 0;
        public string Ccusto { get; set; } = "";
        public string Ccustostamp { get; set; } = "";
        public bool DeficilCobrar { get; set; } = false;
        public decimal Plafond { get; set; } = 0;
        public decimal Vencimento { get; set; } = 0;
        public bool Generico { get; set; } = false;
        public bool Desconto { get; set; } = false;
        public decimal Percdesconto { get; set; } = 0;
        public decimal CodCondPagamento { get; set; } = 0;//Codigo de condicoes de Pagamento 
        public string DescCondPagamento { get; set; } = "";//Descricao de condicoes de Pagamento 
        public bool Insencao { get; set; } = false;
        public string MotivoInsencao { get; set; } = "";
        public string Cobrador { get; set; } = "";
        public bool Clivainc { get; set; } = false;
        //Tesoraria por defeito
        public decimal Codtz { get; set; } = 0;
        public string Tesouraria { get; set; } = "";
        public string Localentregas { get; set; } = "";
        //Conta do cliente no Plano de contas ...
        public string ContaPgc { get; set; } = "";
        //Grupo de cliente no PGC ex: 441...
        public string GrupoclPgc { get; set; } = "";
        //Descricao do Cl no PGC ex: Cliente conta corrente...
        public string DescGrupoclPgc { get; set; } = "";
        public string Site { get; set; } = "";
        public bool Variasmoradas { get; set; } = false;
        public string Tipocl { get; set; } = "";//Classificador de clientes quanto ao desconto
        public bool Precoespecial { get; set; } = false; //Define 
        public bool Ctrlplanfond { get; set; } = false;//Controla Plafond de crédito
        public string Contastamp { get; set; } = "";
        public bool Mesavirtual { get; set; } = false;//Mesa resultante de Juncao de mesas 
        public bool Possuifilial { get; set; } = false;//Indica que tem uma filial 

        public string Contasstamp { get; set; } = "";

    }
    public class ProgressValue
    {
        public decimal Value { get; set; }
    }
    public class Selects
    {
        public string? Chave { get; set; } = "";
        public string? Descricao { get; set; } = "";
        public string? Ordem { get; set; } = "";
    }

    public class Dmzviewgrelha
    {
        public List<Dmzview?> Dmzview { get; set; } = new();
    }

    public class Dmzview
    {
        public string Col1 { get; set; } = "";
        public string Col2 { get; set; } = "";
        public string Col3 { get; set; } = "";
        public string Col4 { get; set; } = "";
        public string Col5 { get; set; } = "";
        public string Col6 { get; set; } = "";
        public string Col7 { get; set; } = "";
        public string Col8 { get; set; } = "";
        public string Col9 { get; set; } = "";
        public string Col10 { get; set; } = "";
        public string Col11 { get; set; } = "";
        public string Col12 { get; set; } = "";
        public string Col13 { get; set; } = "";

        public string Col14 { get; set; } = "";
        public string Col15 { get; set; } = "";

        public string Col16 { get; set; } = "";

        public string Col17 { get; set; } = "";

        public string Col18 { get; set; } = "";

        public string Col19 { get; set; } = "";
        public string Col20 { get; set; } = "";
        public string Col21 { get; set; } = "";
        public string Col22 { get; set; } = "";
        public string Col23 { get; set; } = "";
        public string Col24 { get; set; } = "";
        public string Col25 { get; set; } = "";
        public string Col26 { get; set; } = "";
        public string Col27 { get; set; } = "";
        public string Col28 { get; set; } = "";
        public string Col29 { get; set; } = "";
        public string Col30 { get; set; } = "";
        public string Col31 { get; set; } = "";
        public string Col32 { get; set; } = "";
        public string Col33 { get; set; } = "";
        public string Col34 { get; set; } = "";
        public string Col35 { get; set; } = "";
        public string Col36 { get; set; } = "";
        public string Col37 { get; set; } = "";
        public string Col38 { get; set; } = "";
        public string Col39 { get; set; } = "";
        public string Col40 { get; set; } = "";
        public string Col41 { get; set; } = "";
        public string Col42 { get; set; } = "";
        public string Col43 { get; set; } = "";
        public string Col44 { get; set; } = "";
        public string Col45 { get; set; } = "";
        public string Col46 { get; set; } = "";
        public string Col47 { get; set; } = "";
        public string Col48 { get; set; } = "";
        public string Col49 { get; set; } = "";
        public string Col50 { get; set; } = "";
        public string Col51 { get; set; } = "";
        public string? Chave { get; set; } = "";
        public string? Descricao { get; set; } = "";
        public string? Ordem { get; set; } = "";

        public string? query { get; set; } = "";

        public string? tabela { get; set; } = "";
    }

    public class Camposeliminar
    {
        public string? Id { get; set; } = "";
        public string? Tabela { get; set; } = "";
        public string? Nomecampochave { get; set; } = "";
    }
    

public class Condicoesprocura
    {
        public string? Tabela { get; set; } = "";
        public string? Campo1 { get; set; } = "";
        public string? Campo2 { get; set; } = "";
        public string? Condicao { get; set; } = "";
        public string?  Campochave { get; set; } = "";
    }


    public static class Acesso
    {
        public static string Login { get; set; } = string.Empty;
        public static string? Nome { get; set; } = string.Empty;
        public static DateTime Data { get; set; }
        public static string ParteInicial { get; set; } = string.Empty;
        public static bool UserAdmin { get; set; }
        public static bool PriEntrada { get; set; }
        public static bool ActivoMil { get; set; }
        public static string Perfil { get; set; } = string.Empty;
        public static bool RtiConta { get; set; }
        public static bool RtiCadastro { get; set; } = false;
        public static bool RtiProgramas { get; set; } = false;
        public static bool RtiTabela { get; set; } = false;
        public static bool RtiRelatorios { get; set; } = false;
        public static bool RtiAdministrador { get; set; } = false;
        public static bool AfectoNoArnazem { get; set; } = false;
        public static bool EdoPessoal { get; set; } = false;
        public static bool EdasFinancas { get; set; } = false;
        public static bool EdaSic { get; set; } = false;
        public static string MilStamp { get; set; } = string.Empty;

        public static DataTable PermissaoMainForm { get; set; }
        public static DataTable Teste { get; set; }
        public static string Test { get; set; }
        public static string Testinho { get; set; }
        public static string? Orgao { get; set; } = string.Empty;
        public static string Departamento { get; set; } = string.Empty;
        public static string Direccao { get; set; } = string.Empty;
        public static string? OrgaoEntradaProcura { get; set; } = string.Empty;
        public static string? OrgaoStamprr { get; set; } = string.Empty;
        public static string? DirecaoEntradaProcura { get; set; } = string.Empty;
        public static string Nomecampo { get; set; } = string.Empty;
        public static string ValorCampo { get; set; } = string.Empty;
        public static string OrgaoProcessoProcura { get; set; } = string.Empty;
        public static string DepartamentoProcessoProcura { get; set; } = string.Empty;
        public static string DirecaoProcessoProcura { get; set; } = string.Empty;
        public static string UnidadeStamprr { get; set; } = string.Empty;
        public static string? DepartamentoEntradaProcura { get; set; } = string.Empty;
        public static string SubUnidadeStamprr { get; set; } = string.Empty;






        public static string OrgaofuncaoDest { get; set; } = string.Empty;
        public static string? OrgaoStampDest { get; set; } = string.Empty;
        public static string OrgaoStamprrDest { get; set; } = string.Empty;
        public static string UnidadefuncaoDest { get; set; } = string.Empty;
        public static string? DirecaoDestinoProcura { get; set; } = string.Empty;
        public static string UnidadeStamprrDest { get; set; } = string.Empty;
        public static string SubUnidadefuncaoDest { get; set; } = string.Empty;
        public static string? DepartamentoSaidaProcura { get; set; } = string.Empty;
        public static string SubUnidadeStamprrDest { get; set; } = string.Empty;






        public static DataTable Testinho2 { get; set; }
        public static DataTable DttMilSalMess { get; set; }
        public static bool RtiVencimento { get; set; } = false;
        public static bool RtLogistica { get; set; } = false;
        public static bool VerSitClass { get; set; }
        public static string? SicDoUtilizador { get; set; }
        public static string Path { get; set; }
        public static string Path2 { get; set; } = string.Empty;

    }
    public class ReportParam
    {
        public string? Filename { get; set; } = "vazio";
        public string? Origem { get; set; } = "vazio";
        public string? Xmlstring { get; set; } = "vazio";
    }
    public class Procura
    {
        public string? Tabela { get; set; } = "";
        public string? Campo { get; set; } = "";
        public string? Campo1 { get; set; } = "";
        public string? Camposseleccionados { get; set; } = "";
        public string? Valorprocurado { get; set; } = "";
        public int CurrentNumber { get; set; } = 0;
        public int Pagesize { get; set; } = 0;
        public bool Marcar { get; set; } = false;
        public string Condicoes { get; set; } = "";
        public string Alunoestamp { get; set; } = "";
        public string Rhstamp { get; set; } = "";
        public string Descricao { get; set; } = "";
        public string Origem { get; set; } = "";
        public string Referencia { get; set; } = "";
        public Usuario Usuario  { get; set; } = new();
    }

    public class Mdnviewgrelha
    {
        public List<Mdnview?> Mdnview { get; set; } = new();
    }

    public class Mdnview
    {
        public string Col1 { get; set; } = "";
        public string Col2 { get; set; } = "";
        public string Col3 { get; set; } = "";
        public string Col4 { get; set; } = "";
        public string Col5 { get; set; } = "";
        public string Col6 { get; set; } = "";
        public string Col7 { get; set; } = "";
        public string Col8 { get; set; } = "";
        public string Col9 { get; set; } = "";
        public string Col10 { get; set; } = "";
        public string Col11 { get; set; } = "";
        public string Col12 { get; set; } = "";
        public string Col13 { get; set; } = "";

        public string Col14 { get; set; } = "";
        public string Col15 { get; set; } = "";

        public string Col16 { get; set; } = "";

        public string Col17 { get; set; } = "";

        public string Col18 { get; set; } = "";

        public string Col19 { get; set; } = "";
        public string Col20 { get; set; } = "";
        public string Col21 { get; set; } = "";
        public string Col22 { get; set; } = "";
        public string Col23 { get; set; } = "";
        public string Col24 { get; set; } = "";
        public string Col25 { get; set; } = "";
        public string Col26 { get; set; } = "";
        public string Col27 { get; set; } = "";
        public string Col28 { get; set; } = "";
        public string Col29 { get; set; } = "";
        public string Col30 { get; set; } = "";
        public string Col31 { get; set; } = "";
        public string Col32 { get; set; } = "";
        public string Col33 { get; set; } = "";
        public string Col34 { get; set; } = "";
        public string Col35 { get; set; } = "";
        public string Col36 { get; set; } = "";
        public string Col37 { get; set; } = "";
        public string Col38 { get; set; } = "";
        public string Col39 { get; set; } = "";
        public string Col40 { get; set; } = "";
        public string Col41 { get; set; } = "";
        public string Col42 { get; set; } = "";
        public string Col43 { get; set; } = "";
        public string Col44 { get; set; } = "";
        public string Col45 { get; set; } = "";
        public string Col46 { get; set; } = "";
        public string Col47 { get; set; } = "";
        public string Col48 { get; set; } = "";
        public string Col49 { get; set; } = "";
        public string Col50 { get; set; } = "";
        public string Col51 { get; set; } = "";
        public string? Chave { get; set; } = "";
        public string? Descricao { get; set; } = "";
        public string? Ordem { get; set; } = "";

        public string? query { get; set; } = "";

        public string? tabela { get; set; } = "";
    }
    public class Filepdf
    {
        public string? Filename { get; set; } = "vazio";
    }
    public class Selectview
    {
        public List<Selects?> Selects { get; set; } = new();
    }


    public class PaginationResponseBl<T> where T : class
    {
        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPageNumber { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public T Data { get; set; }

        public bool Status { get; set; }

        public string Msg { get; set; }
        public string Professorstamp { get; set; } = "";
        public string Alunoestamp { get; set; } = "";
        public string Rhstamp { get; set; } = "";

        public PaginationResponseBl(int totalCount, T data, int currentPageNumber, int pageSize)
        {
            TotalCount = totalCount;
            Data = data;
            CurrentPageNumber = currentPageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            HasPreviousPage = CurrentPageNumber > 1;
            HasNextPage = CurrentPageNumber < TotalPages;
        }
    }

    public class PaginationResponse<T> where T : class
    {
        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public int CurrentPageNumber { get; set; }

        public int TotalPages { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public T Data { get; set; }

        public PaginationResponse(int totalCount, T data, int currentPageNumber, int pageSize)
        {
            this.TotalCount = totalCount;
            this.Data = data;
            this.CurrentPageNumber = currentPageNumber;
            this.PageSize = pageSize;
            this.TotalPages = (int)Math.Ceiling((double)this.TotalCount / (double)this.PageSize);
            this.HasPreviousPage = this.CurrentPageNumber > 1;
            this.HasNextPage = this.CurrentPageNumber < this.TotalPages;
        }
    }

}
