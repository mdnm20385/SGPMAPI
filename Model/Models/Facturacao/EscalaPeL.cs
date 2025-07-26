using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class EscalaPeL
    {
        [Key]
        public string EscalaPeLstamp { get; set; }
        [ForeignKey("EscalaPe")]
        public string EscalaPestamp { get; set; }
        public string Nome { get; set; }
        public string No { get; set; }
        public DateTime HoraSaida { get; set; }
        public DateTime HoraRend { get; set; }
        public string Turno { get; set; }
        public string SiglaTurno { get; set; }
        public string ServiTurnostamp { get; set; }
        public string Corredor { get; set; }
        public string Corredorstamp { get; set; }// 
        public string CodMotorista { get; set; }//
        public string Motorista { get; set; }//
        public string Motoristastamp { get; set; }//
        public string Carreirastamp { get; set; }
        public string Carreira { get; set; }
        public string Viatura { get; set; }
        public string Viaturastamp { get; set; }
        public string Campo3 { get; set; }
        public string Campo4 { get; set; }
        [MaxLength(3000)]
        public string Motivo { get; set; }
        public string Pestamp { get; set; }
        public decimal Dias { get; set; }
        public bool Reserva { get; set; }
        public string DiasTrabalhos { get; set; }
        public string Codcarreira { get; set; }
        public string CodCarreirastamp { get; set; }//
        #region MyRegion
        public bool Ferias { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public bool Feriado { get; set; }
        #endregion
        public virtual EscalaPe EscalaPe { get; set; }


    }
}
