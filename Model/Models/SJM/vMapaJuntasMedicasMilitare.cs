using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    public  class VMapaJuntasMedicasMilitare
    {
        
        [StringLength(100)]
        public string Nome { get; set; }

        public string Numero { get; set; }
        [StringLength(100)]
        public string Proveniencia { get; set; }
        public DateTime? DataEntrada { get; set; }

        [StringLength(250)]
        public string Homologado { get; set; }
        public DateTime? DataSaida { get; set; }
    }
}
