namespace Model.Models.PDV
{
    public class TributacaoFiscalEstados
    {
        public int TributacaoFiscalEstadosId { get; set; }
        public int OperacaoId { get; set; }
        public int UF { get; set; }
        public bool OperacaoUFSelecionado { get; set; }
    }
}
