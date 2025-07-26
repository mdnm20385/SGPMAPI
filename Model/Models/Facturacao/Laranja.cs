using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Laranja
    {
        [Key]
        public string Laranjastamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
