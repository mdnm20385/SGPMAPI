using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class StDrpc
    {
        [Key]
        public string Stdrpcstamp { get; set; }
        [ForeignKey("St2")]
        public string Ststamp { get; set; }
        public DateTime Data { get; set; }//data
        public DateTime Datac { get; set; }//data civil
        [DecimalPrecision(20, 2,true)]
        public decimal Valdep { get; set; }//Valor depreciavel 
        [DecimalPrecision(20, 2,true)]
        public decimal Valdepact { get; set; }//Valor depreciavel actual  
        [DecimalPrecision(5, 2,true)]
        public decimal TaxaDeprec { get; set; }//Taxa depreciavel 
        //public string TipoMov { get; set; }
        //public decimal TotalLiquid { get; set; }
        public virtual St2 St2 { get; set; }
    }
}
