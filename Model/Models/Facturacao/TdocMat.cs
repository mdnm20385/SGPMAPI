using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class TdocMat
    {
        [Key]
        public string TdocMatstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Defa { get; set; }
        public bool Inscricao { get; set; } = false;
        public bool Matricula { get; set; } = false;
    }
}
