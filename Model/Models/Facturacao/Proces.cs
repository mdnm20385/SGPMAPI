using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Proces
    {
        [Key]
        public string Processtamp { get; set; }
        public DateTime Data { get; set; }
        public string Mes { get; set; }
        public decimal Ano { get; set; }
        public string Descricao { get; set; }
        public string CCusto { get; set; }
        public string Ccustamp { get; set; }
        public string Tipoproces { get; set; }
        public decimal Codigo { get; set; }
        public decimal Processado { get; set; }
        public DateTime Ultproc { get; set; }
        public decimal Nrmes { get; set; }
        [StringLength(4000)]
        public string Obs { get; set; }

        public string Periodo { get; set; }

        [DecimalPrecision(16, 2,true)]
        public decimal TotalSubsidio { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalBaseVencimento { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalDesconto { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalAliment { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalHextra { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalFaltas { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalSindicato { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalSegSocfunc { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalSegSocEmp { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalIrps { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal Totalliquido { get;  set;}
        [DecimalPrecision(16, 2,true)]
        public decimal TotalEmprestimo { get; set; }
        [StringLength(4000)]
        public string Erros { get; set; }
        public string Mesesstamp { get; set; }
        public virtual ICollection<Prc> Prc { get; set; }
       // public virtual ICollection<Procesl> Procesl { get; set; }//Centros de custos processados 
    }
}
