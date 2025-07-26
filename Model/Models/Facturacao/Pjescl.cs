using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Pjescl
    {
        [Key] 
        public string Pjesclstamp { get; set; }
        public string Pjescstamp { get; set; }
        [MaxLength(800)]
        public string Actividade { get; set; }
        public string Resp { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Pretermino { get; set; }
        public DateTime Termino { get; set; }
        public decimal Perc { get; set; }
        public bool Factura { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public virtual Pj Pj { get; set; }
    }
}
