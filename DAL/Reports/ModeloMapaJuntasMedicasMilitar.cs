using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Reports
{
    public class ModeloMapaJuntasMedicasMilitar
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        /// <summary>
        /// Província de proveniência da junta ou do paciente?
        /// </summary>
        public string Proveniencia { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Homologado { get; set; }
        public DateTime DataSaida { get; set; }
    }
}
