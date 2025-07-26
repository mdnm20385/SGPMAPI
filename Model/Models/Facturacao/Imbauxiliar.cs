using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Imbauxiliar
    {
        [Key]
        public string Imbauxiliarstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public string Obs { get; set; }
        [Required]
        public bool Padrao { get; set; }
        public decimal Tabela { get; set; }
        public string Desctabela { get; set; }
        public virtual ICollection<Imbauxiliarl> Imbauxiliarl { get; set; }
    }
}
