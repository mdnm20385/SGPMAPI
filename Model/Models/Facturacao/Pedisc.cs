using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pedisc
    {
        [Key]
        public string Pediscstamp { get; set; }
        public string Disciplina { get; set; }
        public string Sigla { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public string Ststamp { get; set; }
        public virtual Pe Pe { get; set; }
    }
}