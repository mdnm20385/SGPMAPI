using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Paramac
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Paramacstamp { get; set; }
        public string AnoLectivo { get; set; }
    }
}
