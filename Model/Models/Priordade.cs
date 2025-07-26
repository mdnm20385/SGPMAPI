using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Priordade
    {
        [Key]
        public string Priordadestamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }

        public bool Padrao { get; set; }
    }
}
