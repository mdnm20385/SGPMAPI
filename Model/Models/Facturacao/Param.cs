using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public  class Param
    {
        [Key]
        public string Paramstamp { get; set; }
        public string Codprod { get; set; }
        public  bool ImprimeMultDocumento { get; set; }
        public string CodprodMascra { get; set; }
        public bool Vendeservico { get; set; }
        public decimal Ano { get; set; }
        public bool Prodenum { get; set; }
        public decimal Ivcodentr { get; set; }
        public string Ivdescentr { get; set; }
        public decimal Ivcodsai { get; set; }
        public string Ivdescsai { get; set; }
        public bool Usames { get; set; }
        public string Contmascara { get; set; }
        public bool  Mostranib { get; set; }
        //Tempo para o bloqueio da tela no POS Restaurante 
        public decimal Intervalo { get; set; }
        //Preenche o valor na celula de numerário automaticamente 
        public bool Fillvalue { get; set; }
        //Permite mostrar os produtos sem stock no POS...
        public bool MostraProdutoSemStock { get; set; }
        public bool Excluemascara { get; set; }
        public bool DiarioMesNum { get; set; }
        public bool DiarioDiamesnum { get; set; }
        public bool DiarioAnonum { get; set; }
        public bool CriaContacc { get; set; }
        public bool Usanumauto { get; set; }
        public string Nummascara { get; set; }
        public string Mascfact { get; set; }
        public string Radicalfact { get; set; }
        //Actualiza os precos de compra automaticamente durante a compra ...
        public bool Actualizapreco { get; set; }
        //O numero da factura é uma montada ao emitir o recibo na mesma ...
        public bool Montanumero { get; set; }
        //Controle de operacao POSSUP
        public string Tipooperacao { get; set; }
        //Número de impressão seguidas no pagamento em pos... 
        public decimal NumImpressao { get; set; }
        //Report a imprimir no pagamento em POS Modelo Retalho 
        [MaxLength(250)]
        public string Printfile { get; set; }
        //Report a imprimir no pagamento em POS modelo supermercado 
        [MaxLength(250)]
        public string Printfile2 { get; set; }
        public bool Mostraendereco { get; set; } //Mostra campo endereço na tabela de armazens
        public string Smtpserver { get; set; } //Servidor SMTP
        public decimal Smtpport { get; set; } //porta do SMTP
        public string Outgoingemail { get; set; }
        public string Outgoingpassword { get; set; }
        public string Subjemail { get; set; }
        [MaxLength(650)]
        public string Emailtext { get; set; }
        public bool Autoprecos { get; set; }//Automatiza os precos de venda apartir de compras
        [DecimalPrecision(16, 2,true)]
        public decimal Perlucro { get; set; }//Define a percentagem minima de lucro 
        public decimal Anoref { get; set; }//Ano de Referencia na Gestao  
        public bool Localrdlc { get; set; }//Define se usa report na pasta ou guardados na base de dados 
        public bool Usalocalreport { get; set; }//Define se usa o Report local ou Gravado na base de dados 
       //Contabilidade 
       public bool Criacl { get; set; }//Define se cria se automaticamente um cliente na contabilidade  
       public bool Criafnc { get; set; }//Define se cria se automaticamente um fornecedor na contabilidade 
       public bool Criast { get; set; }//Define se cria se automaticamente um Produto/servico na contabilidade 
       public bool Criacontas { get; set; }//Define se cria se automaticamente uma Conta de tesouraria na contabilidade 
       public bool Criacontasprazo { get; set; }//Define se cria se automaticamente uma Conta de tesouraria na contabilidade 
       public bool Criape { get; set; }//Define se cria se automaticamente uma pessoa na contabilidade 
       //Fin das definicoes de gestao para contabilidade 
        public bool Ivaposdesconto { get; set; } // determina se o iva será deduzido depois de desconto...
        public string ContaIrps { get; set; }//Conta IRPC 
        public string ContaIrpsdesc { get; set; }//Descricao da conta do IRPC 
        public string Contaiva85 { get; set; }//Conta a receber o custo de 8.5% do iva  
        public string Contaiva85desc { get; set; }//Descricao da Conta a receber o custo de 8.5% do iva  
        #region Campos de Projecto
        public bool Naomostradatain { get; set; }
        public bool Naomostradatater { get; set; }
        public bool Naomostraduracao { get; set; }
        public bool Naomostrasequencia { get; set; }
        public bool PoObrigatorio { get; set; }
        public bool PjFechoautomatico { get; set; }
        #endregion
        [DecimalPrecision(6, 2,true)]
        public decimal TaxaInsspe { get; set; }//Taxa INSS Trabalhador  
        [DecimalPrecision(6, 2,true)]
        public decimal TaxaInssemp { get; set; }//Taxa INSS Empresa
        public decimal Diastrab { get; set; }//Dias Normais de trabalho num mes
        public bool Ponaorepete { get; set; }//Modeloja
        public bool Modeloja { get; set; }//O ecram de facturacao como venda em loja ...
        public bool Integracaoautomatica { get; set; } //Define se a gestao integra os documentos automaticamente ou nao 
        public decimal Aredondamento { get; set; }//Define o numero de casas decmais para arredondamento 
        public decimal Posicao { get; set; }
        public bool Totalinteiro { get; set; }//Arrredonda sempre para Inteiro se estiver True..
        public bool Mostraccusto { get; set; }//Permite mostrar Centros de custo nas linhas 
        public bool Integradocs { get; set; }//A Empreas integra documentos na contabilidade via CPOCs
        public bool ObrigaNc { get; set; }//Obriga criar nota de credito ao anualar a factura ou VD
        public string Codsrc { get; set; }//Codigo de Servico
        public string Codactivo { get; set; }//Codigo de Activo Duodessimos
        public bool Duodessimos { get; set; }
        public bool Depmensais { get; set; } //Depreciacoes mensais 
        public bool Esconderef { get; set; }
        public bool Escondestock { get; set; }
        public bool Escondecolprecos { get; set; }
        public string Preconormal { get; set; }
        public bool EcranPosPequeno { get; set; } // Indica que o ecran de pos so tem maximo de 1280x768
        public bool Mostrarefornec { get; set; }//Mostra referencia de fornecedor nas linhas para busca
        public bool Naoaredonda { get; set; }
        public decimal Horastrab { get; set; }
        public bool ObrigaBi { get; set; }//Obriga O Preencumento do Campo BI
        public bool Segundavia { get; set; }//Controla a sgunda via dos documentos de facturaca 
        public bool MostraTodasContas { get; set; }//serve para mostrar totas contas na factura independente do centro de custo
        public virtual ICollection<ParamImp> ParamImp { get; set; }
        public virtual ICollection<Paramgct> Paramgct { get; set; }
        public virtual ICollection<Parampv> Parampv { get; set; }//Parametros de definicao automatica de precos de venda 
        public virtual ICollection<Paramemail> Paramemail { get; set; }//Parametros de definicao automatica de precos de venda 
        public decimal Origem { get; set; }
        public bool GeraGuiaAutomatica { get; set; }
        public decimal Anolectivo { get; set; }
        public string AnoSem { get; set; }
        public string Mascaracl { get; set; }//Mascara do estudante 
        #region Parametros do módulo academia ....
        public bool Usacademia { get; set; }//Usa modelo academia 
        public bool Dispensa { get; set; }//Há dispensas
        public bool Exclui { get; set; }//Há exclusões
        public bool MatriculaComCCaberto { get; set; }//Matricula com conta corrente aberto
        public bool Removematricula { get; set; }// remover o bontão de Delete
        #endregion
        public bool NaoverificaNuit { get; set; }//Deixar Que o utilizador Cadastre Vários Clientes Com o mesmo Nuit
        public string EmailRespo { get; set; }
        public decimal Modulos { get; set; }//usado em que modulo
        public bool PermiteApagarPos { get; set; }
        public bool UsaMultRefereciaSt { get; set; }
        public bool UsaLotes { get; set; }
        public string Campomultiuso { get; set; }//Usado para varios fins
    }
}
