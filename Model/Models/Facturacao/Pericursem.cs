using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pericursem
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Pericursemstamp { get; set; }
        [ForeignKey("Pericur")]
        public string Pericurstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        [MaxLength(400)]
        public string Obs { get; set; }
        public virtual Pericur Pericur { get; set; }
        public virtual ICollection<Pericursemtur> Pericursemtur { get; set; }
    }
}
