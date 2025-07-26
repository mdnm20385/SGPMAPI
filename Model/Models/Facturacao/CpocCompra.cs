using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public  class CpocCompra
    {
        [Key]
        public string CpocComprastamp { get; set; }
        [ForeignKey("Cpoc")]
        public string Cpocstamp { get; set; }
        public int Tabiva { get; set; }

        public string Taxaiva { get; set; }
        [Required]
        [StringLength(12)]
        public string ValCompra { get; set; }
        public string Iva { get; set; }
        public string Desconto { get; set; } //Desconto Comercial 
        public string Descontofin { get; set; } //Desconto Financeiro  
        public bool Nac { get; set; }
        //Conta para cliente extrangeiro ...
        public string ValVendaest { get; set; }
        public string ValVendaoutro { get; set; }

        public virtual Cpoc Cpoc { get; set; }

    }
}
