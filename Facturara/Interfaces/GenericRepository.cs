using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using DAL.BL;
using DAL.Conexao;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Model.Models.Gene;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{

    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly SGPMContext _dbContext;
        private SqlConnection _sqlCon;
        private SqlCommand _cmd;
        public async Task<(int ret, string msg)> Save<T>(T? entity, string stamp = "") where T : class, new()
        {
            try
            {
                if (entity == null) return (0, "A Entidade não pode ser vazia");
                Utilities.AllTrim(entity);
                var pkValue = Utilities.PkeyValue(entity, stamp);
                var existe = SQL.CheckExist($@"select {entity.GetType().Name}stamp from {entity.GetType().Name} where {entity.GetType().Name}stamp='{pkValue}'");
                if (!existe)
                {
                    try
                    {

                        _dbContext.Set<T>().Add(entity);
                        int num = await _dbContext.SaveChangesAsync();
                        return (num, "Operação feita com sucesso!...");
                    }
                    catch (DbUpdateException dbEx)
                    {
                        return (-1, dbEx.InnerException.InnerException.ToString());
                    }
                }
                try
                {
                    _dbContext.Set<T>().Update(entity);
                    int num = await _dbContext.SaveChangesAsync();
                    return (num, "Operação feita com sucesso!...");
                }
                catch (DbUpdateException dbEx)
                {
                    return (-1, dbEx.InnerException.InnerException.ToString());
                }
            }
            catch (Exception dbEx)
            {
                return (0, dbEx.Message);
            }
        }

        public GenericRepository(
          SGPMContext dbContext)
        {
            _dbContext = dbContext;
            _sqlCon = new SqlConnection(_dbContext.Database.GetDbConnection().ConnectionString);
        }
        public async Task<TModelo?> Obter(Expression<Func<TModelo, bool>> filtro)
        {
            TModelo? modelo;
            try
            {
                modelo = await _dbContext.Set<TModelo>().FirstOrDefaultAsync(filtro);
            }
            catch (Exception ex)
            {
                throw;
            }
            return modelo;
        }

        public Task<IdentityResult> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            return null;
        }

        public async Task<RespostaPaginacao<List<TModelo>>> GetObjectPagination(
            int currentNumber,
            int pagesize,
            string qry)
        {
            RespostaPaginacao<List<TModelo>> objectPagination;
            using (SqlConnection cnn = new SqlConnection
                       (_dbContext.Database.GetDbConnection().ConnectionString))
            {
                cnn.Open();
                SqlMapper.GridReader gridReader = cnn.QueryMultiple(qry, commandTimeout: new int?(20000));
                RespostaPaginacao<List<TModelo>> RespostaPaginacao = new RespostaPaginacao<List<TModelo>>
                    (gridReader.Read<int>().FirstOrDefault(), gridReader.Read<TModelo>().ToList<TModelo>(), currentNumber, pagesize);
                cnn.Close();
                objectPagination = RespostaPaginacao;
            }
            return objectPagination;
        }



     
        public async Task<bool> Criar1(TModelo modelo)
        {
            TModelo modelo1;
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                int num = await _dbContext.SaveChangesAsync();
                if (num > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }
        public async Task<TModelo> Criar(TModelo modelo)
        {
            TModelo modelo1;
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                int num = await _dbContext.SaveChangesAsync();
                modelo1 = modelo;
            }
            catch (Exception ex)
            {
                throw;
            }
            return modelo1;
        }
        //_applicationDbContext.Users.Update(model);
        public async Task<bool> Update(TModelo modelo)
        {
            bool flag;
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                // _dbContext.TModelo.Update(modelo)
                int num = await _dbContext.SaveChangesAsync();
                flag = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return flag;
        }


        public async Task<bool> Editar(TModelo modelo)
        {
            bool flag;
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                int num = await _dbContext.SaveChangesAsync();
                flag = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return flag;
        }

        public async Task<bool> Eliminar(TModelo modelo)
        {
            bool flag;
            try
            {
                _dbContext.Set<TModelo>().Remove(modelo);
                int num = await _dbContext.SaveChangesAsync();
                flag = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return flag;
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> filtro = null)
        {
            IQueryable<TModelo> queryable;
            try
            {
                queryable = filtro == null ? (IQueryable<TModelo>)_dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
            }
            catch (Exception ex)
            {
                throw;
            }
            return queryable;
        }



        public async Task<int> Maxiomo(string tabela, string campo, string condicao)
        {
            string empty = string.Empty;
            int num;
            try
            {
                string cmdText;
                if (string.IsNullOrEmpty(condicao))
                    cmdText = "select ISNULL(max(" + campo + "),0) +1 as " + campo + " from " + tabela;
                else
                    cmdText = "select ISNULL(max(" + campo + "),0) +1 as " + campo + " from " + tabela + " where " + condicao;
                _sqlCon.Open();
                int int32 = Convert.ToInt32((await GetReturnTable(new SqlCommand(cmdText, _sqlCon))).Rows[0][0]);
                _sqlCon.Close();
                num = int32;
            }
            catch
            {
                throw;
            }
            return num;
        }

        public async Task<string> InsertOrUpdate(string query)
        {
            try
            {
                _sqlCon.Open();
                _cmd = new SqlCommand(query, _sqlCon);
                int num = _cmd.ExecuteNonQuery();
                _cmd.CommandTimeout = 5000;
                _sqlCon.Close();
                return num.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<DataTable> GetDataTable(string v)
        {
            DataTable dataTable;
            try
            {

                _sqlCon.Open();
                if (v.ToLower().Contains("imenu"))
                {
                    // _sqlCon.ChangeDatabase("ISEDEF");
                }
                SqlCommand sqlComando = new SqlCommand(v, _sqlCon);
                DataTable returnTable = await GetReturnTable(sqlComando);
                sqlComando.CommandTimeout = 20000;
                _sqlCon.Close();
                dataTable = returnTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dataTable;
        }

        public Task<DataTable> ConnectExistentUser(SqlConnection conexao, string query)
        {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand(query, conexao);
                cmd.CommandTimeout = 5000;
                Task<DataTable> returnTable = GetReturnTable(cmd);
                conexao.Close();
                return returnTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<DataTable> GetDataAntigoSistema(string querry, SqlConnection conexao)
        {
            try
            {
                conexao.Open();
                SqlCommand cmd = new SqlCommand(querry, conexao);
                cmd.CommandTimeout = 20000;
                Task<DataTable> returnTable = GetReturnTable(cmd);
                conexao.Close();
                return returnTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<DataTable> GetReturnTable(SqlCommand cmd)
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable returnTable = new DataTable();
            DataTable dataTable = returnTable;
            sqlDataAdapter.Fill(dataTable);
            return returnTable;
        }



       


        public DatabaseFacade ReturnDataBaseContext() => _dbContext.Database;

        //public Task<PaginationResponseBl<List<TModelo>>> GetObjectPaginationf(int currentNumber, int pagesize, string qry)
        //{
        //    PaginationResponseBl<List<TModelo>> objectPagination;
        //    using (SqlConnection cnn = new SqlConnection
        //               (_dbContext.Database.GetDbConnection().ConnectionString))
        //    {
        //        cnn.Open();
        //        SqlMapper.GridReader gridReader = cnn.QueryMultiple(qry, commandTimeout: new int?(20000));
        //        PaginationResponseBl<List<TModelo>> RespostaPaginacao = new PaginationResponseBl<List<TModelo>>(gridReader.Read<int>().FirstOrDefault(), gridReader.Read<TModelo>().ToList<TModelo>(), currentNumber, pagesize);
        //        cnn.Close();
        //        objectPagination = RespostaPaginacao;
        //    }
        //    return objectPagination;
        //}



        public async Task<PaginationResponseBl<List<TModelo>>> GetObjectPaginationf(int currentNumber, int pagesize, string qry)
        {
            PaginationResponseBl<List<TModelo>> objectPagination;
            using (SqlConnection cnn = new SqlConnection
                       (_dbContext.Database.GetDbConnection().ConnectionString))
            {
                cnn.Open();
                SqlMapper.GridReader gridReader = cnn.QueryMultiple(qry, commandTimeout: new int?(20000));
                PaginationResponseBl<List<TModelo>> RespostaPaginacao = new PaginationResponseBl<List<TModelo>>(gridReader.Read<int>().FirstOrDefault(), gridReader.Read<TModelo>().ToList<TModelo>(), currentNumber, pagesize);
                cnn.Close();
                objectPagination = RespostaPaginacao;
            }
            return objectPagination;
        }



        

        public async Task<bool> GetEntitywithChildrens(string id, string entityName)
        {




            //var entityType = AppDomain.CurrentDomain
            //    .GetAssemblies()
            //    .SelectMany(a => a.GetTypes())
            //    .FirstOrDefault(t => t.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));
            //var keyProp = entityType.GetProperties()
            //    .FirstOrDefault(prop => prop.GetCustomAttribute<KeyAttribute>() != null);


            //// Incluir todas as propriedades de navegação
            //var query = _dbContext.Set(entityType).AsQueryable(); // sem <TModelo>
            //var navProps = _dbContext.Model.FindEntityType(entityType)!.GetNavigations();

            //foreach (var nav in navProps)
            //{
            //    query = query.Include(nav.Name); // isso agora funciona com entityType
            //}

            ////var query = _dbContext.Set<TModelo>().AsQueryable();
            ////var navProps = _dbContext.Model.FindEntityType(entityType)!.GetNavigations();
            ////foreach (var nav in navProps)
            ////{
            ////    query = query.Include(nav.Name);
            ////}
            //var entity = await query.FirstOrDefaultAsync(e => Microsoft.EntityFrameworkCore.EF.Property<object>(e, keyProp.Name).Equals(id));





            return false;
        }

    }
}
