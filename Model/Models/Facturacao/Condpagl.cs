using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Condpagl
    {
        [Key]
        public string Condpaglstamp { get; set; }
        [ForeignKey("Condpag")]
        public string Condpagstamp { get; set; }
        public decimal Diain { get; set; } //Dias Inicio 
        public decimal Diafim { get; set; } //Dias Termino 
        [DecimalPrecision(5, 2, true)]
        public decimal Percetagem { get; set; } //Dias Termino 
        public virtual Condpag Condpag { get; set; } 
    }
}
