using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Familiacarsub
    {
        [Key]
        public string Familiacarsubstamp { get; set; }
        [ForeignKey("Familiacar")]
        public string Familiacarstamp { get; set; }
        public string Ststamp { get; set; }
        public string Codcarreira { get; set; }
        public string Desccarreira { get; set; }
        public virtual Familiacar Familiacar { get; set; }
    }
}
