using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Factreg
    {
        [Key] 
        public string Factregstamp { get; set; }
        public string Factstamp { get; set; }
        public string Ccstamp { get; set; }
        public string Descricao { get; set; }
        public decimal Nrdoc { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Valpreg { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Valorreg { get; set; }
        public virtual Fact  Fact{ get; set; }
    }
}
