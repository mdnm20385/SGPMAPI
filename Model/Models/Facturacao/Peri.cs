using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Peri
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Peristamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool Concluido { get; set; }
        public virtual ICollection<Pericur> Pericur { get; set; }
    }
}
