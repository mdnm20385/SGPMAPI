using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Rdf
    {
        [Key]
        public string Rdfstamp { get; set; }
        public decimal Numero { get; set; }
        public DateTime data { get; set; }
        public decimal no { get; set; }
        public string nome { get; set; }
        public string moeda { get; set; }
        public string Banco { get; set; }
        public decimal Total { get; set; }
        public decimal Mtotal { get; set; }
        public string Obs { get; set; }
        public string Bancoprov { get; set; }
        public string Titulo { get; set; }
        public string Numtitulo { get; set; }
        public string Ccusto { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Nomedoc { get; set; }
        public decimal Codmovcc { get; set; }
        public string Descmovcc { get; set; }
        public bool Anulado { get; set; }

        public virtual ICollection<Fcc> Fcc { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Rdfl> Rdfl { get; set; }
    }
}
