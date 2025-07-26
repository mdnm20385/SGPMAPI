using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Fing //Formas de Ingresso 
    {
        [Key]
        public string Fingstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
