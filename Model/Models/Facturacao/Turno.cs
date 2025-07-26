using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Turno
    {
        [Key]
        public string Turnostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime Horain { get; set; }
        public DateTime Horafim { get; set; }
        public DateTime Intervaloin { get; set; }
        public DateTime Intervalofim { get; set; }
        [MaxLength(2100)]
        public string Obs { get; set; }
    }
}
