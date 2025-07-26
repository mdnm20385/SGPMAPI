using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Feriadol
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Feriadolstamp { get; set; }
        [ForeignKey("Feriado")]
        public string Feriadostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual Feriado Feriado { get; set; }
    }
}
