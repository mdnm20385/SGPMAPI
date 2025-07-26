using Microsoft.EntityFrameworkCore;
using Model.Models.Facturacao;
using Model.Models.SGPM;
using Model.Models.SJM;
using Param = Model.Models.Facturacao.Param;

namespace DAL.Conexao;
public sealed class SGPMContext : DbContext
{
    public SGPMContext(DbContextOptions<SGPMContext> options) : base(options) { }

    #region Tables SGPM
  
    public DbSet<Cat> Cat { get; set; }
    public DbSet<Pat> Pat { get; set; }
    public DbSet<ParamAno> ParamAno { get; set; }
    public DbSet<Busca> Busca { get; set; }
    public DbSet<Localidade> Localidade { get; set; }//UserType
    public DbSet<Orgao> Orgao { get; set; }
    public DbSet<Pais> Pais { get; set; }
    public DbSet<PermForm> PermForm { get; set; }
    public DbSet<Permissao> Permissao { get; set; }
    public DbSet<Provincia> Provincia { get; set; }
    public DbSet<Subunidade> Subunidade { get; set; }
    public DbSet<Unidade> Unidade { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<UsuarioSessao> UsuarioSessao { get; set; }
    public DbSet<PostAdm> PostAdm { get; set; }//UserType
    public DbSet<Armazem> Armazem { get; set; }
    public DbSet<Artigo> Artigo { get; set; }
    public DbSet<ArtigoContrato> ArtigoContrato { get; set; }
    public DbSet<ArtigoGeral> ArtigoGeral { get; set; }
    public DbSet<CodCarta> CodCarta { get; set; }
    public DbSet<Contrato> Contrato { get; set; }
    public DbSet<Curso> Curso { get; set; }
    public DbSet<Desconto> Desconto { get; set; }
    public DbSet<Distrito> Distrito { get; set; }
    public DbSet<Email> Email { get; set; }
    public DbSet<Entrada> Entrada { get; set; }
    public DbSet<Escalao> Escalao { get; set; }
    public DbSet<Especial> Especial { get; set; }
    public DbSet<Especie> Especie { get; set; }
    public DbSet<Existencia> Existencia { get; set; }
    public DbSet<Fornecedor> Fornecedor { get; set; }
    public DbSet<Fornecimento> Fornecimento { get; set; }
    public DbSet<Instituicao> Instituicao { get; set; }
    public DbSet<Licenca> Licenca { get; set; }
    public DbSet<Mil> Mil { get; set; }
    public DbSet<MilAgre> MilAgre { get; set; }
    public DbSet<MilConde> MilConde { get; set; }
    public DbSet<MilDoc> MilDoc { get; set; }
    public DbSet<MilEmail> MilEmail { get; set; }
    public DbSet<MilEmFor> MilEmFor { get; set; }
    public DbSet<MilEspecial> MilEspecial { get; set; }
    public DbSet<MilFa> MilFa { get; set; }
    public DbSet<MilFor> MilFor { get; set; }
    public DbSet<MilFot> MilFot { get; set; }
    public DbSet<MilFuncao> MilFuncao { get; set; }
    public DbSet<MilIDigital> MilIDigital { get; set; }
    public DbSet<MilLice> MilLice { get; set; }
    public DbSet<MilLingua> MilLingua { get; set; }
    public DbSet<MilMed> MilMed { get; set; }
    public DbSet<MilPeEmerg> MilPeEmerg { get; set; }
    public DbSet<MilProm> MilProm { get; set; }
    public DbSet<MilRea> MilRea { get; set; }
    public DbSet<MilReco> MilReco { get; set; }
    public DbSet<MilReg> MilReg { get; set; }
    public DbSet<MilRetReaSal> MilRetReaSal { get; set; }
    public DbSet<MilSa> MilSa { get; set; }
    public DbSet<MilSalario> MilSalario { get; set; }
    public DbSet<MilSalMensal> MilSalMensal { get; set; }
    public DbSet<MilSit> MilSit { get; set; }
    public DbSet<MilSitCrim> MilSitCrim { get; set; }
    public DbSet<MilSitDisc> MilSitDisc { get; set; }
    public DbSet<MilSitQPActivo> MilSitQPActivo { get; set; }
    public DbSet<MilSubEspecial> MilSubEspecial { get; set; }
    public DbSet<QualifcTecnica> QualifcTecnica { get; set; }
    public DbSet<Ramo> Ramo { get; set; }
    public DbSet<Reg> Reg { get; set; }
    public DbSet<SubEspecial> SubEspecial { get; set; }
    public DbSet<Subsidio> Subsidio { get; set; }
    public DbSet<Suplemento> Suplemento { get; set; }
    public DbSet<Telefone> Telefone { get; set; }
    public DbSet<Entrega> Entrega { get; set; }
    public DbSet<Subunidade1> Subunidade1 { get; set; }
    public DbSet<Subunidade2> Subunidade2 { get; set; }
    public DbSet<Param> Param { get; set; }

    #endregion
    #region Menu


    // DbSets
    public DbSet<Menu> Menu { get; set; }
    public DbSet<MenuChildrenItem> MenuChildrenItems { get; set; }
    public DbSet<MenuTag> MenuTag { get; set; }
    public DbSet<MenuPermissions> MenuPermission { get; set; }
    public DbSet<UsuarioMenu> UsuarioMenus { get; set; }
    public DbSet<Menuusr> Menuusr { get; set; }
    #endregion

 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        //// Configuração da entidade Menu
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(m => m.MenuStamp);
            entity.Property(m => m.MenuStamp).IsRequired();

            entity.HasMany(m => m.Children)
                  .WithOne(c => c.ParentMenu)
                  .HasForeignKey(c => c.ParentMenuStamp)
                  .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(m => m.Label)
                  .WithMany()
                  .HasForeignKey(m => m.LabelStamp)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Badge)
                  .WithMany()
                  .HasForeignKey(m => m.BadgeStamp)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Permissions)
                  .WithMany()
                  .HasForeignKey(m => m.MenuPermissionsStamp)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuração da entidade MenuChildrenItem
        modelBuilder.Entity<MenuChildrenItem>(entity =>
        {
            entity.HasKey(c => c.MenuChildrenItemStamp);
            entity.Property(c => c.MenuChildrenItemStamp).IsRequired();

            entity.HasOne(c => c.Permissions)
                  .WithMany()
                  .HasForeignKey(c => c.MenuPermissionsStamp)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(c => c.Children)
                  .WithOne(c => c.ParentItem)
                  .HasForeignKey(c => c.ParentItemStamp)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UsuarioMenu>(entity =>
        {
            entity.HasKey(um => new { um.PaStamp, um.MenuStamp }); // chave composta

            entity.HasOne(um => um.Usuario)
                .WithMany(u => u.UsuarioMenu)
                .HasForeignKey(um => um.PaStamp);

            entity.HasOne(um => um.Menu)
                .WithMany(m => m.UsuarioMenus)
                .HasForeignKey(um => um.MenuStamp);

            entity.ToTable("UsuarioMenus"); // nome da tabela no banco
        });

        SqlConstring.ModelCreating(modelBuilder);
    }

}