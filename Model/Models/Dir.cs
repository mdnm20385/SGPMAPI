using Model.Models.SJM;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Dir
    {
        [Key]
        public string Dirstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Activopa { get; set; }


        public virtual List<Dirdep> Dirdep { get; set; } = new List<Dirdep>();//Departamentos
        public virtual List<EmailClass> EmailClass { get; set; } = new List<EmailClass>();//Departamentos
    }
    public class AcessoTeste : Pa
    {
        public string Numero { get; set; }
        public string Proveniencia { get; set; }
        public string DataEntrada { get; set; }
        public string Homologado { get; set; }
        public string DataSaida { get; set; }

        //public string Conprinc { get; set; }
        // public string Conalter { get; set; }

    }
}
