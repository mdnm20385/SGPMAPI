using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class EscalaPe
    {
        [Key]
        public string EscalaPestamp { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public DateTime Dataem { get; set; }
        public string Situacao { get; set; }
        public string departamento { get; set; }
        public string CCusto { get; set; }
       // public string Pestamp { get; set; }
        public string Codccu { get; set; }
        //public string CCusto { get; set; }
        public string Ccustamp { get; set; }
        public virtual ICollection<EscalaPeLL> EscalaPeLL { get; set; }
        public virtual ICollection<EscalaPeL> EscalaPeL { get; set; }        
    }
}
