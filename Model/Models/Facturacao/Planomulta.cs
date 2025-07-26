using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Planomulta
    {
        [Key]
        public string Planomultastamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Anosem { get; set; }
        public string Anosemstamp { get; set; }
        public virtual ICollection<Planomultal> Planomultal { get; set; }
    }
}
