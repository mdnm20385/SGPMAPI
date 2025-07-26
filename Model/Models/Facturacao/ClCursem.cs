using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClCursem
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Clcursemstamp { get; set; }
        [ForeignKey("ClCurso")]
        public string ClCursostamp { get; set; }
        public string Codsem { get; set; }
        public string Sem { get; set; }
        public virtual ClCur ClCurso { get; set; }
        public virtual ICollection<ClCursemdisc> ClCursemdisc { get; set; }
    }
}
