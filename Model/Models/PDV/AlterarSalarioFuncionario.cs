namespace Model.Models.PDV
{
    public class AlterarSalarioFuncionario
    {
        public int AlterarSalarioFuncionarioId { get; set; }
        public int FuncionarioId { get; set; }
        public DateTime DataHora { get; set; }
        public decimal? Valor { get; set; }
        public string Obser { get; set; }
        public int  FornecedorId { get; set; }

        public AlterarSalarioFuncionario()
        {

        }

        public AlterarSalarioFuncionario(int funcionarioId)
        {
            FuncionarioId = funcionarioId;
        }
    }
}
