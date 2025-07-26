using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pefunc
    {
        [Key]
        [StringLength(30)]
        public string Pefuncstamp { get; set; }
        public string Funcao { get; set; }
        public string Tipo { get; set; }
        public string Local { get; set; }
        public DateTime DataIn { get; set; }
        public DateTime Datafim { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
