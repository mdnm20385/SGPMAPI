using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class StRefFncCod
    {
        [Key]
        public string StRefFncCodstamp { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        //public string Refornec { get; set; }
        public byte[] SerieCodBarras { get; set; }
        public string Codigobarras { get; set; }
        public bool Estado { get; set; }
        public virtual St St { get; set; }
    }
}
