using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClCursemdisc
    {
        [Key]
        public string ClCursemdiscstamp { get; set; }
        public string Coddisc { get; set; }
        public string Disc { get; set; }
        public decimal Valor { get; set; }
        public decimal Cargah { get; set; }
        public bool Prec { get; set; }
        [ForeignKey("ClCursem")]
        public string ClCursemstamp { get; set; }
        public virtual ClCursem ClCursem { get; set; }
    }
}
