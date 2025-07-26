using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Pjvt
    {
        [Key]
        public string Pjvtstamp { get; set; }
        public string Referenc { get; set; }
        public string Descricao { get; set; }
        public decimal Custo { get; set; }
        public decimal Quant { get; set; }
        public decimal Total { get; set; }
        public string Pjstamp { get; set; }
        public virtual Pj Pj { get; set; }
    }
}
