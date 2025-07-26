using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class TPercl
    {
        [Key]
        public string TPerclstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Descmovcc { get; set; }
        public decimal Codmovcc { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
        public string Contastesoura { get; set; }
        public decimal Codtz { get; set; }
        public string Titulo { get; set; }
        public string Ccusto { get; set; }
        public string Obs { get; set; }
        public decimal Entida { get; set; }
        public bool Activo { get; set; }
        public bool Defa { get; set; }
        public bool Alteranum { get; set; }
        public bool Usaemail { get; set; }
        public bool Usaanexo { get; set; }
        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        //public decimal TesouraPgc { get; set; }
        public string Nomfile { get; set; }
        public bool Especial { get; set; } //Usado definir se pode ser visivel, ou emite recibo especial
                                           // public virtual ICollection<Docmodulo> Docmodulo { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string XmlString { get; set; }

    }
}
