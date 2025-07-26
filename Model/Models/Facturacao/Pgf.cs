using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Pgf
    {
        [Key]
        public string Pgfstamp { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Moeda { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Nuit { get; set; }
        public string Morada { get; set; }
        public string Localidade { get; set; }
        public string Banco { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Total { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mtotal { get; set; }
        public string Obs { get; set; }
        public bool Process { get; set; }
        public DateTime Dprocess { get; set; }
        public bool Anulado { get; set; }
        public string Ccusto { get; set; }
        public string NrFornec { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Tpgfstamp { get; set; }
        public string Nomedoc { get; set; }
        public decimal Codmovcc { get; set; }
        public string Descmovcc { get; set; }
        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Cambiousd { get; set; }
        public string Moeda2 { get; set; }
        public decimal Pjno { get; set; }
        public string Pjstamp { get; set; }
        public string PjNome { get; set; }
        public string Fncstamp { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Descontofin { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal MDescontofin { get; set; }
        [DecimalPrecision(5, 2, true)]
        public decimal Perdescfin { get; set; }
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public string Usrstamp { get; set; }
        public string Ccustamp { get; set; }

        public string Refornec { get; set; }//Numero da factura do Fornecedor 
        public virtual ICollection<Fcc> Fcc { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Pgfl> Pgfl { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
    }
}
