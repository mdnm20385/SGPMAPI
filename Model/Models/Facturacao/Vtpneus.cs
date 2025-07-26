using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Vtpneus
    {
        [Key]
        public string Vtpneusstamp { get; set; }
        public string Descricao { get; set; }
        public decimal Numero { get; set; }
        public DateTime Dataent { get; set; }
        public DateTime Datasaida { get; set; }
        public string Posicao { get; set; }
        public string Vtstamp { get; set; }
        public string Distamp { get; set; }
        public virtual Vt Vt { get; set; }
    }
}
