using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Prc//Tabela que recebe processamento de salarios 
    {
        [Key]
        public string Prcstamp { get; set; }
        [ForeignKey("Process")]
        public string Processtamp { get; set; }
        public decimal Mes { get; set; }//Mes processado 
        public decimal Ano { get; set; }
        public DateTime Data { get; set; }
        public string No { get; set; }//Numero de Funcionario 
        public string Nome { get; set; }//Nome do Funcionario 
        public string Referenc { get; set; } //Codigo de movimentos(abonos,descontos,etc)
        public string Descricao { get; set; }//descricao de movimentos(abonos,descontos,etc)
        [DecimalPrecision(16, 2,true)]
        public decimal Valor { get; set; }
        [DecimalPrecision(6, 2,true)]
        public decimal Taxa { get; set; }
        public bool Fixo { get; set; }//Representa se o desconto ou subsidio é fixo ou não
        [DecimalPrecision(16, 2,true)]
        public decimal Quant { get; set; } 
        public decimal Tipo { get; set; }//0=Vencim, 1=Abonos,2=Descontos,3=Horas Extras, 4=Faltas,5 INSS EMpresa,56 INSS EMpresa,56 INSS EMpresa
        public string Codsind { get; set; }//Numero do Sindicato
        public string Codsit { get; set; }
        public decimal BaseVencimento { get; set; }//Vencimento base 
        [DecimalPrecision(16, 2,true)]
        public decimal TotalVencimento { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal TotalAbonus { get; set; } // Total Bonus especial 
        [DecimalPrecision(16, 2,true)]
        public decimal TotalDescontos { get; set; }// Total de descontos 
        [DecimalPrecision(16, 2,true)]
        public decimal TotalAliment { get; set; } //Total de alimentacao processada                                               
        [DecimalPrecision(16, 2,true)]
        public decimal TotalHextra { get; set; } //Total de Horas extras processada
        [DecimalPrecision(16, 2,true)]
        public decimal TotalFaltas { get; set; } //Total de faltas processada 
        [DecimalPrecision(16, 2,true)]
        public decimal TotalSindicato { get; set; } //Total de sindicato faltas processada 
        [DecimalPrecision(16, 2,true)]
        public decimal TotalLiquido { get; set; }//Total liquido
        public string Obs { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal ValEmp { get; set; }//Valor de emprestimo
        [DecimalPrecision(16, 2,true)]
        public decimal TotalSegSocEmp { get; set; }//Valor da seguranca social a ser pago pela empresa 
        
        [DecimalPrecision(16, 2,true)]
        public decimal TotalSegSocfunc { get; set; }//Valor da seguranca social a ser pago pela empresa 
        public string Departamento { get; set; }
        [DecimalPrecision(16, 2,true)]
	    public decimal TotalIrps { get; set; }
	    public string Diassal { get; set; }
        public string Periodo { get; set; }//se é mensal ou nao
	    public string SegSocial { get; set; }
        [DecimalPrecision(16, 2,true)]
	    public decimal SalarioHora { get; set; }
	    public string CCusto { get; set; }
        public string Ccustamp { get; set; }
        public string ContaEmpresa { get; set; }
	    public string TabIrps { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal SalHoraHExtra { get; set; }
        [DecimalPrecision(16, 2,true)]
	    public decimal SalHoraTurno { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal FundoPensao { get; set; }
	    public decimal DiasPrc { get; set; }
	    public string Moeda { get; set; }
        [DecimalPrecision(6, 2,true)]
        public decimal Cambio { get; set; }
	    public string CambioMoeda { get; set; }
        [DecimalPrecision(16, 2,true)]
	    public decimal CambioValor { get; set; }
        public string Tipoproces { get; set; }
        public bool Linhatotal { get; set; }
        public bool Alimentacao { get; set; }//Indica que 'e subsidio de Alimentacao 
        public bool Ferias { get; set; }//Indica que 'e subsidio de Ferias  
        public string Pefaltastamp { get; set; }
        public string Pehextrastamp { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal TotalEmprestimo { get; set; }
        [DecimalPrecision(6, 2,true)]
        public decimal TaxaSegSocial { get; set; }//Soma da percentagem da empresa e do funcionario (3+4)
        [DecimalPrecision(16, 2,true)]
        public decimal TotalSegSocial { get; set; } //Soma do valor fo funcionario + o valor da empresa
        [MaxLength(800)]
        public string Obsinss { get; set; }
        [MaxLength(800)]
        public string TipoEvento { get; set; } //Ocorencias mensais relacionados com a seguranca social 
        public string Pestamp { get; set; }
        [StringLength(4000)]
        public string Errosl { get; set; }
        public string PeSalbasestamp { get; set; }//
        public string Mesesstamp { get; set; }
        public virtual Proces Proces { get; set; }
        public virtual ICollection<Pecc> Pecc { get; set; }
        
    }
}
