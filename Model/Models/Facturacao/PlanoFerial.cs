using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class PlanoFerial
    {
        [Key]
        public string PlanoFerialstamp { get; set; }
        [ForeignKey("PlanoFeria")]
        public string PlanoFeriastamp { get; set; }
        public string Pestamp { get; set; }
        public string Nome { get; set; }
        [DecimalPrecision(10, 2, true)]
        public decimal Saldoferia { get; set; }
        public DateTime Datain { get; set; }
        public DateTime Datater { get; set; }
        [DecimalPrecision(10, 2, true)]
        public decimal Diasnaouteis { get; set; }
        [DecimalPrecision(10, 2, true)]
        public decimal Diasuteis { get; set; }
        [DecimalPrecision(10, 2, true)]
        public decimal Totaldias { get; set; }
        public decimal Anoref { get; set; }
        public decimal Diaslei { get; set; }
        public virtual PlanoFeria PlanoFeria { get; set; }
    }
}
