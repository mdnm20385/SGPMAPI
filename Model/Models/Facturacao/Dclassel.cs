using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Dclassel
    {
        [Key]
        public string Dclasselstamp { get; set; }
        [ForeignKey("Dclasse")]
        public string Dclassestamp { get; set; }
        public string Turmastamp { get; set; }
        public string Turma { get; set; }
        public string Cursostamp { get; set; }
        public string Curso { get; set; }
        public virtual Dclasse Dclasse { get; set; }
    }
}