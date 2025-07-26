using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pect
    {
        [Key]
        public string Pectstamp { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public string Conta { get; set; }
        public string Descgrupo { get; set; }
        public bool Contacc { get; set; }
        public bool MovIntegra { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
