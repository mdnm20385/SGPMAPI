using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Unimesal
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Unimesalstamp { get; set; }
        [ForeignKey("Unimesa")]
        public string Unimesastamp { get; set; }
        public string Messastamp { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Total { get; set; }
        public virtual Unimesa Unimesa { get; set; }
    }
}
