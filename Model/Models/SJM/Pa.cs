using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Model.Models.SJM
{
    [Table("Pa")]
    public class Pa
    {
        [Key]
        [StringLength(100)]
        public string?  PaStamp { get; set; }

        [Required]
        [StringLength(100)]
        public string?  Nome { get; set; }
        [Required]
        [StringLength(10)]
        public string?  Sexo { get; set; }

        [StringLength(30)]
        public string?  NumBi { get; set; }

        [Required]
        [StringLength(50)]
        public string?  Naturalidade { get; set; }

        [Required]
        [StringLength(50)]
        public string?  ResProv { get; set; }

        [Required]
        [StringLength(50)]
        public string?  ResDist { get; set; }

        [StringLength(50)]
        public string?  ResPosto { get; set; }

        [StringLength(50)]
        public string?  ResLocal { get; set; }

        [StringLength(50)]
        public string?  ResBairro { get; set; }

        [StringLength(20)]
        public string?  ResQuarteirao { get; set; }

        [StringLength(100)]
        public string?  ResAvenida { get; set; }

        [StringLength(20)]
        public string?  NumCasa { get; set; }

        [StringLength(15)]
        public string?  ConPrinc { get; set; }

        [StringLength(15)]
        public string?  ConAlter { get; set; }

        [StringLength(50)]
        public string?  Ramo { get; set; }

        [StringLength(50)]
        public string?  Orgao { get; set; }
        [StringLength(100)]
        public string?  Unidade { get; set; }
        [StringLength(100)]
        public string?  Subunidade { get; set; }

        [StringLength(50)]
        public string?  Patente { get; set; }
        [StringLength(50)]
        public string? Catpat { get; set; }
        [StringLength(100)]
        public string?  Inseriu { get; set; }
        [StringLength(30)]
        public string?  InseriuDataHora { get; set; }

        [StringLength(100)]
        public string?  Alterou { get; set; }
        [StringLength(30)]
        public string?  AlterouDataHora { get; set; }
        [StringLength(100)]
        public string?  Tipodoc { get; set; }
        public bool? Activo { get; set; }

        public string?  Path { get; set; }
        [JsonIgnore]
        public virtual DClinicos DClinicos { get; set; }
        public ICollection<Processo> Processo { get; set; }

        public byte[] Junta { get; set; }

        [NotMapped]
        public string JuntaHom { get; set; }
        [NotMapped]
        public string Path1 { get; set; }
    }

    [Table("EspecieDocumental")]
    public partial class EspecieDocumental
    {
        [Key]
        public string?  EspecieStamp { get; set; }

        public string?  Descricao { get; set; }

        public string?  VidaUtil { get; set; }

        public string?  Inseriu { get; set; }

        public DateTime? InseriuDataHora { get; set; }

        public string?  Alterou { get; set; }

        public DateTime? AlterouDataHora { get; set; }

        public string?  CodClassif { get; set; }

        public string?  DestnFnl { get; set; }
    }
}
