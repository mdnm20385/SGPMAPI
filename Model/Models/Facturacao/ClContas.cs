using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class ClContas
    {
        [Key]
        public string ClContasstamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Moeda { get; set; }
        [DecimalPrecision(16, 0,true)]
        public decimal Numero { get; set; }
        public string Banco { get; set; }
        public string Nib { get; set; }
        public string Swift { get; set; }
        public string Iban { get; set; }
        public virtual Cl Cl { get; set; }
    }
}
