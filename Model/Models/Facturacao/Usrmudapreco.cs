using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Usrmudapreco
    {
        [Key]
        public string Usrmudaprecostamp { get; set; }
        [ForeignKey("Usrstamp")]
        public string Usrstamp { get; set; }
        public string Usrvenda { get; set; }
        public string Usrsupervidor { get; set; }
        public string Referenc { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Preco { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Precoalter { get; set; }
        public DateTime Data { get; set; }
        public string Docstamp { get; set; }
        public string Origem { get; set; }
        public virtual Usr Usr { get; set; }
    }
}
