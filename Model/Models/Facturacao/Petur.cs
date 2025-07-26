using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Petur
    {
        [Key]
        public string Peturstamp { get; set; }
        public string Pestamp { get; set; }
        public string Codturma { get; set; }
        public string Descricao { get; set; }
        public string Semestre { get; set; }
        public string Disciplina { get; set; }
        public string Anolect { get; set; }
        public virtual Pe Pe { get; set; }
    }
}
