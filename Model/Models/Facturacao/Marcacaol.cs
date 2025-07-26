using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Marcacaol
    {
        [Key]
        public string Marcacaolstamp { get; set; }
        public string Marcacaostamp { get; set; }
        public string Ststamp { get; set; }
        public string Entidadestamp { get; set; }//clstamp
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Ref { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Descricao { get; set; }
        [DecimalPrecision(16, 4, true)]
        public decimal Quant { get; set; }
        public string Unidade { get; set; }
        public decimal Armazem { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Preco { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mpreco { get; set; }
        public decimal Tabiva { get; set; }
        [DecimalPrecision(5, 2, true)]
        public decimal Txiva { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Valival { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mvalival { get; set; }
        public bool Ivainc { get; set; }
        public bool Factura { get; set; }
        public bool Activo { get; set; }//Indica se o artigo em activo segundo contabil.
        public decimal Perdesc { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Descontol { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mdescontol { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Subtotall { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Msubtotall { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Totall { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mtotall { get; set; }
        public bool Status { get; set; }


        #region Tratamento de Lotes/Validades
        public DateTime Lotevalid { get; set; }
        public DateTime Lotelimft { get; set; }
        public bool Usalote { get; set; }
        public string Lote { get; set; }
        [MaxLength(2000)]
        public string Obs { get; set; }//Concatenação de Referência do Produto com Lote  
        #endregion
        public bool Servico { get; set; }
        public string Oristampl { get; set; }
        public decimal Dispon { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal QttOrig { get; set; }
        public bool Nmovstk { get; set; }
        public string Oristamp { get; set; }
        public bool Tit { get; set; }
        public decimal Ordem { get; set; }
        public bool Stkprod { get; set; }
        public bool LineAnulado { get; set; }
        public string Titstamp { get; set; }
        [DefaultValue("0")]
        public decimal Contatz { get; set; }
        [DefaultValue("0")]
        public decimal Pack { get; set; }
        public decimal Cpoc { get; set; }
        public decimal Cpoo { get; set; }
        public bool Composto { get; set; }
        public string Descarm { get; set; }
       // public bool Factura { get; set; }
        public string Refornec { get; set; }//Referencia do fornecedor 
        public bool Usaquant2 { get; set; }//Utiliza quantidade 2 nas vendas casos de bedidas a pressao 
        [DecimalPrecision(16, 4, true)]
        public decimal Quant2 { get; set; }
        #region Dados de entrega de produtos ao cliente ....

        public string Morada { get; set; }
        public string Telefone { get; set; }
        public bool Entrega { get; set; }
        public DateTime Dataentrega { get; set; }
        public string Pcontacto { get; set; }//Pessoa de contacto
        public string Email { get; set; }
        public string Pais { get; set; }
        [MaxLength(200)]
        public string Guias { get; set; } //Indicar as Guias a facturar Caso Tores Cargos 
        #endregion
        [MaxLength(200)]
        public string Contrato { get; set; }
        public bool Gasoleo { get; set; } //Linhaprincipal

        [DecimalPrecision(10, 4, true)]
        public decimal Cambiousd { get; set; }
        public string Moeda { get; set; }
        public string Moeda2 { get; set; }
        public string Ccusto { get; set; }
        public string Codccu { get; set; }
        //[Column(TypeName="nvarchar(max)")]
        public string Armazemstamp { get; set; }
        public string Codigobarras { get; set; }
        public string StRefFncCodstamp { get; set; }
        public string Campomultiuso { get; set; }//1

        [DecimalPrecision(18, 4, true)]
        public decimal PrecoPromo { get; set; }
        public virtual Marcacao Fact { get; set; }
    }
}
