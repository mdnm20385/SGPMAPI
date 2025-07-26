using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Mescont
    {
        [Key]
        public string Mescontstamp { get; set; }
        public string Codigo { get; set; }
        public string Nomemes { get; set; }
        public string Mes { get; set; }
    }
}
