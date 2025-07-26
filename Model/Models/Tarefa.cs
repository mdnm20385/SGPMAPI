using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Model.Models
{
    public class Tarefa
    {
        [Key] public string Tarefastamp { get; set; } 

        public decimal Numero { get; set; } = 0;
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Descrição da Tarefa")]
        public string Descricao { get; set; } = string.Empty;
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Notas De Fecho")]
        public string? NotaFecho { get; set; } = string.Empty;
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyy}")]
        public DateTime Datain { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Datafim { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Datafimesperado { get; set; } = DateTime.Now;
        [Precision(16, 2)]
        public decimal Total { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        [Display(Name = "Observação")]
        public string Obs { get; set; }=string.Empty;
        public decimal Prazo { get; set; } = 0;
        public string Prioridade { get; set; } = string.Empty;//Urgente,Confidencial, Media, Baixa 
        [Display(Name = "Situação")]
        public string Situacao { get; set; } = string.Empty;//Em andamento, fechado 
        public virtual List<Tarefadi> Tarefadi { get; set; } = new();//Direcoes que recebem a tarefa 
        public virtual List<Tarefajob> Tarefajob { get; set; } = new();//Actividades da Tarefa 
        public virtual List<TarefaDoc> TarefaDoc { get; set; } = new();//Documentos da Tarefa 
    }
}
