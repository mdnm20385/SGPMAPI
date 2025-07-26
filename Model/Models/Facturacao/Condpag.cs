using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Condpag//Condicoes de Pagamento 
    {
        [Key]
        public string Condpagstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Cliente { get; set; }
        public bool Forn { get; set; }
        public decimal Dias  { get; set; }
        public virtual ICollection<Condpagl> Condpagl { get; set; }
    }
}
