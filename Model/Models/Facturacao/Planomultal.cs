using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Planomultal
    {
        [Key]
        public string Planomultalstamp { get; set; }
        [ForeignKey("Planomulta")]
        public string Planomultastamp { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Valor { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Perc { get; set; }
        public decimal Dias { get; set; }
        public string Multadesc { get; set; }
        public bool Usaperc { get; set; }
        public decimal Ordem { get; set; }
        public virtual Planomulta Planomulta { get; set; }
    }
}