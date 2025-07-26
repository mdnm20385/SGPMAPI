using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Situacao
    {
        [Key]
        public string Situacaostamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Padrao { get; set; }
    }
}
