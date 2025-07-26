using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Factanexo
    {
        [Key]
        public string Factanexostamp { get; set; }
        [ForeignKey("Fact")]
        public string Factstamp { get; set; }
        public string Descricao { get; set; }
        public byte[] Anexo { get; set; }
        public virtual Fact Fact { get; set; }
    }
}
