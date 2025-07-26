using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Tarefadep
    {
        [Key]
        public string Tarefadepstamp { get; set; }
        [ForeignKey("Tarefajob")]
        public string Tarefajobistamp { get; set; }
        public bool Responsavel { get; set; }   = false;
        public string Codigo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public virtual  Tarefajob Tarefajob { get; set; }

    }
}
