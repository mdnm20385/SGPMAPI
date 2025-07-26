using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public  class Pjpe
    {
        [Key]
        public string Pjpestamp { get; set; }
        [ForeignKey("Pj")]
        public string Pjstamp { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }

        public string funcao { get; set; }
        public bool status { get; set; }
        public virtual Pj Pj { get; set; }
    }
}
