using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class PeSalbase
    {
        [Key]
        public string PeSalbasestamp { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public string Mes { get; set; }
        public string Mesesstamp { get; set; }
        public DateTime Datalanc { get; set; }//data de lancamento
        [DecimalPrecision(16, 2, true)]
        public decimal Nrhoras { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal SalHora { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal ValBasico { get; set; }
        public string Usrstamp { get; set; }
    }
}