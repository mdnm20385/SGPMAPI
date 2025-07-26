using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class SubGrupo
    {
        [Key]
        public string SubGrupostamp { get; set; }
        [ForeignKey("Grupo")]
        public string Grupostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}