using Model.Models.Gene;
using Model.Models.SJM;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{
    public interface InterGeral
    {
        Task<PaginationResponseBl<List<object>>> GetGrades(ModeloPaginacao model);
        Task<bool> Eliminar<T>(T? entity, string id, string nomecolunaxave) where T : class, new();
        Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave);
        Task<T> Criar<T>(T? entity, string stamp = "") where T : class, new ();
        Task<ServiceResponse<Selectview>> Comboboxes(string tabela, string campo1, string campo2, string condicao = "");
        Task<ServiceResponse<Usuario>> TrocarSenha(Busca busca);
        Task<object> AddOrUpdateAsync(object entity);
    }
}
