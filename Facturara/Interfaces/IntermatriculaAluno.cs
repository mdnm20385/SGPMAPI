using Model.Models.Facturacao;
using Model.Models.Gene;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{

    public interface IntermatriculaAluno
    {
        Task<PaginationResponseBl<List<MatriculaAluno>>> GetGrades(
            string nimNome,
            int currentNumber,
            int pagesize);
        Task<bool> Editar(MatriculaAluno modelo);
        Task<bool> Eliminar(string id);

        Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave);
        Task<PaginationResponseBl<List<Planopag>>> GetHorariofromplanopagamento(string stamp, int currentNumber, int pagesize);
        Task<ServiceResponse<Dmzviewgrelha>> GetDados(string MatriculaAlunostamp, string tabela);
        Task<ServiceResponse<Selects>> GetMax(string tabela, string campo, string condicao);
        Task<MatriculaAluno> Criar(MatriculaAluno modelo2, bool inserindo);

        Task<ServiceResponse<Dmzviewgrelha>> Comboboxesdmz(string campos, string tabela, string condicoes);
        Task<ServiceResponse<Dmzviewgrelha>> GetAnybyquery(string campos, string tabelas, string clstamp);
        Task<ServiceResponse<TdocMat>> GetTdoc(string tdocstamp);

        Task<ServiceResponse<object?>> MetodoGenerico(Selects itemt);
        Task<ServiceResponse<Dmzviewgrelha>> GetGenerico(Selects itemt);
        Task<ServiceResponse<TRcl>> GettRclsingleq(string tdocstamp);
        Task<ServiceResponse<Dmzviewgrelha>> GetPlanopamentoestudante(string clstamp);
        Task<ServiceResponse<object?>> Iniciatileany(Selects item);
        Task<ServiceResponse<object?>> GetQualquerObjectDt(Selects itemt);
    }
}
