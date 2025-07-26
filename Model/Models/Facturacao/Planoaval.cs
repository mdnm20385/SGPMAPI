using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Planoaval
    {
        [Key]
        public string Planoavalstamp { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Anosem { get; set; }
        public string AnoSemstamp { get; set; }
        public string Formulademedia { get; set; }//Formula de media da etapa
        public string Formulademediafinal { get; set; }//Formula de media da etapa
        public bool Dispensa { get; set; }//Indica se a escola possui de dispensa de alunos
        public decimal Notadisp { get; set; }//Nota de dispensa na disciplina ....
        public decimal Nraval { get; set; }//Numero de avaliacoes 
        public bool Exclui { get; set; }

        
        public virtual ICollection<Planoavall> Planoavall { get; set; }
    }
}
