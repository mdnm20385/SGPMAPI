using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class ProcessoClinico
    {

        [Key]
        public string ProcessoClinicostamp { get; set; }
        public string Marcacaostamp { get; set; }
        public DateTime DataConsulta { get; set; }
        [MaxLength(200000000)]
        public string? QueixaPrincipal { get; set; }
        [MaxLength(200000000)]
        public string? HistoricoClinico { get; set; }
        [MaxLength(200000000)]
        public string? Diagnostico { get; set; }
        [MaxLength(200000000)]
        public string? Prescricao { get; set; }
        [MaxLength(200000000)]
        public string? Observacoes { get; set; }
        public DateTime? ProximoRetorno { get; set; }
       // public DateTime? Data { get; set; }
        public string Pestamp { get; set; }
        [MaxLength(200000000)]
        public string Nome { get; set; }
        public virtual Marcacao? Marcacao { get; set; }
        public ICollection<EquipaMedica> EquipaMedica { get; set; }
    }
}
