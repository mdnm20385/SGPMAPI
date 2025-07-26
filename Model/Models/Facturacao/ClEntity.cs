using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class ClEntity
    {
        [Key]
        public string ClEntitystamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Representante Legal
        public bool Rep { get; set; }
        // Usado em modulo escolar
        public string Profissao { get; set; }
        public string Clstamp1 { get; set; }
        public virtual Cl Cl { get; set; }
    }
}
