using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Alauxiliarl
    {
        [Key]
        public string Alauxiliarlstamp { get; set; }
        [ForeignKey("Alauxiliar")]
        public string Alauxiliarstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual Alauxiliar Alauxiliar { get; set; }
    }
}
