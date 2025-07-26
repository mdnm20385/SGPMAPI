using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Codstk
    {
        [Key]
        public string Codstkstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
