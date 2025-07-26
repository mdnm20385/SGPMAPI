using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Vtcfg
    {
        [Key]
        public string Vtcfgstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public bool Feito { get; set; }
        public string Vtstamp { get; set; }
        public string Distamp { get; set; }
        public string Matricula { get; set; }
        public decimal Valor2 { get; set; }
        public virtual Vt Vt { get; set; }
    }
}
