using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class MatriculaTurmaAlunol
    {
        [Key]
        public string MatriculaTurmaAlunolstamp { get; set; }
        [ForeignKey("MatriculaAluno")]
        public string MatriculaAlunostamp { get; set; } 
        public string Codigo { get; set; }
        public string Descricao { get; set; }
       public string AnoSemstamp { get; set; }
        public string Descanoaem { get; set; }
        public string Descurso { get; set; }
        public string Cursostamp { get; set; }
        public string Descgrade { get; set; }
        public string Gradestamp { get; set; }
        public string Etapa { get; set; }
        public string Sala { get; set; }
        public string Turno { get; set; }
        public decimal Vagasmin { get; set; }
        public decimal Vagasmax { get; set; }
        public string Responsavel { get; set; }
        public string Responsavel2 { get; set; }
        public decimal Semanaslec { get; set; }//Nº de semanas lectivas 
        public decimal Horasaulas { get; set; }//Nº de horas aulas por semana 
        public string Formaaval { get; set; }//Forma de avaliacao 
        public string Situacao { get; set; }//Selecione a situação da turma entre Em Inscrição (matrículas), Em Andamento (turma em atividade) e Concluída (finalizada)
        [MaxLength(2100)]
        public string Obs { get; set; }
        public DateTime  Datain { get; set; }
        public DateTime Datafim { get; set; }
        public DateTime Horain { get; set; }
        public DateTime Horafim { get; set; }
        public string Turmastamp { get; set; }
        public string Turmadiscstamp { get; set; }

        public bool Padrao { get; set; }//True=matrícula cancelada e false = matrícula activa
        public virtual MatriculaAluno MatriculaAluno { get; set; }
        //public virtual ICollection<Turma> Turma { get; set; }
       // public virtual MatriculaTurmaL MatriculaTurmaL { get; set; }
        //public string MatriculaTurmaLstamp { get; set; }
    }
}
