using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClCur
    {
        [Key]
        [ScaffoldColumn(false)]
        public string ClCurstamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string Curso { get; set; }
        public string Codcurso { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public bool Concluido { get; set; }
        public virtual Cl Cl { get; set; }
        public virtual ICollection<ClCursem> ClCursol { get; set; }
    }
}
