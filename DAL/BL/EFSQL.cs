using System.Linq.Expressions;
using DAL.Conexao;
using Microsoft.EntityFrameworkCore;

namespace DAL.BL
{
    //LINQ QUERRY CLASSE 
    public static class EFSQL
    {
        #region Executa CRUD Completo............

        public static (int ret, string msg) Save<T>(SGPMContext mdc,T entity, string stamp = "") where T : class, new()
        {
            try
            {
                // mdc.....Connection.ConnectionString = SqlHelper.GetConString();
                if (entity == null) return (0, "A Entidade não pode ser vazio");

                Utilities.AllTrim(entity);

                var pkValue = Utilities.PkeyValue(entity, stamp);
                var ent = GetEntByPk<T>(mdc,    pkValue);
                if (ent == null)
                {
                    mdc.Set<T>().Add(entity);
                }
                else
                {
                    mdc.Entry(entity).State = EntityState.Modified;
                }
                try
                {
                    return (mdc.SaveChanges(), "Gravado com sucesso");
                }
                catch (DbUpdateException dbEx)
                {
                    return (-1, dbEx.InnerException.InnerException.ToString());
                }
            }
            catch (Exception dbEx)
            {
                throw dbEx.InnerException;

            }
        }

        public static int Remove<T>(SGPMContext mdc, string primaryKey) where T : class, new()
        {
            var entity = GetEntByPk<T>(mdc, primaryKey);
            return Remove(mdc, entity);
        }

        public static int Remove<T>(SGPMContext mdc, T entity) where T : class, new()
        {
            try
            {
                if (entity == null) return 0;
                //mdc.Entry(entity).State = EntityState.Deleted;
                mdc.Set<T>().Remove(entity);
                return mdc.SaveChanges();
            }
            catch (Exception dbEx)
            {
                throw dbEx.InnerException;
            }
        }
        #endregion
        // Get Entity by PrimaryKey Column passing a value only...
        public static T GetEntByPk<T>(SGPMContext mdc, string primaryKey) where T : class
        {
            try
            {
                T entity;
                entity = mdc.Set<T>().Find(primaryKey);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        //Get Entity passing conditios...
        public static T GetEnt<T>(SGPMContext mdc, Func<T, bool> condition = null) where T : class
        {
            try
            {
                T entity;
                entity = condition != null ? mdc.Set<T>().SingleOrDefault(condition) : mdc.Set<T>().SingleOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        //Get List of Entity passing condition and the columns you select 
        public static IEnumerable<T> GetAll<T>(SGPMContext mdc,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            string includePropeerties = null) where T : class
        {
            try
            {
                IQueryable<T> query = mdc.Set<T>();
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                if (includePropeerties != null)
                {
                    foreach (var p in includePropeerties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(p);
                    }
                }
                if (OrderBy != null)
                {
                    return OrderBy(query).ToList();
                }
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }





        #region Retorna um Entity especifico apartir de um método generico de QUERY............


        #endregion
    }
}
