using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public  class Docmodulo
    {
        [Key]
        public string Docmodulostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool? Estado { get; set; } = false;
        [ForeignKey("Rlt")]
        public string Rltstamp { get; set; } = null;
        [ForeignKey("Tdi")]
        public string Tdistamp { get; set; } = null;
        [ForeignKey("Tdoc")]
        public string Tdocstamp { get; set; }= null;
        [ForeignKey("Tdocf")]
        public string Tdocfstamp { get; set; }= null;
        public virtual Tdi Tdi { get; set; }
        public virtual Tdocf Tdocf { get; set; }
        public virtual Tdoc Tdoc { get; set; }
        public virtual Rlt Rlt { get; set; }
    }
}
