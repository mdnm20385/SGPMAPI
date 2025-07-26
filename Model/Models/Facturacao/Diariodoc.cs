using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Diariodoc
    {
        [Key]
        public string Diariodocstamp { get; set; }
        [ForeignKey("Diario")]
        public string Diariostamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Padrao { get; set; }
        public virtual Diario Diario { get; set; }
    }
}
