using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Codtz
    {
        [Key]
        public string Codtzstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
