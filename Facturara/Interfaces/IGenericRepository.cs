using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Model.Models.Gene;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{

    public interface IGenericRepository<TModel>
    {
        Task<TModel?> Obter(Expression<Func<TModel, bool>> filtro);

        Task<TModel> Criar(TModel modelo);

        Task<bool> Criar1(TModel modelo);

        Task<bool> Editar(TModel modelo);

        Task<bool> Eliminar(TModel modelo);

        Task<IQueryable<TModel>> Consultar(Expression<Func<TModel, bool>> filtro = null);

        Task<string> InsertOrUpdate(string query);

        Task<DataTable> GetDataTable(string v);
        Task<int> Maxiomo(string tabela, string campo, string condicao);
        DatabaseFacade ReturnDataBaseContext();
        Task<DataTable> ConnectExistentUser(SqlConnection conexao, string query);
        Task<DataTable> GetDataAntigoSistema(string querry, SqlConnection conexao);
        Task<IdentityResult> ChangePasswordAsync(
            string oldPassword,
            string newPassword); Task<RespostaPaginacao<List<TModel>>> GetObjectPagination(
            int currentNumber,
            int pagesize,
            string qry);
        
        Task<PaginationResponseBl<List<TModel>>> GetObjectPaginationf(
            int currentNumber,
            int pagesize,
            string qry);
        
        Task<bool> GetEntitywithChildrens(string id, string entityName);


    }
}
