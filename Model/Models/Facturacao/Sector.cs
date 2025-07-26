using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Sector
    {
        [Key]
        public string Sectorstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<SectMesas> Mesas { get; set; }
    }
}
