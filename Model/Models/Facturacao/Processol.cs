using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Processol
    {
        [Key]
        public string Processolstamp { get; set; }
        public string ProcessoClinicstamp { get; set; }
        public string Ref { get; set; }
        public string Descricao { get; set; }
        public DateTime Datain { get; set; }
        public DateTime Datafim { get; set; }
        public decimal Dias { get; set; }
        public virtual ProcessoClinic ProcessoClinic { get; set; }
    }
}
