using Model.Models.Gene;
using Model.Models.SJM;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{
    public interface InterfBusca
    {
        Task<PaginationResponseBl<List<Busca>>> GetGrades(
            ModeloPaginacao model);


        Task<bool> Editar(Busca modelo);

        Task<bool> Eliminar(string id);

        Task<bool> Eliminargradel(string id, string tabela, string nomecolunachave);
        Task<Busca> Criar(Busca modelo2, bool inserindo);
    }
}
