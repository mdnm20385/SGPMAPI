using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Paises
    {
        [Key]
        public string Paisestamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
