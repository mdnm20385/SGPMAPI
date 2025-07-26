using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Starm
    {
        [Key]
        public string Starmstamp { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        public decimal Codarm { get; set; }
        public string Descricao { get; set; }
        public string Armazemstamp { get; set; }
        public string Ref { get; set; }
        [DecimalPrecision(20, 2,true)]
        public decimal Stock { get; set; }
        [DecimalPrecision(20, 2,true)]
        public decimal StockMin { get; set; }//Capacidade mínimo de armazenamento
        [DecimalPrecision(20, 2,true)]
        public decimal StockMax { get; set; }//Capacidade máximo de armazenamento
        [DecimalPrecision(20, 2,true)]
        public decimal Reserva { get; set; }
        public decimal Encomenda { get; set; }
        [DecimalPrecision(20, 2,true)]
        public decimal Vendido { get; set; } 
        [DecimalPrecision(20, 2,true)]
        public decimal Comprado { get; set; } 
        public bool Padrao { get; set; }
        public string Endereco { get; set; }
        //Alocações
        public string Coluna { get; set; }
        public string Rua { get; set; }
        public string Nivel { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal StockMinVend { get; set; }//Stock mínimo de Venda
        [DecimalPrecision(20, 2, true)]
        public decimal StockMaxVend { get; set; }//Stock máximo de Venda
        public virtual St St { get; set; }
        
    }
}
