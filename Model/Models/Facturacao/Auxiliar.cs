using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Auxiliar
    {
        [Key]
        public string Auxiliarstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public string Obs { get; set; }
        [Required]
        public bool Padrao { get; set; }
        public decimal Tabela { get; set; }
        public string Desctabela { get; set; }
        public string Tel { get; set; }
        public virtual ICollection<Auxiliar2> Auxiliar2 { get; set; }
    }
}
