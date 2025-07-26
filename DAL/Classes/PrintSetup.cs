using System.Data;

namespace DAL.Classes
{

    public class PrintSetup
    {
        public bool Inserindo { get; set; }
        public string? OrigemlabelText { get; set; } = "";
        public string? CLocalStamp { get; set; }
        public string? No { get; set; } = "";
        public string? Nomfile { get; set; } = "";
        public string? Origem { get; set; } = "";
       // public Form MdiForm { get; set; }
        public string? XmlString { get; set; }
        public DataTable DtPrint { get; set; }
        public DataTable Formasp { get; set; }
      //  public DS Ds { get; internal set; }
        public bool UseFormasp { get; set; }
        public string? Filtro { get; set; } = "";
        public string? CTituloRelatorio { get; set; } = "";
        public string? Impressora { get; set; } = "";
        public decimal NrCopias { get; set; } = 1;
        public List<string> ListaTipodoc { get; set; }
        public string? LinguaNacional { get; set; } = "PT";
        public string? Intervalo { get; set; } = "";
        public string? NomeProduto { get; set; } = "";
        public string? EntidadePrint { get; set; } = "";
       // public List<ReportParameter> ListaParam { get; set; }
        public string? DataSource2 { get; set; }
        public string? DataSource3 { get; set; }
        public string? DataSource4 { get; set; }
        public string? DataSource5 { get; set; }
        public string? DatasetName { get; set; } = "DataSet1";
        public string?  Horario { get; set; }
        public string?  Turmadisc { get; set; }
        public string? ReportPath { get; set; } = "";
        public bool POS { get; internal set; } = false;
        public DataTable DMZ2 { get; set; }
        public string? XmlStringA5 { get; set; } = "";
        public string? NomfileA5 { get; set; } = "";
        public string? XmlStringA4 { get; set; } = "";
        public string? NomfileA4 { get; set; } = "";
    }
}
