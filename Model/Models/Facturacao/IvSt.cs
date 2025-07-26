using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class IvStimg
    {
        [Key]
        public string IvStimgstamp { get; set; }
        [ForeignKey("Ivl")]
        public string Ivlstamp { get; set; }
        public bool Tipodoc { get; set; }
        public string Licstamp { get; set; }
        public byte[] Anexo { get; set; }
        public string Documento { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public virtual IVL Ivl { get; set; }

    }
}
