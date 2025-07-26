using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Parampv
    {
        [Key]
        public string Parampvstamp { get; set; }
        [ForeignKey("Param")]
        public string Paramstamp { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valor { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Factor { get; set; }
        public virtual Param Param { get; set; }
    }
}
