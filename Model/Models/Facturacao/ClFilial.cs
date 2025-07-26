using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClFilial
    {
        [Key]
        public string ClFilialstamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string Oristamp { get; set; }
        public string Descricao { get; set; }
        public virtual Cl Cl { get; set; }
    }
}
