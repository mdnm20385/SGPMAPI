using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class FncContact
    {
        [Key]
        public string FncContactstamp { get; set; }
        [ForeignKey("Fnc")]
        public string Fncstamp { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //Representante Legal
        public bool Rep { get; set; }
        // Pessoa de Cobrancas 
        public bool Cob { get; set; }
        public virtual Fnc Fnc { get; set; }
    }
}
