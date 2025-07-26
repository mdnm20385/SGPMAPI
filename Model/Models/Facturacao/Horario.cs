using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Horario
    {
        [Key]
        public string Horariostamp { get; set; }
        public string Turmastamp { get; set; }
        public string Turma { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Anosem { get; set; }
        public bool Visualizar { get; set; }// Visualizar horário a partir da data
        public bool Hactivo { get; set; }//Hoarario activo ou em exercicio 
        public virtual ICollection<Horariol> Horariol { get; set; }//Linhas do horario  
    }
}
