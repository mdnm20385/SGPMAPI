using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Teste
    {
        [Key]
        public string Testestamp { get; set; }
        public string descricao { get; set; }
    }
}
