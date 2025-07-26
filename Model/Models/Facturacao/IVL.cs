using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class IVL
    {
        [Key]
        public string Ivlstamp { get; set; }
        [ForeignKey("IV")]
        public string Ivstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Referenc { get; set; }
        public string Descricao { get; set; }
        public decimal Quant { get; set; }//Referente a quantidade física
        public string Unidade { get; set; }
        public string Armazem { get; set; }
        public string Descarmazem { get; set; }
        public string Armazemstamp { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Preco { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Totall { get; set; }//Referente ao valor fisico
        public bool Status { get; set; }
        public bool Servico { get; set; }
        public decimal Difer { get; set; }
        public bool Nmovstk { get; set; }
        public string Remotestamp { get; set; }
        public bool Tit { get; set; }
        public decimal Ordem { get; set; }
        public string Titstamp { get; set; }
        public string Lote { get; set; }
        public DateTime Lotevalid { get; set; }
        public DateTime lotelimft { get; set; }
        public bool usalote { get; set; }
        public string Coluna { get; set; }
        public string Rua { get; set; }
        public string Nivel { get; set; }
        public string Ststamp { get; set; }
        public string Obs { get; set; }

        [DecimalPrecision(20, 2, true)]
        public decimal Qtdfisica { get; set; }//Referente a quantidade no sistema
        [DecimalPrecision(20, 2, true)]
        public decimal Totalfisic { get; set; }//Referente ao valor no sistema
        [DecimalPrecision(20, 2, true)]
        public decimal DivQutd { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal DivTotal { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Acuracidade { get; set; }
        public string Classificador { get; set; }//1-Danificado completamente,2- Danificado parc,3- validade vencida, 4- validade por vencer
        [DecimalPrecision(20, 2, true)]
        public decimal DanificadoComp { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Danificadparcial { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Validadevenc { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal ValidadePorvenc { get; set; }


        public virtual IV IV { get; set; }
        public virtual ICollection<Mstk> Mstk { get; set; }
        public virtual ICollection<IvStimg> IvStimg { get; set; }
    }
}
