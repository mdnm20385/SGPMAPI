using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Usrcontas
    {
        [Key]
        public string Usrcontasstamp { get; set; }
        [ForeignKey("Usrstamp")]
        public string Usrstamp { get; set; }
        public string Conta { get; set; }
        public string Contasstamp { get; set; }
        public decimal Codtz { get; set; }
        public bool Cx { get; set; }
        public string Descpos { get; set; }
        public virtual Usr Usr { get; set; }
    }
}
