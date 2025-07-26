using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class StPrecos
    {
        [Key]
        public string StPrecostamp { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        public string Moeda { get; set; }
        public string CCusto { get; set; }
        public string CodCCu { get; set; }
        public string Ccustamp { get; set; }
        public bool Ivainc { get; set; }
        public bool Padrao { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Preco { get; set; }

        [DecimalPrecision(16, 2, true)]
        public decimal Precoemb { get; set; }// Preço de embalagem/caixa
        
        [DecimalPrecision(16, 2, true)]
        public decimal PrecoCompra { get; set; }
        [DecimalPrecision(9, 2, true)]
        public decimal Perc { get; set; }
        [DecimalPrecision(9, 2, true)]
        public decimal Percemb { get; set; }
        public DateTime Dataincio { get; set; }
        public DateTime Datatermino { get; set; }
        public string Descpreco { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Quant { get; set; }
        public virtual St St { get; set; }
    }
}
