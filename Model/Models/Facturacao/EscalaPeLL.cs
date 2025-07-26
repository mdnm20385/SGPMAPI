using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class EscalaPeLL
    {
        [Key]
        public string EscalaPeLLstamp { get; set; }
        [ForeignKey("EscalaPe")]
        public string EscalaPestamp { get; set; }
        public string Turno { get; set; }
        public string SiglaTurno { get; set; }
        public string ServiTurnostamp { get; set; }  
        public string EscalaPeLstamp { get; set; }
        public decimal Dias { get; set; }
       
        [MaxLength(990)]
        public string DiasTrabalhos { get; set; }
        public string Pestamp { get; set; }
        public virtual EscalaPe EscalaPe { get; set; }



    }
}
