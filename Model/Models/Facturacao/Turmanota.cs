using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Turmanota
    {
        [Key]
        public string Turmanotastamp { get; set; }
        [ForeignKey("Turma")]
        public string Turmastamp { get; set; }
        public string No { get; set; }
        public string Alunostamp { get; set; }
        public string AlunoNome { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal N1 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal N2 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal N3 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal N4 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal N5 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Media { get; set; }
        public DateTime Data { get; set; }
        public bool Aprovado { get; set; }
        public string Coddis { get; set; }
        public string Disciplina { get; set; }
        public string Anosem { get; set; }
        public string Sem { get; set; }
        public string Cursostamp { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal E1 { get; set; }//Exame Normal 
        [DecimalPrecision(16, 2, true)]
        public decimal E2 { get; set; }//Exame Recurso
        [DecimalPrecision(16, 2, true)]
        public decimal Es { get; set; }//Exame especial 
        [DecimalPrecision(16, 2, true)]
        public decimal Mediafinal { get; set; }
        public string Pestamp { get; set; }
        public string Profnome { get; set; }
        public string Pestamp2 { get; set; }
        public string Profnome2 { get; set; }
        public bool Fecho { get; set; }//Fechar o diario pelo professor (Basta fechar nao tera mais possibilidade de alterar)
        [MaxLength(3000)]
        public string Obs { get; set; }

        //Dados adicionados e alterados
        public DateTime Datafecho { get; set; }
        public string Resultado { get; set; }     //Para Obter todos admitidos/Excluidos

        public string ResultadoFinal { get; set; }   //Para obter todas stuacoes
        //de resultados nos exames

        public decimal CodSit { get; set; } //1=exluido,2=admitido,3=dispensado
        //,4=aprovado,5=reprovado
        public string Codetapa { get; set; }

        public bool Activo { get; set; }//True=matrícula cancelada e false = matrícula activa
        [MaxLength(3000)]
        public string Motivo { get; set; }//Motivo pelo qual lhe leva ao cancelamento da matrícula
        public virtual Turma Turma { get; set; }
    }
}
