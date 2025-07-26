using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public  class Tdocf
    {
        [Key]
        public string Tdocfstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public bool Alteranum { get; set; }
        public bool CtrlData { get; set; }
        public bool Armazem { get; set; }
        public decimal Armdefeito { get; set; }
        public bool Movstk { get; set; }
        public decimal Codmovstk { get; set; }
        public string Descmovstk { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
        public bool Movcc { get; set; }
        public string Descmovcc { get; set; }
        public decimal Codmovcc { get; set; }
        public bool Recibo { get; set; }
        public bool Composto { get; set; }
        public bool Obgccusto { get; set; }
        public decimal Codtz { get; set; }
        public string Contastesoura { get; set; }
        public bool Movtz { get; set; }
        public bool Activo { get; set; }
        public bool Defa { get; set; }
        public bool Reserva { get; set; }
        public bool Noneg { get; set; }
        public bool Armapenas { get; set; }
        public string Nomfile { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public bool Ligapj { get; set; }
        public bool Obrigapj { get; set; }
        public bool Usaserie { get; set; }
        public decimal Tipodoc { get; set; }
        public bool Usalote { get; set; }
        public string Coment { get; set; }

        #region Definiçoes de contabilidade ....
        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        //public decimal TesouraPgc { get; set; }
        public bool Lancacustopj { get; set; }//Permite definir se o documento vai lancar o seu custo ao projecto

        #endregion


        public string Ccusto { get; set; }
        public bool Nc { get; set; }
        public bool Nd { get; set; }
        public bool Ft { get; set; }
        public bool Vd { get; set; }
        public bool Usaprovacao { get; set; }
        public decimal Dias { get; set; }
        public bool Stockmax { get; set; } //Controlo Stock máximo de um produto num armazem...
        [Column(TypeName = "nvarchar(max)")]
        public string ReportXml { get; set; }
        public string XmlString { get; set; }
        public string Campomultiuso { get; set; }//Usado para varios fins
        public virtual ICollection<Docmodulo> Docmodulo { get; set; }
        
    }
}
