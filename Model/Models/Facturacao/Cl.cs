using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Cl
    {
        [Key]
        [ScaffoldColumn(false)]
        public string Clstamp { get; set; }
        //[Required]
         //[Index("IX_X_Cl", 1, IsUnique = true)]
       // [Index(IsUnique = true)] // Define um índice único
        public string? No { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public decimal Codprov { get; set; }
        public decimal Coddist { get; set; }
        public decimal Codpad { get; set; }
        public string Localidade { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        [DecimalPrecision(16, 0, true)]
        public decimal Nuit { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal Saldo { get; set; }
        public string Moeda { get; set; }
        public string Status { get; set; }
        [Display(Name = "Data")]
        public DateTime Datacl { get; set; }
        [MaxLength(650)]
        public string Obs { get; set; }
        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }
        public byte[] Codigobarra { get; set; }
        public byte[] CodigoQr { get; set; }
        public bool Prontopag { get; set; }
        public string Tipo { get; set; }
        public bool Pos { get; set; }
        public string Pais { get; set; }
        //Dados especificos de estudantes............ 
        public string Codcurso { get; set; }
        public string Curso { get; set; }
        public string Gradestamp { get; set; }
        public string Descgrelha { get; set; }
        public DateTime Anoingresso { get; set; }
        public bool Bolseiro { get; set; }
        public string Coddep { get; set; }
        public string Departamento { get; set; }
        public string Codfac { get; set; }
        public string Faculdade { get; set; }
        //Dados do cliente fornecedor 
        public string Nofnc { get; set; }
        public string Fnc { get; set; }
        public DateTime Datanasc { get; set; }
        public string Sexo { get; set; }
        [MaxLength(200)]
        public string Areafiscal { get; set; }//Direcao da area fiscal caso mozlec 
        public bool Aluno { get; set; }
        public string Estadocivil { get; set; }
        public string Religiao { get; set; }
        public string Nivelac { get; set; }
        public string Codaluno { get; set; }
        public string Codesc { get; set; }
        public string Escola { get; set; }
        public bool Planosaude { get; set; }
        public string Medico { get; set; }
        public string Hospital { get; set; }
        public string Instplanosaude { get; set; }
        public string Transp { get; set; }
        public bool Sozinho { get; set; }
        public bool Acompanhado { get; set; }
        //Fim de dados de estudante............
        public decimal Codccu { get; set; }
        public string Ccusto { get; set; }
        public string Ccustostamp { get; set; }
        public bool DeficilCobrar { get; set; }
        //Valor maximo de crédito que pode ser atribuido ao cliente..
        [DecimalPrecision(16, 2, true)]
        public decimal Plafond { get; set; }
        //Tempo para vencimento de facturas 
        public decimal Vencimento { get; set; }
        public bool Generico { get; set; }
        public bool Desconto { get; set; }
        public decimal Percdesconto { get; set; }
        public decimal CodCondPagamento { get; set; }//Codigo de condicoes de Pagamento 
        public string DescCondPagamento { get; set; }//Descricao de condicoes de Pagamento 
        public bool Insencao { get; set; }
        public string MotivoInsencao { get; set; }
        public string Cobrador  { get; set; }
        public bool Clivainc { get; set; }
        public bool Paciene { get; set; }
        public bool Entidade { get; set; }
        //Tesoraria por defeito
        public decimal Codtz { get; set; }
        public string Tesouraria { get; set; }
        public string Localentregas { get; set; }
        //Conta do cliente no Plano de contas ...
        public string ContaPgc { get; set; }
        //Grupo de cliente no PGC ex: 441...
        public string GrupoclPgc { get; set; }
        //Descricao do Cl no PGC ex: Cliente conta corrente...
        public string DescGrupoclPgc { get; set; }
        public string Site { get; set; }
        public bool Variasmoradas { get; set; }
        public string Tipocl { get; set; }//Classificador de clientes quanto ao desconto
        public bool Precoespecial { get; set; } //Define 
        public bool Ctrlplanfond { get; set; }//Controla Plafond de crédito
        public string Contastamp { get; set; }
        public bool Mesavirtual { get; set; }//Mesa resultante de Juncao de mesas 
        public bool Possuifilial { get; set; }//Indica que tem uma filial 
        public virtual ICollection<ClFam> ClFam { get; set; }
        //public virtual ICollection<ClClasse> ClClasse { get; set; }
        public virtual ICollection<ClTur> ClTurma { get; set; }
        public virtual ICollection<ClContact> ClContact { get; set; }
        public virtual ICollection<ClCt> ClCt { get; set; }
        public virtual ICollection<ClDoc> Cldoc { get; set; }
        public virtual ICollection<ClCur> ClCurso { get; set; }
        public virtual ICollection<ClDoenca> ClDoenca { get; set; }
        public virtual ICollection<ClBolsa> ClBolsa { get; set; }
        public virtual ICollection<ClMorada> ClMorada { get; set; }
        public virtual ICollection<Clst> Clst { get; set; }
        public virtual ICollection<ClContas> ClContas { get; set; }
        public virtual ICollection<ClFilial> ClFilial { get; set; }
        public virtual ICollection<ClCart> ClCart { get; set; }//Cartao de estudante //Peling
        public virtual ICollection<ClLing> ClLing { get; set; }//Linguas que o aluno fala 
        public string Contasstamp { get; set; }
        public virtual ICollection<Marcacao> Marcacao { get; set; }
        public virtual ICollection<ClEntity> ClEntity { get; set; }
    }
}

