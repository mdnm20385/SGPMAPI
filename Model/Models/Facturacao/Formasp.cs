using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Formasp
    {
        [Key]
        public string Formaspstamp { get; set; }
        public string Titulo { get; set; }
        public string Numtitulo { get; set; }
        public DateTime Dcheque { get; set; }
        public string Banco { get; set; }
        public string Banco2 { get; set; }
        [Required(ErrorMessage = "A conta tesouraria não pode ser vazio")]
        public string Contatesoura { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "O número da tesouraria não pode ser vazio")]
        public decimal Codtz { get; set; }
        public decimal Codtz2 { get; set; }
        public string Contatesoura2 { get; set; }
        public string Contasstamp2 { get; set; }
        public bool Trf { get; set; }
        public bool Numer { get; set; }
        public bool Tipo { get; set; }
        public bool ObgTitulo { get; set; }
        public string Rclstamp { get; set; }
        public string Oristamp { get; set; }
        [ForeignKey("Fact")]
        public string Factstamp { get; set; }
        [ForeignKey("Facc")]
        public string Faccstamp { get; set; }
        [ForeignKey("Pgf")]
        public string Pgfstamp { get; set; }
        [ForeignKey("Percl")]
        public string Perclstamp { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Di")]
        public string Distamp { get; set; }
        public decimal Cpoc { get; set; }
        public decimal ContaPgc { get; set; }
        public string Origem { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mvalor { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
        public decimal Codmovtz2 { get; set; }
        public string Descmovtz2 { get; set; }
        public string UsrLogin { get; set; }//RECEBE O STAMP DO UTILIZADOR 
        public bool AberturaCaixa { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Numero { get; set; }
        public string Ccusto { get; set; }
        public virtual Fact Fact { get; set; }
        public virtual Facc Facc { get; set; }
        public virtual RCL Rcl { get; set; }
        public virtual Pgf Pgf { get; set; }
        public virtual Di Di { get; set; }
        public string Contasstamp { get; set; }
        public virtual Percl Percl { get; set; }
        public string Ccustamp { get; set; }
        public string Moeda { get; set; }
        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        public virtual ICollection<Mvt> Mvt { get; set; }
        public string Caixalstamp { get; set; }
        public string Caixastamp { get; set; }
    }
}
