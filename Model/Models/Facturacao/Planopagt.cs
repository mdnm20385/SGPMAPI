using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Planopagt
    {
        [Key]
        public string Planopagtstamp { get; set; }
        [ForeignKey("Planopag")]
        public string Planopagstamp { get; set; }
        public string Codcurso { get; set; }
        public string Codturma { get; set; }
        public string Descturma { get; set; }
        public string Turmastamp { get; set; }
        public virtual Planopag Planopag { get; set; }
    }
}