using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Dil3
    {
        [Key]
        public string Dil3Stamp { get; set; }
        public string Cod { get; set; }
        public string Descricao { get; set; }
        public string Distamp { get; set; }
        public string Intertekstamp { get; set; }

        public virtual Di Di { get; set; }
    }
}
