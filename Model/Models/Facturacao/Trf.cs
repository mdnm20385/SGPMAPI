using System.ComponentModel.DataAnnotations;
using Model.Models.Facturacao.Generic;

namespace Model.Models.Facturacao
{
public class Trf
    {

        [Key]
        public string Trfstamp { get; set; }
        public decimal Codigo { get; set; }
        public string Numinterno { get; set; }
        public DateTime Data { get; set; }
        public string Origem { get; set; }
        public decimal Orinum { get; set; }
        public string Moeda1 { get; set; }
        public string Destino { get; set; }
        public decimal Destnum { get; set; }
        public string Moeda2 { get; set; }
       [DecimalPrecision(16, 2,true)]
        public decimal Valor { get; set; }
        public string Obs { get; set; }
        public string Titulo { get; set; }
        public string Numtitulo { get; set; }
        public string Ccusto { get; set; }
        public virtual ICollection<Mvt> Mvt { get; set; }
    }
}
