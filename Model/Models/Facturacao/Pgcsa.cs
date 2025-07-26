using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Pgcsa
    {
        [Key]
        public string Pgcsastamp { get; set; }
        [ForeignKey("Pgc")]
        public string Pgcstamp { get; set; }
        [Column(Order = 0)]
        public string Conta { get; set; }
        [Column(Order = 1)]
        public decimal Ano { get; set; }
        [Column(Order = 2)]
        public decimal Mes { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Deb { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Cre { get; set; }
        public virtual Pgc Pgc { get; set; }
    }
}
