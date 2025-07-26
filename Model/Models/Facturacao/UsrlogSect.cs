using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class UsrlogSect
    {
        [Key]
        public string UsrlogSectstamp { get; set; }

        [ForeignKey("Usrstamp")]
        public string Usrstamp { get; set; }
        public DateTime  EntradaDataHora { get; set; }
        public DateTime?  SaidaDataHora { get; set; }
        [MaxLength(10000)]
        public string ObsUsrPw { get; set; }
        [MaxLength(10000)]
        public string ObsfielUsrname { get; set; }
        [MaxLength(10000)]
        public string Obs { get; set; }
        public virtual Usr  Usr { get; set; }
    }
}
