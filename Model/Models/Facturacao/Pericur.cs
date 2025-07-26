using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pericur
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Pericurstamp { get; set; }
        [ForeignKey("Peri")]
        public string Peristamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Nivel { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string Descperiodo { get; set; }
        public string Anolect { get; set; }
        public virtual Peri Peri { get; set; }
        public virtual ICollection<Pericursem> Pericursem { get; set; }
    }
}
