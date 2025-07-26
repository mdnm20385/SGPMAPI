using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class Tarefajob
    {
        [Key]
        public string Tarefajobstamp { get; set; }
        public string Tarefastamp { get; set; }
        public bool Responsavel { get; set; }
        public string Codigo { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Datain { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Datafim { get; set; } = DateTime.Now;

        public virtual Tarefa Tarefa { get; set; }
        public virtual List<Tarefadep> Tarefadep { get; set; } = new();//Actividades da Tarefa 

    }
}
