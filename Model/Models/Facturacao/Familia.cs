using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Familia
    {
        [Key]
        public string Familiastamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public byte[] Imagem { get; set; }
        public bool Pos { get; set; }
        public string Descpos { get; set; }
        public decimal Sequenc { get; set; }
        public decimal Tipofam { get; set; }//Indica se é familia ou Corredor 
        public string Cpoc { get; set; } //Codigo de Integracao para vendas e Compras 
        public virtual ICollection<SubFam> SubFam { get; set; }
        public virtual ICollection<Familiacar> Familiacar { get; set; }//Carreiras 
        public virtual ICollection<Familiapb> Familiapb { get; set; }//Valores de bagagens estao associadas ao corredor  
    }

}
