using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class StCt
    {
         [Key]
        public string StCtstamp { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        public string Conta { get; set; }
        public string Descgrupo { get; set; }
        public bool Contacc { get; set; }
        public bool MovIntegra { get; set; }
        public virtual St St { get; set; }
    }

}
