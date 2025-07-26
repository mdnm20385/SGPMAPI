using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Peempl
    {
        [Key]
        public string Peemplstamp { get; set; }
        public decimal Codigo { get; set; }
        public decimal Valor { get; set; }
        public string Mespagar { get; set; }
        public decimal Ano { get; set; }
        public decimal Nummes { get; set; }
        public decimal Pago { get; set; }
        public DateTime Ultdevol { get; set; }
        public decimal Saldo { get; set; }
        public bool Devolvido { get; set; }
        [ForeignKey("Peemp")]
        public string Peempstamp { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Nrdoc { get; set; }
        public string Moeda { get; set; }
        public string Banco { get; set; }
        public string Contatesoura { get; set; }
        public string Titulo { get; set; }
        public string Numtitulo { get; set; }
        public decimal Codtz { get; set; }
        public virtual Peemp Peemp { get; set; }
        public virtual ICollection<Peempcc> Peempcc { get; set; }
        //public virtual ICollection<Prcemp> Prcemp { get; set; }
    }
}
