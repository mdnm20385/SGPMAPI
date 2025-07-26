using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Mvt
    {
        [Key]
        public string Mvtstamp { get; set; }
        public DateTime Datamov { get; set; }
        public string Origem { get; set; }
        public string Oristamp { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Entrada { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Saida { get; set; }
        public string Local { get; set; }
        public decimal Codlocal { get; set; }
        public string Documento { get; set; }
        public string Titulo { get; set; }
        public string Numtitulo { get; set; }
        public DateTime Dprocess { get; set; }
        public bool Process { get; set; }
        public string Nrdoc { get; set; }
        public string Moeda { get; set; }
        public string Descricao { get; set; }
        public decimal Numeracao { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Saldo { get; set; }
        public bool Reconc { get; set; }
        public string Extcontastamp { get; set; }
        public string Extracto { get; set; }
        public string Banco { get; set; }
        public string Ccusto { get; set; }
        public decimal? Contatz { get; set; }
        public string Referenc { get; set; }
        [ForeignKey("Formasp")]
        public string Formaspstamp { get; set; }
        public decimal Tipomov { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mentrada { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Msaida { get; set; }
        public decimal Numcaixa { get; set; }
        public DateTime Datcaixa { get; set; }
        public bool Fechado { get; set; }
        public decimal Inicial { get; set; }
        public string? Numero { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
        public string UsrLogin { get; set; }
        public string Contasstamp { get; set; }
        public bool AberturaCaixa { get; set; }
        public string Ccustamp { get; set; }
        public virtual Formasp Formasp { get; set; }
        public string Caixalstamp { get; set; }
        public string Caixastamp { get; set; }
    }
}
