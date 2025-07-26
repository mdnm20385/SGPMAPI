using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Contas
    {
        [Key]
        public string Contasstamp { get; set; }
        public decimal Codigo { get; set; }
        public decimal Codtipo { get; set; }
        public string Tipo { get; set; }
        public string Moeda { get; set; }
        [DecimalPrecision(16, 0,true)]
        public decimal Numero { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public string Banco { get; set; }
        public string Morada { get; set; }
        public string Nib { get; set; }
        public string Swift { get; set; }
        public string Iban { get; set; }
        public string Nomecontacto { get; set; }
        public string Contacto { get; set; }
        public string Obs { get; set; }
        public string Status { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Saldo { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal MSaldo { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Saldor { get; set; }
        public bool Noneg { get; set; }
        public bool Cxmn { get; set; }
        //Indica necessidade de aparecer na impressao da factura 
        public bool VernaFactura { get; set; }
        public decimal Codpos { get; set; }
        public string Descpos { get; set; }
        public string CodCcu { get; set; }
        public string Ccusto { get; set; }
        public bool Especial { get; set; } //Usado definir se pode ser visivel, ou recebe pagamento especial
        public DateTime Data { get; set; }
        public string Cpoc { get; set; }//Codigo de integracao
        public bool Moedaest { get; set; }//Indica se a Moeda é nacional ou nao  
        public string Ccustamp { get; set; }
        public string Entidadebanc { get; set; }
        public virtual ICollection<Contasct> Contasct { get; set; }
    }
}
