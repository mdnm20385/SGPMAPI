using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Bomba
    {
        [Key]
        public string Bombastamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public decimal Codmedicao  { get; set; }
        public decimal Totalizador { get; set; }
        public string Medicao { get; set; }
        public string Serie { get; set; }
        public string Armazemstamp { get; set; }
        public string Armazem { get; set; }
        public virtual ICollection<BombaBico> Bico { get; set; }
    }
}
