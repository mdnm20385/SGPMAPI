using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Familiacarl
    {
        [Key]
        public string Familiacarlstamp { get; set; }
        [ForeignKey("Familiacar")]
        public string Familiacarstamp { get; set; }
        public string Ststamp { get; set; }
        public string Descviatura { get; set; }
        public string Matricula { get; set; }
        public virtual Familiacar Familiacar { get; set; }
    }
}