using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Fact
    {
        [Key]
        public string Factstamp { get; set; }
        public decimal Numdoc { get; set; }        
       // [NotMapped]
        //public string Obscc { get; set; }
        public string Tdocstamp { get; set; }
        public string Sigla { get; set; }
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public DateTime Dataven { get; set; }
        public DateTime DataAprovacao { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }
        public string Fax { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Nuit { get; set; }
        public string Email { get; set; }
        public string Moeda { get; set; }
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
        public decimal Codvend { get; set; }
        public string Vendedor { get; set; }
        [DecimalPrecision(10, 3, true)]
        public decimal Cambiousd { get; set; }
        public bool Cambfixo { get; set; }
        public bool Anulado { get; set; }
        public string CodInterno { get; set; }
        public bool Movtz { get; set; }
        public bool Movstk { get; set; }
        public decimal Codmovstk { get; set; }
        public bool Movcc { get; set; }
        public decimal Codmovcc { get; set; }
        public string Nomedoc { get; set; }
        public string Descmovcc { get; set; }
        public string Descmovstk { get; set; }
        public string Numinterno { get; set; }
        public string Ccusto { get; set; }
        [MaxLength(1000)]
        public string Obs { get; set; }
        public string Oristamp { get; set; }
        public bool Aprovado { get; set; }
        public bool Adjudicado { get; set; }
        public string Origem { get; set; }
        public string Coment { get; set; }
        public decimal Codarm { get; set; }
        public decimal Codturno { get; set; }
        public string Turno { get; set; }
        public string Mesa { get; set; }
        public bool Fechada { get; set; }
        public bool Isiva { get; set; }
        public bool Clivainc { get; set; }
        public string Campo1 { get; set; }
        public string Campo2 { get; set; }
        public decimal Tipodoc { get; set; }
        public decimal No2 { get; set; }
        public string Nome2 { get; set; }//Nome do dono da conta na restauração
        public string Morada2 { get; set; }
        public string Localidade2 { get; set; }
        public string Nomecomerc { get; set; }//Clstamp do dono da conta na restauração
        public bool Integra { get; set; }
        public decimal NoDiario { get; set; }
        public string Diario { get; set; }
        public decimal NDocCont { get; set; }
        public string DescDocCont { get; set; }
        public bool Contabilizado { get; set; }
        public bool Reserva { get; set; }
        public decimal Lant { get; set; }
        public decimal Lact { get; set; }
        public decimal Lreal { get; set; }
        public DateTime Ldata { get; set; }        
        public string Tipoentida { get; set; }
        public string Zona { get; set; }
        public string Ncont { get; set; }
        public decimal Codzona { get; set; }
        public string Fleitura { get; set; }
        public string Ncontador { get; set; }
        public string Moeda2 { get; set; }
        public decimal Pjno { get; set; }
        public string Pjnome { get; set; }//Total Pago no Supermercado
        public string Pjstamp { get; set; }
        public decimal Estabno { get; set; }
        public string Estabnome { get; set; }
        public decimal Codisiva { get; set; }
        public string Motivoisiva { get; set; }
        public decimal Numcaixa { get; set; }
        public DateTime Datcaixa { get; set; }
        public decimal Codsec { get; set; }
        public string Descsector { get; set; }
        public decimal Posto { get; set; }
        public bool Fechado { get; set; }

        #region Dados de entrega de Produtos ...
        public bool Entrega { get; set; }
        public string Localentrega { get; set; }
        public string Localpartida { get; set; }
        public DateTime Datapartida { get; set; }
        public string Requisicao { get; set; }
        public DateTime Dataentrega { get; set; }
        public string Pais { get; set; }
        [MaxLength(20000)]
        public string Departamento { get; set; }
        public string Cell { get; set; }
        public string Mail { get; set; }
        public string Estado { get; set; }
        public string Matricula { get; set; } //Codigo do Produto
        public string Pcontacto { get; set; }//Pessoa de contacto
        #endregion
        public bool Regularizado { get; set; }
        public decimal ValRegularizado { get; set; }
        public decimal Liquidofactura { get; set; }
        public bool Vendido { get; set; }
        public bool SegundaVia { get; set; }//Indiaca que é da segundavia
        public string NrFactura { get; set; }//Numero que é da segundavia
        [MaxLength(2000)]
        public string Motivoanula { get; set; }//Motivo de anualr o documento por NC
        public string Nrdocanuala { get; set; }//Numero do documento anualado
        public string Clstamp { get; set; }
        public decimal CodCondPagamento { get; set; }//Codigo de condicoes de Pagamento 
        public string DescCondPagamento { get; set; }//Descricao de condicoes de Pagamento 
        public string Ccustamp { get; set; }
        public string Usrstamp { get; set; }
        public bool Nc { get; set; }
        public bool Nd { get; set; }
        public bool Ft { get; set; }
        public bool Vd { get; set; }
        
        //public bool Pago { get; set; }
        //[MaxLength(20000)]
        //public string Obscc { get; set; }
        //public DateTime Data_limite_pagamento { get; set; }
        //public DateTime Datapagamento { get; set; }
        public virtual ICollection<Factl> Factl { get; set; }
        public virtual ICollection<Factprest> Factprest { get; set; }
        public virtual ICollection<Factreg> Factreg { get; set; }
        public virtual ICollection<Formasp> Formasp { get; set; }
        public virtual ICollection<Cc> Fcc { get; set; }
        public virtual ICollection<Factanexo> Factanexo { get; set; }
        public string Motorista { get; set; }
        public string Cursostamp { get; set; }
        public string Desccurso { get; set; }//Total de troco no Supermercado
        public string Turmastamp { get; set; }
        public string Descturma { get; set; }
        public string Anosem { get; set; }
        public string Etapa { get; set; }
        public bool Inscricao { get; set; }
        public string Entidadebanc { get; set; }
        public string Referencia { get; set; }
        public bool Multa { get; set; }
        public bool Pos { get; set; }//Indica a factura foi feita no pos 
        public string caixastamp { get; set; }
        public string caixalstamp { get; set; }
        public bool MatriculaAluno { get; set; } = false;
    }
}
