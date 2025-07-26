using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class FncBomb
    {
        [Key]
        public string Fncbombstamp { get; set; }
        [ForeignKey("Fnc")]
        public string Fncstamp { get; set; }
        public string No { get; set; }
        public string Descricao { get; set; }
        public virtual Fnc Fnc { get; set; }

    }
}
