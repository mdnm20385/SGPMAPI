using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    public class Distrito
    {
        [Key]
        [StringLength(50)]
        public string distritoStamp { get; set; }

        [StringLength(50)]
        public string codDistrito { get; set; }

        [Required]
        [StringLength(100)]
        public string descricao { get; set; }

        [Required]
        [StringLength(50)]
        public string codProv { get; set; }

        [Required]
        [StringLength(100)]
        public string inseriu { get; set; }

        [Required]
        [StringLength(100)]
        public string inseriuDataHora { get; set; }

        [StringLength(100)]
        public string alterou { get; set; }

        [StringLength(100)]
        public string alterouDataHora { get; set; }

        [Required]
        [StringLength(50)]
        public string provinciaStamp { get; set; }
        
    }
}
