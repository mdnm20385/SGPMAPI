using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Pehextra
    {
        [Key]
        public string Pehextrastamp { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Horas { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Valor { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal ValorProc { get; set; }//Valor Processado 
        public decimal Tipo { get; set; }
        public bool Processado { get; set; }
        public bool ExcluiProc { get; set; }
        public DateTime DataProc { get; set; }
        public decimal NumPeriodoProcessado { get; set; }
        public decimal AnoProcessado { get; set; }
        public decimal NumProc { get; set; }
        [MaxLength(300)]
        public string Obs { get; set; }
        public string Processtamp { get; set; }
        public string Prcstamp { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
