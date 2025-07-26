using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Pj
    {
        [Key]
        public string Pjstamp { get; set; }
        public string Numdoc { get; set; }
        public string Nomedoc { get; set; }
        public string Sigla { get; set; }
        public string Tdocpjstamp { get; set; }
        public decimal Codigo { get; set; }
        public DateTime Data { get; set; }
        public DateTime Datfim { get; set; }
        [DecimalPrecision(5, 2, true)]
        public decimal Dias { get; set; }
        public string No { get; set; }
        public string Nome { get; set; }
        public string Clstamp { get; set; }
        public string Descricao { get; set; }
        public decimal Tcusto { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Trecebido { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Tpago { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Orc { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Adenda { get; set; }
        [DecimalPrecision(6, 2, true)]
        public decimal Adendaper  { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotComp { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Totft { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotGi { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Lucro { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotftIva { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal TotCompIva { get; set; }
        public string Obs { get; set; }
        public string Pcontact { get; set; }
        public string Tcontact { get; set; }
        public string Ccusto { get; set; }
        public string Codccu { get; set; }
        public string Ccudesc { get; set; }
        public string Status { get; set; }
        //Endereco da obra ......
        public decimal Codprov { get; set;  }
        public string Ccustamp { get; set; }
        //Ccustamp
        public string Prov { get; set;  }
        public decimal Coddist { get; set;  }
        public string Dist { get; set;  }
        public string Endereco { get; set;  }
        //End.....

        [DecimalPrecision(16, 2, true)]
        public decimal Subtotal { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Desconto { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Totaliva { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Total { get; set; }
        public string Po { get; set; }//Numero de PO
        public string Morada { get; set; }//Morada do cliente
        public string Contrato { get; set; }//Nr de contrato
        public string Empfiscal { get; set; }//Empresa Fiscal 
        public string Localentrega { get; set; }
        public string Localpartida { get; set; }
        public bool Fechado { get; set; }
        public DateTime Fechadodata { get; set; }

        [DecimalPrecision(8, 2, true)]
        public decimal Cambiousd { get; set; }
        //Conversao de moedas 
        [DecimalPrecision(16, 2, true)]
        public decimal Msubtotal { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mdesconto { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mtotaliva { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Mtotal { get; set; }
        public string Moeda { get; set; }
        public string Moeda2 { get; set; }
        public virtual ICollection<Pjpe> Pjpe { get; set; }
        public virtual ICollection<Pjdepart> Pjdepart { get; set; }
        public virtual ICollection<Pjclpe> Pjclpe { get; set; }
        public virtual ICollection<Pjesc> Pjesc { get; set; }//Escopo ou linhas do projecto
        public virtual ICollection<Pjdoc> Pjdoc { get; set; }//Documentos do projecto 
        public virtual ICollection<PjAudit> PjAudit { get; set; }//Auditoria das alteracoes do projecto
    }
}
