using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Docac //Documentos necessario na academia 
    {
        [Key]
        public string Docacstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
