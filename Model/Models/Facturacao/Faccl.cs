using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Faccl
    {
        [Key]
        public string Facclstamp { get; set; }
        [Required]
        [ForeignKey("Facc")]
        public string Faccstamp { get; set; }
        public string Ststamp { get; set; }
        public string Entidadestamp { get; set; }//Fncstamp
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Ref { get; set; }
        [Column("Descricao", TypeName="nvarchar(max)")]
        public string Descricao { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Quant { get; set; }
        public string Unidade { get; set; }
        public decimal Armazem { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Preco { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mpreco { get; set; }
        public decimal Tabiva { get; set; }
        [DecimalPrecision(5, 2,true)] 
        public decimal Txiva { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Valival { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mvalival { get; set; }
        public bool Ivainc { get; set; }
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
        public bool Usadesign { get; set; }
        public bool Servico { get; set; }
      //  public bool Stactivo { get; set; }//Indica se o artigo em activo segundo contabil.
        public bool Nmovstk { get; set; }
        public string Remotestamp { get; set; }
        public string Oristamp { get; set; }
        public bool Tit { get; set; }
        public decimal Ordem { get; set; }
        public bool Stkprod { get; set; }
        public string Titstamp { get; set; }
        public decimal Contatz { get; set; }
        public decimal Cpoo { get; set; }
        public bool Composto { get; set; }
        public decimal Pack { get; set; }

        #region Tratamento de Lotes
        public bool Usalote { get; set; }
        public DateTime Lotevalid { get; set; }
        public DateTime Lotelimft { get; set; }
        public string Lote { get; set; }
        public string Reffornecl { get; set; }//Concatenação de Referência do Produto com Lote 
        #endregion
        [DecimalPrecision(18, 4, true)]
        public decimal Qttmedida { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Totalmedida { get; set; }
        public decimal Grupo { get; set; }
        public bool Usaperlinha { get; set; }
        public decimal Perlinha { get; set; }
        public decimal Tipocheck { get; set; }
        public string Descarm { get; set; }
        public string Oristampl { get; set; }
        public decimal Cpoc { get; set; }
        public bool Gasoleo { get; set; } 
        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        public string Moeda { get; set; } 
        public string Moeda2 { get; set; } 
        public bool LineAnulado { get; set; }
        public string Ccusto { get; set; }
        public string Codccu { get; set; }
        [MaxLength(2500)]
        public string Obs { get; set; }
         public bool Activo { get; set; }//Indica se o artigo em activo segundo contabil.
        public string Armazemstamp { get; set; }
        public string Refornec { get; set; }//Referencia do fornecedor 
        public bool Usaquant2 { get; set; }//Utiliza quantidade 2 nas vendas casos de bedidas a pressao 
        [DecimalPrecision(18, 4, true)]
        public decimal Quant2 { get; set; }
        public virtual Facc Facc { get; set; }
        public string Codigobarras { get; set; }
        public string StRefFncCodstamp { get; set; }
        public string Campomultiuso { get; set; }//1

        [DecimalPrecision(18, 4, true)]
        public decimal PrecoPromo { get; set; }
        public virtual ICollection<Mstk> Mstk { get; set; }
    }
}
