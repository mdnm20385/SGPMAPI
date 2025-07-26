using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Alteracmes
    {
        [Key]
        public string Alteracmesstamp { get; set; }
        public string Pestamp { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Periodo { get; set; }
        public decimal Nrmes { get; set; }
        public string Mes { get; set; }
        public DateTime Datain { get; set; }
        public DateTime Datater { get; set; }
        public virtual ICollection<Pehextra> Pehextra { get; set; }
        public virtual ICollection<Pefalta> Pefalta { get; set; }
        public virtual ICollection<Pesub> Pesub { get; set; }
        public virtual ICollection<Pedesc> Pedesc { get; set; }
    }
}
