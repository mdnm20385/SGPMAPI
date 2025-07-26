using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClLing
    {
        [Key]
        public string ClLingstamp { get; set; }
        [ForeignKey("Cl")]
        public string Lingua { get; set; }
        public string Fala { get; set; }
        public string Leitura { get; set; }
        public string Escrita { get; set; }
        public string Compreecao { get; set; }
        public bool Materna { get; set; }
        public string Clstamp { get; set; }
        public virtual Cl Cl { get; set; }
    }
}