using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class PjAudit
    {
        [Key]
        public string Pjauditstamp { get; set; }
        [ForeignKey("Pj")]
        public string Pjstamp { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Comprado { get; set; }
        public decimal Vendido { get; set; }
        public decimal Interno { get; set; }
        public string Login { get; set; }
        public virtual Pj Pj { get; set; }
    }
}
