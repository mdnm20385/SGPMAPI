using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Tirps
    {
        [Key]
        public string Tirpsstamp {get;set;}
        public string Codigo {get;set;}
        public string Descricao {get;set;}
        public bool Padrao { get; set; }
        public virtual ICollection<Tirpsl> Tirpsl { get; set; }
    }
}
