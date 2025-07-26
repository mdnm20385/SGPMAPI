using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class StQuant
    {
        [Key]
        public string StQuantstamp { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Quant { get; set; }
        [MaxLength(2000)]
        public string Descpos { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Preco { get; set; }
        public bool Ivainc { get; set; }
        public byte[] Imagem { get; set; }
        public string CCusto { get; set; }
        public string CodCCu { get; set; }
        public string Ccustamp { get; set; }
        public virtual St St { get; set; }

    }
}
