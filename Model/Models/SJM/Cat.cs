using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    public class Cat
    {
        [Key]
        public string CatStamp { get; set; }

       
       // [Column(Order = 1)]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codCategoria { get; set; }

        [StringLength(20)]
        public string codCat { get; set; }

       
       // [Column(Order = 2)]
        [StringLength(50)]
        public string descricao { get; set; }

       
       // [Column(Order = 3)]
       // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codRamo { get; set; }

       
       // [Column(Order = 4)]
        [StringLength(100)]
        public string ramo { get; set; }

       
       // [Column(Order = 5)]
        [StringLength(100)]
        public string classeMil { get; set; }

       
       // [Column(Order = 6)]
        [StringLength(100)]
        public string inseriu { get; set; }

       
       // [Column(Order = 7)]
        [StringLength(100)]
        public string inseriuDataHora { get; set; }

        [StringLength(100)]
        public string alterou { get; set; }

        [StringLength(100)]
        public string alterouDataHora { get; set; }
    }
}
