using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Lcont
    {
        [Key]
        public string Lcontstamp { get; set; }
        public string Dinome { get; set; }
        public decimal Dilno { get; set; }
        public string Docnome { get; set; }
        public string Adoc { get; set; }
        public DateTime Data { get; set; }
        public decimal Mes { get; set; }
        public decimal Dia { get; set; }
        public decimal Dino { get; set; }
        public decimal Doctipo { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Debana { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Debord { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Debfin { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Creana { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Creord { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Crefin { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Edebana { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Edebord { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Edebfin { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Ecreana { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Ecreord { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Ecrefin { get; set; }
        public string Memissao { get; set; }
        public string Oristamp { get; set; }//Recebe stamps de documentos externos ou vindo de outros modulos 
        public string Ncont { get; set; }
        public decimal Ano { get; set; }
        [DecimalPrecision(8, 2, true)]
        public decimal Cambio { get; set; }
        public decimal Docno { get; set; }
        public string Moeda2 { get; set; }//Moeda de Cambio 
        public string Moeda { get; set; }
        public bool Apuraiva { get; set; }//indica que é apuramento iva 
        public bool Apurares { get; set; }//indica que é apuramento de resultados  
        public string Diariostamp { get; set; }
        public bool LancamentoInicial { get; set; }//indica que é um lançamento inicial
        [MaxLength(100000)]
        public string Descritivo { get; set; }//indica que é um lançamento inicial
        //[MaxLength(100000)]
        //public string MesLancamento { get; set; }//indica que é um lançamento inicial
        public virtual ICollection<Ml> Ml { get; set; }
    }
}
