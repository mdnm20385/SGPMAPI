namespace Model.Models.Facturacao
{
public class Cabaz
    {
        public string Cabazstamp { get; set; }
        public string Descricao { get; set; }
        public string codigo { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataValidade { get; set; }
        public string Status { get; set; }
        public string TipodeCabaz { get; set; }
        public string Categoria { get; set; }
        public string Categoriastamp { get; set; }
        public decimal Saldototal { get; set; }

    }
}
