using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Dirdep
    {
        [Key]
        public string Dirdepstamp { get; set; }
        public string Dirstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual Dir Dir { get; set; }
        public virtual List<EmailClass> EmailClass { get; set; } = new List<EmailClass>();//Departamentos
    }
}
