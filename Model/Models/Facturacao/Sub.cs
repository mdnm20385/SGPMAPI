using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Sub
    {
        [Key]
        [StringLength(30)]
        public string Substamp { get; set; }
        public string Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public decimal Tipo { get; set; }
        [DecimalPrecision(16,2,true)]
        public decimal Valor { get; set; }
        public decimal Tiposub { get; set; }
        public bool Decimo13 { get; set; }
        public bool Rectro { get; set; }
        public bool SofreDescontoFalta { get; set; }
        public string Obs { get; set; }
	    public bool PagoMesFerias { get; set; }
	    public bool PagoSubsFerias { get; set; }
	    public bool PagoSubsNatal { get; set; }
	    public bool PagoExtra { get; set; }
	    public string Moeda { get; set; }
        public bool SubFixo { get; set; }

    }
}
