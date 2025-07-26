using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Marcacao
    {
        [Key]
        public string Marcacaostamp { get; set; }
        [ForeignKey("Cl")]
        public string Clstamp { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Pestamp { get; set; }
        public string No2 { get; set; }
        public string Nome2 { get; set; }
        public string Categ { get; set; }
        public string CodCateg { get; set; }
        public string Numero { get; set; }
        public string Procedimentostamp { get; set; }
        public string DescProcedimento { get; set; }
        public decimal ValorProcedimento { get; set; }
        public DateTime Data { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Horaini { get; set; }
        public DateTime Horafim { get; set; }
        public DateTime Horaentrada { get; set; }
        public DateTime Horasaida { get; set; }
        public string Obs { get; set; }
        public bool Retorno { get; set; }
        public string Ccustamp { get; set; }
        public string Quempagastamp { get; set; }
        public string Ccusto { get; set; }
        public string Quempaga { get; set; }
        public string Status { get; set; }
        public bool Atendido { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Subtotal { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Perdesc { get; set; }
        [DecimalPrecision(5, 2, true)]
        public decimal Perdescfin { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Desconto { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Descontofin { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal MDescontofin { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Totaliva { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Total { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Msubtotal { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mdesconto { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mtotaliva { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Mtotal { get; set; }
        public bool Fechado { get; set; }
        public bool Ematendimento { get; set; }
        public bool Anulado { get; set; }
        public virtual Cl Cl { get; set; }
        public virtual ICollection<Marcacaol> Marcacaol { get; set; }
        public virtual ICollection<ProcessoClinico> ProcessoClinico { get; set; }

    }
}
