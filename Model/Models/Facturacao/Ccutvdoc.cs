using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Ccutvdoc
    {
        [Key]
        public string Ccutvdocstamp { get; set; }
        [ForeignKey("Ccutv")]
        public string Ccutvstamp { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public bool Padrao { get; set; }
        public virtual Ccutv Ccutv { get; set; }
    }
}
