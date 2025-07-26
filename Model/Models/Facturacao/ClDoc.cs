using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClDoc
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Cldocstamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string Documento { get; set; }
        public string Numero { get; set; }
        public string Localemis { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Validade { get; set; }
        public bool Bi { get; set; }
        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }
        public virtual Cl Cl { get; set; }
    }
}
