using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Dleil
    {
        [Key]
        public string Dleilstamp { get; set; }
        public string Dleistamp { get; set; }
        public decimal Ano { get; set; }
        [DecimalPrecision(5, 2,true)]
        public decimal Coef { get; set; }
    }
}
