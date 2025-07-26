using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Mesas
    {
        [Key]
        public string Mesasstamp { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public decimal TopImg { get; set; }
        public decimal LeftImg { get; set; }
        public string Obs { get; set; }
        public string Codigo { get; set; }
        public bool Status { get; set; }
    }
}
