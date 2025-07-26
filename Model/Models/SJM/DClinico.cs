using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Model.Models.SJM
{
    public  class DClinicos
    {
        [Key]
        [StringLength(100)]
        
        public string PaStamp { get; set; }
        [StringLength(1000)]
        public string DadosAnamense { get; set; }

        [StringLength(1000)]
        public string ExamesObjectivos { get; set; }

        [StringLength(500)]
        public string ExamesClinicos { get; set; }
        [StringLength(500)]
        public string DiaDef { get; set; }

        [StringLength(1000)]
        public string Conclusao { get; set; }

        [StringLength(100)]
        public string Inseriu { get; set; }

        [StringLength(30)]
        public string InseriuDataHora { get; set; }

        [StringLength(100)]
        public string Alterou { get; set; }

        [StringLength(30)]
        public string AlterouDataHora { get; set; }

        public virtual Pa Pa { get; set; }

    }
}
