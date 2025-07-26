using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Rcll
    {
        [Key]
        public string Rcllstamp { get; set; }
        [ForeignKey("Rcl")]
        public string Rclstamp { get; set; }
        public string Ccstamp { get; set; }
        public DateTime Data { get; set; }
        public string Nrdoc { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valorpreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valordoc { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal MValordoc { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valorreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal ValorPend { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal MvalorPend { get; set; }
        public bool Anulado { get; set; }
        public string Numinterno { get; set; }
        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        public string Origem { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mvalorpreg { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mvalorreg { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Descontofin { get; set; }//Desconto Financeiro 
        [DecimalPrecision(16, 2, true)]
        public decimal MDescontofin { get; set; }//Moeda Desconto financeiro 
        [DecimalPrecision(5, 2, true)]
        public decimal Perdescfin { get; set; }//Percentagem de desconto financeiro 
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public virtual RCL RCL { get; set; }
    }
}
