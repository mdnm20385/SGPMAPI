using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class TdiCcu
    {
        [Key]
        public string TdiCcustamp { get; set; }
        public bool? Padrao { get; set; } = false;
        public string Ccusto { get; set; }
        public string Ccustamp { get; set; }
        [ForeignKey("Tdi")]
        public string Tdistamp { get; set; } 
        public string CodCcu { get; set; }
        public virtual Tdi Tdi { get; set; }
    }
}
