using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Serverlink
    {
        [Key]
        [MaxLength(80)]
        public string Serverlinkstamp { get; set; }
        [MaxLength(80)]
        public string ServerName { get; set; }
        [MaxLength(80)]
        public string ServerIp { get; set; }
    }
}
