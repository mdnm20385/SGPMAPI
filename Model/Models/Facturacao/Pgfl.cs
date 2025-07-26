using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Pgfl
    {
        [Key]
        public string Pgflstamp { get; set; }
        [ForeignKey("Pgf")]
        public string Pgfstamp { get; set; }
        public string Fccstamp { get; set; }
        public decimal Nrdoc { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valorpreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valorreg { get; set; }
        public bool Status { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Numinterno { get; set; }
        public string Origem { get; set; }

        [DecimalPrecision(16, 2,true)]
        public decimal Mvalorpreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mvalorreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal ValorPend { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal MvalorPend { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valordoc { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal MValordoc { get; set; }
        public bool Anulado { get; set; }
        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Descontofin { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal MDescontofin { get; set; }
        public decimal Perdescfin { get; set; }//Percentagem de desconto financeiro 
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public virtual Pgf Pgf { get; set; }
    }
}
