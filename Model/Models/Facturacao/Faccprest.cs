using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Faccprest
    {
        [Key]
        public string Faccpreststamp { get; set; }
        [ForeignKey("Facc")]
        public string Faccstamp { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Perc { get; set; }
        public decimal Valor { get; set; }
        public string Obs { get; set; }
        public bool Status { get; set; }

        public virtual Facc Facc { get; set; }
    }
}
