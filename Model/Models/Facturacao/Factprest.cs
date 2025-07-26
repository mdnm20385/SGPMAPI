using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Factprest
    {
        [Key]
        public string Factpreststamp { get; set; }
        public string Factstamp { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Perc { get; set; }
        public decimal Valor { get; set; }
        public string Obs { get; set; }
        public bool Status { get; set; }

        public virtual Fact Fact { get; set; }
    }
}
