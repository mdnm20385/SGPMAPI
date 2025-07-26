using System.ComponentModel.DataAnnotations;

namespace Model.Models.Facturacao
{
public class Dclasse
    {
        [Key]
        public string Dclassestamp { get; set; }
        public string Anosem { get; set; }
        [MaxLength(120)]
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string Tipoprazo { get; set; }
        #region Periodo da etapa
        public DateTime Datain { get; set; }
        public DateTime Datater { get; set; }
        #endregion
        #region Prazo de envio de aulas e frequência 
        public DateTime Datainaula { get; set; }
        public DateTime Datateraula { get; set; }
        #endregion
        #region Prazo de envio de avaliacoes e notas  
        public DateTime Datainnota { get; set; }
        public DateTime Dataternota { get; set; }
        #endregion
        #region Prazo de liberacao de resultados 
        public DateTime Dataresult { get; set; }
        #endregion
        public bool Fechado { get; set; }

        [MaxLength(9000)]
        public string Motivo { get; set; }
        public DateTime DataFecho { get; set; }
        public virtual ICollection<Dclassel> Dclassel { get; set; }
    }
}
