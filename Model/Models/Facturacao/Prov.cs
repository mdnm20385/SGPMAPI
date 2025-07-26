using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Prov
    {
        [Key]
        public string Provstamp { get; set; }
        [Required]
        public decimal Codprov { get; set; }
        [Required]
        public string Descricao { get; set; }

        public virtual ICollection<Dist> Dist { get; set; }

    }
}
