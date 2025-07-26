using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class PjRh
    {
        [Key]
        public string PjRhstamp { get; set; }
        public string Referencia { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public decimal Custo { get; set; }
        public DateTime Dataini { get; set; }
        public DateTime DataFim { get; set; }
        public int Dias { get; set; }
        public decimal Total { get; set; }
        public decimal No { get; set; }
        public decimal ValBasico { get; set; }
        public string Pjstamp { get; set; }
        public virtual Pj Pj { get; set; }

    }
}