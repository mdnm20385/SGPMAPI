using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.SJM
{
    [Table("Permissao")]
    public partial class Permissao
    {
        [Key]
        [StringLength(100)]
        public string permissaoStamp { get; set; }

        [Required]
        [StringLength(200)]
        public string nomeFormulario { get; set; }

        [Required]
        public string descricao { get; set; }

        public bool inserir { get; set; }

        public bool consultar { get; set; }

        public bool alterar { get; set; }

        public bool apagar { get; set; }

        public bool imprimir { get; set; }

        [StringLength(100)]
        public string inseriu { get; set; }

        [StringLength(30)]
        public string inseriuDataHora { get; set; }

        [StringLength(100)]
        public string alterou { get; set; }

        [StringLength(30)]
        public string alterouDataHora { get; set; }

        [StringLength(100)]
        public string paStamp { get; set; }
        
    }
}
