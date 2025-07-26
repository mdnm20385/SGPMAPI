using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Peacidente
    {
        [Key]
        public string Peacidentestamp { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public DateTime Data { get; set; }
        public string TipoAcidente { get; set; }
        public string LocalAcidente { get; set; }
        public bool Hospitalizacao { get; set; }
        public bool Mortal { get; set; }
        public string Incapacidade { get; set; }
        public string Ausencia { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Obs { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
