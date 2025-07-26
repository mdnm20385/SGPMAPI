using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Rltsql
    {
        [Key]
        public string Rltsqlstamp { get; set; }
        [MaxLength(2500)]
        public string Descricao { get; set; }
        [MaxLength(30000)]
        public string Querry { get; set; }
        public string Origem  { get; set; }
        public string Reportname { get; set; }
        public string Tamanho { get; set; }
        public bool Geragrid { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public string Campo3 { get; set; }
        public string XmlString { get; set; }
    }
}
