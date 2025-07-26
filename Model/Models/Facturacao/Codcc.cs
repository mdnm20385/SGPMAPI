using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Codcc
    {
        [Key]
        public string Codccstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
