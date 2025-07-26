using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class EquipaMedica
    {
        [Key]
        public string EquipaMedicastamp { get; set; }
        public string ProcessoClinicostamp { get; set; }
        [StringLength(500)]
        public string Nome { get; set; }
        [StringLength(500)]
        public string Funcao { get; set; } // Ex: Médico, Enfermeiro, etc.
        [StringLength(500)]
        public string Especialidade { get; set; }
        public string Pestamp { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public ProcessoClinico ProcessoClinico { get; set; }
    }
}
