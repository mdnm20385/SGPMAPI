using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Transp
    {
        [Key]
        public string Transpstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Transpvt> Transpvt { get; set; }
    }
}
