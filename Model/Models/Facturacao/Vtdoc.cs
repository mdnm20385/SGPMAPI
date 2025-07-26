using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Vtdoc
    {
        [Key]
        public string Vtdocstamp { get; set; }
        public string Numdoc { get; set; }
        public string Tipodoc { get; set; }
        public string Entidade { get; set; }
        public DateTime Datain { get; set; }
        public DateTime Datatermino { get; set; }
        public byte[] Anexo { get; set; }
        public string Vtstamp { get; set; }
        public virtual Vt Vt { get; set; }
    }
}
