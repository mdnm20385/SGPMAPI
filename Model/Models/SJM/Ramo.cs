using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    public class Ramo
    {
        [Key]
        // [Column(Order = 0)]
        [StringLength(50)]
        public string? RamoStamp { get; set; }
        public int CodRamo { get; set; }
        // [Column(Order = 2)]
        [StringLength(50)]
        public string? Descricao { get; set; }


        // [Column(Order = 3)]

        public int Organica { get; set; }


        // [Column(Order = 4)]

        public int TotalOf { get; set; }


        // [Column(Order = 5)]

        public int TotalOfGen { get; set; }


        // [Column(Order = 6)]

        public int TotalGenEx { get; set; }


        // [Column(Order = 7)]

        public int TotalTteGen { get; set; }


        // [Column(Order = 8)]

        public int TotalMajGen { get; set; }


        // [Column(Order = 9)]

        public int TotalBrigadeiro { get; set; }


        // [Column(Order = 10)]

        public int TotalOfSup { get; set; }


        // [Column(Order = 11)]

        public int TotalCor { get; set; }


        // [Column(Order = 12)]

        public int TotalTteCor { get; set; }


        // [Column(Order = 13)]

        public int TotalMaj { get; set; }


        // [Column(Order = 14)]

        public int TotalOfSub { get; set; }


        // [Column(Order = 15)]

        public int TotalCap { get; set; }


        // [Column(Order = 16)]

        public int TotalTte { get; set; }


        // [Column(Order = 17)]

        public int TotalTteMil { get; set; }


        // [Column(Order = 18)]

        public int TotalAlf { get; set; }


        // [Column(Order = 19)]

        public int TotalAlfMil { get; set; }


        // [Column(Order = 20)]

        public int TotalSarg { get; set; }


        // [Column(Order = 21)]

        public int TotalInt { get; set; }


        // [Column(Order = 22)]

        public int TotalSub { get; set; }


        // [Column(Order = 23)]

        public int TotalPriSar { get; set; }


        // [Column(Order = 24)]

        public int TotalSegSar { get; set; }


        // [Column(Order = 25)]

        public int TotalTerSar { get; set; }


        // [Column(Order = 26)]

        public int TotalFur { get; set; }


        // [Column(Order = 27)]

        public int TotalPra { get; set; }


        // [Column(Order = 28)]

        public int TotalPriCab { get; set; }


        // [Column(Order = 29)]

        public int TotalSegCab { get; set; }


        // [Column(Order = 30)]

        public int TotalSold { get; set; }


        // [Column(Order = 31)]
        [StringLength(100)]
        public string? Inseriu { get; set; }


        // [Column(Order = 32)]
        [StringLength(100)]
        public string? InseriuDataHora { get; set; }


        // [Column(Order = 33)]
        [StringLength(100)]
        public string? Alterou { get; set; }


        // [Column(Order = 34)]
        [StringLength(100)]
        public string? AlterouDataHora { get; set; }
    }
}
