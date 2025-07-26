using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Combustivel
    {
        [Key]
        public string Combustivelstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Tipo { get; set; }
    }
}
