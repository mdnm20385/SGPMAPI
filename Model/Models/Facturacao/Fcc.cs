using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Fcc
    {
        [Key]
        public string Fccstamp { get; set; }
        public string Origem { get; set; }
        public string Oristamp { get; set; }
        public string Nrdoc { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public DateTime Vencim { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Debito { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Debitom { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Debitof { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Debitofm { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Credito { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Creditom { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Creditof { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Creditofm { get; set; }

        public string Documento { get; set; }
        public string Moeda { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Saldo { get; set; }
        public decimal Codmov { get; set; }
        public string Reffornec { get; set; }
        [ForeignKey("Facc")]
        public string Faccstamp { get; set; }
        [ForeignKey("Pgf")]
        public string Pgfstamp { get; set; }
        public string Rdfstamp { get; set; }
        public string Ccusto { get; set; }
        public string  Pgflstamp { get; set; }
        public string Numinterno { get; set; }
        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public virtual Pgf Pgf { get; set; }
        public string Fncstamp { get; set; }
        public string Usrstamp { get; set; }
        public virtual Facc Facc { get; set; }
    }
}
