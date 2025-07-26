using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Auxiliar2
    {
        [Key]
        public string Auxiliar2stamp { get; set; }
        [ForeignKey("Auxiliar")]
        public string Auxiliarstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public bool Nacional { get; set; }
        public string Ccustamp { get; set; }
        public string Ccusto { get; set; }
        public virtual Auxiliar Auxiliar { get; set; }
    }
}
