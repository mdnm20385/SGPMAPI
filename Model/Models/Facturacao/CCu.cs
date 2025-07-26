using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class CCu
    {
        [Key]
        public string Ccustamp { get; set; }
        public string Empresastamp { get; set; }
        public string Nome { get; set; }
        public string CodCcu { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string Status { get; set; }
        public bool Defeito { get; set; }
        public string Morada { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public decimal Nuit { get; set; }
        public bool Padrao { get; set; }
        public bool Controlanumcl { get; set; } //Controla numeracao de clientes 
        public bool Controlanumfnc { get; set; } //Controla numeracao de fornecedores  
        public decimal Minimocl { get; set; } // Minimo numero de cliente na Loja 
        public decimal Maximocl { get; set; } // Maximo numero de cliente na Loja 
        public decimal Minimofnc { get; set; } // Minimo numero de cliente na Loja 
        public decimal Maximofnc { get; set; } // Maximo numero de cliente na Loja 
        public string Director { get; set; }
        public virtual ICollection<Ccu_Caixa> CcuCaixa { get; set; }
        public virtual ICollection<Ccu_Arm> CcuArm { get; set; }
        public virtual ICollection<Ccutv> CcuTv { get; set; }
        public virtual ICollection<Ccudep> Ccudep { get; set; }
    }
}
