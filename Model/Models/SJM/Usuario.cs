using Model.Models.Facturacao;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model.Models.SJM
{

    public class Usuario
    {
        [Key]
        public string? PaStamp { get; set; }

        public int CodUsuario { get; set; }

        public string? Nome { get; set; }

        public string? Login { get; set; }

        public string? Senha { get; set; }

        public string? PriEntrada { get; set; }

        public bool Activopa { get; set; }

        public string? Inseriu { get; set; }

        public string? InseriuDataHora { get; set; }

        public string? Alterou { get; set; }

        public string? AlterouDataHora { get; set; }

        public string? TipoPerfil { get; set; }

        public bool EdaSic { get; set; }

        public string? Sexo { get; set; }

        public string? Orgao { get; set; }

        public string? Direcao { get; set; }

        public string? Departamento { get; set; }

        public string? Orgaostamp { get; set; }

        public string? Departamentostamp { get; set; }

        public string? Direcaostamp { get; set; }

        public bool VerSitClass { get; set; }

        public string? PathPdf { get; set; }
        public string? TdocAniva { get; set; }
        [NotMapped]
        public string Path1 { get; set; }
        public string? Email { get; set; }
        public string? Passwordexperaem { get; set; }
        public bool Medico { get; set; }
        public string Patentetegoria { get; set; }
        public ICollection<UsuarioMenu> UsuarioMenu { get; set; }

    }
}
