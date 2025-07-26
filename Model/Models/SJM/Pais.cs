using System.ComponentModel.DataAnnotations;

namespace Model.Models.SJM
{
    public class Pais
    {
        [Key]
        [StringLength(50)]
        public string?  paisStamp { get; set; }

        public int codPais { get; set; }

        [Required]
        [StringLength(100)]
        public string?  descricao { get; set; }

        [StringLength(10)]
        public string?  abreviatura { get; set; }

        [Required]
        [StringLength(100)]
        public string?  nacional { get; set; }

        public bool pordefeito { get; set; }

        [Required]
        [StringLength(100)]
        public string?  inseriu { get; set; }

        [Required]
        [StringLength(100)]
        public string?  inseriuDataHora { get; set; }

        [Required]
        [StringLength(100)]
        public string?  alterou { get; set; }

        [Required]
        [StringLength(100)]
        public string?  alterouDataHora { get; set; }
    }
}
