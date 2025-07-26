using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Trdf
    {
        [Key]
        public string Trdfstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Descmovcc { get; set; }
        public decimal Codmovcc { get; set; }
        public string Contastesoura { get; set; }
        public decimal Codtz { get; set; }
        public string Titulo { get; set; }
        public string Ccusto { get; set; }
        public string Obs { get; set; }
        public decimal Entida { get; set; }
        public bool Activo { get; set; }
        public bool Defa { get; set; }
        public string Qmc { get; set; }
        public DateTime Qmcdathora { get; set; }
        public string Qma { get; set; }
        public DateTime Qmadathora { get; set; }
        public bool Usaanexo { get; set; }
        public bool Usaemail { get; set; }
        public decimal TesouraPgc { get; set; }
        public bool Etpemiss { get; set; }
        public bool Etpimpress { get; set; }
        public bool Etpemail { get; set; }
        public string Etpemisstxt { get; set; }
        public string Etpimpresstxt { get; set; }
        public string Etpemailtxt { get; set; }
    }
}
