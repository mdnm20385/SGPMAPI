using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class HoraExtra
    {
        [Key]
        public string HoraExtrastamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal Tipo { get; set; }
    }
}
