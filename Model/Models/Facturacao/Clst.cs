using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Clst
    {
        [Key]
        public string Clststamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string Referenc { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Preco { get; set; }
        [DecimalPrecision(6, 1, true)]
        public decimal Quant { get; set; }
        public string Ststamp { get; set; }
        public virtual Cl Cl { get; set; }
    }
}
