using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class EscalaPeriodo
    {
        [Key]
        public string EscalaPeriodostamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public decimal Col { get; set; }
        public string Obs { get; set; }
    }
}
