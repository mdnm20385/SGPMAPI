using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class IV
    {
        [Key]
        public string Ivstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }       
        public string Descricao { get; set; }       
        public decimal Numero { get; set; }
        public string Armazem { get; set; }
        public string Descarmazem { get; set; }
        public string Familia { get; set; }
        public string Codfam { get; set; }
        public string Armazemstamp { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public decimal TotalFisico { get; set; }//
        public DateTime Datalanc { get; set; }
        public bool Lancado { get; set; }
        public string Numinterno { get; set; }
        public string Ccusto { get; set; }
        public string Codccu { get; set; }
        [MaxLength(5000000)]
        public string Obs { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal DivQutd { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal DivTotal { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Totalquant { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal QuantFisico { get; set; }//
        
        public string Codsubfam { get; set; }
        public string Subfamilia { get; set; }
        public decimal Codmarca { get; set; }
        public string Marca { get; set; }
        public decimal Codfab { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string Endereco { get; set; }
        //Alocações
        public string Coluna { get; set; }
        public string Rua { get; set; }
        public string Nivel { get; set; }
        public virtual ICollection<IVL> Ivl { get; set; }
    }
}
