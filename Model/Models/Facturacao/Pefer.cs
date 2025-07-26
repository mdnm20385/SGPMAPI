using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public  class Pefer
    {
        [Key]
        public string Peferstamp { get; set; }
        [ForeignKey("Pe")]
        public string Pestamp { get; set; }
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Termino { get; set; }
        public decimal Dias { get; set; }
        public decimal Ano { get; set; }
        public bool Estado { get; set; } //Fechado
        public string DiasDireito { get; set; }
        public string DiasAdicionais { get; set; }
        public string DiasAnoAnterior { get; set; }
        public string TotalDias { get; set; }
        public string DiasPorGozar { get; set; }
        public string DiasJaGozados { get; set; }
        public string DiasPorMarcar { get; set; }
        public string DiasFeriasJaPagas { get; set; }
        public string PeriodosFerias { get; set; }
        public bool FuncSemFerias { get; set; }
        public string DiasAdicionaisAntig { get; set; }
        public string DiasAdicionaisAssid { get; set; }
        public string DiasAdicionaisIdade { get; set; }
        public string DiasAntecipados { get; set; }
        public virtual Pe Pe { get; set; }

    }
}
