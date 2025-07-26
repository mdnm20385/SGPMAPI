using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class EmpresaMod
    {
        [Key]
        public string EmpresaModstamp { get; set; }
        [ForeignKey("Empresa")]
        public string Empresastamp { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public DateTime Validade { get; set; }
        public bool Trial { get; set; } = false;
        public string Obs { get; set; }
        public virtual Empresa  Empresa { get; set; }
    }
}
