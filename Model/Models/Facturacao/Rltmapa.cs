using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models.Facturacao
{
public class Rltmapa
    {
        [Key]
        public string Rltmapastamp { get; set; }
        [ForeignKey("Rlt")]
        public string Rltstamp { get; set; }
        public string Nome { get; set; }
        public decimal Tamanho { get; set; }
        public string Alinhamento { get; set; }
        public string Formatacao { get; set; }
        public string DataPropertyName { get; set; }
        public string ColumnType { get; set; }
        public string Col1 { get; set; }//Usado como autosizemode 
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string Col4 { get; set; }
        public string Col5 { get; set; }
        public virtual Rlt Rlt { get; set; }
    }
}
