using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Procedimento
    {
        [Key]
        public string Procedimentostamp { get; set; }
        public decimal Valor { get; set; }
        public decimal Tempo { get; set; }
        public string Obs { get; set; }
        public bool Convenio { get; set; }
        public bool Exame { get; set; }
        public string Descricao { get; set; }
    }
}
