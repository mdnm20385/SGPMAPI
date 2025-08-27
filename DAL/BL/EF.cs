using DAL.Classes;
using DAL.Conexao;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model.Models.SGPM;
using Model.Models.SJM;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Email = Model.Models.SGPM.Email;

namespace DAL.BL
{

    public static class EntitySaveHelper
    {
        public static async Task SaveEntityWithChildrenAsync<T>(DbContext dbContext, T entity, object parentKey = null) where T : class
        {
            try
            {
                // Valida e preenche as chaves da entidade principal
                ValidateAndFillEntityKeys(entity, parentKey);

                // Valida e preenche as chaves das entidades filhas
                ValidateAndFillChildrenKeys(entity, GetEntityPrimaryKey(dbContext, entity));

                // Deixa o EF gerenciar as relações automaticamente
                var dbSet = dbContext.Set<T>();
                var keyValue = GetEntityPrimaryKey(dbContext, entity);
                var existingEntity = await dbSet.FindAsync(keyValue);

                if (existingEntity != null)
                {
                    // Atualiza entidade existente
                    dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                    // Atualiza as coleções filhas (o EF gerencia automaticamente)
                    UpdateChildCollections(dbContext, existingEntity, entity);
                }
                else
                {
                    // Adiciona nova entidade (o EF adiciona automaticamente as filhas)
                    await dbSet.AddAsync(entity);
                }

                // Uma única operação de save - o EF gerencia tudo
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar entidade '{typeof(T).Name}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtém a chave primária de uma entidade
        /// </summary>
        private static object GetEntityPrimaryKey<T>(DbContext dbContext, T entity) where T : class
        {
            var entityType = dbContext.Model.FindEntityType(typeof(T));
            if (entityType == null)
                throw new Exception($"Tipo de entidade '{typeof(T).Name}' não encontrado no contexto!");

            var pkProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault();
            if (pkProperty == null)
                throw new Exception($"Chave primária não encontrada para '{typeof(T).Name}'!");

            var keyProp = typeof(T).GetProperty(pkProperty.Name, BindingFlags.Public | BindingFlags.Instance);
            if (keyProp == null)
                throw new Exception($"Propriedade da chave primária '{pkProperty.Name}' não encontrada!");

            return keyProp.GetValue(entity);
        }

        /// <summary>
        /// Valida e preenche as chaves da entidade principal
        /// </summary>
        private static void ValidateAndFillEntityKeys<T>(T entity, object parentKey = null) where T : class
        {
            var entityType = typeof(T);
            var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                if (!prop.CanWrite) continue;

                // Verifica se é chave primária (por convenção ou atributo)
                if (IsPrimaryKey(prop))
                {
                    ValidateAndFillPrimaryKey(entity, prop);
                }
                // Verifica se é chave estrangeira
                else if (IsForeignKey(prop))
                {
                    ValidateAndFillForeignKey(entity, prop, parentKey);
                }
                // Inicializa propriedades não anuláveis básicas
                else
                {
                    InitializeBasicProperty(entity, prop);
                }
            }
        }

        /// <summary>
        /// Valida e preenche as chaves das entidades filhas
        /// </summary>
        private static void ValidateAndFillChildrenKeys<T>(T entity, object parentPrimaryKey) where T : class
        {
            var entityType = typeof(T);
            var collectionProperties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsGenericType &&
                           (p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) ||
                            p.PropertyType.GetGenericTypeDefinition() == typeof(List<>) ||
                            p.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)))
                .ToList();

            foreach (var collectionProp in collectionProperties)
            {
                var collection = collectionProp.GetValue(entity);
                if (collection == null) continue;

                var childType = collectionProp.PropertyType.GetGenericArguments()[0];

                foreach (var childEntity in (System.Collections.IEnumerable)collection)
                {
                    if (childEntity == null) continue;

                    ValidateAndFillChildEntityKeys(childEntity, childType, parentPrimaryKey);
                }
            }
        }

        /// <summary>
        /// Valida e preenche as chaves de uma entidade filha específica
        /// </summary>
        private static void ValidateAndFillChildEntityKeys(object childEntity, Type childType, object parentPrimaryKey)
        {
            var properties = childType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                if (!prop.CanWrite) continue;

                if (IsPrimaryKey(prop))
                {
                    ValidateAndFillPrimaryKey(childEntity, prop);
                }
                else if (IsForeignKey(prop))
                {
                    ValidateAndFillForeignKey(childEntity, prop, parentPrimaryKey);
                }
                else
                {
                    InitializeBasicProperty(childEntity, prop);
                }
            }
        }

        /// <summary>
        /// Verifica se uma propriedade é chave primária
        /// </summary>
        private static bool IsPrimaryKey(PropertyInfo prop)
        {
            // Por convenção: propriedades terminadas em "Id" ou com o nome da classe + "Id"
            // Por atributo: [Key]
            return prop.Name.Equals("Id", StringComparison.OrdinalIgnoreCase) ||
                   prop.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase) ||
                   prop.Name.EndsWith("stamp", StringComparison.OrdinalIgnoreCase) ||
                   prop.GetCustomAttribute<System.ComponentModel.DataAnnotations.KeyAttribute>() != null;
        }

        /// <summary>
        /// Verifica se uma propriedade é chave estrangeira
        /// </summary>
        private static bool IsForeignKey(PropertyInfo prop)
        {
            return prop.GetCustomAttribute<ForeignKeyAttribute>() != null ||
                   (prop.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase) && !IsPrimaryKey(prop)) ||
                   (prop.Name.EndsWith("stamp", StringComparison.OrdinalIgnoreCase) && !IsPrimaryKey(prop));
        }

        /// <summary>
        /// Valida e preenche chave primária
        /// </summary>
        private static void ValidateAndFillPrimaryKey(object entity, PropertyInfo keyProp)
        {
            var keyValue = keyProp.GetValue(entity);

            // Verifica se a chave está vazia, nula ou com valor inválido
            bool isInvalid = keyValue == null ||
                            (keyProp.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(keyValue as string)) ||
                            (keyProp.PropertyType.IsValueType && (keyValue.Equals(Activator.CreateInstance(keyProp.PropertyType)) || keyValue.ToString() == "0"));

            if (isInvalid)
            {
                if (keyProp.PropertyType == typeof(string))
                {
                    keyProp.SetValue(entity, Pbl.Stamp());
                }
                else if (keyProp.PropertyType == typeof(int))
                {
                    // Para chaves int, você pode implementar uma lógica de geração
                    // Por enquanto, deixo 0 que pode ser auto-increment
                    keyProp.SetValue(entity, 0);
                }
                else if (keyProp.PropertyType == typeof(Guid))
                {
                    keyProp.SetValue(entity, Guid.NewGuid());
                }
            }
        }

        /// <summary>
        /// Valida e preenche chave estrangeira
        /// </summary>
        private static void ValidateAndFillForeignKey(object entity, PropertyInfo fkProp, object parentKey)
        {
            var fkValue = fkProp.GetValue(entity);

            // Só preenche se estiver vazia E se tivermos uma chave pai
            bool isEmpty = fkValue == null ||
                          (fkProp.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(fkValue as string)) ||
                          (fkProp.PropertyType.IsValueType && fkValue.Equals(Activator.CreateInstance(fkProp.PropertyType)));

            if (isEmpty && parentKey != null)
            {
                // Verifica compatibilidade de tipos
                if (fkProp.PropertyType == parentKey.GetType() ||
                    (fkProp.PropertyType == typeof(string) && parentKey is string) ||
                    (fkProp.PropertyType.IsValueType && parentKey.GetType().IsValueType))
                {
                    fkProp.SetValue(entity, parentKey);
                }
            }

            // Validação final: chave estrangeira não pode ser nula ou inválida
            fkValue = fkProp.GetValue(entity);
            bool isStillInvalid = fkValue == null ||
                                 (fkProp.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(fkValue as string)) ||
                                 (fkProp.PropertyType.IsValueType && fkValue.Equals(Activator.CreateInstance(fkProp.PropertyType)));

            if (isStillInvalid)
            {
                throw new Exception($"Chave estrangeira '{fkProp.Name}' não pode ser nula ou vazia na entidade '{entity.GetType().Name}'!");
            }
        }

        /// <summary>
        /// Inicializa propriedades básicas não anuláveis
        /// </summary>
        private static void InitializeBasicProperty(object entity, PropertyInfo prop)
        {
            var value = prop.GetValue(entity);

            // Handle value types (int, decimal, bool, DateTime, etc.)
            if (prop.PropertyType.IsValueType && Nullable.GetUnderlyingType(prop.PropertyType) == null)
            {
                if (value == null || value.Equals(Activator.CreateInstance(prop.PropertyType)))
                {
                    object defaultValue = prop.PropertyType switch
                    {
                        Type t when t == typeof(int) => 0,
                        Type t when t == typeof(long) => 0L,
                        Type t when t == typeof(decimal) => 0m,
                        Type t when t == typeof(float) => 0f,
                        Type t when t == typeof(double) => 0d,
                        Type t when t == typeof(bool) => false,
                        Type t when t == typeof(DateTime) => DateTime.MinValue,
                        Type t when t == typeof(byte) => (byte)0,
                        _ => Activator.CreateInstance(prop.PropertyType)
                    };
                    prop.SetValue(entity, defaultValue);
                }
            }
            // Handle string
            else if (prop.PropertyType == typeof(string) && value == null)
            {
                prop.SetValue(entity, string.Empty);
            }
            // Handle byte[]
            else if (prop.PropertyType == typeof(byte[]) && value == null)
            {
                prop.SetValue(entity, Array.Empty<byte>());
            }
        }

        /// <summary>
        /// Atualiza as coleções filhas (usado para updates)
        /// </summary>
        private static void UpdateChildCollections<T>(DbContext dbContext, T existingEntity, T newEntity) where T : class
        {
            var entityType = typeof(T);
            var collectionProperties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType.IsGenericType &&
                           (p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) ||
                            p.PropertyType.GetGenericTypeDefinition() == typeof(List<>) ||
                            p.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)))
                .ToList();

            foreach (var collectionProp in collectionProperties)
            {
                var newCollection = collectionProp.GetValue(newEntity);
                if (newCollection != null)
                {
                    collectionProp.SetValue(existingEntity, newCollection);
                }
            }
        }
    }

    public class SalvarBD
    {



        private static string GetClientMAC(string strClientIP)
        {
            string mac_dest = "";
            try
            {
                Int32 ldest = inet_addr(strClientIP);
                Int32 lhost = inet_addr("");
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref macinfo, ref len);
                string mac_src = macinfo.ToString("X");

                while (mac_src.Length < 12)
                {
                    mac_src = mac_src.Insert(0, "0");
                }

                for (int i = 0; i < 11; i++)
                {
                    if (0 == (i % 2))
                    {
                        if (i == 10)
                        {
                            mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                        else
                        {
                            mac_dest = "-" + mac_dest.Insert(0, mac_src.Substring(i, 2));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                throw new Exception("L?i " + err.Message);
            }
            return mac_dest;
        }
        public string GetIPAddress(string ipAddress)
        {
           // System.Web.HttpContext context = System.Web.HttpContext.Current;
           // string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return ipAddress;
        }
        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);



        private readonly SGPMContext _dbContext;
        public SalvarBD(SGPMContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Recursive save method
      
        public  async Task<(int ret, string msg)> Save<T>(T? entity, string stamp = "") where T : class, new()
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
                        return (-1, dbEx.Message);
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
                    return (-1, dbEx.Message);
                }
            }
            catch (Exception dbEx)
            {
                return (0, dbEx.Message);
            }
        }
    }


    public static class EF
    {
        public  static SGPMContext _dbContext;
        private static SqlConnection _sqlCon;
        private static SqlCommand _cmd;


        public static class EntityTypeFactory
        {
            private static readonly Dictionary<string, Type> _tiposConhecidos = new(StringComparer.OrdinalIgnoreCase)
    {
        // Mapeamento completo de todos os tipos
        { "Armazem", typeof(Armazem) },
        { "Artigo", typeof(Artigo) },
        { "ArtigoContrato", typeof(ArtigoContrato) },
        { "ArtigoGeral", typeof(ArtigoGeral) },
        { "CodCarta", typeof(CodCarta) },
        { "Contrato", typeof(Contrato) },
        { "Curso", typeof(Curso) },
        { "Desconto", typeof(Desconto) },
        { "Email", typeof(Email) },
        { "Entrada", typeof(Entrada) },
        { "Entrega", typeof(Entrega) },
        { "Escalao", typeof(Escalao) },
        { "Pat", typeof(Pat) },
        { "Especial", typeof(Especial) },
        { "Especie", typeof(Especie) },
        { "Existencia", typeof(Existencia) },
        { "Fornecedor", typeof(Fornecedor) },
        { "Fornecimento", typeof(Fornecimento) },
        { "Instituicao", typeof(Instituicao) },
        { "Licenca", typeof(Licenca) },
        { "Mil", typeof(Mil) },
        { "MilAgre", typeof(MilAgre) },
        { "MilConde", typeof(MilConde) },
        { "MilDoc", typeof(MilDoc) },
        { "MilEmail", typeof(MilEmail) },
        { "MilEmFor", typeof(MilEmFor) },
        { "MilEspecial", typeof(MilEspecial) },
        { "MilFa", typeof(MilFa) },
        { "MilFor", typeof(MilFor) },
        { "MilFot", typeof(MilFot) },
        { "MilFuncao", typeof(MilFuncao) },
        { "MilIDigital", typeof(MilIDigital) },
        { "MilLice", typeof(MilLice) },
        { "MilLingua", typeof(MilLingua) },
        { "MilMed", typeof(MilMed) },
        { "MilPeEmerg", typeof(MilPeEmerg) },
        { "MilProm", typeof(MilProm) },
        { "MilRea", typeof(MilRea) },
        { "MilReco", typeof(MilReco) },
        { "MilReg", typeof(MilReg) },
        { "MilRetReaSal", typeof(MilRetReaSal) },
        { "MilSa", typeof(MilSa) },
        { "MilSalario", typeof(MilSalario) },
        { "MilSalMensal", typeof(MilSalMensal) },
        { "MilSit", typeof(MilSit) },
        { "MilSitCrim", typeof(MilSitCrim) },
        { "MilSitDisc", typeof(MilSitDisc) },
        { "MilSitQPActivo", typeof(MilSitQPActivo) },
        { "MilSubEspecial", typeof(MilSubEspecial) },
        { "QualifcTecnica", typeof(QualifcTecnica) },
        { "Reg", typeof(Reg) },
        { "SubEspecial", typeof(SubEspecial) },
        { "Subsidio", typeof(Subsidio) },
        { "Subunidade1", typeof(Subunidade1) },
        { "Subunidade2", typeof(Subunidade2) },
        { "Suplemento", typeof(Suplemento) },
        { "Telefone", typeof(Telefone) }
    };

            public static Type? GetTypeByName(string typeName)
            {
                _tiposConhecidos.TryGetValue(typeName, out Type? type);
                return type;
            }

            public static IEnumerable<string> GetAvailableTypes()
            {
                return _tiposConhecidos.Keys;
            }

            public static bool IsTypeSupported(string typeName)
            {
                return _tiposConhecidos.ContainsKey(typeName);
            }
        }
        private static async Task ProcessChildPrimaryKey(DbContext dbContext, object child)
        {
            var childType = child.GetType();

            // Obtém o tipo de entidade do EF Core para o filho
            var childEntityType = dbContext.Model.FindEntityType(childType);
            if (childEntityType == null)
                return;

            // Obtém a propriedade da chave primária do filho
            var childPkProperty = childEntityType.FindPrimaryKey()?.Properties.FirstOrDefault();
            if (childPkProperty == null)
                return;

            var childKeyProp = childType.GetProperty(childPkProperty.Name, BindingFlags.Public | BindingFlags.Instance);
            if (childKeyProp == null || !childKeyProp.CanWrite)
                return;

            var childKeyValue = childKeyProp.GetValue(child);

            // Verifica se precisa gerar nova chave baseado no tipo
            bool needsNewKey = ShouldGenerateNewKey(childKeyProp.PropertyType, childKeyValue);

            if (needsNewKey)
            {
                var newKeyValue = GenerateNewKeyValue(childKeyProp.PropertyType);
                childKeyProp.SetValue(child, newKeyValue);
            }
        }


        private static bool ShouldGenerateNewKey(Type keyType, object keyValue)
        {
            if (keyValue == null)
                return true;

            if (keyType == typeof(string) )
            {
                if (keyValue.ToString().Equals("0"))
                {
                    return true;
                }
                return string.IsNullOrWhiteSpace(keyValue as string);
            }

            if (keyType == typeof(int) || keyType == typeof(int?))
                return (int)keyValue == 0;

            if (keyType == typeof(long) || keyType == typeof(long?))
                return (long)keyValue == 0;

            if (keyType == typeof(Guid) || keyType == typeof(Guid?))
                return (Guid)keyValue == Guid.Empty;

            // Para outros tipos, considera null como necessidade de nova chave
            return keyValue == null;
        }


        private static object GenerateNewKeyValue(Type keyType)
        {
            if (keyType == typeof(string))
                return Pbl.Stamp();

            if (keyType == typeof(int) || keyType == typeof(int?))
            {
                // Se Pbl.Stamp() retorna string, você pode tentar converter
                // ou usar outro método para gerar int
                var stamp = Pbl.Stamp();
                return Math.Abs(stamp.GetHashCode()); // Exemplo de conversão
            }

            if (keyType == typeof(long) || keyType == typeof(long?))
            {
                var stamp = Pbl.Stamp();
                return Math.Abs(stamp.GetHashCode()); // Exemplo de conversão
            }

            if (keyType == typeof(Guid) || keyType == typeof(Guid?))
                return Guid.NewGuid();

            // Para tipos não suportados, tenta usar Pbl.Stamp() como string
            return Pbl.Stamp();
        }
        // Métodos auxiliares para gerar IDs numéricos (você pode implementar conforme sua necessidade)
        private static int GenerateIntId()
        {
            return (int)(DateTime.Now.Ticks & 0x7FFFFFFF); // Exemplo simples
        }

        private static long GenerateLongId()
        {
            return DateTime.Now.Ticks; // Exemplo simples
        }



        public static async Task SaveEntityWithChildrenAsync<T>(DbContext dbContext, T entity, object parentKey = null) where T : class
        {
            try
            {
                // Obtém o tipo de entidade do EF Core
                var entityType = dbContext.Model.FindEntityType(typeof(T));
                if (entityType == null)
                    throw new Exception($"Tipo de entidade '{typeof(T).Name}' não encontrado no contexto!");

                // Obtém o nome da propriedade da chave primária
                var pkProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault();
                if (pkProperty == null)
                    throw new Exception($"Chave primária não encontrada para '{typeof(T).Name}'!");

                var keyProp = typeof(T).GetProperty(pkProperty.Name, BindingFlags.Public | BindingFlags.Instance);
                if (keyProp == null)
                    throw new Exception($"Propriedade da chave primária '{pkProperty.Name}' não encontrada!");

                var keyValue = keyProp.GetValue(entity);

                // Se PK for string e não estiver preenchida, gera um novo valor
                if (keyValue != null && (keyProp.PropertyType == typeof(string) && (keyValue == null || 
                        string.IsNullOrWhiteSpace(keyValue as string)) || keyValue.ToString()!.Equals("0")))
                {
                    keyProp.SetValue(entity, Pbl.Stamp());
                    keyValue = keyProp.GetValue(entity);
                }
                else if (keyValue == null)
                {
                    throw new Exception($"Chave primária não preenchida para '{typeof(T).Name}'!");
                }

                // Inicializa propriedades não anuláveis
                foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!prop.CanWrite) continue;
                    var value = prop.GetValue(entity);

                    // Handle value types (int, decimal, bool, DateTime, etc.)
                    if (prop.PropertyType.IsValueType && Nullable.GetUnderlyingType(prop.PropertyType) == null)
                    {
                        if (value == null || value.Equals(Activator.CreateInstance(prop.PropertyType)))
                        {
                            object defaultValue = prop.PropertyType switch
                            {
                                Type t when t == typeof(int) => 0,
                                Type t when t == typeof(long) => 0L,
                                Type t when t == typeof(decimal) => 0m,
                                Type t when t == typeof(float) => 0f,
                                Type t when t == typeof(double) => 0d,
                                Type t when t == typeof(bool) => false,
                                Type t when t == typeof(DateTime) => DateTime.MinValue,
                                Type t when t == typeof(byte) => (byte)0,
                                _ => Activator.CreateInstance(prop.PropertyType)
                            };
                            prop.SetValue(entity, defaultValue);
                        }
                    }
                    // Handle string
                    else if (prop.PropertyType == typeof(string) && value == null)
                    {
                        prop.SetValue(entity, string.Empty);
                    }
                    // Handle byte[]
                    else if (prop.PropertyType == typeof(byte[]) && value == null)
                    {
                        prop.SetValue(entity, Array.Empty<byte>());
                    }
                }

                // Preenche chaves estrangeiras se necessário - CORRIGIDO
                if (parentKey != null)
                {
                    foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
                    {
                        var fkAttr = prop.GetCustomAttribute<ForeignKeyAttribute>();
                        if (fkAttr != null)
                        {
                          
                            var fkValue = prop.GetValue(entity);
                            if (prop.Name.ToLower().Equals("milDocStamp".ToLower()))
                            {

                            }
                            // Só atualiza se estiver vazio ou nulo
                            if (fkValue == null ||
                                (prop.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(fkValue as string)) ||
                                (prop.PropertyType.IsValueType && fkValue.Equals(Activator.CreateInstance(prop.PropertyType))))
                            {
                                prop.SetValue(entity, parentKey);
                            }
                        }
                    }
                }

                // Agora processa os filhos - CORRIGIDO para evitar loops
                await ProcessChildrenAsync(dbContext, entity, keyValue);
                // Desanexa a entidade se já estiver sendo rastreada - IMPORTANTE
                var existingEntry = dbContext.Entry(entity);
                if (existingEntry.State != EntityState.Detached)
                {
                    existingEntry.State = EntityState.Detached;
                }

                // Verifica existência
                var dbSet = dbContext.Set<T>();
                var found = await dbSet.FindAsync(keyValue);
                bool exists = found != null;

                if (exists)
                {
                    // Atualiza a entidade existente
                    dbContext.Entry(found).CurrentValues.SetValues(entity);
                    dbContext.Entry(found).State = EntityState.Modified;
                }
                else
                {
                    // Adiciona nova entidade
                    await dbSet.AddAsync(entity);
                }

                // Salva as mudanças da entidade principal primeiro
                await dbContext.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                //throw new Exception($"Erro ao salvar entidade '{typeof(T).Name}': {ex.Message}", ex);
            }
        }

       
        private static async Task ProcessChildrenAsync<T>(DbContext dbContext, T entity, object parentKey) where T : class
        {
            foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (!prop.CanRead) continue;
                var childValue = prop.GetValue(entity);

                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) &&
                    prop.PropertyType != typeof(string) &&
                    prop.PropertyType != typeof(byte[]))
                {
                    if (childValue is System.Collections.IEnumerable children)
                    {
                        foreach (var child in children)
                        {
                            if (child != null)
                            {
                                // Sempre obriga o preenchimento da chave estrangeira
                                foreach (var childProp in child.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                                {
                                    var fkAttr = childProp.GetCustomAttribute<ForeignKeyAttribute>();
                                    if (fkAttr != null)
                                    {
                                        childProp.SetValue(child, parentKey);
                                    }
                                }
                                await ProcessChildPrimaryKey(dbContext, child);
                            }
                        }
                        await ProcessEnumerableChildren(dbContext, children, parentKey);
                    }
                }
                else if (prop.PropertyType.IsClass &&
                         prop.PropertyType != typeof(string) &&
                         prop.PropertyType != typeof(byte[]) &&
                         childValue != null)
                {
                    // Processa a chave primária do objeto único
                    await ProcessChildPrimaryKey(dbContext, childValue);
                    await ProcessSingleChild(dbContext, childValue, parentKey);
                }
            }
        }


        private static async Task ProcessDataTableChildren(DbContext dbContext, DataTable dt, string propertyName, object parentKey)
        {
            foreach (DataRow row in dt.Rows)
            {
                var childEntityType = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

                if (childEntityType == null) continue;

                var childEntity = ConvertDataRowToEntity(row, childEntityType, parentKey);
                if (childEntity != null)
                {
                    // Processa a chave primária do filho ANTES de salvar
                    await ProcessChildPrimaryKey(dbContext, childEntity);

                    var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
                        ?.MakeGenericMethod(childEntityType);
                    if (saveMethod != null)
                        await (Task)saveMethod.Invoke(null, new[] { dbContext, childEntity, parentKey });
                }
            }
        }
        private static async Task ProcessEnumerableChildren(DbContext dbContext, System.Collections.IEnumerable children, object parentKey)
        {
            foreach (var child in children)
            {
                if (child != null)
                {
                    // Processa a chave primária do filho ANTES de salvar
                    await ProcessChildPrimaryKey(dbContext, child);
                    await ProcessSingleChild(dbContext, child, parentKey);
                }
            }
        }

        private static async Task ProcessSingleChild(DbContext dbContext, object child, object parentKey)
        {
            var childType = child.GetType();

            // Evita processamento de tipos primitivos ou do sistema
            if (childType.IsPrimitive || childType.Namespace?.StartsWith("System") == true)
                return;

            // Processa a chave primária do filho ANTES de salvar
            await ProcessChildPrimaryKey(dbContext, child);

            var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
                ?.MakeGenericMethod(childType);

            if (saveMethod != null)
            {
                await (Task)saveMethod.Invoke(null, new[] { dbContext, child, parentKey });
            }
        }

        //public static async Task SaveEntityWithChildrenAsync<T>(DbContext dbContext, T entity, object parentKey = null) where T : class
        //{
        //    // Obtém o tipo de entidade do EF Core
        //    var entityType = dbContext.Model.FindEntityType(typeof(T));
        //    if (entityType == null)
        //        throw new Exception("Tipo de entidade não encontrado no contexto!");

        //    // Obtém o nome da propriedade da chave primária
        //    var pkProperty = entityType.FindPrimaryKey()?.Properties.FirstOrDefault();
        //    if (pkProperty == null)
        //        throw new Exception("Chave primária não encontrada!");

        //    var keyProp = typeof(T).GetProperty(pkProperty.Name, BindingFlags.Public | BindingFlags.Instance);
        //    if (keyProp == null)
        //        throw new Exception("Propriedade da chave primária não encontrada!");

        //    var keyValue = keyProp.GetValue(entity);

        //    // Se PK for string e não estiver preenchida, gera um novo valor
        //    if (keyProp.PropertyType == typeof(string) && (keyValue == null || string.IsNullOrWhiteSpace(keyValue as string)))
        //    {
        //        keyProp.SetValue(entity, Pbl.Stamp());
        //        keyValue = keyProp.GetValue(entity);
        //    }
        //    else if (keyValue == null)
        //    {
        //        throw new Exception("Chave primária não preenchida!");
        //    }

        //    // Inicializa propriedades não anuláveis
        //    foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        //    {
        //        if (!prop.CanWrite) continue;
        //        var value = prop.GetValue(entity);
        //        var dddd = prop.Name;
        //        // Handle value types (int, decimal, bool, DateTime, etc.)
        //        if (prop.PropertyType.IsValueType && Nullable.GetUnderlyingType(prop.PropertyType) == null)
        //        {
        //            if (value == null || value.Equals(Activator.CreateInstance(prop.PropertyType)))
        //            {
        //                object defaultValue = prop.PropertyType switch
        //                {
        //                    Type t when t == typeof(int) => 0,
        //                    Type t when t == typeof(long) => 0L,
        //                    Type t when t == typeof(decimal) => 0m,
        //                    Type t when t == typeof(float) => 0f,
        //                    Type t when t == typeof(double) => 0d,
        //                    Type t when t == typeof(bool) => false,
        //                    Type t when t == typeof(DateTime) => DateTime.MinValue,
        //                    Type t when t == typeof(byte) => (byte)0,
        //                    _ => Activator.CreateInstance(prop.PropertyType)
        //                };
        //                prop.SetValue(entity, defaultValue);
        //            }
        //        }
        //        // Handle string
        //        else if (prop.PropertyType == typeof(string) && value == null)
        //        {
        //            prop.SetValue(entity, string.Empty);
        //        }
        //        // Handle byte[]
        //        else if (prop.PropertyType == typeof(byte[]) && value == null)
        //        {
        //            prop.SetValue(entity, Array.Empty<byte>());
        //        }
        //    }

        //    // Preenche chaves estrangeiras se necessário
        //    foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        //    {
        //        var fkAttr = prop.GetCustomAttribute<ForeignKeyAttribute>();
        //        if (fkAttr != null && parentKey != null)
        //        {
        //            var fkValue = prop.GetValue(entity);
        //            if (fkValue != null && !fkValue.ToString()!.ToLower().Equals(parentKey.ToString()?.ToLower()))
        //            {

        //                prop.SetValue(entity, parentKey);
        //            }
        //        }
        //    }

        //    // Verifica existência
        //    var dbSet = dbContext.Set<T>();
        //    var found = await dbSet.FindAsync(keyValue);
        //    bool exists = found != null;

        //    dbContext.Entry(entity).State = exists ? EntityState.Modified : EntityState.Added;

        //    // Salva filhos recursivamente (mantém seu código original)
        //    foreach (var prop in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
        //    {
        //        if (!prop.CanRead) continue;
        //        var childValue = prop.GetValue(entity);

        //        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
        //        {
        //            if (childValue is DataTable dt)
        //            {
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    var childEntityType = AppDomain.CurrentDomain.GetAssemblies()
        //                        .SelectMany(a => a.GetTypes())
        //                        .FirstOrDefault(t => t.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase));
        //                    if (childEntityType == null) continue;

        //                    var childEntity = ConvertDataRowToEntity(row, childEntityType, keyValue);
        //                    var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
        //                        ?.MakeGenericMethod(childEntityType);
        //                    if (saveMethod != null)
        //                        await (Task)saveMethod.Invoke(null, new[] { dbContext, childEntity, keyValue });
        //                }
        //            }
        //            else if (childValue is System.Collections.IEnumerable children)
        //            {
        //                foreach (var child in children)
        //                {
        //                    if (child != null)
        //                    {
        //                        var childType = child.GetType();
        //                        var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
        //                            ?.MakeGenericMethod(childType);
        //                        if (saveMethod != null)
        //                            await (Task)saveMethod.Invoke(null, new[] { dbContext, child, keyValue });
        //                    }
        //                }
        //            }
        //        }
        //        else if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string) && childValue != null)
        //        {
        //            var childType = childValue.GetType();
        //            var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
        //                ?.MakeGenericMethod(childType);
        //            if (saveMethod != null)
        //                await (Task)saveMethod.Invoke(null, new[] { dbContext, childValue, keyValue });
        //        }
        //    }

        //    await dbContext.SaveChangesAsync();
        //}
        #region Executa CRUD Completo............

        //public static (int ret, string msg) Save<T>(T entity, string stamp = "", JuntasContext _APIcontext=null) where T : class, new()
        //{
        //    try
        //    {
        //        if (entity == null) return (0, "A Entidade não pode ser vazio");
        //        Utilities.AllTrim(entity);
        //        var ret = Utilities.PkeyValues(entity, stamp);
        //        var existe = SQL.CheckExist($"select {ret.pkName} from {ret.tbName} where {ret.pkName}='{ret.pkValue}'");
        //        if (!existe)
        //        {
        //            _APIcontext.Set<T>().Add(entity);
        //        }
        //        else //if(NovoRegisto == 2)
        //        {
        //            _APIcontext.Entry(entity).State = EntityState.Modified;
        //        }
        //        try
        //        {
        //            return (_APIcontext.SaveChanges(), "Gravado com sucesso");
        //        }
        //        catch (DbUpdateException dbEx)
        //        {
        //            return (-1, dbEx.InnerException.InnerException.ToString());
        //        }
        //    }
        //    catch (DbUpdateException dbEx)
        //    {
        //        return (-1, dbEx.InnerException.InnerException.ToString());
        //    }
        //}






        public static bool VerificarExistenciaNoBanco<T>(SGPMContext context, T entity, string stamp) where T : class
        {
            PropertyInfo? chavePrimaria = typeof(T).GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Any());// Fallback para "Id"

            if (chavePrimaria == null)
                throw new Exception("Chave primária não encontrada!");
            
            var valorChave = Utilities.PkeyValue(entity, stamp);

            //var existe = SQL.CheckExist($"Select {chavePrimaria.Name} from {typeof(T).Name} where {chavePrimaria.Name}='{valorChave}'");
            var dbSet = context.Set<T>();
            bool existe = dbSet.Any(e => Microsoft.EntityFrameworkCore.EF.Property<object>(e, chavePrimaria.Name).Equals(valorChave));
            return existe;
        }

        // Método para remover tags HTML de um texto
        public static string? RemoveHtmlTags(string? input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            var resul= input.Replace("'", "''") // Escapa aspas simples
                .Replace("--", "")  // Remove comentários SQL
                .Replace(";", "").// Remove ponto e vírgula
                Replace("drop", "")
                .Replace("create", "");  
            return Regex.Replace(resul, "<.*?>", string.Empty);


        }

        // Método genérico para sanitizar um objeto
        public static T SanitizeObject<T>(T obj) where T : class
        {
            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(string) && prop.CanWrite)
                {
                    if (prop != null)
                    {
                        if (obj != null)
                        {
                            string? value = (string)prop.GetValue(obj)!;
                            if (!value.IsNullOrEmpty())
                            {
                                prop.SetValue(obj, RemoveHtmlTags(value));
                            }
                        }
                    }
                }
            }
            return obj;
        }
        public static async Task<(int ret, string msg)> Save<T>(T? entity, string stamp = "") where T : class, new()
        {
            try
            {
                if (entity == null) return (0, "A Entidade não pode ser vazia");
                //SanitizeObject(entity);
                Utilities.AllTrim(entity);
                bool existe;
                existe = VerificarExistenciaNoBanco(_dbContext, entity, stamp);
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
                        return (-1, dbEx.Message);
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
                    return (-1, dbEx.Message);
                }
            }
            catch (Exception dbEx)
            {
              return (0, dbEx.Message);
            }
        }

        public static int Remove<T>(string primaryKey) where T : class, new()
        {
            var entity = GetEntByPk<T>(primaryKey);
            return Remove(entity);
        }
        
        public static int Remove<T>(T entity) where T : class, new()
        {

            try
            {

                return Remove(entity);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        #endregion
        // Get Entity by PrimaryKey Column passing a value only...
        public static T? GetEntByPk<T>(string primaryKey) where T : class, new()
        {
            try
            {
                //T? entity = new T();
                //if (entity != null)
                //{
                //    var tam = entity.GetType().Name;
                //}
                var entity = new T();

                entity = SQL.GetGenDt(primaryKey).DtToList<T>().FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        //Get Entity passing conditios...
        public static T? GetEnt<T>(Func<T, bool> condition = null) where T : class
        {
            try
            {
                T? entity;
                string quer = "";
                entity = SQL.GetGenDt(quer ).DtToList<T>().FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

      


        #region Retorna uma Lista de Entities apartir de QUERY usando DataContex................
        public static List<T> EntList<T>(string query) where T : class, new()
        {
            var list = new List<T>();
            try
            {
                
                list = SQL.GetGenDt(query).DtToList<T>();
                return list;
            }
            catch
            {
                return list;
            }
        }
       

        public static List<T?> ListaDeEntidade<T>(string campos="",string condicoes="") where T : class, new()
        {
            var list = new List<T>();
            try
            {
                var tabela = typeof(T).Name;
                tabela = tabela.Replace("view", "");
                if (campos.IsNullOrEmpty())
                {
                    campos = "*";
                }
                if (!condicoes.IsNullOrEmpty())
                {
                    condicoes = $"  where {condicoes}";
                }
                list = SQL.GetGenDt($"select {campos} from {tabela} {condicoes}").DtToList<T>();
                return list;
            }
            catch
            {
                return list;
            }
        }


        public static List<T> EntListAtravesCampos<T>(string Campos, string condicoes="") where T : class, new()
        {
            var list = new List<T>();
            try
            {
                if (!condicoes.IsNullOrEmpty())
                {
                    condicoes = $" where {condicoes}";
                }
                var tabel = typeof(T).Name;
                var query = $"select {Campos} from {tabel} {condicoes}";
                list = SQL.GetGenDt(query).DtToList<T>();
                return list;
            }
            catch
            {
                return list;
            }
        }
        #endregion

        #region Retorna um Entity especifico apartir de um método generico de QUERY............


        public static T? RetornaEnt<T>(string condicao = null) where T : class, new()
        {
            try
            { var entity = new T();
                var tabela = entity.GetType().Name;
                if (tabela.ToLower().Equals("PeView".ToLower()))
                {
                    tabela = "pe";
                }
                if (tabela.ToLower().Equals("Clsession".ToLower()))
                {
                    tabela = "Cl";
                }
                string cond;
                cond = string.IsNullOrEmpty(condicao) ? "" : $"where {condicao} ";
                var qry = $"select * from {tabela} {cond}";
                entity = SQL.GetGenDt(qry).DtToList<T>().FirstOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public static T? QEnt<T>(string condicao = "",string campos="") where T : class, new()
        {
            try
            {
                var entity = new T();
                var tabela = entity.GetType().Name;
                string cond;
                cond = string.IsNullOrEmpty(condicao) ? "" : $"where {condicao} ";

                campos = string.IsNullOrEmpty(campos) ? "*" : $" {campos} "; ;
                var qry = $"select {campos} from {tabela} {cond}";
                entity =SQL.GetGenDt(qry).DtToList<T>().SingleOrDefault();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static DataTable DtQEnts<T>( string condicao = null,string camps="*") where T : class, new()
        {
            try
            {
                var entity = new T();
                var tabela = entity.GetType().Name;
                string cond;
                cond = string.IsNullOrEmpty(condicao) ? "" : $"where {condicao} ";
                var qry = $"select {camps} from {tabela}  {cond}";
                var dt = SQL.GetGenDt(qry);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion


        public static T AllTrim<T>(T ef) where T : class?, new()
        {
            var nomeClasse = typeof(T).Name;
            var lista = SQL.GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{nomeClasse.Trim()}' and IS_NULLABLE='YES' ", " column_name ");
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in properties)
            {
                if (p.PropertyType != typeof(string)) continue;
                var valor = p.GetValue(ef, null);
                if (lista?.Rows.Count > 0)
                {
                    var row = lista.Select().Where(x => x.Field<string>("column_name").Equals(p.Name.Trim()))
                        .FirstOrDefault();
                    if (row == null)
                    {
                        //if (valor=="")
                        //{
                        //    p.SetValue(ef, null);   
                        //}
                        //else
                        //{
                        //    p.SetValue(ef, valor);  
                        //}
                        p.SetValue(ef, valor != null ? valor.ToString().Trim() : "");

                    }

                }
                else
                {
                    p.SetValue(ef, valor != null ? valor.ToString().Trim() : "");
                }


            }
            return ef;
        }


        public static PropertyInfo GetProperty<T>(string propertyName, T entity) where T : class
        {
            PropertyInfo p = null;
            if (entity != null)
            {
                p = entity.GetType().GetProperties().FirstOrDefault(xx =>
                    xx.Name.ToLower().Trim().Equals(propertyName.ToLower().Trim()));
            }
            return p;
        }

        public static void BindValue<T>(T entity, PropertyInfo p, object value) where T : class
        {
            if (value != null && p != null && p.PropertyType == typeof(string))
            {
                p.SetValue(entity, value.ToString());
            }
            if (value != null && p != null && p.PropertyType == typeof(decimal))
            {
                p.SetValue(entity, value.ToDecimal());
            }

            if (!Convert.IsDBNull(value) && p != null && p.PropertyType == typeof(DateTime))
            {
                p.SetValue(entity, Convert.ToDateTime(value));
            }
            if (p != null && p.PropertyType == typeof(bool))
            {
                p.SetValue(entity, value.ToBool());
            }
            if (p != null && p.PropertyType == typeof(byte[]))
            {
                if (!string.IsNullOrWhiteSpace(value.ToString()))
                {
                    p.SetValue(entity, (byte[])value);
                }
            }
        }

        public static void BindValue<T>(T entity, PropertyInfo p, DataRow dr) where T : class
        {
            dr[p.Name.Trim()] = p.GetValue(entity, null);

        }

        public static T FillEntity<T>(T entity) where T : class
        {
            var pr = entity.GetType().GetProperties();
            foreach (var ep in pr)
            {
                var val=ep.GetValue(entity, null);
                var p = Utilities.GetProperty(ep.Name, entity);
                if (p != null)
                {
                    Utilities.BindValue(entity, p, val);
                }
            }
            return entity;
        }
        private static object ConvertDataRowToEntity(DataRow row, Type entityType, object parentKey)
        {
            try
            {
                var entity = Activator.CreateInstance(entityType);

                foreach (var prop in entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (!prop.CanWrite) continue;

                    if (row.Table.Columns.Contains(prop.Name))
                    {
                        var value = row[prop.Name];
                        if (value != DBNull.Value)
                        {
                            prop.SetValue(entity, Convert.ChangeType(value, prop.PropertyType));
                        }
                    }
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao converter DataRow para {entityType.Name}: {ex.Message}", ex);
            }
        }
    }
}
