using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Escaladeservico
    {
        [Key]
        public string Escaladeservicostamp { get; set; }
        public string Nome { get; set; }
        //public DateTime HorarioInicio { get; set; }
        //public DateTime HorarioFim { get; set; }
        public string Situacao { get; set; }
        public string departamento { get; set; }
        public string CCusto { get; set; }
        public string Pestamp { get; set; }
        public string Descricao { get; set; }
        public string Codccu { get; set; }
        //public string CCusto { get; set; }
        public string Ccustamp { get; set; }
        public string Turno { get; set; }
        public string ServiTurnostamp { get; set; }      
        public string Corredor { get; set; }
        // public string Escalalstamp { get; set; }

        public virtual ICollection<Escalal> Escalal { get; set; }
    }
}
