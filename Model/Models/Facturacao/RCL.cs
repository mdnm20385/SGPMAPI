using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class RCL
    {
        [Key]
        public string Rclstamp { get; set; }
        public string Numero { get; set; }
        public string TRclstamp { get; set; }
        public DateTime Data { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Nuit { get; set; }
        public string Morada { get; set; }
        public string Localidade { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Moeda { get; set; }
        public string Banco { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Total { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mtotal { get; set; }
        public string Obs { get; set; }
        public bool Process { get; set; }
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public DateTime Dprocess { get; set; }
        public bool Anulado { get; set; }
        public string Ccusto { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Nomedoc { get; set; }
        public decimal Codmovcc { get; set; }
        public string Descmovcc { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
        public string Nomecomerc { get; set; }
        public bool Integra { get; set; }
        public decimal Nodiario { get; set; }
        public string Diario { get; set; }
        public decimal NdocCont { get; set; }
        public string DescDocCont { get; set; }
        public decimal Estabno { get; set; }
        public string Estabnome { get; set; }
        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        public string Moeda2 { get; set; }
        public bool Especial { get; set; } //Usado definir se pode ser visivel, ou recebe pagamento especial
        public decimal Pjno { get; set; }
        public string Pjstamp { get; set; }
        public string Clstamp { get; set; }
        public string PjNome { get; set; }//Total Pago no Supermercado
        public string Desccurso { get; set; }//Total de troco no Supermercado
        [DecimalPrecision(16, 2, true)]
        public decimal Descontofin { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal MDescontofin { get; set; }
        [DecimalPrecision(5, 2, true)]
        public decimal Perdescfin { get; set; }
        public string Usrstamp { get; set; }
        public string Ccustamp { get; set; }
        public bool Pos { get; set; }//Indica a factura foi feita no pos
                                     //
        public string Cursostamp { get; set; }
        public string Turmastamp { get; set; }
        public string Descturma { get; set; }
        public string Anosem { get; set; }
        public string Etapa { get; set; }
        public virtual ICollection<Cc> Cc { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Rcll> Rcll { get; set; }
    }
}
