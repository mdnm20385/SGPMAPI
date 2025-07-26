using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Instunidl
    {
        [Key]
        public string Instunidlstamp { get; set; }
        [ForeignKey("Instunid")]
        public string Instunidstamp { get; set; }
        public string Coduni { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public virtual Instunid Instunid { get; set; }

    }
}
