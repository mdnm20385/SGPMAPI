using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model.Models.SJM;

namespace DAL.BL
{

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
    }


    public static class EF
    {
        public  static SGPMContext _dbContext;
        private static SqlConnection _sqlCon;
        private static SqlCommand _cmd;




        public static async Task SaveEntityWithChildrenAsync<T>(DbContext dbContext, T entity, 
            object parentKey = null) where T : class
                {
            // Initialize non-nullable properties with default values if they are null
            foreach (var prop in typeof(T).GetProperties())
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

            // Find [Key] property and check if it's filled
            var keyProp = typeof(T).GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Any());
            if (keyProp == null)
                throw new Exception("Chave primária não encontrada!");
            var keyValue = keyProp.GetValue(entity);

            // If PK is string and not filled, set with Pbl.Stamp()
            if (keyProp.PropertyType == typeof(string) && (keyValue == null || string.IsNullOrWhiteSpace(keyValue as string)))
            {
                keyProp.SetValue(entity, Pbl.Stamp());
                keyValue = keyProp.GetValue(entity);
            }
            // If PK is not string and not filled, throw
            else if (keyValue == null)
            {
                throw new Exception("Chave primária não preenchida!");
            }

            // Set foreign keys if not filled
            foreach (var prop in typeof(T).GetProperties())
            {
                var fkAttr = prop.GetCustomAttribute<ForeignKeyAttribute>();
                if (fkAttr != null && parentKey != null)
                {
                    var fkValue = prop.GetValue(entity);
                    if (fkValue == null || (prop.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(fkValue as string)))
                    {
                        prop.SetValue(entity, parentKey);
                    }
                }
            }

            // Check existence
            bool exists = false;
            var dbSet = dbContext.Set<T>();
            var found = await dbSet.FindAsync(keyValue);
            exists = found != null;

            dbContext.Entry(entity).State = exists ? EntityState.Modified : EntityState.Added;

            // Save children recursively
            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanRead) continue;
                var childValue = prop.GetValue(entity);

                // Handle collections
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                {
                    if (childValue is DataTable dt)
                    {
                                // DataTable rows as children
                                foreach (DataRow row in dt.Rows)
                                {
                                    // Try to infer entity type from property name (e.g., "MilFa" => typeof(MilFa))
                                    var childEntityType = AppDomain.CurrentDomain.GetAssemblies()
                                        .SelectMany(a => a.GetTypes())
                                        .FirstOrDefault(t => t.Name.Equals(prop.Name, StringComparison.OrdinalIgnoreCase));
                                    if (childEntityType == null) continue; // Skip if type not found

                                    var childEntity = ConvertDataRowToEntity(row, childEntityType, keyValue);
                                    var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
                                        ?.MakeGenericMethod(childEntityType);
                                    if (saveMethod != null)
                                        await (Task)saveMethod.Invoke(null, new[] { dbContext, childEntity, keyValue });
                                }
                    }
                    else if (childValue is System.Collections.IEnumerable children)
                    {
                        foreach (var child in children)
                        {
                            if (child != null)
                            {
                                var childType = child.GetType();
                                var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
                                    ?.MakeGenericMethod(childType);
                                if (saveMethod != null)
                                    await (Task)saveMethod.Invoke(null, new[] { dbContext, child, keyValue });
                            }
                        }
                    }
                }
                // Handle single child entity
                else if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string) && childValue != null)
                {
                    var childType = childValue.GetType();
                    var saveMethod = typeof(EF).GetMethod(nameof(SaveEntityWithChildrenAsync), BindingFlags.Public | BindingFlags.Static)
                        ?.MakeGenericMethod(childType);
                    if (saveMethod != null)
                        await (Task)saveMethod.Invoke(null, new[] { dbContext, childValue, keyValue });
                }
            }

            await dbContext.SaveChangesAsync();
        }
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

        private static object ConvertDataRowToEntity(DataRow row, Type entityType, object parentKey = null)
{
    var entity = Activator.CreateInstance(entityType);
    foreach (var prop in entityType.GetProperties())
    {
        if (!prop.CanWrite) continue;
        if (row.Table.Columns.Contains(prop.Name))
        {
            var value = row[prop.Name];
            if (value == DBNull.Value) value = null;
            prop.SetValue(entity, value);
        }
    }
    // Set foreign key if needed
    var fkProp = entityType.GetProperties()
        .FirstOrDefault(p => p.GetCustomAttribute<ForeignKeyAttribute>() != null);
    if (fkProp != null && parentKey != null)
    {
        var fkValue = fkProp.GetValue(entity);
        if (fkValue == null || (fkProp.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(fkValue as string)))
        {
            fkProp.SetValue(entity, parentKey);
        }
    }
    return entity;
}
    }
}
