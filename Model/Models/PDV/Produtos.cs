namespace Model.Models.PDV
{
  

    public class Produtos
    {
        public long ProdutosId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string CodigoBarras { get; set; }
        public string Fornecedor { get; set; }
        public string Formapagamento { get; set; }
        public int? UnidadeMedidaId { get; set; }
        public int? GrupoProdutosId { get; set; }
        public int? FormaPagamentoId { get; set; }
        public int? SubgrupoProdutosId { get; set; }
        public int? TributacaoFiscalId { get; set; }
        public int? FornecedorId { get; set; }
        public long TabelaIBPTId { get; set; }
        public decimal? ValorCompra { get; set; }
        public decimal? ValorVenda { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? EstoqueInicial { get; set; }
        public decimal? EstoqueAtual { get; set; }
        public decimal? EstoqueMinimo { get; set; }
        public decimal? EstoqueMaximo { get; set; }
        public string Observacao { get; set; }
        public string DataCadastro { get; set; } 
        public string UltimaCompra { get; set; }
        public string Ano { get; set; }
        public string Mes { get; set; }
        public int? No { get; set; }
        public int ComQuemEstaValorid { get; set; }
        public string Recebeu { get; set; }
        public bool JaPago { get; set; }

        public DateTime DataCadastrosAoAlterar { get; set; }
        public Produtos()
        {

        }

        public Produtos(int produtoId)
        {
            ProdutosId = produtoId;
        }

        public bool Dezembro1 { get; set; }
        public bool Janeiro { get; set; }
        public bool Fevereiro { get; set; }
        public bool Marco { get; set; }
        public bool Abril { get; set; }
        public bool Maio { get; set; }
        public bool Junho { get; set; }
        public bool Julho { get; set; }
        public bool Agosto { get; set; }
        public bool Setembro { get; set; }
        public bool Outubro { get; set; }
        public bool Novembro { get; set; }
        public bool Dezembro { get; set; }
        public bool Janeiro1 { get; set; }
        public bool Fevereiro1 { get; set; }
        public bool Março1 { get; set; }
        public bool Abril1 { get; set; }
        public bool Maio1 { get; set; }
        public bool Junho1 { get; set; }
        public bool Marcar { get; set; }

    }
}
