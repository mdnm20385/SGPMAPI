using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Vtoleos
    {
        [Key]
        public string Vtoleosstamp { get; set; }
        public string Descricao { get; set; }
        public string Reforig { get; set; }
        public string Outraref1 { get; set; }
        public string Outraref2 { get; set; }
        public string Outraref3 { get; set; }
        public string Outraref4 { get; set; }
        public decimal Codigo { get; set; }
        public string Vtstamp { get; set; }
        public virtual Vt Vt { get; set; }
    }
}
