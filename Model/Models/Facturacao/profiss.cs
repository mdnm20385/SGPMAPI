using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Profiss
    {
        [Key]
        [StringLength(30)]
        public string Profissstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
