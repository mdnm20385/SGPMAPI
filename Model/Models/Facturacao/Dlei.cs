using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Dlei
    {
        [Key]
        public string Dleistamp { get; set; }
        public decimal Codigo { get; set; }
        [MaxLength(2000)]
        public string Descricao { get; set; }
        public decimal Ano { get; set; }
        public string Conta { get; set; }
        public string Depmapa { get; set; }
        public string Reavmapa { get; set; }
        [DecimalPrecision(5, 2,true)]
        public decimal Perc { get; set; }//Valor depreciavel 

    }
}
