using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class ProcessoClinic
    {
        [Key]
        public string ProcessoClinicstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public decimal Numero { get; set; }
        public DateTime Data { get; set; }
        public DateTime Dataven { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Pestamp { get; set; }
        public decimal Tipo { get; set; }
        public virtual ICollection<Processol> Processol { get; set; }
    }
}
