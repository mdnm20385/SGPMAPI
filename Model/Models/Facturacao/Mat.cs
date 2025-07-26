using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Mat
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Matriculastamp { get; set; }
        public string Clstamp { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Codcurso { get; set; }
        public DateTime Datamat { get; set; }
        public string Turno { get; set; }
        public string Periodo { get; set; }
        public string Turma { get; set; }
        public string Codtur { get; set; }
        public string Anolect { get; set; }
        public string Localmat { get; set; }
        public string Emails { get; set; }
        [MaxLength(400)]
        public string Obs { get; set; }
        public virtual ICollection<Matdisc> Matdisc { get; set; }

    }
}
