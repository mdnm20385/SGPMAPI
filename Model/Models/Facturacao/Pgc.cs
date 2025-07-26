using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Pgc
    {
        [Key]
        public string Pgcstamp { get; set; }
        public string Conta { get; set; }
        public string Descricao { get; set; }
        public string Ncont { get; set; }//Stamp do Centro de Custo de Função
        public string Obs { get; set; }//Descrição do Centro de Custo de Função
        public string Codis { get; set; }//Descrição do Centro de Custo de actividade
        public string Oristamp { get; set; }//Stamp do Centro de Custo de actividade
        public bool Integracao { get; set; }
        public string Contaiva { get; set; }
        public decimal Codiva { get; set; }
        public decimal Codiva2 { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Taxaiva { get; set; }
        public DateTime Udata { get; set; }
        public string Ppconta { get; set; }
        public decimal Ano { get; set; }
        public bool Criadanoano { get; set; }
        public bool Dedutivel { get; set; }
        public bool Liquidado { get; set; }
        public bool Moviva { get; set; }
        public bool Activo { get; set; }
        public decimal Numero { get; set; }//Indica se é usado no mapa balanco ou nao e a sua posicao 
        public string Moeda { get; set; }//Indica a moeda usada pela conta

    }
}
