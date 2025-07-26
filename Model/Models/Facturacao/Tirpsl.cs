using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Tirpsl
    {
        [Key]
        public string Tirpslstamp {get;set;}
        [DecimalPrecision(16, 2, true)]
        public decimal ValMin {get;set;}
        [DecimalPrecision(16, 2, true)]
        public decimal ValMax {get;set;}
        [DecimalPrecision(16, 2, true)]
        public decimal Dep00 {get;set;}
        [DecimalPrecision(16, 2, true)]
        public decimal Dep01 {get;set;}
        [DecimalPrecision(16, 2, true)]
        public decimal Dep02 {get;set;}
        [DecimalPrecision(16, 2, true)]
        public decimal Dep03 {get;set;}
        [DecimalPrecision(16, 2, true)]
        public decimal Dep04 {get;set;}
        public decimal Percentagem {get;set;}
        public decimal Ano {get;set;}
        public virtual Tirps Tirps{ get; set; }
    }
}
