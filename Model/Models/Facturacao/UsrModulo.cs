using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class UsrModulo
    {
        [Key]
        public string Usrmodulostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        [ForeignKey("Usrstamp")]
        public string Usrstamp { get; set; }         
        public bool Activo { get; set; }
        public virtual Usr Usr { get; set; }
        public virtual ICollection<Usracessos> Usracessgrupo { get; set; }
    }
}
