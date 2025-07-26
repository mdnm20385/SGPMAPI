using Model.Models.SGPM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("Subunidade")]
    public partial class Subunidade
    {
        [Key]
        // [Column(Order = 0)]
        [StringLength(50)]
        public string  subunidadeStamp { get; set; }

    
        // [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codsubunidade { get; set; }

    
        // [Column(Order = 2)]
        [StringLength(100)]
        public string?  descricao { get; set; }

    
        // [Column(Order = 3)]
        public bool cibm { get; set; }

    
        // [Column(Order = 4)]
        public bool estabEnsino { get; set; }

    
        // [Column(Order = 5)]
        public bool unidSubordCentral { get; set; }

    
        // [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codUnidade { get; set; }

    
        // [Column(Order = 7)]
        [StringLength(100)]
        public string?  unidade { get; set; }

    
        // [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int organica { get; set; }

    
        // [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOf { get; set; }

    
        // [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOfGen { get; set; }

    
        // [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalGenEx { get; set; }

    
        // [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTteGen { get; set; }

    
        // [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalMajGen { get; set; }

    
        // [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalBrigadeiro { get; set; }

    
        // [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOfSup { get; set; }

    
        // [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalCor { get; set; }

    
        // [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTteCor { get; set; }

    
        // [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalMaj { get; set; }

    
        // [Column(Order = 19)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOfSub { get; set; }

    
        // [Column(Order = 20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalCap { get; set; }

    
        // [Column(Order = 21)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTte { get; set; }

    
        // [Column(Order = 22)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTteMil { get; set; }

    
        // [Column(Order = 23)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalAlf { get; set; }

    
        // [Column(Order = 24)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalAlfMil { get; set; }

    
        // [Column(Order = 25)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSarg { get; set; }

    
        // [Column(Order = 26)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalInt { get; set; }

    
        // [Column(Order = 27)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSub { get; set; }

    
        // [Column(Order = 28)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalPriSar { get; set; }

    
        // [Column(Order = 29)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSegSar { get; set; }

    
        // [Column(Order = 30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTerSar { get; set; }

    
        // [Column(Order = 31)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalFur { get; set; }

    
        // [Column(Order = 32)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalPra { get; set; }

    
        // [Column(Order = 33)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalPriCab { get; set; }

    
        // [Column(Order = 34)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSegCab { get; set; }

    
        // [Column(Order = 35)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSold { get; set; }

        [StringLength(200)]
        public string?  zona { get; set; }

    
        // [Column(Order = 36)]
        [StringLength(200)]
        public string?  provincia { get; set; }

    
        // [Column(Order = 37)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codProvincia { get; set; }

    
        // [Column(Order = 38)]
        [StringLength(200)]
        public string?  distrito { get; set; }

    
        // [Column(Order = 39)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codDistrito { get; set; }

    
        // [Column(Order = 40)]
        [StringLength(200)]
        public string?  postoAdm { get; set; }

    
        // [Column(Order = 41)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codPostoAdm { get; set; }

    
        // [Column(Order = 42)]
        [StringLength(200)]
        public string?  localidade { get; set; }

    
        // [Column(Order = 43)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codLocalidade { get; set; }

    
        // [Column(Order = 44)]
        [StringLength(100)]
        public string?  inseriu { get; set; }

    
        // [Column(Order = 45)]
        [StringLength(100)]
        public string?  inseriuDataHora { get; set; }

    
        // [Column(Order = 46)]
        [StringLength(100)]
        public string?  alterou { get; set; }

        [StringLength(100)]
        public string?  alterouDataHora { get; set; }


        [ForeignKey("Unidade")]
        // [Column(Order = 47)]
        [StringLength(50)]
        public string?  unidadeStamp { get; set; }
        public virtual Unidade Unidade { get; set; }

     

        public virtual ICollection<Subunidade1> Subunidade1 { get; set; }

       // public virtual ICollection<Fornecimento> Fornecimento { get; set; }
    }
}
