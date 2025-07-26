using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Falta
    {
        [Key]
        public string Faltastamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public bool DescontaSubAlimenta { get; set; }
        public bool DescontaSubPorTurno { get; set; }
    }
}
