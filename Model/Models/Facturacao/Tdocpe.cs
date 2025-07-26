using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Tdocpe
    {
        [Key]
        public string Tdocpestamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public decimal Tipo { get; set; }
        public string Nomfile { get; set; }
        public bool Defa { get; set; }
    }
}
