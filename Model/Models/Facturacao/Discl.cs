using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Stl
    {
        [Key]
        public string Stlstamp { get; set; }
        public string Ststamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual St St { get; set; }
    }
}
