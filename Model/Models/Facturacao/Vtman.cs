using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Vtman
    {
        [Key]
        public string Vtmanstamp { get; set; }
        public string Matricula { get; set; }
        public decimal Valparam { get; set; }
        public decimal Valkm { get; set; }
        public decimal Diferenca { get; set; }
        public bool Feito { get; set; }
        public string Vtstamp { get; set; }
        public string Distamp { get; set; }
        public virtual Vt Vt { get; set; }
    }
}
