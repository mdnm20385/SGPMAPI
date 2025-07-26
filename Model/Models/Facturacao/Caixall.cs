using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Caixall
    {
        [Key]
        public string Caixallstamp { get; set; }
        [ForeignKey("Caixal")]
        public string Caixalstamp { get; set; }
        public string Caixastamp { get; set; }
        public DateTime Data { get; set; }
        public decimal Codtz { get; set; }
        public string Contatesoura { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Entrada { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Saida { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Saldo { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Lancado { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotalDefice { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Campo1 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Campo2 { get; set; }
        public string Campo3 { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
        public bool Fechado { get; set; }
        public bool Supervisor { get; set; }
        public string Usrstamp { get; set; }
        public string Contasstamp { get; set; }
        public virtual Caixal Caixal { get; set; }
    }
}
