using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    public class UsuarioSessao
    {
        [Key]
        public string UsuarioSessaoStamp { get; set; }

        [StringLength(500)]
        public string NomeComputador { get; set; }

        [StringLength(500)]
        public string NomeCompletoComputador { get; set; }

        [StringLength(500)]
        public string WindowsEdition { get; set; }
       
        [StringLength(350)]
        public string TipoComputador { get; set; }
       
        [StringLength(500)]
        public string AdaptadorRede { get; set; }

        [StringLength(100)]
        public string DataSessao { get; set; }

        [StringLength(50)]
        public string HoraSessaoEntrada { get; set; }

        public int DuracaoHora { get; set; }

        public int DuracaoMin { get; set; }

        public int DuracaoSegundos { get; set; }

        [StringLength(100)]
        public string HoraSessaoSaida { get; set; }

        [StringLength(100)]
        public string NomeUtilizador { get; set; }
    }
}
