using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Familiapb
    {
        [Key]
        public string Familiapbstamp { get; set; }
        [ForeignKey("Familia")]
        public string Familiastamp { get; set; }
        public string Codigo { get; set; }
        public string Order { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Preco { get; set; }
        public bool Bagagem { get; set; }
        public virtual Familia Familia { get; set; }
    }
}