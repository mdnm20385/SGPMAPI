using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public  class Tdoc
    {
        [Key]
        public string Tdocstamp { get; set; }
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
        public bool Composto { get; set; }
        public bool Obgccusto { get; set; }
        public decimal Codtz { get; set; }
        public string Contastesoura { get; set; }
        public bool Movtz { get; set; }
        public bool Nalteratz { get; set; }
        public bool Activo { get; set; }
        public bool Defa { get; set; }
        public bool Pos { get; set; }
        public string Ccusto { get; set; }
        public bool Reserva { get; set; }
        public bool Noneg { get; set; }
        public bool Armapenas { get; set; }
        public string Coment { get; set; }
        public string Titulo { get; set; }
        public string Nomfile { get; set; }
        public string Nomfile2 { get; set; }//Nome do Ficheiro em Ingles 
        public string Nomfile3 { get; set; }//Nome do Ficheiro em Moeda extrangeira 
        [MaxLength(1200)]
        public string Obs2 { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public bool Ligapj { get; set; }
        public bool Obrigapj { get; set; }
        public bool Usaserie { get; set; }
        public bool Usalote { get; set; }
        public bool Adjudica { get; set; }
        public bool Aprova { get; set; }
        public decimal Tipodoc { get; set; }

        #region Definiçoes de contabilidade ....

        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        // public decimal TesouraPgc { get; set; }

        #endregion
        public bool Nc { get; set; }
        public bool Nd { get; set; }
        public bool Ft { get; set; }
        public bool Vd { get; set; }
        public decimal Dias { get; set; } //Validade do documento ...
        public bool Usamascara { get; set; } //Define se usa mascara ou não 
        public string Mascara { get; set; } //numero de digitos que o numero da factura possui 
        public bool Plafond { get; set; } //Controla o plafond de credito do cliente ....
        public bool Lancaend { get; set; }//Permite lancar endereco nas linhas da grid factl 
        public bool Stockmin { get; set; }//Controla o Stokmin para envio de emails ...

        public bool Mostraguia { get; set; }//Controla o campo guias de Carga na grig factl..
        public bool MostraContrato { get; set; }//Controla o campo contrato na grid factl ...
        public bool Lancacustopj { get; set; }//Permite definir se o documento vai lancar o seu custo ao projecto
        public bool Ncobrigadoc { get; set; }//Obriga a indicacao do documento a regularizar (Factura,VD ou ND)

        public string ReportXml { get; set; }
        public virtual ICollection<Docmodulo> Docmodulo { get; set; }
        public string XmlString { get; set; }
        public string XmlStringA5 { get; set; }
        public string XmlStringPOS { get; set; }
        public bool Inscricao { get; set; }
        public bool Multa { get; set; }

        public string Campomultiuso { get; set; }//Usado para varios fins
        public bool Usaprovacao { get; set; }
    }

}
