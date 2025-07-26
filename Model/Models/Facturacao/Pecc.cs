using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Pecc
    {
        [Key]
        public string Peccstamp { get; set; }
        public string Origem { get; set; }
        public string Oristamp { get; set; }
        public decimal Nrdoc { get; set; }
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

        [DecimalPrecision(5, 2, true)]
        public decimal Cambiousd { get; set; }
        public decimal Codmov { get; set; }
        [ForeignKey("Prc")]
        public string Prcstamp { get; set; }
        [ForeignKey("Percl")]
        public string Perclstamp { get; set; }
        public string Ccusto { get; set; }
        public string Numinterno { get; set; }
        public decimal Estabno { get; set; }
        public string Estabnome { get; set; }
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public string Pestamp { get; set; }
        public virtual Prc Prc { get; set; }//Processamento de salarios 
        public virtual Percl Percl { get; set; }//Recibos de pessoal

    }
}
