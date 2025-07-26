using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    public class Busca
    {
        [Key]
        public string  buscaStamp { get; set; }

        public long codBusca { get; set; }

        // [Column(Order = 2)]
        public string?  descricao { get; set; }

        
        // [Column(Order = 3)]
        [StringLength(50)]
        public string?  numTabela { get; set; }

        
        // [Column(Order = 4)]
        [StringLength(100)]
        public string? inseriu { get; set; }

        
        // [Column(Order = 5)]
        [StringLength(100)]
        public string?  inseriuDataHora { get; set; }

        [StringLength(100)]
        public string? alterou { get; set; }

        [StringLength(100)]
        public string?  alterouDataHora { get; set; }
    }


    public class Trabalho
    {
        public string Trabalhostamp { get; set; } = "";
        public string Turmalstamp { get; set; } = "";
        public string Ststamp { get; set; } = "";
        public string Clstamp { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime Data { get; set; } = DateTime.Now;
        public string Path { get; set; } = "";
        public string Path1 { get; set; } = "";
        public  string numTabela { get; set; } = "";
        public string descricao { get; set; } = "";
        public Usuario Usuario { get; set; } = new();
        public Pa Pa { get; set; } = new();

    }


}
