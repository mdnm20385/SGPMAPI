using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Turmadiscp
    {
        [Key]
        public string Turmadiscpstamp { get; set; }
        [ForeignKey("Turmadisc")]
        public string Turmadiscstamp { get; set; }
        public string Pestamp { get; set; }
        public string Ststamp { get; set; }
        public string Nome { get; set; }
        public virtual Turmadisc Turmadisc { get; set; }
    }
}