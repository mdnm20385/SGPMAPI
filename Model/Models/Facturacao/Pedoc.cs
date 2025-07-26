using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pedoc
    {
        [Key]
        public string Pedocstamp { get; set; }
        public string Documento { get; set; }
        public string Numero { get; set; }
        public string Local { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Validade { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public byte[] Anexo { get; set; }
        public bool Bi { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
