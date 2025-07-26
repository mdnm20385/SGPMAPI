using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class calendario
    {
        [Key]
        public string calendariostamp { get; set; }
        public DateTime date { get; set; }
        public string events { get; set; }
        //public string CLocalStamp { get; set; } = "";
        //public string Ctabela { get; set; }
    }
}
