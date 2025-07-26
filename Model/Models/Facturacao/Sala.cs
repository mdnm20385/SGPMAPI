using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Sala
    {
        [Key]
        public string Salastamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Capacidade { get; set; }
    }
}
