using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Fpagam
    {
        [Key]
        public string Fpagamstamp { get; set; }

        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Tipo { get; set; }
        public bool ObgTitulo { get; set; }
        public bool Pos { get; set; }
        public bool Numer { get; set; }

    }
}
