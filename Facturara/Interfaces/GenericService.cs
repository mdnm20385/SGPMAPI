using System.ComponentModel.DataAnnotations;
using System.Reflection;
using DAL.Conexao;
using Microsoft.EntityFrameworkCore;

namespace SGPMAPI.Interfaces
{
    public class GenericService<TEntity> where TEntity : class
    {
        private readonly SGPMContext _context;

        public GenericService(SGPMContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetWithChildrenAsync(string id)
        {
            var tipo = typeof(TEntity);

            var keyProp = tipo.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);
            if (keyProp == null)
                throw new Exception("Chave primária não encontrada.");

            // Incluir propriedades de navegação
            var query = _context.Set<TEntity>().AsQueryable();
            var navProps = _context.Model.FindEntityType(tipo)!.GetNavigations();

            foreach (var nav in navProps)
            {
                query = query.Include(nav.Name);
            }

            var convertedId = Convert.ChangeType(id, keyProp.PropertyType);
            var entity = await query.FirstOrDefaultAsync(e =>
                EF.Property<object>(e, keyProp.Name).Equals(convertedId));

            return entity;
        }
    }


}
