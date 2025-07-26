using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public  class Apivliq
    {
        [Key]
        public string Apivliqlstamp { get; set; }
        public string Conta { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Apparam")]
        public string Apparamstamp { get; set; }
        public virtual Apparam Apparam { get; set; }
    }
}
