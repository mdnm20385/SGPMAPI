using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Caixal
    {
        [Key]
        public string Caixalstamp { get; set; }
        [ForeignKey("Caixa")]
        public string Caixastamp { get; set; }
        public DateTime Data { get; set; }
        public decimal Codtz { get; set; }//Se 1, aberto, 2 fechado
        public string Contatesoura { get; set; }
        public string Qmf { get; set; }
        public DateTime Qmfdathora { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Entrada { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Saida { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Saldo { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Lancado { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotalDefice { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Campo1 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Campo2 { get; set; }
        public string Campo3 { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        public string Contasstamp { get; set; }
        public string MobileUnicNumber { get; set; }
        public string SerialNumber { get; set; }
        //inicio
        [DecimalPrecision(16, 2, true)]
        public decimal Valormanual { get; set; }//foi adicionado no dia 18/04/2024(mandado por Eng:Zuca)
        //fim
        public string Corredor { get; set; }//Nome de quem abriu e quem fechou userstamp de quem abriu e quem fechou
        public string Corredorstamp { get; set; }// userstamp de quem abriu e quem fechou
        public string Carreirastamp { get; set; }
        public string Carreira { get; set; }
        public bool Fechado { get; set; }//
        public string Matricula { get; set; }
        public string Viaturastamp { get; set; }
        public string Mobileserial { get; set; }
        //public string Turno { get; set; }
        //public string Turnostamp { get; set; }


        public string Motorista { get; set; }
        public string Motoristastamp { get; set; }
        public virtual Caixa Caixa { get; set; }
        public virtual ICollection<Caixall> Caixall { get; set; }
        //public DateTime Dhorafecho { get; set; }

        
        
    }



}
