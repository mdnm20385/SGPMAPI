using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class FncCt
    {
        [Key]
        public string FncCtstamp { get; set; }
        [ForeignKey("Fnc")]
        public string Fncstamp { get; set; }
        public string Conta { get; set; }
        public string Descgrupo { get; set; }
        public bool Contacc { get; set; }
        public bool MovIntegra { get; set; }
        public virtual Fnc Fnc { get; set; }
    }
}
