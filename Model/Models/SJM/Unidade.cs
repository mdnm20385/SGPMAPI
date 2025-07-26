using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.SGPM;

namespace Model.Models.SJM
{
    [Table("Unidade")]
    public partial class Unidade
    {
        [Key]
       // [Column(Order = 0)]
        [StringLength(50)]
        public string  unidadeStamp { get; set; }

        
       // [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codUnidade { get; set; }

        
       // [Column(Order = 2)]
        [StringLength(100)]
        public string?  descricao { get; set; }

        
       // [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codOrgao { get; set; }

        
       // [Column(Order = 4)]
        [StringLength(200)]
        public string?  orgao { get; set; }

        
       // [Column(Order = 5)]
        public bool cibm { get; set; }

        
       // [Column(Order = 6)]
        public bool estabEnsino { get; set; }

        
       // [Column(Order = 7)]
        public bool hospitalMilitar { get; set; }

        
       // [Column(Order = 8)]
        public bool unidSubordCentral { get; set; }

        
       // [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int organica { get; set; }

        
       // [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOf { get; set; }

        
       // [Column(Order = 11)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOfGen { get; set; }

        
       // [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalGenEx { get; set; }

        
       // [Column(Order = 13)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTteGen { get; set; }

        
       // [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalMajGen { get; set; }

        
       // [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalBrigadeiro { get; set; }

        
       // [Column(Order = 16)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOfSup { get; set; }

        
       // [Column(Order = 17)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalCor { get; set; }

        
       // [Column(Order = 18)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTteCor { get; set; }

        
       // [Column(Order = 19)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalMaj { get; set; }

        
       // [Column(Order = 20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalOfSub { get; set; }

        
       // [Column(Order = 21)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalCap { get; set; }

        
       // [Column(Order = 22)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTte { get; set; }

        
       // [Column(Order = 23)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTteMil { get; set; }

        
       // [Column(Order = 24)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalAlf { get; set; }

        
       // [Column(Order = 25)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalAlfMil { get; set; }

        
       // [Column(Order = 26)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSarg { get; set; }

        
       // [Column(Order = 27)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalInt { get; set; }

        
       // [Column(Order = 28)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSub { get; set; }

        
       // [Column(Order = 29)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalPriSar { get; set; }

        
       // [Column(Order = 30)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSegSar { get; set; }

        
       // [Column(Order = 31)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalTerSar { get; set; }

        
       // [Column(Order = 32)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalFur { get; set; }

        
       // [Column(Order = 33)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalPra { get; set; }

        
       // [Column(Order = 34)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalPriCab { get; set; }

        
       // [Column(Order = 35)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSegCab { get; set; }

        
       // [Column(Order = 36)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int totalSold { get; set; }

        
       // [Column(Order = 37)]
        [StringLength(200)]
        public string?  provincia { get; set; }

        public int? codProvincia { get; set; }

        [StringLength(200)]
        public string?  distrito { get; set; }

        public int? codDistrito { get; set; }

        [StringLength(200)]
        public string?  postoAdm { get; set; }

        public int? codPostoAdm { get; set; }

        [StringLength(200)]
        public string?  localidade { get; set; }

        public int? codLocalidade { get; set; }

        [StringLength(100)]
        public string?  inseriu { get; set; }

        [StringLength(100)]
        public string?  inseriuDataHora { get; set; }

        [StringLength(100)]
        public string?  alterou { get; set; }

        [StringLength(100)]
        public string?  alterouDataHora { get; set; }


        [ForeignKey("Orgao")]
        // [Column(Order = 38)]
        [StringLength(100)]
        public string?  orgaoStamp { get; set; }
        public virtual Orgao Orgao { get; set; }

        public virtual ICollection<Subunidade> Subunidade { get; set; }


        public virtual ICollection<Fornecimento> Fornecimento { get; set; }
        // [Column(Order = 39)]
        public bool Pco { get; set; }
    }
}
