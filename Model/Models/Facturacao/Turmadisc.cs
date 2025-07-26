using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Turmadisc
    {
        [Key]
        public string Turmadiscstamp { get; set; }
        [ForeignKey("Turma")]
        public string Turmastamp { get; set; }
        public string Ststamp { get; set; }
        public string Referenc { get; set; }
        public string Disciplina { get; set; }
        public string NumeroTeste { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual ICollection<Turmadiscp> Turmadiscp { get; set; }//Professores 
    }
}