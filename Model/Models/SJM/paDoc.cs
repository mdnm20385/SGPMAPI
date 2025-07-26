using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("paDoc")]
    public partial class paDoc
    {
        [Key]
        [StringLength(100)]
        public string paDocStamp { get; set; }

        public int codpaDoc { get; set; }

        [Required]
        [StringLength(100)]
        public string tipoDocumento { get; set; }

        [Required]
        [StringLength(100)]
        public string numeroDoc { get; set; }

        [Required]
        [StringLength(100)]
        public string localemissao { get; set; }

        [StringLength(100)]
        public string dataemissao { get; set; }

        [StringLength(100)]
        public string datavalid { get; set; }

        [Required]
        [StringLength(100)]
        public string inseriu { get; set; }

        [Required]
        [StringLength(20)]
        public string inseriuDataHora { get; set; }

        [Required]
        [StringLength(100)]
        public string alterou { get; set; }

        [Required]
        [StringLength(100)]
        public string alterouDataHora { get; set; }

        [Required]
        [StringLength(100)]
        public string paStamp { get; set; }
        
    }
}
