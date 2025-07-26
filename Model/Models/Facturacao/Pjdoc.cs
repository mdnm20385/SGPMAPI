using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pjdoc
    {
        [Key] 
        public string Pjdocstamp { get; set; }
        [ForeignKey("Pj")]
        public string Pjstamp { get; set; }
        [MaxLength(600)]
        public string Descricao { get; set; }
        public byte[] Anexo { get; set; }
        public bool Doclc { get; set; }
        public virtual Pj Pj { get; set; }
    }
}
