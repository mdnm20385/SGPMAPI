using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class St2 //Gere dados de imobilizado 
    {
        [ForeignKey("St")]
        [Key]
        public string Ststamp { get; set; }
        public DateTime  Data { get; set; }//data de Aquisicao 
        public DateTime  Datain { get; set; }//data de inicio de utilizacao
        public DateTime Depin { get; set; }//Inicio de depreciacoes 
        public string  Localizacao { get; set; }//Localizacao
        public decimal  Nrelement { get; set; }//Numero de elementos
        public decimal  Nranos { get; set; }//Numero de anos do activo quando adquerido
        public decimal  Vidafis { get; set; }//Vida fiscal
        public decimal  Anomvalia { get; set; }//Ano da mais valia
        public bool  Reinsvest { get; set; }//Reinvestimento
        public bool  Ndep { get; set; }//Nao depreciar o activo
        public bool  Quotas { get; set; }//Quotas degressivas
        public bool  Duodessimos { get; set; }//Duodessimos
        public bool  Usado { get; set; }//Adquerido usado 
        public bool  Repactivo { get; set; }//Reparacao de outro activo
        public string  Activorep { get; set; }//Activo a ser reparado...
        [DecimalPrecision(20, 2,true)]
        public decimal  Valmvaliacusto { get; set; }//Valor de mais valia aceite como custo
        [DecimalPrecision(20, 2,true)]
        public decimal  Valmvaliareivest { get; set; }//Valor total de mais valia reinvestido
        //Imobilizado.........
        [DecimalPrecision(20, 2,true)]
        public decimal ValAquis { get; set; }//Valor de aquisicao total 
        [DecimalPrecision(20, 2,true)]
        public decimal ValAquisact { get; set; }//Valor de aquisicao Actualizada 
         [DecimalPrecision(20, 2,true)]
        public decimal Quantdep { get; set; }//Quantia depreciavel 
        [DecimalPrecision(20, 2,true)]    
        public decimal Quantrec { get; set; }//Quantia Recuperavel
        [DecimalPrecision(20, 2,true)]                                     
        public decimal Perdas { get; set; }//Perdas por imparidade 
        [DecimalPrecision(20, 2,true)]
        public decimal ValResidual { get; set; }//Valor residual 
        [DecimalPrecision(20, 2,true)]
        public decimal ValFiscal { get; set; }//Valor Liquido Fiscal 
        public decimal CodAmotr { get; set; }
        public string Amotr { get; set; }
        public string NaturAct { get; set; }
        public string Codtipoact { get; set; }//Codigo Tipo de activo 
        public string Tipoact { get; set; }//Tipo de activo 
        public decimal Tipoartigo { get; set; }//se é:1-Produto,2-Servico, 3-Viatura, 4-Activo
        //Fim de imobilizado 
        [DecimalPrecision(20, 2,true)]
        public decimal ValMatricial { get; set; }//Valor matricial
        [DecimalPrecision(20, 2,true)]
        public decimal Deptotalnact { get; set; }//Depreciacoes totais nao actualizadas 
        [DecimalPrecision(20, 2,true)]
        public decimal Deptotalact { get; set; }//Depreciacoes totais actualizadas
        [DecimalPrecision(20, 2,true)]
        public decimal Valdepact { get; set; }//Valor depreciavel actualizada
        [DecimalPrecision(20, 2,true)]
        public decimal Valquantesc { get; set; }//Valor quantia escriturada 
        [DecimalPrecision(5, 2,true)]
        public decimal Percdep { get; set; }//% Depreciacoes efectuadas
        [DecimalPrecision(5, 2,true)]
        public decimal Percndep { get; set; }//% Depreciacoes nao depreciavel 

        [DecimalPrecision(5, 2,true)]
        public decimal Perctaxaceite { get; set; }//% de taxa acrescida aceite 
        [DecimalPrecision(20, 2,true)]
        public decimal Quotasperdidas { get; set; }//Quotas perdidas 
        [DecimalPrecision(20, 2,true)]
        public decimal Deptotaisperdidas { get; set; }//Depreciacoes totais perdidas 
        
        //Inicio de dados da contabilidade 
        public string SNC { get; set; }//Conta SNC
        public string Depex { get; set; }//Conta de depreciacoes no exercicio 
        public string Depacu { get; set; }//Conta de depreciacoes acumuladas 
        public string Mvalia { get; set; }//Conta de mais valia 
        public string Venda { get; set; }//Conta de contabilização do produto da venda 
        public string Aliena { get; set; }//Conta de contabilização de alienação 
        public string Abate { get; set; }//Conta de contabilização de abate 
        public string Reaval { get; set; }//Conta de contabilização de reavaliações  
        public string Perdaimpa { get; set; }//Conta de contabilização de perdas por imparidade  
        public string Reversimpa { get; set; }//Reversão de imparidade 
        public string Perdaimpacum { get; set; }//Perdas por imparidade acumulada 
        public string Excedreval { get; set; }//Excedentes de revalorizacao 
        public string Passimposto { get; set; }//Passisvos por impostos diferidos 
        public string Menosvalia { get; set; }//Menos valia 

        //Fim de dados de contabilidade 
        public decimal Vdreal { get; set; }//Vida real 
        //[DecimalPrecision(20, 2,true)]
        //public decimal Valresidual { get; set; }//Valor residual 
        [DecimalPrecision(20, 2,true)]
        public decimal Valavaliac { get; set; }//Valor de avaliacoes 
        public DateTime Datavaliac { get; set; } //Data de avaliacoes
        public decimal Duracao { get; set; } //Duracao do contrato de leasing 
        public DateTime Datafim { get; set; } //Data fim da utilizacao Databate
        public DateTime Databate { get; set; } //Data  de Databate 
        [DecimalPrecision(20, 2,true)]
        public decimal Valvenda { get; set; }//Valor de avaliacoes 
        [MaxLength(2000)]
        public string Motivo { get; set; }
        [MaxLength(2000)]
        public string Grupo { get; set; }
        [MaxLength(2000)]
        public string Subgrupo { get; set; }
        public string Origem { get; set; }
        public string Oristamp { get; set; }
        [DecimalPrecision(5, 2, true)]
        public decimal Cambio { get; set; }
        public string Moeda { get; set; }
        [DecimalPrecision(5, 2, true)]
        public decimal Percent { get; set; }
        public virtual St St { get; set; }

        public virtual ICollection<StDrp> Drp { get; set; }//Depreciacoes de activos em imobilizado
        public virtual ICollection<StDrpc> StDrpc { get; set; }//Depreciacoes de activos em imobilizado
        public virtual ICollection<Stimpar> Stimpar { get; set; }//Historico por imparidades 
        public virtual ICollection<Streaval> Streaval { get; set; }//Historico das reavaliacoes  
        public virtual ICollection<Streval> Streval { get; set; }//Historico das revalorizacoes   
    }
}
