using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Dist
    {
        [Key]
        public string Diststamp { get; set; }
        [Required]
        public decimal Codprov { get; set; }
        [Required]
        public decimal CodDist { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        [ForeignKey("Prov")]
        public string Provstamp { get; set; }
        public virtual Prov Prov { get; set; }

        public virtual ICollection<Pad> Pad { get; set; }
    }
}
