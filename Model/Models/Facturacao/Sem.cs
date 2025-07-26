using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Sem
    {
        [Key]
        public string Semstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Ordem { get; set; }
        public virtual ICollection<Gradel> Gradel { get; set; }//Linhas das grades do curso 
    }
}
