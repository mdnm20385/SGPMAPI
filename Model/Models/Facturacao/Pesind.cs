using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Pesind
    {
        [Key]
        public string Pesindstamp { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public decimal Perc { get; set; }      
        public decimal Valor { get; set; }  
        [MaxLength(500)]
        public string Obs { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
