using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Reserval
    {
        [Key]
        public string Reservalstamp { get; set; }
        public string Mesastamp { get; set; }//Corresponde a Clstamp
        public string Referenc { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Quant { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Valor { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Totall { get; set; }
        public DateTime Din { get; set; }
        public DateTime Dfim { get; set; }
        public DateTime Hin { get; set; }
        public DateTime Hfim { get; set; }
        [ForeignKey("Reserva")]
        public string Reservastamp { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}
