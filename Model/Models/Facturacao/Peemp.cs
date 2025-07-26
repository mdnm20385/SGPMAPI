using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Peemp
    {
        [Key]
        public string Peempstamp { get; set; }
        public decimal Codigo { get; set; }
        public decimal Valor { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Mesin { get; set; }
        public decimal Numprest { get; set; }
        public bool Devsal { get; set; }
        public bool Devolvido { get; set; }
        public string Pestamp { get; set; }
        [StringLength(250)]
        public string Obs { get; set; }
        public decimal Codmes { get; set; }
        public decimal Saldo { get; set; }
        public decimal Ano { get; set; }
        public string Moeda { get; set; }
        public string Banco { get; set; }
        public string Contatesoura { get; set; }
        public string Titulo { get; set; }
        public string Numtitulo { get; set; }
        public virtual ICollection<Peempl> Peempl { get; set; }
    }
}
