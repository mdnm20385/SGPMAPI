using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Instunid
    {
        [Key]
        public string Instunidstamp { get; set; }
        [ForeignKey("Inst")]
        public string Inststamp { get; set; }
        public string Codesc { get; set; }
        public string Codunid { get; set; }
        public string Descricao { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public virtual Inst Inst { get; set; }
        public virtual ICollection<Instunidl> Instunidl { get; set; }
    }
}
