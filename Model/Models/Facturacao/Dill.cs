using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Dill
    {
        [Key]
        public string Dillstamp { get; set; }
        [ForeignKey("Dil")]
        public string Dilstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Ref { get; set; }
        public string Descricao { get; set; }
        public decimal Quant { get; set; }
        public string Unidade { get; set; }
        public decimal Armazem { get; set; }
        public decimal Armazem2 { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Preco { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mpreco { get; set; }
        public string Lote { get; set; }
        public decimal Tabiva { get; set; }
        public decimal Txiva { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Valival { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mvalival { get; set; }
        public bool Ivainc { get; set; }
        public decimal Perdesc { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Descontol { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mdescontol { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Subtotall { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Msubtotall { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Totall { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mtotall { get; set; }
        public decimal ordem { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal cambiol { get; set; }
        public string Descarm { get; set; }
        public bool Servico { get; set; }
        public virtual Dil Dil { get; set; }
        public string Nome { get; set; }
        public string No { get; set; }
        public string Matricula { get; set; }
    }
}
