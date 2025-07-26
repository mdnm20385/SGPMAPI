using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Familiacar
    {
        [Key]
        public string Familiacarstamp { get; set; }
        [ForeignKey("Familia")]
        public string Familiastamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual Familia Familia { get; set; }
        public virtual ICollection<Familiacarl> Familiacarl { get; set; }//Viaturas Associadas 
        public virtual ICollection<Familiacarsub> Familiacarsub { get; set; }//Viaturas Associadas 
    }
}