using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("PermForm")]
    public partial class PermForm
    {
        [Key]
        public int permFormStamp { get; set; }

        [Required]
        public string descricaoNodo { get; set; }

        [Required]
        public string descricaoNodoFilho { get; set; }

        [Required]
        public string descricaoNodoFilhoFILho { get; set; }

        [Required]
        [StringLength(100)]
        public string inseriu { get; set; }

        [Required]
        [StringLength(30)]
        public string inseriuDataHora { get; set; }

        [Required]
        [StringLength(100)]
        public string alterou { get; set; }

        [Required]
        [StringLength(30)]
        public string alterouDataHora { get; set; }

        [Required]
        [StringLength(100)]
        
        public string paStamp { get; set; }
        
    }
}
