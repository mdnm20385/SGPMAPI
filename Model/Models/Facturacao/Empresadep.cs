using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Empresadep
    {
        [Key]
        public string Empresadepstamp { get; set; }
        [ForeignKey("Empresa")]
        public string Empresastamp { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public string Obs { get; set; }
        public virtual Empresa  Empresa { get; set; }
    }
}
