using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Procurml
    {
        [Key]
        public string Procurmlstamp { get; set; }
        [ForeignKey("Procurm")]
        public string Procurmstamp { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Descricao { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tipo { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Duracao { get; set; }
        public string Fncstamp { get; set; }
        public decimal Qual { get; set; }
        public string Estado { get; set; }
        public string Sequenc { get; set; }
        
        public DateTime? Inicio { get; set; }
        public DateTime? Termino { get; set; }
        public DateTime? PrazoEntrega { get; set; }
        #region Linhas da Fact
        public string Ref { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Quant { get; set; }
        public string Unidade { get; set; }
        public decimal Armazem { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Preco { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mpreco { get; set; }
        public decimal Tabiva { get; set; }
        public decimal Txiva { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Valival { get; set; }
        public decimal Perdesc { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Descontol { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Subtotall { get; set; }
        public string Oristampl { get; set; }
        public string Oristamp { get; set; }
        public string Descarm { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]
        public string Email { get; set; }
        public decimal Totall { get; set; }

        public bool? Activo { get; set; }
        public string Ststamp { get; set; }
        public string Pjescstamp { get; set; }
        public string CCusto { get; set; }
        public string CodCCu { get; set; }
        public string Entidadestamp { get; set; }
        public string Moeda { get; set; }
        public string Moeda2 { get; set; }
        public decimal Cambiousd { get; set; }


            public decimal Mvalival { get; set; }
        public decimal Mdescontol { get; set; }
        public decimal Msubtotall { get; set; }
        public decimal Mtotall { get; set; }
        public bool Executado { get; set; }
        public bool Ivainc { get; set; }
        public bool Servico { get; set; }
        public bool Encerrado { get; set; }
        public bool Factura { get; set; }
        public bool Adenda { get; set; }

        //public bool Pessoal { get; set; }
        public bool SubContrada { get; set; }
        // public bool Actividade { get; set; }
        public decimal Ordem { get; set; }

        [DecimalPrecision(16, 2, true)]
        public decimal PrecoCompra { get; set; }
        [DecimalPrecision(9, 2, true)]
        public decimal Perc { get; set; }

        #endregion
        public virtual Procurm Procurm { get; set; }
    }
}
