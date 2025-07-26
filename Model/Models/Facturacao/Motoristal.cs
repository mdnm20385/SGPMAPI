using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Motoristal
    {
        [Key]
        public string Motoristalstamp { get; set; }
        public string Motoristastamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual Motorista Motorista { get; set; }
    }
}
