using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Rdlcxml
    {
        [Key] 
        public string RdlcxmLstamp { get; set; }
        [Required] 
        [Column("Xmlstring", TypeName="nvarchar(max)")]
        public string XmlString { get; set; }
        [Required] 
        public string Rdlcname { get; set; }
        public string Descricao { get; set; }

        [Column("Querry", TypeName = "nvarchar(max)")]
        public string Querry { get; set; }
    }
}
