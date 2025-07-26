using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Ls
    {
        [Key]
        [MaxLength(80)]
        public string Lsstamp { get; set; }
        [Required]
        public string Descricao { get; set; }
    }
}
