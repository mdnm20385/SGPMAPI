using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Tarefadi
    {
        [Key]
        public string Tarefadistamp { get; set; }
        [ForeignKey("Tarefa")]
        public string Tarefastamp { get; set; }
        public bool Responsavel { get; set; }   = false;
        public string Codigo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public virtual  Tarefa Tarefa { get; set; }
        public string? Dirstamp { get; set; } = string.Empty;
    }
}
