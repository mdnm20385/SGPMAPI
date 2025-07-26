using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Pebanc
    {
        [Key]
        public string Pebancstamp { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Conta { get; set; }
        public string Nib { get; set; }
        public string Swift { get; set; }
        public bool Padrao { get; set; }
        public string Obs { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
