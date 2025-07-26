using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Faccanexo
    {
        [Key]
        public string Faccanexostamp { get; set; }
        [ForeignKey("Facc")]
        public string Faccstamp { get; set; }
        public string Descricao { get; set; }
        public byte[] Anexo { get; set; }
        public virtual Facc Facc { get; set; }
    }
}
