using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Rdl
    {
        [Key]
        public string Rdstamp { get; set; }
        public decimal Ordem { get; set; }
        public string Descricao { get; set; }
        public decimal valorl { get; set; }
        public decimal Mvalorl { get; set; }
        public string Rdlstamp { get; set; }
        public bool Status { get; set; }

        public virtual Rd Rd { get; set; }
    }
}
