using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Di
    {
        [Key]
        public string Distamp { get; set; }
        public decimal Numdoc { get; set; }
        public string Sigla { get; set; }
        public string Tdistamp { get; set; }
        public string Numinterno { get; set; }
        public string Numero { get; set; }
        public decimal Entidade { get; set; }
        public DateTime Data { get; set; }
        public DateTime Dataven { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Entidadestamp { get; set; }
        public string Moeda { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Subtotal { get; set; }
        [DecimalPrecision(18, 4, true)]
        public decimal Perdesc { get; set; }
        [DecimalPrecision(18, 4, true)]
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
        public decimal Codvend { get; set; }
        public string Vendedor { get; set; }
        public decimal Cambio { get; set; }
        public bool Cambfixo { get; set; }
        public bool Anulado { get; set; }
        public bool Movtz { get; set; }
        public bool Movstk { get; set; }
        public bool Trf { get; set; }
        public string Nomedoc { get; set; }
        public decimal Codtz { get; set; }
        public string Contatesoura { get; set; }
        public decimal Codmovstk { get; set; }
        public string Descmovstk { get; set; }
        public string Reffornec { get; set; }
        public string Ccusto { get; set; }

        public decimal Codmovstk2 { get; set; }
        public string Descmovstk2 { get; set; }
        [MaxLength(2000)]
        public string Obs { get; set; }
        public string Oristamp { get; set; }
        public bool Aprovado { get; set; }
        public decimal Codarm { get; set; }
        public string Descarm { get; set; }
        public decimal Codarm2 { get; set; }
        public string Descarm2 { get; set; }
        public bool Clivainc { get; set; }
        public decimal No2 { get; set; }
        public string Nome2 { get; set; }
        public bool Fechado { get; set; }
        public decimal Pjno { get; set; }
        public string Pjstamp { get; set; }
        public string PjNome { get; set; }
        public string Trailerref { get; set; }//Referência da Trailer
        public string Trailer { get; set; }//Trailer na Frota
        public decimal Tipo { get; set; }
        public decimal No3 { get; set; }
        public string Nome3 { get; set; }
        public decimal No4 { get; set; }
        public string Nome4 { get; set; }
        public string Mercadoria { get; set; }
        public string Refcl { get; set; }
        public string Nrfornec { get; set; }
        public string Destino { get; set; }
        public string Moeda2 { get; set; }
        public decimal Seguro { get; set; }
        public DateTime Dchegada { get; set; }
        public decimal Codmovtz { get; set; }
        public string Descmovtz { get; set; }
        public decimal Codmovtz2 { get; set; }
        public string Descmovtz2 { get; set; }
        public bool TrfConta { get; set; }
        public bool Encomenda { get; set; }
        public bool Reserva { get; set; }
        public bool Vendido { get; set; }
        public bool Comprado { get; set; }
        public bool Estorno { get; set; }
        //novos campos 
        public bool Manutantecipada { get; set; }//Define se manutencao é atencipada ou antes do periodo def
        public string Matricula { get; set; }
        public string Localpartida { get; set; }
        public DateTime Horapartida { get; set; }
        public DateTime Horachegada { get; set; }

        public string Localmanut { get; set; }
        public bool Fechomanut { get; set; }
        public DateTime Datafecho { get; set; }
        //Sinistro
        public string Kilometragem { get; set; }
        public string Morada { get; set; }
        public string Nuit { get; set; }
        public string Bomba { get; set; }//Define a bomba de combustivel onde foi feito o abastecimento
        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        public string Requisicao { get; set; }
        public string Ccustamp { get; set; }
        public string Usrstamp { get; set; }
        public virtual ICollection<Dil> Dil { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Dianexo> Dianexo { get; set; }
        public virtual ICollection<Ditec> Ditec { get; set; }
        public string Localentrega { get; set; }
        public string Departamento { get; set; }
        public string Motorista { get; set; }
        public string Pais { get; set; }
        public string Mail { get; set; }
        public string Cell { get; set; }
        public string Pcontacto { get; set; }
        public DateTime Dataentrega { get; set; }
        public DateTime Datapartida { get; set; }
        public bool Entrega { get; set; }
        public bool Prod { get; set; }
        public string Caixastamp { get; set; }
        public string Caixalstamp { get; set; }
    }
}
