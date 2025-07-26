using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Ctauxiliarl
    {
        [Key]
        public string Ctauxiliarlstamp { get; set; }
        [ForeignKey("Ctauxiliar")]
        public string Ctauxiliarstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual Ctauxiliar Ctauxiliar { get; set; }
    }
}
