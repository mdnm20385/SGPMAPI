namespace SGPMAPI.Interfaces
{
    public class GenericSearchService
    {
        private readonly IServiceProvider _provider;

        public GenericSearchService(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<object?> GetEntityWithChildrenAsync(string entityName, string id)
        {
            var entityType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .FirstOrDefault(t => t.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));

            if (entityType == null)
                return null;

            // Cria GenericService<TEntity>
            var serviceType = typeof(GenericService<>).MakeGenericType(entityType);
            var serviceInstance = _provider.GetRequiredService(serviceType);

            // Invoca o método GetWithChildrenAsync dinamicamente
            var method = serviceType.GetMethod("GetWithChildrenAsync");
            var task = (Task)method.Invoke(serviceInstance, new object[] { id })!;
            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result");
            return resultProperty?.GetValue(task);
        }
    }

}
