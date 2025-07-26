using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Numdocs
    {
        [Key]
        public string Numdocsstamp { get; set; }
        public string Oristamp { get; set; }
        public string Sigla { get; set; }
        public string CCusto { get; set; }
        public string Codccu { get; set; }
        public decimal Numero { get; set; }
    }
}
