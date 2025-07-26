using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Gene
{
    public class Utilizador
    {
        public string PaStamp { get; set; }
        public int CodUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool PriEntrada { get; set; }
        public bool ActivoMil { get; set; }
        public string Perfil { get; set; }
        public string Inseriu { get; set; }
        public DateTime InseriuDataHora { get; set; }
        public string Alterou { get; set; }
        public DateTime AlterouDataHora { get; set; }
        public bool Medico { get; set; }
        public string Sexo { get; set; }
    }
}
