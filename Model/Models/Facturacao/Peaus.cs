using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Peaus
    {
        [Key]
        public string Peausstamp { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public  string Descricao { get; set; }
        public  DateTime Datain{ get; set; }
        public  DateTime Datater { get; set; }
        public  bool Processa { get; set; }
        public  bool Cancelada { get; set; }
        public  virtual Pe Pe { get; set; }
    }
}
