using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class St
    {
        [Key]
        public string Ststamp { get; set; }
        [Required]
        public string Referenc { get; set; }
        [MaxLength(4100)]
        public string Obs { get; set; }
        public string Refornec { get; set; }
        public string Tipo { get; set; }//Bar; Cozinha; Restaurant,Extras 
        public string CodigoBarras { get; set; }
        public string Status { get; set; }
        public string Unidade { get; set; }
        public string Descricao { get; set; }
        public bool Servico { get; set; }
        public decimal Tabiva { get; set; }
        [DecimalPrecision(5, 2,true)] 
        public decimal Txiva { get; set; }
        [DecimalPrecision(20, 2, true)]
        public decimal Valor { get; set; }
        public bool Ivainc { get; set; }
        public string Codfam { get; set; }
        public string Familia { get; set; }
        public string Codsubfam { get; set; }
        public string Subfamilia { get; set; }
        public string Codarm { get; set; }
        public string Armazem { get; set; }
        public decimal Codmarca { get; set; }
        public string Marca { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }
        public string Motor { get; set; }
        public string Chassis { get; set; }
        public decimal Anofab { get; set; }

        public decimal Tara { get; set; }//Usado como Nivel Académico NO MÓDULO ACADEMIA//1=Licenciatura//2=Mestrado
        public decimal Pesobruto { get; set; }
        public bool Combustivel { get; set; }
        public string TipoCombustivel { get; set; }
        public decimal Codfab { get; set; }
        public string Fabricante { get; set; }
        public bool Negativo { get; set; }
        public bool Viatura { get; set; }
        public bool Avisanegativo { get; set; }
        public bool Descontinuado { get; set; }
        public bool Ligaprojecto { get; set; }
        public bool Composto { get; set; }
        [DecimalPrecision(20, 2,true)] 
        public decimal Stock { get; set; }
        public decimal Ultimopreco { get; set; }
        public decimal Precoponderado { get; set; }
        public byte[] Imagem { get; set; }
        public decimal Codtrailer { get; set; }
        public bool Trailer { get; set; }
        public bool Procedimento { get; set; }
        //Novos campos
        public bool Usaconvunid { get; set; }//Usa conversão de unidades 
        public decimal Quantidade { get; set; }//Quantidade de conversao 
        public string Unidsaida { get; set; }//Unidade de saida
        public bool Usadoprod { get; set; }//Usado na Producao
        public bool Dimensao { get; set; }//Artigo com dimencoes 
        public bool Devolc { get; set; }//Sujeito a Devolucao  
        public bool Usaserie { get; set; }//Usa Series 
        [DecimalPrecision(20, 2,true)]
        public decimal Stockmin { get; set; }
        [DecimalPrecision(20, 2,true)]
        public decimal Stockmax { get; set; }
        [DecimalPrecision(20, 2,true)]
        public decimal Reserva { get; set; }
        [DecimalPrecision(20, 2,true)]
        public decimal Encomenda { get; set; }
        public bool Nmovstk { get; set; }
        public bool Pos { get; set; }
        public string Motorista { get; set; }
        public string Departanto { get; set; }
        public string Ccusto { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Cilindrada { get; set; } 
        //Dados de Leasing 
        public string Companhia { get; set; }  
        public string Contrato { get; set; }  
        public DateTime Inicio { get; set; }  
        public DateTime Termino { get; set; } 
        [DecimalPrecision(20, 2,true)]
        public decimal ValorLeasing { get; set; }
        [DecimalPrecision(16, 2,true)]
        public decimal Mensalidade { get; set; }
        //Fim de Leasing 
        public bool Bloqueado { get; set; }
        public decimal Assentos { get; set; } 
        public decimal Portas { get; set; } 
        public DateTime Data { get; set; } 
        public string Trailref { get; set; } 
        public string Traildesc { get; set; } 
        public decimal Anomodelo { get; set; } 
        public decimal Eixos { get; set; } 
        public decimal Pneus { get; set; } 
        [DecimalPrecision(20, 2,true)]
        public decimal Carga { get; set; } 

        [DecimalPrecision(20, 2,true)]
        public decimal Vendido { get; set; } 
        [DecimalPrecision(20, 2,true)]
        public decimal Comprado { get; set; }
        public bool Obterpeso { get; set; } 
        public decimal Peso { get; set; } 
        public decimal Volume { get; set; }
        public bool Usalote { get; set; } 
        public bool Ivametade { get; set; } //IVA Metade 
        //Contabilidade 
        public string Cpoc { get; set; } //Codigo de Integracao para vendas e Compras 
        public string ContaInv { get; set; } //Conta de Inventario 
        public string ContaCev { get; set; } //CEV -Conta de Existencias Vendidas  
        public string ContaReo { get; set; } //Conta de REO 
        public string ContaCoi { get; set; } //Conta de COI 
        public string Nofrota { get; set; }
        public string Cor { get; set; }
        public bool Gasoleo { get; set; } 
        public bool Naovisisvel { get; set; } //Permite que o produto nao seja visivel na facturacao
        //Imobilizado.........
        public bool Activo { get; set; }
        public decimal Tipoartigo { get; set; }//se é:1-Produto,2-Servico, 3-Viatura, 4-Activo
        [DecimalPrecision(10, 2, true)]
        public decimal Quantvenda { get; set; }
        //Fim de imobilizado 

        public bool Usaquant2 { get; set; }//Utiliza quantidade 2 nas vendas casos de bedidas a pressao 
        public virtual St2 St2 { get; set; }
        public virtual ICollection<StPrecos> StPrecos { get; set; }
        public virtual ICollection<StRefFncCod> StRefFncCod { get; set; }
        public virtual ICollection<Stcp> Stcp { get; set; }
        public virtual ICollection<StFnc> StFnc { get; set; }
        public virtual ICollection<Starm> Starm { get; set; }
        public virtual ICollection<StVtman> StVtman { get; set; }
        public virtual ICollection<StVtdoc> StVtdoc { get; set; }
        public virtual ICollection<StVtTrailer> StVtTrailer { get; set; }//Drp
        public virtual ICollection<StCt> StCt { get; set; }//Contas na contabilidade de artigos 

        public virtual ICollection<StQuant> StQuant { get; set; }//quantidade em ml ou litros versus o preco 
        public bool Disciplina { get; set; }
        public string Sigla { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Credac { get; set; }//Credito Academico
        [DecimalPrecision(6, 2, true)]
        public decimal Cargahtotal { get; set; }//Somatorio de teorica e pratica 
        [DecimalPrecision(6, 2, true)]
        public decimal Cargahteorica { get; set; }//Carga Horaria Teorica 
        [DecimalPrecision(6, 2, true)]
        public decimal Cargahpratica { get; set; }//Carga Horaria Pratica 
        public bool Prec { get; set; }//Indica se a disciplina tem precedencia 
        public virtual ICollection<Stl> Stl { get; set; }//Disciplinas de precedencia 
        public virtual ICollection<Stb> Stb { get; set; }//Bibliografia recomendada 
        public virtual ICollection<Stpe> Stpe { get; set; }//Funcionarios - modulo de EMTPM 
        public virtual ICollection<Stmaq> Stmaq { get; set; }//Maquinas de venda - modulo de EMTPM 
        public bool Multa { get; set; }
        public bool Bilhete { get; set; }
        public bool Bilheteespecial { get; set; }
        //public bool BilheteCarga { get; set; }
        public decimal TipoProduto { get; set; }

        // QRCODE
        public byte[] Codigobarra { get; set; }
        public byte[] CodigoQr { get; set; }
        //

        public string Codigobarrasemba { get; set; }//Codigo barras de embalagem/caixa
        public bool UsaMultCodigobarraSt { get; set; }
        public string Campomultiuso { get; set; }//1
        public decimal ValidadeDias { get; set; }// O Produto pode ser vendido até tantos dias (antes ou depois)
        public decimal GarantiaDias { get; set; }// O Produto tem tantos dias de garantia
    
    }
}
