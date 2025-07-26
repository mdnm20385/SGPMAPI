using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Dc
    {
        [Key]
        public string Dcstamp { get; set; }
        public decimal Docno { get; set; }
        public string Docnome { get; set; }
        public string Abrv { get; set; }
        public bool Pedeval { get; set; }
        public bool Arredonda { get; set; }
        public bool Nvaimapa { get; set; }
        public string Olcodigo { get; set; }//Stamp do Centro de Custo de Função
        public string Oldesc { get; set; }//Descrição do Centro de Custo de Função

        public string Qmc { get; set; }//stamp do Centro de Custo de Actividade
        public string Qma { get; set; }//Descrição do Centro de Custo de Actividade
        public bool Lancaol { get; set; }
        public bool Naolancapla { get; set; }
        public bool Oltrfa { get; set; }
        public bool Introol { get; set; }
        public bool Ollinhas { get; set; }
        public bool Automl { get; set; }
        public DateTime Qmcdathora { get; set; }
        public DateTime Qmadathora { get; set; }
        public bool Apuraiva { get; set; }
        public bool Apurares { get; set; }

        public virtual ICollection<Dcli> Dcli { get; set; }
    }
}
