using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Ccu_Arm
    {
        [Key]
        public string Ccu_Armstamp { get; set; }
        [ForeignKey("CCu")]
        public string Ccustamp { get; set; }
        public decimal Codarm { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
        public bool Defeito { get; set; }
        public string Armazemstamp { get; set; }
        public virtual CCu CCu { get; set; }
    }
}
