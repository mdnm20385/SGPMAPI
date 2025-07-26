using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Inst
    {
        [Key]
        public string Inststamp { get; set; }
        public string Codesc { get; set; }
        public string Descricao { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public virtual ICollection<Instunid> Instunid { get; set; }
    }
}
