using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Facc
    {
        [Key]
        public string Faccstamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Tdocfstamp { get; set; }
        public string Sigla { get; set; }
        public string Numero { get; set; }
       // [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public DateTime Dataven { get; set; }
        public DateTime DataAprovacao { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Moeda { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Subtotal { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Perdesc { get; set; }
        public decimal Desconto { get; set; }
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
        public bool Anulado { get; set; }
        public string CodInterno { get; set; }
        public bool Movtz { get; set; }
        public bool Movstk { get; set; }
        public bool Movcc { get; set; }
        public string Nomedoc { get; set; }
        public decimal Codmovstk { get; set; }
        public string Descmovstk { get; set; }
        public decimal Codmovcc { get; set; }
        public string Descmovcc { get; set; }
        public string Numinterno { get; set; }
        public string Ccusto { get; set; }
        public string Obs { get; set; }
        public string Oristamp { get; set; }
        public bool Aprovado { get; set; }
        public decimal Tipodoc { get; set; }
        public bool Integra { get; set; }
        public bool Reserva { get; set; }
        public decimal No2 { get; set; }
        public string Nome2 { get; set; }
        [DecimalPrecision(10, 3, true)]
        public decimal Cambiousd { get; set; }
        public string Moeda2 { get; set; }
        public string Pjnome { get; set; }
        public string Pjstamp { get; set; }
        public bool Comprado { get; set; }
        public bool Encomenda { get; set; }
        public decimal Pjno { get; set; }
        public string Requisicao { get; set; }
        public string Fncstamp { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Descontofin { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal MDescontofin { get; set; }
        [DecimalPrecision(8, 3, true)]
        public decimal Perdescfin { get; set; }
        public decimal CodCondPagamento { get; set; }//Codigo de condicoes de Pagamento 
        public string DescCondPagamento { get; set; }//Descricao de condicoes de Pagamento 
        public string Ccustamp { get; set; }
        public string Usrstamp { get; set; }
        public bool Nc { get; set; }
        public bool Nd { get; set; }
        public bool Ft { get; set; }
        public bool Vd { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Nuit { get; set; }
        public virtual ICollection<Faccprest> Faccprest { get; set; }
        public virtual ICollection<Faccl> Faccl { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Fcc> Fcc { get; set; }
        public virtual ICollection<Faccanexo> Faccanexo { get; set; }
    }
}
