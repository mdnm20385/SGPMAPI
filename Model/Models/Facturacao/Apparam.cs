using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Apparam
    {
        [Key]
        public string Apparamstamp { get; set; }
        public string Conta { get; set; }
        public string Descricao { get; set; }
        public string Cc1 { get; set; }
        public string Cc2 { get; set; }
        public string Cc3 { get; set; }
        public string Qmc { get; set; }
        public DateTime Qmcdathora { get; set; }
        public string Qma { get; set; }
        public DateTime Qmadathora { get; set; }
        public string Ivarec { get; set; }
        public string Ivaant { get; set; }
        public string Ivapag { get; set; }
        public string Origem { get; set; }
        public string Cmesant { get; set; }
        public string Desmesant { get; set; }
        public decimal Sequec { get; set; }
        public decimal Tiposaldo { get; set; }
        public virtual ICollection<Apivded> Apivdeds { get; set; }
        public virtual ICollection<Apivliq> Apivliqs { get; set; }
    }
}
