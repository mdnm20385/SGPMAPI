using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Alauxiliar
    {
        [Key]
        public string Alauxiliarstamp { get; set; }
        [Required]
        public decimal Codigo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public string Obs { get; set; }
        [Required]
        public bool Padrao { get; set; }
        public decimal Tabela { get; set; }
        public string Desctabela { get; set; }
        public virtual ICollection<Alauxiliarl> Alauxiliarl { get; set; }
    }
public class Exemplo
{
    public int Id { get; set; }
    public string Nome { get; set; }
}
}
