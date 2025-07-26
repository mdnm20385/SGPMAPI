using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pad
    {
        [Key]
        public string Padstamp { get; set; }
        public decimal Codpad { get; set; }
        public decimal Coddist { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Dist")]
        public string Diststamp { get; set; }

        public virtual Dist Dist { get; set; }
    }
}
