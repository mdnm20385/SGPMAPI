namespace Model.Models.PDV
{
    public class DespesasDoGrupo
    {
        public int DespesasDoGrupoId { get; set; }
        public int UsuarioId { get; set; }
        public int FornecedorId { get; set; }
        public int FuncionarioId { get; set; }
        
        public DateTime DataEmissao { get; set; }
        public DateTime DataDespesasDoGrupoFinalizada { get; set; }
        public decimal Desconto { get; set; }
         public decimal TotalIndividual { get; set; }
        public decimal TotalRestanteIndividual { get; set; }
        public string DescricaoDespesa { get; set; }
        public bool Individual { get; set; }
    }

    public class BracoEmpresarial
    {

        public int Id { get; set; }
    public string Descricao { get; set; }
    public decimal Valor   { get; set; }
    public DateTime Data    { get; set; }
    public int Percentagemb { get; set; }
    public decimal Percvvalor { get; set; }
    public decimal Percmvalor   { get; set; }
    public string Obs  { get; set; }
    public decimal ValorAnterior    { get; set; }
}
    public class DividasDoGrupo
    {
        public int Devid { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
