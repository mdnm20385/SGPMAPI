using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class StVtdoc
    {
        [Key]
        public string StVtdocstamp { get; set; }
        public string Numdoc { get; set; }
        public string Tipodoc { get; set; }
        public string Entidade { get; set; }
        public DateTime Datain { get; set; }
        public DateTime Datatermino { get; set; }
        public decimal Premio { get; set; }
        public decimal Franquia { get; set; }
        public byte[] Anexo { get; set; }
        [ForeignKey("St")]
        public string Ststamp { get; set; }
        public virtual St St { get; set; }
    }
}
