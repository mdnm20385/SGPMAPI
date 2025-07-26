using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Modulos
    {
        [Key]
        public string Modulosstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Obs { get; set; }
        public virtual ICollection<Modulosfrmdoc> Modulosfrmdoc { get; set; }
    }
public class Modulosfrmdoc
    {
        [Key]
        public string Modulosfrmdocstamp { get; set; }
        [ForeignKey("Modulos")]
        public string Modulosstamp { get; set; }
        [Required]
        public string Sigla { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Ecran { get; set; }
        public string Origem { get; set; }
        public string Obs { get; set; }
        public bool Isdoc { get; set; }
        public string Oristamp { get; set; }
        public virtual Modulos Modulos { get; set; }
    }

}
