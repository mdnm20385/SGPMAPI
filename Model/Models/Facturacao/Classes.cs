using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Clas//Classe de comboios 
    {
        [Key]
        public string Classtamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Padrao { get; set; }
    }
}
