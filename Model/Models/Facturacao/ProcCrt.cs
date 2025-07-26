using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ProcCrt
    {
        [Key]
        public string ProcCrtstamp { get; set; }
        [ForeignKey("Procurm")]
        public string Procurmstamp { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Criterio { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Grau { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Avaliacao { get; set; }

        public virtual Procurm Procurm { get; set; }
    }
}
