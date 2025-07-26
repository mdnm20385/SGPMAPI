using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class RltCc
    {
        [Key]
        public string RltCcstamp { get; set; }
        public string Ccusto { get; set; }
        public string Codccu { get; set; }
        public bool Estado { get; set; }
        [ForeignKey("Rlt")]
        public string Rltstamp { get; set; }
        public virtual Rlt Rlt { get; set; }
    }
}
