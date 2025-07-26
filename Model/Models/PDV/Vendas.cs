namespace Model.Models.PDV
{
    public class UsrAudit
    {
        public int Id { get; set; }
        public int VendasId { get; set; }
    public DateTime Data { get; set; }

    public decimal Valor { get; set; }
}
    public class Vendas
    {
        public decimal? Pagando { get; set; }
        public decimal? Desvantagem { get; set; }
        public int Id { get; set; }
        public string Chave { get; set; }
        public string ExpiraEm { get; set; }

        public long? VendasId { get; set; }
        public int  CaixaId { get; set; }
        public int? UsuarioId { get; set; }
        public long? ClientesId { get; set; }
        public long ProdutosId { get; set; }
        public int? FormaPagamentoId { get; set; }
        public int StatusId { get; set; }
        public int? FornecedorId { get; set; }
        public int FuncionarioId { get; set; }
        public string NumeroDocumento { get; set; }
        public string SituaPagto { get; set; }
        public DateTime DataEmissao { get; set; }
        public string DataEmissao1 { get; set; }
        public DateTime? DataVenda { get; set; }
        public DateTime? DataVendaFinalizada { get; set; }
        public DateTime? DataPagto { get; set; }
        public int? No { get; set; }
        public string Cpf { get; set; }
        public string Cfop { get; set; }
        public string MesAno { get; set; }
        public decimal Valorexistente { get; set; }
        public decimal Estoque { get; set; }
        
        public int ValorExistenteId { get; set; }
        public int DespesasDoGrupoId { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TotalRestanteIndividual { get; set; }
        public decimal? TotalIndividual { get; set; }
        public string DescricaoDespesa { get; set; }
        public  decimal? Total { get; set; }
        public  decimal? Totalu { get; set; }
        public decimal? Totalt { get; set; }
        public decimal? Paga { get; set; }
        public decimal? Desconto { get; set; }
        public decimal? LucroVenda { get; set; }
        public decimal? CustoVenda { get; set; }
        public decimal? PercentagemVenda { get; set; }
        public decimal? PercentualLucroVenda { get; set; }
        public decimal? SaldoGrupoUtilizado { get; set; }
        public string Observacao { get; set; }
        public decimal? ValorRestante { get; set; }
        public decimal? Troco { get; set; }
        public string MembroNome { get; set; }
        public string ClienteNome { get; set; }
        public decimal BaseCalculoIcms { get; set; }
        public decimal? EmFalta { get; set; }
        public decimal BaseCalculoPis { get; set; }
        public decimal BaseCalculoCofins { get; set; }
        public decimal ValorIcms { get; set; }
        public decimal ValorIcmsST { get; set; }
        public decimal ValorPis { get; set; }
        public decimal ValorCofins { get; set; }
        public string Serie { get; set; }
        public bool CupomFiscal { get; set; }
        public string NumeroCupomFiscal { get; set; }
        public string DescricaoFormaPagamento { get; set; }

        public string VendaNumeroCFe { get; set; }
        public string VendaChaveAcessoCFe { get; set; }
        public string VendaNumeroSerieSatCFe { get; set; }
        public string VendaNumeroCancelamentoCFe { get; set; }
        public string VendaAssinaturaQRCODECFe { get; set; }
        public string VendaChaveAcessoCancelamentoCFe { get; set; }
        public DateTime VendaDataHoraCancelamentoCFe { get; set; }
        public string VendaQRCODECancelamentoCFe { get; set; }
        public DateTime VendaDataHoraAutorizacao { get; set; }
        public int VendaNFCeNumero { get; set; }
        public int VendaNFCeAmbiente { get; set; }
        public int VendaNFCeSerie { get; set; }
        public string VendaNFCeChaveAcesso { get; set; }
        public string VendaNFCeNumeroRecibo { get; set; }
        public DateTime VendaNFCeDataHoraAutorizacao { get; set; }
        public string VendaNFCeProtocoloAutorizacao { get; set; }
        public string VendaNFCeDataHoraCancelamento { get; set; }
        public string VendaNFCeProtocoloCancelamento { get; set; }
        public string VendaNFCeQrCode { get; set; }
        
        public decimal? VendaSpedIcmsBaseCalculo { get; set; }
        public decimal? VendaSpedIcmsValor { get; set; }
        public decimal? VendaSpedIpiBaseCalculo { get; set; }
        public decimal? VendaSpedIpiValor { get; set; }
        public decimal? VendaSpedPisBaseCalculo { get; set; }
        public decimal? VendaSpedPisValor { get; set; }
        public decimal? VendaSpedCofinsBaseCalculo { get; set; }
        public decimal? VendaSpedCofinsValor { get; set; }
        public string Membro { get; set; }
        public string Cliente { get; set; }
        public bool Ativo { get; set; }//é igual ao campo Japago
        public string Mes { get; set; }
        public string Ano { get; set; }
        public int? NomeFormaPagamentoDestino { get; set; }
        public string NomeFormaPagamentoDestinoDescr { get; set; }
        public decimal? LucroTotall { get; set; }
    }
}
