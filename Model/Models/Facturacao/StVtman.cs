using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class StVtman
    {
        [Key]
        public string StVtmanstamp { get; set; }
        public string Matricula { get; set; }
        public decimal Valparam { get; set; }
        public decimal Valkm { get; set; }
        public decimal Diferenca { get; set; }
        public bool Feito { get; set; }
        public string Distamp { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        public virtual St St { get; set; }
    }
}
