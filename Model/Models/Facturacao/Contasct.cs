using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Contasct
    {
        [Key]
        public string Contasctstamp { get; set; }
        [ForeignKey("Contas")]
        public string Contasstamp { get; set; }
        public string Conta { get; set; }
        public string Descgrupo { get; set; }
        public bool Contacc { get; set; }
        public bool MovIntegra { get; set; }
        public virtual Contas Contas { get; set; }
    }
}
