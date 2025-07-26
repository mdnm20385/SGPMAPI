using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("Localidade")]
    public partial class Localidade
    {
        [Key]
        // [Column(Order = 0)]
        [StringLength(50)]
        public string?  localidadeStamp { get; set; }

        [StringLength(50)]
        public string?  codLocalidade { get; set; }

        
        // [Column(Order = 1)]
        [StringLength(100)]
        public string?  descricao { get; set; }

        
        // [Column(Order = 2)]
        [StringLength(50)]
        public string?  codPostoAdm { get; set; }

        
        // [Column(Order = 3)]
        [StringLength(100)]
        public string?  inseriu { get; set; }

        
        // [Column(Order = 4)]
        [StringLength(100)]
        public string?  inseriuDataHora { get; set; }

        [StringLength(100)]
        public string?  alterou { get; set; }

        [StringLength(100)]
        public string?  alterouDataHora { get; set; }



        [ForeignKey("PostAdm")]
        // [Column(Order = 5)]
        [StringLength(50)]
        public string?  postAdmStamp { get; set; }
        // [Column(Order = 5)]
        public virtual PostAdm PostAdm { get; set; }
        
    }
}
