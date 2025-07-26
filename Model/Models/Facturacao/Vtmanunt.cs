using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Vtmanunt
    {
        [Key] 
        public string Vtmanuntstamp { get; set; }
        public string Matricula { get; set; }
        public DateTime Data { get; set; }
        public decimal Km { get; set; }
        public string Motorista { get; set; }
    }
}
