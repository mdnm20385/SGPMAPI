using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public  class Rltusr
    {
        [Key]
        public string Rltusrstamp { get; set; }
        public string Login { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Rlt")]
        public string Rltstamp { get; set; }
        public bool Status { get; set; }
        public virtual Rlt Rlt { get; set; }
    }
}
