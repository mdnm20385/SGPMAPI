using Model.Models.SGPM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("PostAdm")]
    public partial class PostAdm
    {
        [Key]
        // [Column(Order = 0)]
        [StringLength(50)]
        public string postAdmStamp { get; set; }

        [StringLength(50)]
        public string codPostoAdm { get; set; }

        
        // [Column(Order = 1)]
        [StringLength(100)]
        public string descricao { get; set; }

        
        // [Column(Order = 2)]
        [StringLength(50)]
        public string codDistrito { get; set; }

        
        // [Column(Order = 3)]
        [StringLength(100)]
        public string inseriu { get; set; }

        
        // [Column(Order = 4)]
        [StringLength(100)]
        public string inseriuDataHora { get; set; }

        [StringLength(100)]
        public string alterou { get; set; }

        [StringLength(100)]
        public string alterouDataHora { get; set; }


        [ForeignKey("Distrito")]
        // [Column(Order = 5)]
        [StringLength(50)]
        public string distritoStamp { get; set; }
        public virtual Distrito Distrito { get; set; }

        public virtual ICollection<Localidade> Localidade { get; set; }


    }
}
