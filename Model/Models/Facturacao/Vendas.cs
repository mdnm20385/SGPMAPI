using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Vendas
    {

        [Key]
        public string Vendasstamp { get; set; }
        public string Descricao { get; set; }
        public string CodBlilhete { get; set; }
        public string Nrdoc { get; set; }
        public DateTime Data { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Entrada { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Saida { get; set; }
        public string Clstamp { get; set; }
        public string Ststamp { get; set; }
        public string Factlstamp { get; set; }
        public string Tdocstamp { get; set; }
        public string Oristamp { get; set; }//Entra tdocstamp
        public string ClCartstamp { get; set; }
    }
}
