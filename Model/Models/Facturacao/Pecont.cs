using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pecont
    {
        [Key]
        public string Pecontstamp { get; set; }
        public string Contacto { get; set; }
        public bool Email { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public bool Padrao { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
