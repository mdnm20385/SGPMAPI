using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Percl {
        [Key] 
        public string Perclstamp { get; set; }
        public string Pestamp { get; set; }
        public decimal Numero { get; set; }
        public string TPerclstamp { get; set; }
        public DateTime Data { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Nuit { get; set; }
        [MaxLength(10000)]
        public string Morada { get; set; }
        [MaxLength(10000)]
        public string Localidade { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Moeda { get; set; }
        public string Banco { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Total { get; set; } //Total Liquido...
        [DecimalPrecision(16, 2,true)]
        public decimal Mtotal { get; set; }
        public bool Process { get; set; }
        public DateTime Dprocess { get; set; }
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
        [DecimalPrecision(16, 0, true)]
        public decimal Cambiousd { get; set; }
        public string Moeda2 { get; set; }
        public bool Especial { get; set; } //Usado definir se pode ser visivel, ou recebe pagamento especial
        public decimal Pjno { get; set; }
        public string Pjstamp { get; set; }
        public string Processtamp { get; set; }//Stamp do processamento do salario 
        public string PjNome { get; set; }
        [MaxLength(600)]
        public string Obs { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotalAbonos { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotalDescontos { get; set; }
        public bool Anulado { get; set; }
        public bool Rcladiant { get; set; }//Recibo de adiantamento
        public string Usrstamp { get; set; }
        public string Ccustamp { get; set; }
        public virtual ICollection<Pecc> Pecc { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Percll> Percll { get; set; }
    }


}
