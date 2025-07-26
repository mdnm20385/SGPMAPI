using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BL
{

    public sealed class SqlParametros
    {
        private string _campo;
        private object _valor;
        public string Campo
        {
            get { return _campo; }
            set { _campo = value; }
        }
        public object Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        public SqlParametros()
        {
        }
        public SqlParametros(string campo)
        {
            Campo = campo;
        }
        public SqlParametros(string campo, object valor)
        {
            Campo = campo;
            Valor = valor;
        }
    }
}
