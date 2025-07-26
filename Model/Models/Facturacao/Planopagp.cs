using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Planopagp//Plano de pagamento parcelas 
    {
        [Key]
        public string Planopagpstamp { get; set; }
        [ForeignKey("Planopag")]
        public string Planopagstamp { get; set; }
        public decimal Ordem { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Parecela { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Valorbruto { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Valordesc { get; set; }//valor Desconto 
        [DecimalPrecision(16, 0, true)]
        public decimal Valorextra { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Valordescextra { get; set; }//Valor desconto extra 
        [DecimalPrecision(16, 0, true)]
        public decimal ValorTotal { get; set; }//Valor Total 
        public string Titulo { get; set; }
        public bool Pzerro { get; set; }//Parcela Zerro
        public virtual Planopag Planopag { get; set; }
    }
}