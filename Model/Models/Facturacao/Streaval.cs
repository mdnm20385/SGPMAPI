using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Streaval
    {
        [Key]
        public string Streavalstamp { get; set; }
        [ForeignKey("St2")]
        public string Ststamp { get; set; }
        public string Decreto { get; set; }
        public DateTime Data { get; set; }//data
        [DecimalPrecision(20, 2,true)]
        public decimal Aquis { get; set; }//Valor de Aquisicao a reavaliar 
        [DecimalPrecision(20, 2,true)]
        public decimal Aquisreaval { get; set; }//Valor Aquisicao reavaliado
        [DecimalPrecision(20, 2,true)]
        public decimal Dep { get; set; }//Valor de depreciacoes a reavaliar 
        [DecimalPrecision(20, 2,true)]
        public decimal Depcorrig { get; set; }//Valor de depreciacoes a corrigidas  
        public bool Contab { get; set; }//Contabilizado 
        public virtual St2 St2 { get; set; }
    }
}
