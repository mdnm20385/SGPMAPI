using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Diario
    {
        [Key]
        public string Diariostamp { get; set; }
        public decimal Dino { get; set; }
        public string Descricao { get; set; }
        public decimal Docno { get; set; }
        public string Docnome { get; set; }
        public decimal Dilno { get; set; }
        public decimal Deb { get; set; }
        public decimal Cre { get; set; }
        public decimal Conana { get; set; }
        public decimal Confin { get; set; }
        public decimal Conord { get; set; }
        public decimal Edeb { get; set; }
        public decimal Ecre { get; set; }
        public decimal Diano { get; set; }
        public string Qmc { get; set; }
        public DateTime Qmcdathora { get; set; }
        public string Qma { get; set; }
        public DateTime Qmadathora { get; set; }
        public bool Defeito { get; set; }
        public bool Apura { get; set; }
        public virtual ICollection<Diariodoc> Diariodoc { get; set; }
    }
}
