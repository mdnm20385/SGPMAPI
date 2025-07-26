using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Stimpar
    {
        [Key]
        public string Stimparstamp { get; set; }
        [ForeignKey("St2")]
        public string Ststamp { get; set; }
        public string Descricao { get; set; }
        public string Referencia { get; set; }
        public DateTime Data { get; set; }//data
        [DecimalPrecision(20, 2,true)]
        public decimal Valdep { get; set; }//Valor depreciavel 
        [DecimalPrecision(20, 2,true)]
        public decimal Depreciacao { get; set; }//Depreciacoes 
        [DecimalPrecision(20, 2,true)]
        public decimal Valescriturada { get; set; } 
        [DecimalPrecision(20, 2,true)]
        public decimal Valrecup { get; set; }//Valor recuperavel  
        [DecimalPrecision(20, 2,true)]
        public decimal Valimparidade { get; set; }//Valor recuperavel  
        [DecimalPrecision(20, 2,true)]
        public decimal Valacuimp { get; set; }//Valor acumulado de imparidades   
        [DecimalPrecision(20, 2,true)]
        public decimal Valacurevers { get; set; }//Valor acumulado de reversoes    
        public virtual St2 St2 { get; set; }
    }
}
