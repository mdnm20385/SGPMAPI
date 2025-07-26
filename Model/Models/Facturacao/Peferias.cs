using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Peferias
    {
        [Key]
        public string Peferiasstamp { get; set; }
        public string Pestamp { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public decimal Dias { get; set; }
        public decimal Ano { get; set; }
        public bool Estado { get; set; }
        public bool Status { get; set; }
        public virtual Pe Pe { get; set; }

    }
}
