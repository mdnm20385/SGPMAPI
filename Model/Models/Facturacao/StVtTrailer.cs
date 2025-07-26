using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class StVtTrailer
    {
        [Key]
        public string StVtTrailerstamp { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        public string Matricula { get; set; }
        public string Obs { get; set; }
        public virtual St St { get; set; }
    }
}
