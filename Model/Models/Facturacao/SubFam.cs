using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class SubFam
    {
        [Key]
        public string Subfamstamp { get; set; }
        [ForeignKey("Familia")]
        public string Familiastamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public bool Pos { get; set; }
        public string Descpos { get; set; }
        public decimal Sequenc { get; set; }
        public virtual Familia Familia { get; set; }
    }
}
