using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class PlanoFeria
    {
        [Key]
        public string PlanoFeriastamp { get; set; }
        [MaxLength(600)]
        public string Descricao { get; set; }
        public decimal Ano { get; set; }
        public DateTime Dataplano { get; set; }
        public decimal Codigo { get; set; }
        public string CCusto { get; set; }
        public string Ccustamp { get; set; }
        public bool Planogeral { get; set; }
        public virtual ICollection<PlanoFerial> PlanoFerial { get; set; }
    }
}
