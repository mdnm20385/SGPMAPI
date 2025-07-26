using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Grade
    {
        [Key]
        public string Gradestamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Codcurso { get; set; }
        public string Desccurso { get; set; }
        public string Cursostamp { get; set; }
        public bool Activo { get; set; }
        public string Anoseminic { get; set; }//Ano/semestre inicio 
        public string AnoSemstamp { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotalCargahora { get; set; }//Carga Horaria 
        [DecimalPrecision(16, 2, true)]
        public decimal TotalCargaTeorica { get; set; }//Carga Horaria Teórica
        [DecimalPrecision(16, 2, true)]
        public decimal TotalCargaPratica { get; set; }//Carga Horaria Pratica
        [MaxLength(2100)]
        public string Obs { get; set; }
        public decimal Totaldisc { get; set; }//Total de disciplinas 
        public decimal TotalCreda { get; set; }//Total de creditos academicos 
        public DateTime  Data { get; set; }//Data de Criacao 
        public string Planopagstamp { get; set; }
        public string Descplano { get; set; }
        public virtual ICollection<Gradel> Gradel { get; set; }
    }
}
