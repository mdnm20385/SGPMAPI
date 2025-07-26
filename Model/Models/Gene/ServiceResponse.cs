using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Gene
{
    public class ServiceResponse<T>
    {
        public T Dados { get; set; }

        public string Mensagem { get; set; } = string.Empty;

        public bool Sucesso { get; set; } = true;
    }
}
