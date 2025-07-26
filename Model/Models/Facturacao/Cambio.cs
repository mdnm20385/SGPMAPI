using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Cambio
    {
        [Key]
        public string Cambiostamp { get; set; }

        [Required]
        public string Moeda { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [DecimalPrecision(14, 2,true)]
        public decimal Compra { get; set; }
        [DecimalPrecision(14, 2,true)]
        public decimal Venda { get; set; }
    }
}
