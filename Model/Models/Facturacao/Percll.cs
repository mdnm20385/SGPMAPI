using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Percll
    {
        [Key]
        public string Percllstamp { get; set; }
        [ForeignKey("Percl")]
        public string Perclstamp { get; set; }
        public string Pccstamp { get; set; }
        public DateTime Data { get; set; }
        public string Nrdoc { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valorpreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valordoc { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valorreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal ValorPend { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal MvalorPend { get; set; }
        public bool Anulado { get; set; }
        public string Numinterno { get; set; }
        public string Origem { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mvalorpreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mvalorreg { get; set; }
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public virtual Percl Percl { get; set; }
    }
}
