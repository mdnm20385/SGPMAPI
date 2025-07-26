using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Turmal
    {
        [Key]
        public string Turmalstamp { get; set; }
        [ForeignKey("Turma")]
        public string Turmastamp { get; set; }
        public string Clstamp { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }

        public bool Activo { get; set; }//True=matrícula cancelada e false = matrícula activa
        [MaxLength(3000)]
        public string Motivo { get; set; }//Motivo pelo qual lhe leva ao cancelamento da matrícula
        public virtual Turma Turma { get; set; }
    }
}