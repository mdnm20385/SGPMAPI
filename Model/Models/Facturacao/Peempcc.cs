using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Peempcc
    {
        [Key]
        public string Peempccstamp { get; set; }
        public decimal Codigo { get; set; }
        public decimal Valor { get; set; }
        public decimal Ano { get; set; }
        public decimal Nummes { get; set; }
        public string Mes { get; set; }
        public decimal Nrdoc { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public DateTime Vencim { get; set; }
        public decimal Debito { get; set; }
        public decimal Debitom { get; set; }
        public decimal Debitof { get; set; }
        public decimal Debitofm { get; set; }
        public decimal Credito { get; set; }
        public decimal Creditom { get; set; }
        public decimal Creditof { get; set; }
        public decimal Creditofm { get; set; }
        [ForeignKey("Peempl")]
        public string Peemplstamp { get; set; }
        public string Prcstamp { get; set; }
        public string Origem { get; set; }
        public string Oristamp { get; set; }
        public string Documento { get; set; }
        public string Moeda { get; set; }
        public string Ccusto { get; set; }
        public decimal Codmov { get; set; }
        public string Empdevstamp { get; set; }
        public string Prcempstamp { get; set; }
        public virtual Peempl Peempl { get; set; }
    }
}
