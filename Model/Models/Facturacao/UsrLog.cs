using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class UsrLog
    {
        [Key]
        public string UsrLogstamp { get; set; }
        [ForeignKey("Usrstamp")]
        public string Usrstamp { get; set; }
        public DateTime  EntradaDataHora { get; set; }
        public DateTime  SaidaDataHora { get; set; }
        public bool  FirstLogin { get; set; }
        public decimal Valor { get; set; }
        public string Corredor { get; set; }
        public string Corredorstamp { get; set; }
        public string Sentidostamp { get; set; }
        public string Sentido { get; set; }
        public string Carreira { get; set; }
        public string Cobradorstamp { get; set; }
        public decimal Estado { get; set; }
        public decimal Codigo { get; set; }
        public string Matricula { get; set; }
        public string Viaturastamp { get; set; }
        public string Carreirastamp { get; set; }
        public virtual Usr  Usr { get; set; }
    }
}
