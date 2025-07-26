using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class DistribuicaoTurno
    {
        [Key]
        public string DistribuicaoTurnostamp { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public string DescTurno { get; set; }
        public string Nome { get; set; }
        public string Turnostamp { get; set; }
        public string Sigla { get; set; }
        public string No { get; set; }
        public string Categ { get; set; }
        public string Tipo { get; set; } 
        public DateTime Data { get; set; }
        public string Data1 { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
