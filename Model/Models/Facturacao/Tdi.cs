using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Tdi
    {
        [Key]
        public string Tdistamp { get; set; }
        public string Descricao { get; set; }
          public string Sigla { get; set; }
        public decimal Tipo { get; set; }
        public string Desctipo { get; set; }
        public string Tiposigla { get; set; }
        public bool Alteranum { get; set; }
        public bool CtrlData { get; set; }
        public bool Armazem { get; set; }
        public decimal Armdefeito { get; set; }
        public bool Movstk { get; set; }
        public decimal Codmovstk { get; set; }
        public string Descmovstk { get; set; }
        public bool Composto { get; set; }
        public bool Obgccusto { get; set; }
        public bool Activo { get; set; }
        public bool Defa { get; set; }
        public bool Trf { get; set; }
        public decimal Codmovstk2 { get; set; }
        public string Descmovstk2 { get; set; }
        public decimal Numdoc { get; set; }
        public bool Reserva { get; set; }
        public bool Noneg { get; set; }
        public bool Armapenas { get; set; }
        public bool Prod { get; set; }
        public bool Copyqtt { get; set; }
        public bool Copyvalor { get; set; }
        public bool Prccusto { get; set; }
        public decimal Armdefeito2 { get; set; }
        public bool Facturar { get; set; }
        public decimal Ndocfact { get; set; }
        public string Docfact { get; set; }
        public bool CopiaDocs { get; set; }
        public string Nomfile { get; set; }
        public string Ecran { get; set; }
        public string Titimpress { get; set; }
        public bool Copia { get; set; }
        public bool Usaaprova { get; set; }
        public string Descpreco { get; set; }
        public string Campopreco { get; set; }
        public bool Usafecho { get; set; }
        public decimal No { get; set; }
        public string Nome { get; set; }
        public bool Usaemail { get; set; }
        public string DestinationEmail { get; set; }
        public string Subj { get; set; }
        public string EmailText { get; set; }
        public bool Usaattach { get; set; }
        public bool Usaorigem { get; set; }
        public bool Usadestino { get; set; }
        public bool Usaanexo { get; set; }
        public bool Ligapj { get; set; }
        public bool Lancacustopj { get; set; }//Permite definir se o documento vai lancar o seu custo ao projecto
        public bool Usaserie { get; set; }
        public bool Autoemail { get; set; }
        public string Condcopia { get; set; }
        public bool Orc { get; set; }
        public bool Movtz { get; set; }
        public decimal Tipomovtz { get; set; }
        public bool Noentid { get; set; }
        public bool Regrd { get; set; }
        public bool Usalote { get; set; }
        public bool VisivelPos { get; set; }
        public bool Aprova { get; set; }
        public bool Introdir { get; set; }
        public decimal Tipodoc { get; set; }
        public string Nomefiles { get; set; }
        public bool Usatec { get; set; }
        public bool Nopergtec { get; set; }
        public bool Obrigalote { get; set; }
        public bool Usaqttmedida { get; set; }
        public string Descqttmedida { get; set; }
        public bool Noalteramedida { get; set; }
        public decimal Dias { get; set; }
        public string Ccusto { get; set; }
        public string Contastesoura { get; set; }
        public decimal Codtz { get; set; }
        public string Titulo { get; set; }
        public bool Nalteratz { get; set; }
        public bool Precocl { get; set; }
        public bool TrfConta { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
        public decimal Codmovtz2 { get; set; }
        public string Descmovtz2 { get; set; }
        public bool Stkinicial { get; set; }
        public bool Encomenda { get; set; }

        #region Definiçoes de Contabilidade ....

        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        [MaxLength(1000)]
        public string Obs { get; set; }

        #endregion

        #region Assuntos de Guias de remessas para clientes e fornecedores ....

        //Este documento da saida de um produto vendido mas mantido na loja (Casos de entregas a domicilio)...
        public bool Vendido { get; set; }
        //Este documento da entrada de stock comprado mas ainda nao tinha chegado...
        public bool Comprado { get; set; }
        #endregion
        //Este Documento permite devolver os produtos ao stock real caso o cliente cancele a reserva 
        public bool Estorno { get; set; }
        public bool Stockmax { get; set; } //Controlo Stock máximo de um produto num armazem...
        public string ReportXml { get; set; }
        public string XmlString { get; set; }
        public bool Inscricao { get; set; }
        public bool Promocao { get; set; }
        public string Campomultiuso { get; set; }//Usado para varios fins
        public virtual ICollection<Docmodulo> Docmodulo { get; set; }

        public virtual ICollection<TdiCcu> TdiCcu { get; set; }
    }
}
