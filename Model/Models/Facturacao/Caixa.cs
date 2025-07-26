using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Caixa
    {
        [Key]
        public string Caixastamp { get; set; }
        public decimal Numero { get; set; }
        public decimal Inicial { get; set; }
        public DateTime Data { get; set; }
        public decimal Codtz { get; set; }
        public string Contatesoura { get; set; }
        public bool Fechado { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public string Qmc { get; set; }
        public string Qmf { get; set; }
        public DateTime Qmcdathora { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public DateTime Dhorafecho { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Entrada { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Saida { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Saldo { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal TotalCaixa { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Defice { get; set; }

        [DecimalPrecision(16, 2,true)]
        public decimal Campo1 { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Campo2 { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Campo3 { get; set; }
        public string Campo4 { get; set; }
        public string Campo5 { get; set; }
        public bool Supervisor { get; set; }
        public string Usrstamp { get; set; }
        public string Contasstamp { get; set; }
        public virtual ICollection<Caixal> Caixal { get; set; }
        public string Ccusto { get; set; }
        public string Ccustamp { get; set; }
        public string Moeda { get; set; }
        public string Ccutvstamp { get; set; }
        public string Ccutvdesc { get; set; }
    }
}
