using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Ml
    {
        [Key]
        public string Mlstamp { get; set; }
        public string Dinome { get; set; }
        public decimal Dilno { get; set; }
        public string Docnome { get; set; }
        public string Adoc { get; set; }
        public DateTime Data { get; set; }
        public decimal Mes { get; set; }
        public decimal Dia { get; set; }
        public decimal Ano { get; set; }
        public string Conta { get; set; }
        public string Descricao { get; set; }
        public string Rubrica { get; set; }//ccusto de actividade
        [DecimalPrecision(18, 2, true)]
        public decimal Deb { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Cre { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Edeb { get; set; }
        [DecimalPrecision(18, 2, true)]
        public decimal Ecre { get; set; }


        public decimal Dino { get; set; }
        public string Descritivo { get; set; }
        public decimal Docno { get; set; }
        public decimal Doctipo { get; set; }
        public decimal Ordem { get; set; }
        [ForeignKey("Lcont")]
        public string Lcontstamp { get; set; }
        public string Origem { get; set; }
        public string Oristamp { get; set; }//Recebe Stamp de cabecalhos 
        public string Oristampl { get; set; }//Recebe Stamp de filhas  
        [MaxLength(200)]
        public string Obs { get; set; }//ccustamp de actividade
        [DecimalPrecision(8, 2, true)]
        public decimal Cambio { get; set; }
        public string Moeda2 { get; set; }//Moeda de Cambio 
        public string Moeda { get; set; }
        public string Ccusto { get; set; }//ccusto de Funcao
        public string Codccu { get; set; }//ccustamp de Funcao
        public string Pgcstamp { get; set; }
        public  bool Processado { get; set; }//Indica se o IVA do mes anterior ja esta processao
        public bool Apuraiva { get; set; }//indica que é apuramento iva 
        public bool Apurares { get; set; }//indica que é apuramento de resultados 
        public bool LancamentoInicial { get; set; }//indica que é um lançamento inicial
        public virtual Lcont Lcont { get; set; }
    }
}
