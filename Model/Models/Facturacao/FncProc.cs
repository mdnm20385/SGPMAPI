using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class FncProc
    {
        [Key]
        public string FncProcstamp { get; set; }
        [ForeignKey("Fnc")]
        public string Fncstamp { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Avaliacao { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Criterio { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Grau { get; set; }
        public virtual Fnc Fnc { get; set; }
    }
}
