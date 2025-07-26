using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{


    public  class Processo
    {
        [Key]
        [StringLength(50)]
        public string ProcessoStamp { get; set; }
        public int Numero { get; set; }

        [Required]
        [StringLength(100)]
        public string TipoDoc { get; set; }

        [Required]
        [StringLength(500)]
        public string? Assunto { get; set; }

        [Required]
        [StringLength(100)]
        public string? Inseriu { get; set; }

        public DateTime InseriuDataHora { get; set; }

        [Required]
        [StringLength(100)]
        public string? Alterou { get; set; }
        public DateTime AlterouDataHora { get; set; }
        public string? Orgao { get; set; }

        public string? Direcao { get; set; }

        public string? Departamento { get; set; }
        public string? Orgaostamp { get; set; }
        public string? Departamentostamp { get; set; }
        public string? Direcaostamp { get; set; }
        public string Estado { get; set; }
        public string Visado { get; set; }
        public string Usrstamp { get; set; }

        [StringLength(250)]
        public string Homologado { get; set; }
        [Required]
        [StringLength(100)]
        [ForeignKey("Pa")]
        public string PaStamp { get; set; }
        public virtual Pa? Pa { get; set; }

        [NotMapped]
        public string Path1 { get; set; }

    }

    public class Destruicao
    {
        [Key]
        public string ArquivoStamp { get; set; }

        public string Observ { get; set; }

        public DateTime DataDest { get; set; }

        public string Inseriu { get; set; }

        public DateTime? InseriuDataHora { get; set; }

        public string Alterou { get; set; }

        public DateTime? AlterouDataHora { get; set; }

        

    }
    


}
