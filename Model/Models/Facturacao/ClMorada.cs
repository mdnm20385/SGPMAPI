using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClMorada
    {
        [Key]
        public string ClMoradastamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string Departamento { get; set; }
        public string Morada { get; set; }
        public string Pessoa { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual Cl Cl { get; set; }
    }
}
