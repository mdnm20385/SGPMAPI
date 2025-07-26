using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Rdfl
    {
        [Key]
        public string Rdflstamp { get; set; }
        public decimal Ordem { get; set; }
        public string Descricao { get; set; }
        public decimal Valorl { get; set; }
        public decimal Mvalorl { get; set; }
        public string Rdfstamp { get; set; }
        
        public bool Status { get; set; }

        public virtual Rdf Rdf { get; set; }
    }
}
