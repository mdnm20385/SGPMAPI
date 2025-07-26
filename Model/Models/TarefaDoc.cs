using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Model.Models
{
    public class TarefaDoc
    {
        [Key]
        public string TarefaDocstamp { get; set; }
        [ForeignKey("Tarefadoc")]
        public string Tarefastamp { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Directório")]
        public string Path { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;
        public virtual  Tarefa Tarefa { get; set; }

        [Required(ErrorMessage = "Please choose the Profile Photo")]
        [Display(Name = "Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }

    }
}
