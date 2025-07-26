using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Escalal
    {
        [Key]
        public string Escalalstamp { get; set; }

        [ForeignKey("Escaladeservico")]
        public string Escaladeservicostamp { get; set; }

        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        public bool ExcluiProc { get; set; }
        public bool ExcluiEstat { get; set; }
        public bool DescontaVenc { get; set; }
        public bool DescontaRem { get; set; }
        public decimal NumPeriodoProcessado { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal ValorDescontado { get; set; }
        public decimal AnoProcessado { get; set; }
        public decimal NumProc { get; set; }
        public bool DescontaSubsTurno { get; set; }
        public bool SubAlimProporcional { get; set; }
        public decimal Horas { get; set; }
        public decimal Injustificada { get; set; }
        public decimal Justificada { get; set; }
        public decimal Total { get; set; }
        public bool Processado { get; set; }
        [MaxLength(500)]
        public string Obs { get; set; }
        public byte[] Docjustifica { get; set; }
        public string Pestamp { get; set; }
        public string Processtamp { get; set; }
        public string Prcstamp { get; set; }

        public virtual Escaladeservico Escaladeservico { get; set; }
       // public virtual Escaladeservico Escaladeservico { get; set; }
        public DateTime DataProc { get; set; }
    }
}
