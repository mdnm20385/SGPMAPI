using Model.Models.Facturacao.Generic;
using Model.Models.Facturacao;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    
    public class Usr
    {
        [Key]
        public string Usrstamp { get; set; } 
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string? NormalizedUserName { get; set; } = string.Empty;
        public string? NormalizedEmail { get; set; } = string.Empty;
        public bool? EmailConfirmed { get; set; } = false;
        public string? PasswordHash { get; set; } = string.Empty;
        public string? SecurityStamp { get; set; } = string.Empty;
        public string? ConcurrencyStamp { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public bool? PhoneNumberConfirmed { get; set; } = false;
        public bool? TwoFactorEnabled { get; set; } = false;
        public DateTime? LockoutEnd { get; set; }=DateTime.Now;
        public bool? LockoutEnabled { get; set; } = false;
        public int? AccessFailedCount { get; set; } = 0;
        public string? UserTypeDescription { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; } = string.Empty;

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string? Password { get; set; } = string.Empty;
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [Display(Name = "Lembrar a senha?")]
        public bool? RememberMe { get; set; }=false;

        
        public decimal Numero { get; set; }
        public decimal TipoAcesso { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public bool Pos { get; set; }
        public bool Usradmin { get; set; }
        public string Codccu { get; set; }
        public string Ccusto { get; set; }
        public string Contacto { get; set; }
        public decimal Codposto { get; set; }
        public string Posto { get; set; }
        public string Pw { get; set; }
        public bool MostraLimpar { get; set; }
        public decimal Codtz { get; set; }
        public string ContaTesoura { get; set; }
        public decimal Codarm { get; set; }
        public string Armazem { get; set; }
        public bool Supervisor { get; set; }
        public bool Mudasenha { get; set; }
        public string Sigla { get; set; }
        public decimal Codgrupo { get; set; }
        public string Grupo { get; set; }
        public bool AprovaPagamento { get; set; }
        //Define se é visivel ou nao a coluna desconto nos POS's
        public bool Desconto { get; set; }
        public bool Fechacaixa { get; set; }//Permite abertura de caixa em POS
        public bool Abrecaixa { get; set; }//Permite Fecho de caixa em POS
        public string Status { get; set; }
        public string Codstatus { get; set; }
        [Display(Name = "Imagem")]
        public byte[] Imagem { get; set; }
        public string Contasstamp { get; set; }
        [DecimalPrecision(16, 2, true)]
        public decimal ValorMaxPagamento { get; set; }
        public bool Mostraprcompra { get; set; }
        public bool ReabrePj { get; set; } //Tem permissao para reabrir o Projecto
        public bool Alteracambio { get; set; }
        public bool AlteraNumero { get; set; }//Permite alterar o numero da factura manualmente
        //Tesouraria 
        public bool Mostrasaldo { get; set; }
        public bool Mostraextrato { get; set; }
        //Fim de Tesouraria 
        public bool NaoMostrafacturacao { get; set; }
        public bool NaoMostraProcessos { get; set; }
        public bool NaoMostraCadastro { get; set; }
        public bool NaoMostraConfig { get; set; }
        public bool NaoMostracompras { get; set; }
        public bool NaoMostravendas { get; set; }
        public bool NaoMostraAnalises { get; set; }

        //Fim tesouraria 
        //Dados da impressora 
        public bool Usanormal { get; set; }//Usa sempre a impressora normal o sistema nao pede para escolher a impressora nas impressoes 
        public string Impnormal { get; set; }//impressora normal 
        public string Imppos { get; set; }//Impressora pos
        //Fim da impressora 
        public decimal Lingua { get; set; }//lingua do sistema: 1-portugues, 2- Ingles
        public string Armazemstamp { get; set; }
        public string Ccustamp { get; set; }
        public bool Cancelamulta { get; set; }//Permite cancelar multas e facturas de alunos .....
        public decimal Tipousr { get; set; }//1-Vender e Caixa, 2- Vendedor sem caixa 
        public bool Naoaltera { get; set; }//Indica que nao altera vendas de outro vendedor
        public string Campomultiuso { get; set; }//1
        public virtual ICollection<UsrAudit> UsrAudit { get; set; }
        public virtual ICollection<UsrModulo> UsrModulo { get; set; }
        public virtual ICollection<Usrmudapreco> Usrmudapreco { get; set; }
        public virtual ICollection<UsrLog> UsrLog { get; set; }
        public virtual ICollection<Usracessos> Usracessos { get; set; }
        public virtual ICollection<Usrcontas> Usrcontas { get; set; }
        public virtual ICollection<UsrlogSect> UsrlogSect { get; set; }


    }
}
