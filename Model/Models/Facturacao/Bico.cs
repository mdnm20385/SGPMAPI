using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Bico
    {
        [Key]
        public string Bicostamp { get; set; }
        public decimal Codigo { get; set; }
        public string Codigoconc { get; set; }//Codigo do bico no concetrador 
        public string Armazemstamp { get; set; }
        public string Armazem { get; set; }//Tanque de combustivel 
        public string Combustivel { get; set; }
        public string Cor { get; set; }
        public decimal IipoCombustivel { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Encerrante { get; set; }
    }
}
