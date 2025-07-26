using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("Pat")]
    public partial class Pat
    {
        [Key]
        // [Column(Order = 0)]
        [StringLength(50)]
        public string patStamp { get; set; }

       
        // [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codPatente { get; set; }

       
        // [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codPat { get; set; }

       
        // [Column(Order = 3)]
        [StringLength(50)]
        public string descricao { get; set; }

       
        // [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codRamo { get; set; }

       
        // [Column(Order = 5)]
        [StringLength(100)]
        public string ramo { get; set; }

       
        // [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codCategoria { get; set; }

       
        // [Column(Order = 7)]
        [StringLength(100)]
        public string categoria { get; set; }

       
        // [Column(Order = 8)]
        [StringLength(100)]
        public string classeMil { get; set; }

       
        // [Column(Order = 9)]
        [StringLength(100)]
        public string inseriu { get; set; }

       
        // [Column(Order = 10)]
        [StringLength(100)]
        public string inseriuDataHora { get; set; }

        [StringLength(100)]
        public string alterou { get; set; }

        [StringLength(100)]
        public string alterouDataHora { get; set; }
        // [Column(Order = 11)]
        [StringLength(50)]
        public string catStamp { get; set; }
    }
}
