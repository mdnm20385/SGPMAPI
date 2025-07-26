using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class BombaBico
    {
        [Key]
        public string BombaBicostamp { get; set; }
        [ForeignKey("Bomba")]
        public string Bombastamp { get; set; }
        public string Bicostamp { get; set; }
        public string Descricao { get; set; }//Descricao do Bico 
        public decimal IipoCombustivel { get; set; }//Codigo de combustivel 
        public virtual Bomba Bomba { get; set; }
    }
}
