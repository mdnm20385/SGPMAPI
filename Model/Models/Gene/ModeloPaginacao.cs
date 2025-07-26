using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Gene
{
    public class ModeloPaginacao
    {
        public string nimdescricao{ get; set; }
        public int currentNumber{ get; set; }
        public int pagesize { get; set; }
        public string Tabela { get; set; }
        public string Camposelecao { get; set; }
        public string CamposOrdyby { get; set; }
    }
}
