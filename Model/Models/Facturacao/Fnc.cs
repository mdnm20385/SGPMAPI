using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Fnc
    {
        [Key]
        public string Fncstamp { get; set; }
        [Required]
        public string No { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Nuit { get; set; }
        public string Tipo { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Saldo { get; set; }
        public string Moeda { get; set; }
        public string Status { get; set; }
        public DateTime Data { get; set; }
        public string Obs { get; set; }
        public string Pais { get; set; }
        public string Ccusto { get; set; }
        public decimal Codarm { get; set; }
        public string Armazem { get; set; }
        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }
        public bool Prontopag { get; set; }
        public string Localidade { get; set; }
        public string Site { get; set; }

        //Valor maximo de crédito que pode ser atribuido pelo fornecedor..
        public decimal Plafond { get; set; }
        //Tempo para vencimento de facturas 
        public decimal Vencimento { get; set; }
       // public bool Generico { get; set; }
        public bool Desconto { get; set; }
        public decimal Percdesconto { get; set; }
        public bool Insencao { get; set; }
        public string MotivoInsencao { get; set; }
        //public string Cobrador  { get; set; }
        public bool Clivainc { get; set; }
        //Tesoraria por defeito
        public decimal Codtz { get; set; }
        public string Tesouraria { get; set; }
        public string Contastamp { get; set; }
        public string Localentregas { get; set; }
        public bool Generico { get; set; }//Fornecedor Generico 
        public bool Fncivainc { get; set; }//Fornecedor iva incluso 
        public bool Ctrlplanfond { get; set; } //Controla o plafond de crédito 
        public decimal CodCondPagamento { get; set; }//Codigo de condicoes de Pagamento 
        public string DescCondPagamento { get; set; }//Descricao de condicoes de Pagamento 

        public string Familia { get; set; }
        public virtual ICollection<FncContact> FncContact { get; set; }
        public virtual ICollection<FncCt> FncCt { get; set; }
        public virtual ICollection<FncBomb> FncBomb { get; set; }
    }
}
