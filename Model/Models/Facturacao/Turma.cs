using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.SGPM;

namespace Model.Models.Facturacao
{
public class Turma
    {
        [Key]
        public string Turmastamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("AnoSem")]
        public string AnoSemstamp { get; set; }
        public string Descanoaem { get; set; }
        public string Descurso { get; set; }
        [ForeignKey("Curso")]
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
        //Etapa
        public string Codetapa { get; set; }
        public virtual AnoSem AnoSem { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual ICollection<Turmal> Turmal { get; set; }//Alunos
        public virtual ICollection<Turmadisc> Turmadisc { get; set; }//Disciplinas 
        public virtual ICollection<Turmanota> Turmanota { get; set; }//Lancamento de notas  
    }
}
