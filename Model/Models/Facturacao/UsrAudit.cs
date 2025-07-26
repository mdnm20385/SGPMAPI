using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class UsrAudit
    {
        [Key]
        public string UsrAuditstamp { get; set; }

        [ForeignKey("Usrstamp")]
        public string Usrstamp { get; set; }
        public string Oristamp { get; set; }
        public DateTime DataAdd { get; set; }
        public DateTime DataUpd { get; set; }
        public string FormName { get; set; }
        public string DocName { get; set; }
        public string DocSigla { get; set; }
        public decimal DocNumero { get; set; }
        [StringLength(3000)] 
        public string Coment { get; set; }//Obsercacao 
        [DecimalPrecision(18, 2, true)]
        public decimal Total { get; set; } 
        public virtual Usr Usr { get; set; }
    }
}
