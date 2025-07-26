using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pjdepart
    {
        [Key] 
        public string Pjdepartstamp { get; set; }
        [ForeignKey("Pj")]
        public string Pjstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        [MaxLength(600)]
        public string Resp { get; set; }
        public virtual Pj Pj { get; set; }
    }
}
