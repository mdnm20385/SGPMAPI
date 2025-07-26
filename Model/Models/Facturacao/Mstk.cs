using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Mstk
    {
        [Key]
        public string Mstkstamp { get; set; }
        public string Oristamp { get; set; }
        public string Stampcab { get; set; }
        public string Ststamp { get; set; }
        public string Entidadestamp { get; set; }//clstamp,fncstamp,pestamp,entidadestamp,etc
        public string Origem { get; set; }
        public DateTime Data { get; set; }
        public string Tipodoc { get; set; }
        public string Nrdoc { get; set; }
        public string Documento { get; set; }
        public decimal Numdoc { get; set; }
        public string Ref { get; set; }
        public string Descricao { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Entrada { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Saida { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Vendido { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Vendidosaida { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Comparado { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Comparadoentrada { get; set; }
        public decimal Reserva { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Reservasaida { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Encomenda { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Encomendaentrada { get; set; }
        public decimal Codarm { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Preco { get; set; }
        public string Moeda { get; set; }
        public decimal Entidade { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public DateTime Datahora { get; set; }
        public string Lote { get; set; }
        public decimal Codmovstk { get; set; }
        public string Descmovstk { get; set; }
        public string Numinterno { get; set; }
        
        public string Factstamp { get; set; }
        public string Faccstamp { get; set; }
        public string Distamp { get; set; }
        public string Ivstamp { get; set; }
        [ForeignKey("Factl")]
        public string Factlstamp { get; set; }
        [ForeignKey("Faccl")]
        public string Facclstamp { get; set; }
        [ForeignKey("Dil")]
        public string Dilstamp { get; set; }
        [ForeignKey("Ivl")]
        public string Ivlstamp { get; set; }
        public string Turno { get; set; }//Nova referencia que é concatenação de Referencia do produto e Lote do produto//// Farmácia
        public string Vendedor { get; set; }
        public decimal Codvend { get; set; }
        public string Serie { get; set; }
        public bool Ivainc { get; set; }

        public decimal Tabiva { get; set; }
        public decimal Txiva { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Preco2 { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Preco3 { get; set; }
        public DateTime Lotevalid { get; set; }
        public DateTime Lotelimft { get; set; }
        public bool Usalote { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Qttmedida { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Totalmedida { get; set; }
        public string Ccusto { get; set; }
        public string Codccu { get; set; }
        public string Unidade { get; set; }
        public string Armazemstamp { get; set; }
        public string Ccustamp { get; set; }
        public string Usrstamp { get; set; }
        public string Codigobarras { get; set; }
        public string StRefFncCodstamp { get; set; }
        public string Campomultiuso { get; set; }//1
        public virtual Factl Factl { get; set; }
        public virtual Dil Dil { get; set; }
        public virtual Faccl Faccl { get; set; }
        public virtual IVL IVL { get; set; }
    }
}
