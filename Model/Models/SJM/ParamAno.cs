using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("ParamAno")]
    public partial class ParamAno
    {
        [Key]
        [StringLength(50)]
        public string ParamAnoStamp { get; set; }

        public DateTime Ano { get; set; }

        [Required]
        [StringLength(100)]
        public string Inseriu { get; set; }

        [Required]
        [StringLength(100)]
        public string InseriuDataHora { get; set; }

        [StringLength(100)]
        public string Alterou { get; set; }

        [StringLength(100)]
        public string AlterouDataHora { get; set; }
    }
}
