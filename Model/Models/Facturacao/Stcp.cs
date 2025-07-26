using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Stcp
    {
        [Key]
        public string Stcpstamp { get; set; }
        public string refcp { get; set; }
        public string descricao { get; set; }
        [DecimalPrecision(10, 2, true)]
        public decimal quantcp { get; set; }
        [DecimalPrecision(10, 2, true)]
        public decimal Precocp { get; set; }
        public bool servico { get; set; }
        [ForeignKey("St")]
        public string ststamp { get; set; }
        public bool status { get; set; }
        public bool Ivainc { get; set; }
        public string Oristamp { get; set; }
        [DecimalPrecision(10, 2, true)]
        public decimal Totall { get; set; }
        public virtual St St { get; set; }
    }
}
