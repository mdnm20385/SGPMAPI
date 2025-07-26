using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Vend
    {
        [Key]
        public string Vendstamp { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public string Nuit { get; set; }
        public decimal Codccu { get; set; }
        public string CCusto { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
        public string Tipo { get; set; }
        public string Obs { get; set; }
        public string Status { get; set; }
    }
}
