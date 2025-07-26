using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Ditec
    {
        [Key]
        public string Ditecstamp { get; set; }
        [ForeignKey("Di")]
        public string Distamp { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        [MaxLength(300)]
        public string Funcao { get; set; }
        public bool Chefe { get; set; }
        public virtual Di Di  { get; set; }
    }
}
