using Model.Models.ProdutTest.Base;

namespace Model.Models.ProdutTest.Interface.BaseRepository
{
    public interface IRepository<T> where T : BaseModel
    {
        IEnumerable<T> All();
        T Find(long id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
