using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class ServiTurno
    {
        [Key]
        public string ServiTurnostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string sigla { get; set; }
        public decimal Capacidade { get; set; }
        public DateTime Horainicio { get; set; }
        public DateTime horafim { get; set; }
    }
}
