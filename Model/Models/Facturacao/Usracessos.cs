using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Usracessos
    {
            [Key]
            public string Usracessostamp { get; set; }
            public string Descricao { get; set; }
            public bool Ver { get; set; }
            public bool Intro { get; set; }
            public bool Altera { get; set; }
            public bool Apaga { get; set; }
            public bool Anula { get; set; }
            public bool Imprimir { get; set; }

            [ForeignKey("UsrModulo")]
        public string Usrmodulostamp { get; set; }

        [ForeignKey("Usrstamp")]
        public string Usrstamp { get; set; }
            public string Ecran { get; set; }
            public decimal Tipo { get; set; }
            public string Sigla { get; set; }
            public decimal Numdoc { get; set; }
            public decimal Numrlt { get; set; }
            public decimal Nordem { get; set; }
            public decimal Codmodulo { get; set; }
            public decimal Codmenu { get; set; }
            public decimal Ordem { get; set; }
            public bool Headgroup { get; set; }
            public bool Activo { get; set; }
            public bool Painel { get; set; }
            public string Origem { get; set; }
            public string Oristamp { get; set; }
            public virtual UsrModulo UsrModulo { get; set; }
            public virtual Usr Usr { get; set; }
    }
}