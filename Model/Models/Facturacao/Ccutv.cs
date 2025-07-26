using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Ccutv
    {
        [Key]
        public string Ccutvstamp { get; set; }
        [ForeignKey("CCu")]
        public string Ccustamp { get; set; }

        public decimal Codigo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }

        public decimal Codarm { get; set; }
        public string Armazem { get; set; }//Armazem Padrao do Terminal

        public bool Tervendsusp { get; set; }//Termina Vendas suspensas noutro pos
        public virtual CCu CCu { get; set; }
        public virtual ICollection<Ccutvdoc> Ccutvdoc { get; set; }
        public virtual ICollection<Ccutvdocdi> Ccutvdocdi { get; set; }
    }
}
