using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Tpgp
    {
        [Key]
        public string Tpgpstamp { get; set; }
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
        #region Definiçoes de contabilidade ....
        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        //public decimal TesouraPgc { get; set; }
        #endregion
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public string Nomfile { get; set; }
        public string Nomfile2 { get; set; }
        public string XmlString { get; set; }
        public string XmlStringa5 { get; set; }
        // public virtual ICollection<Docmodulo> Docmodulo { get; set; }
    }
}
