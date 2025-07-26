using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Dianexo
    {
        [Key]
        public string Dianexostamp { get; set; }
        [ForeignKey("Di")]
        public string Distamp { get; set; }
        public string Descricao { get; set; }
        public byte[] Anexo { get; set; }
        public virtual Di Di { get; set; }
    }
}
