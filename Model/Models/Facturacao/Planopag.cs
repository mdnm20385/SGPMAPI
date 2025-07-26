using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Planopag
    {
        [Key]
        public string Planopagstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Parcelas { get; set; }
        public string Anosem { get; set; }
        public decimal Anolectivo { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Valor { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Valorextra { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Desconto { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Valorparzero { get; set; }
        public DateTime Datapartida { get; set; }
        public DateTime Datafim { get; set; }
        public bool Diauteis { get; set; }
        public bool Pularsabados { get; set; }
        public bool Pulardomingos { get; set; }
        public bool Pularferiados { get; set; }
        public decimal Tipo { get; set; }
        public bool Distrato { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Valordistrato { get; set; }
        public decimal Diasvenc { get; set; }//Dias de vencimento 
        public decimal TipoValdistrato { get; set; }//1-Valor Fixo, 2-Percentagem
        public string Descdistrato { get; set; }//Cursando,Falecido,Matricula cancelada,formando
        public string Cursostamp { get; set; }
        public string Desccurso { get; set; }
        public string Descanosem { get; set; }
        public string AnoSemstamp { get; set; }
        public virtual ICollection<Planopagp> Planopagp { get; set; }
        public virtual ICollection<Planopagt> Planopagt { get; set; }
    }
}
