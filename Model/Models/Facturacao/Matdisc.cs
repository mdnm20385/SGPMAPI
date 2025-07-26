using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Matdisc
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Matdiscstamp { get; set; }
        [ForeignKey("Mat")]
        public string Matstamp { get; set; }

        public string Coddisc { get; set; }
        public string Disc { get; set; }
        public virtual Mat Mat { get; set; }

    }
}
