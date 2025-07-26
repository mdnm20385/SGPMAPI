using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Unimesa//Uniao de Mesas 
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Unimesastamp { get; set; }
        public string Clstamp { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Unimesal> Unimesal { get; set; }
    }
}
