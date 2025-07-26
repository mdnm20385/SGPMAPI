using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Procurm
    {
        [Key]
        public string Procurmstamp { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string GaranProv { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string NumLote { get; set; }
        public string Clstamp { get; set; }
        public decimal Codigo { get; set; }
        public DateTime Datini { get; set; }
        public DateTime Datfim { get; set; }
        public decimal Dias { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }

        //  public DateTime Fechadodata { get; set; }
        //  public DateTime HoraFechado { get; set; }
        public DateTime Horaabert { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Descricao { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Classe { get; set; }
        public bool Estado { get; set; }
        public DateTime Datfecho { get; set; }
        public decimal Tcusto { get; set; }
        public decimal TRecebido { get; set; }
        public decimal TPago { get; set; }
        public decimal Orc { get; set; }
        public decimal Adenda { get; set; }
        public decimal Adendaper { get; set; }
        public decimal Totorc { get; set; }
        public decimal TotComp { get; set; }
        public decimal Totft { get; set; }
        public decimal TotGI { get; set; }
        public decimal Totftper { get; set; }
        public decimal Totrec { get; set; }
        public decimal Totrecper { get; set; }
        public decimal Totprec { get; set; }
        public decimal Totprecper { get; set; }
        public decimal Totpft { get; set; }
        public decimal Totpftper { get; set; }
        public decimal Lucro { get; set; }
        public decimal Lucroper { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string LclProp { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Ugea { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Regime { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Modalidade { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Criter { get; set; }

        public string Ccusto { get; set; }
        public string Codccu { get; set; }
        public string Ccudesc { get; set; }
        public string Status { get; set; }
        //campos adicionados
        public decimal Totpessoal { get; set; }
        public decimal Totvt { get; set; }
        public decimal TotProc { get; set; }
        public decimal Totcusto { get; set; }

        //Endereco da obra ......
        public decimal Codprov { get; set; }
        public string Prov { get; set; }
        public decimal Coddist { get; set; }
        public string Dist { get; set; }
        public string Endereco { get; set; }
        //End.....
        public virtual ICollection<Procurml> Procurml { get; set; }

    }
}
