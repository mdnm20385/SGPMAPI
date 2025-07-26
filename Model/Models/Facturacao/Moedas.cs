using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Moedas
    {
        [Key]
        public string Moedasstamp { get; set; }
        public string Moeda { get; set; }
        public string Descricao { get; set; }
        public string Pais { get; set; }
        public bool Princip { get; set; }
    }
}
