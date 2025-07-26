using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClCart
    {
        [Key]
        public string ClCartstamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Datavenc { get; set; }
        public bool Produzido { get; set; }
        public bool Entregue { get; set; }
        public DateTime Dataentrega { get; set; }
        public string Usrentrega { get; set; }
        public decimal Quantidade { get; set; }
        public virtual Cl Cl { get; set; }
    }
}