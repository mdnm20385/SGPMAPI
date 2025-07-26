using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Grupo
    {
        [Key]
        public string Grupostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public virtual ICollection<SubGrupo> SubGrupo { get; set; }
    }
}
