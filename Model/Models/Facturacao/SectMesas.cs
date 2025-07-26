using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class SectMesas
    {
        [Key]
        public string Sectmesasstamp { get; set; }
        public string Mesasstamp { get; set; }
        public string Descricao { get; set; }
        [ForeignKey("Sector")]
        public string Sectorstamp { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
