using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class DisciplinaTumra
    {
        [Key]
        public string DisciplinaTumrastamp { get; set; }

        public string Disciplina { get; set; }
        public string Referenc { get; set; }
        [ForeignKey("MatriculaAluno")]
        public string MatriculaAlunostamp { get; set; }
        public string Turmastamp { get; set; }
        public string Codigo { get; set; }
        public string Ststamp { get; set; }
        public string Clstamp { get; set; }
        public string Sitcao { get; set; }
        public bool Activo { get; set; }//True=matrícula cancelada e false = matrícula activa
        [MaxLength(3000)]
        public string Motivo { get; set; }//Motivo pelo qual lhe leva ao cancelamento da matrícula
        public virtual MatriculaAluno MatriculaAluno { get; set; }
    }
}
