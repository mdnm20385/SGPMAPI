using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Cpoc
    {
        [Key]
        public string Cpocstamp { get; set; }
        public decimal Codcpoc { get; set; }
        public decimal Nrdoc { get; set; }
        public string Documento { get; set; }
        public string Codccu { get; set; }
        public string Ccusto { get; set; }
        public string Descricao { get; set; }
        public string Qmc { get; set; }
        public DateTime Qmcdathora { get; set; }
        public string Qma { get; set; }
        public DateTime Qmadathora { get; set; }
        public bool Servico { get; set; }
        public virtual ICollection<CpocCompra> CpocCompra { get; set; }
        public virtual ICollection<CpocVend> CpocVend { get; set; }
    }
}
