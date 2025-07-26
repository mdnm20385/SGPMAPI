using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class FactConcet
    {
        [Key]
        public string FactConcetstamp { get; set; }
        public string UsrCode { get; set; }
        public decimal Quant { get; set; }
        public string Bomba { get; set; }
        public string Bico { get; set; }
        public decimal Preco { get; set; }
        public string Combustivel { get; set; }
        public string Tipocomb { get; set; }
    }
}
