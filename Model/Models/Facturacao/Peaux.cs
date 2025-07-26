using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Peaux
    {
        [Key]
        public string Peauxstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public decimal Tabela { get; set; }
        public string Desctabela { get; set; }
        [Required]
        public bool Padrao { get; set; }
        public string Obs { get; set; }

    }
}
