using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Pesub
    {
        [Key]
        public string Pesubstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16,2,true)]
        public decimal Valor { get; set; }
        public decimal Tipo { get; set; }
        public decimal Tiposub { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public DateTime Datain { get; set; }
        public DateTime Datafim{ get; set; }
        public bool ExcluiProc { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
