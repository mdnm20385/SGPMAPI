using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Ccudep
    {
        [Key]
        public string Ccudepstamp { get; set; }
        [ForeignKey("CCu")]
        public string Ccustamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual CCu CCu { get; set; }
    }
}