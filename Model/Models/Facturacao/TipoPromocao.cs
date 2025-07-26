using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class TipoPromocao
    {
        [Key]
        public string TipoPromocaostamp { get; set; }
        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Obs { get; set; }
    }
}
