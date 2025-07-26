using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class MatriculaAluno
    {
        [Key]
        public string MatriculaAlunostamp { get; set; }
        public string Planopagstamp { get; set; }
        public decimal Numero { get; set; }
        //public string nome { get; set; }
        public decimal Numdoc { get; set; }
        public string Codigo { get; set; }
        public string Refonecedor { get; set; }
        public decimal Anolectivo { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Descplano { get; set; } 
        public DateTime Datapartida { get; set; }
        public string Cursostamp { get; set; }
        public DateTime Data { get; set; }//Data de Criacao 
        public string AnoSemstamp { get; set; }
        public string Clstamp { get; set; }
        public string Descricao { get; set; }

        public string Sitcao { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public string Curso { get; set; }
        public string Codcurso { get; set; }
        public DateTime Datamat { get; set; }
        public string Turno { get; set; }
        public string Periodo { get; set; }
        public string AnoSem { get; set; }
        public string Codtur { get; set; }
        public string Anolect { get; set; }
        public string Localmat { get; set; }
        public string Emails { get; set; }
        [MaxLength(400)]
        public string Obs { get; set; }
        //[DecimalPrecision(16, 2, true)]
        public string Gradestamp { get; set; }
        public string DescGrade { get; set; }
        public string Etapa { get; set; }
        public string Turmadiscstamp { get; set; }
        public string Ststamp { get; set; }
        public string Turmastamp { get; set; }
        public string Turnostamp { get; set; }
        public string Codfac { get; set; }
        public string Alauxiliarstamp { get; set; }
        public string Semstamp { get; set; }

        public string Nivelac { get; set; }
        public string Formaingresso { get; set; }
        
        public string Ccusto { get; set; }
        public string Ccustostamp { get; set; }

        public string Coddep { get; set; }
        public string Departamento { get; set; }
        public string Faculdade { get; set; }
        public string Descanoaem { get; set; }
        public string Tipo { get; set; }
        //public string AnoSemstamp { get; set; }

        public bool Activo { get; set; }//True=matrícula cancelada e false = matrícula activa
        [MaxLength(3000)]
        public string Motivo { get; set; }//Motivo pelo qual lhe leva ao cancelamento da matrícula

        public virtual ICollection<MatriculaTurmaAlunol> MatriculaTurmaAlunol { get; set; }
        public virtual ICollection<DisciplinaTumra> DisciplinaTumra { get; set; }
        // public virtual ICollection<MatriculaTurma> MatriculaTurma { get; set; }
        public virtual ICollection<Matdisc> Matdisc { get; set; }
        public bool Inscricao { get; set; }
        public bool Matricula { get; set; }
        public string Nomedoc { get; set; }
    }
}
