using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Rd
    {
        [Key]
        public string Rdstamp { get; set; }
        public decimal Numero { get; set; }
        public DateTime Data { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public string Moeda { get; set; }
        public string Banco { get; set; }
        public decimal Total { get; set; }
        public decimal Mtotal { get; set; }
        public string Obs { get; set; }
        public string bancoprov { get; set; }
        public bool anulado { get; set; }
        public string ccusto { get; set; }
        public decimal numdoc { get; set; }
        public string sigla { get; set; }
        public string Nomedoc { get; set; }
        public decimal Codmovcc { get; set; }
        public string Descmovcc { get; set; }
        public string Nomecomerc { get; set; }
        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        public decimal Estabno { get; set; }
        public string Estabnome { get; set; }
        public virtual ICollection<Cc> Cc { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Rdl> Rdl { get; set; }
    }
}
