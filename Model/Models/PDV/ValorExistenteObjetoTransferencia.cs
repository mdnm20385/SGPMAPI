namespace Model.Models.PDV
{
   public class ValorExistenteObjetoTransferencia
    {
        public int ValorExistenteId { get; set; }
        public decimal? Valor { get; set; }
        public string MesAno { get; set; }
        public string Descricao { get; set; } = "";


    }
}
