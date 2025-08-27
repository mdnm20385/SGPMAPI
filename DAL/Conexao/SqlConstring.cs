using DAL.BL;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
namespace DAL.Conexao
{
    using Microsoft.EntityFrameworkCore;
    using Model.Models.SGPM;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    /// <summary>
    /// Método genérico simplificado para configurar delete cascade - VERSÃO FINAL
    /// Use este método diretamente no seu OnModelCreating
    /// </summary>
    public static class EFCascadeHelper
    {
        /// <summary>
        /// MÉTODO PRINCIPAL - Configura delete cascade para todas as relações automaticamente
        /// </summary>
        /// <param name="modelBuilder">O ModelBuilder do EF Core</param>
        public static void ConfigureDeleteCascadeForAll(ModelBuilder modelBuilder)
        {
            Console.WriteLine("=== Configurando Delete Cascade Automático ===");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // 1. Configura cascade para todas as foreign keys existentes
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
                    Console.WriteLine($"✅ Cascade configurado: {foreignKey.DeclaringEntityType.DisplayName()} -> {foreignKey.PrincipalEntityType.DisplayName()}");
                }

                // 2. Configura cascade para propriedades de navegação em coleção
                foreach (var navigation in entityType.GetNavigations().Where(n => n.IsCollection))
                {
                    try
                    {
                        var principalType = navigation.DeclaringEntityType.ClrType;
                        var dependentType = navigation.TargetEntityType.ClrType;

                        // Força configuração de cascade para relações 1:N
                        modelBuilder.Entity(principalType)
                            .HasMany(dependentType)
                            .WithOne()
                            .OnDelete(DeleteBehavior.Cascade);

                        Console.WriteLine($"✅ Navegação cascade: {principalType.Name} -> {dependentType.Name}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"⚠️ Erro na navegação {navigation.Name}: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("=== Delete Cascade Configurado com Sucesso ===");
        }

        /// <summary>
        /// MÉTODO ALTERNATIVO - Configura apenas para propriedades que seguem convenção
        /// </summary>
        /// <param name="modelBuilder">O ModelBuilder do EF Core</param>
        /// <param name="foreignKeySuffixes">Sufixos que indicam FK (padrão: "Stamp", "Id")</param>
        public static void ConfigureCascadeByConvention(ModelBuilder modelBuilder, params string[] foreignKeySuffixes)
        {
            if (foreignKeySuffixes == null || !foreignKeySuffixes.Any())
                foreignKeySuffixes = new[] { "Stamp", "Id" };

            Console.WriteLine($"=== Configurando Cascade por Convenção: {string.Join(", ", foreignKeySuffixes)} ===");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var entityClrType = entityType.ClrType;

                // Procura propriedades que parecem foreign keys
                foreach (var property in entityType.GetProperties())
                {
                    if (property.IsPrimaryKey()) continue;

                    var propertyName = property.Name;
                    var matchedSuffix = foreignKeySuffixes.FirstOrDefault(suffix =>
                        propertyName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));

                    if (matchedSuffix != null)
                    {
                        // Extrai o nome da entidade principal
                        var principalEntityName = propertyName.Substring(0,
                            propertyName.Length - matchedSuffix.Length);

                        // Procura a entidade principal
                        var principalEntityType = modelBuilder.Model.GetEntityTypes()
                            .FirstOrDefault(et =>
                                et.ClrType.Name.Equals(principalEntityName, StringComparison.OrdinalIgnoreCase) ||
                                et.ClrType.Name.StartsWith(principalEntityName, StringComparison.OrdinalIgnoreCase));

                        if (principalEntityType != null)
                        {
                            try
                            {
                                // Configura a relação com cascade
                                modelBuilder.Entity(entityClrType)
                                    .HasOne(principalEntityType.ClrType)
                                    .WithMany()
                                    .HasForeignKey(propertyName)
                                    .OnDelete(DeleteBehavior.Cascade);

                                Console.WriteLine($"✅ Cascade por convenção: {entityClrType.Name}.{propertyName} -> {principalEntityType.ClrType.Name}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"⚠️ Erro na convenção {entityClrType.Name}.{propertyName}: {ex.Message}");
                            }
                        }
                    }
                }
            }

            Console.WriteLine("=== Cascade por Convenção Configurado ===");
        }

        /// <summary>
        /// MÉTODO COMPLETO - Seu método original + delete cascade
        /// </summary>
        /// <param name="modelBuilder">O ModelBuilder do EF Core</param>
        public static void ModelCreatingComplete(ModelBuilder modelBuilder)
        {
            // Seu método original
            ConfigureStringPropertiesAndPrimaryKeys(modelBuilder);

            // Adiciona delete cascade automático
            ConfigureDeleteCascadeForAll(modelBuilder);

            // Configurações extras úteis
            ConfigureAdditionalSettings(modelBuilder);
        }

        /// <summary>
        /// Seu método original para strings e chaves primárias
        /// </summary>
        private static void ConfigureStringPropertiesAndPrimaryKeys(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                // Configuração de propriedades string
                foreach (var property in entityType.GetProperties())
                {
                    var memberInfo = property.PropertyInfo;
                    if (memberInfo == null) continue;

                    var stringLengthAttr = memberInfo
                        .GetCustomAttributes(typeof(StringLengthAttribute), true)
                        .FirstOrDefault();

                    if (stringLengthAttr != null && property.ClrType == typeof(string))
                    {
                        bool isPrimaryKey = property.IsPrimaryKey();
                        bool isInIndex = entityType.GetIndexes().Any(idx => idx.Properties.Contains(property));

                        if (!isPrimaryKey && !isInIndex)
                        {
                            modelBuilder.Entity(clrType)
                                .Property(memberInfo.Name)
                                .HasColumnType("nvarchar(max)");
                        }
                    }
                }

                // Configuração de chaves primárias
                var pk = entityType.FindPrimaryKey();
                if (pk != null)
                {
                    foreach (var keyProperty in pk.Properties)
                    {
                        modelBuilder.Entity(clrType)
                            .Property(keyProperty.Name)
                            .IsRequired();
                    }
                }
            }
        }

        /// <summary>
        /// Configurações adicionais úteis
        /// </summary>
        private static void ConfigureAdditionalSettings(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                // Índices automáticos para foreign keys
                foreach (var foreignKey in entityType.GetForeignKeys())
                {
                    var fkProperties = foreignKey.Properties.Select(p => p.Name).ToArray();
                    var indexName = $"IX_{clrType.Name}_{string.Join("_", fkProperties)}";

                    try
                    {
                        modelBuilder.Entity(clrType)
                            .HasIndex(fkProperties)
                            .HasDatabaseName(indexName);
                    }
                    catch
                    {
                        // Ignora se o índice já existe
                    }
                }

                // Configurações específicas para propriedades stamp
                foreach (var property in entityType.GetProperties().Where(p => p.Name.EndsWith("Stamp", StringComparison.OrdinalIgnoreCase)))
                {
                    if (property.ClrType == typeof(string))
                    {
                        modelBuilder.Entity(clrType)
                            .Property(property.Name)
                            .HasMaxLength(450); // Tamanho máximo para chaves primárias

                        if (property.IsPrimaryKey())
                        {
                            modelBuilder.Entity(clrType)
                                .Property(property.Name)
                                .ValueGeneratedNever(); // Não auto-gerar stamps
                        }
                    }
                }
            }
        }
    }

    public static class ConvertMysql
    {
       public static string connectionString = $"Server=CHICUANJO\\SERVER19;Database=gecamo;User ID=sa;Password=123;TrustServerCertificate=True;";

     public   static void ConvertJsonToSqlServer()
        {
            string jsonPath = @"C:\Users\CHICUANJO\Downloads\gecamo.json";
            string json = File.ReadAllText(jsonPath);
            var jsonArray = JArray.Parse(json);

            EnsureDatabaseExists("gecamo");

            foreach (var item in jsonArray)
            {
                string type = item["type"]?.ToString();
                if (type == "table")
                {
                   
                    try
                    {
                        string tableName = item["name"]?.ToString();
                      
                        var data = item["data"] as JArray;
                        if (data != null && data.Count > 0)
                        {
                            CreateTableFromData(tableName, data);
                            try
                            {
                                InsertData(tableName, data);
                            }
                            catch (Exception)
                            {
                                //
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        var ddd = item["name"];
                        var errorMessage = $"Erro ao processar a tabela: {item["name"]}. Detalhes: {ex.Message}";
                        //
                    }
                }
            }

            Console.WriteLine("Importação concluída com sucesso.");
        }

        static void EnsureDatabaseExists(string dbName)
        {
            string connectionStringMaster = "Server=CHICUANJO\\SERVER19;Database=master;User ID=sa;Password=123;TrustServerCertificate=True;";

            using var conn = new SqlConnection(connectionStringMaster);
            conn.Open();

            using var cmd = new SqlCommand($"IF NOT EXISTS(SELECT * FROM sys.databases WHERE name='{dbName}') CREATE DATABASE [{dbName}];", conn);
            cmd.ExecuteNonQuery();
        }

        static void CreateTableFromData(string tableName, JArray data)
        {
            var columns = ((JObject)data[0]).Properties().Select(p => p.Name).ToList();
            var columnTypes = new Dictionary<string, string>();

            foreach (var colName in columns)
            {
                columnTypes[colName] = InferSqlTypeForColumn(data, colName);
            }

            string createSql = $"IF OBJECT_ID('{tableName}', 'U') IS NULL CREATE TABLE [{tableName}] (";
            foreach (var colName in columns)
            {
                createSql += $"[{colName}] {columnTypes[colName]},";
            }
            createSql = createSql.TrimEnd(',') + ");";

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            using var cmd = new SqlCommand(createSql, conn);
            cmd.ExecuteNonQuery();
        }

        static string InferSqlTypeForColumn(JArray data, string colName)
        {
            bool isNumber = true, isDecimal = true, isInt = true, isBool = true, isByte = true, isDate = true;
            foreach (var row in data)
            {
                var value = row[colName]?.ToString();
                if (string.IsNullOrEmpty(value)) continue;

                // Testa booleano
                if (!bool.TryParse(value, out _)) isBool = false;

                // Testa byte
                if (!byte.TryParse(value, out _)) isByte = false;

                // Testa inteiro
                if (!int.TryParse(value, out _)) isInt = false;

                // Testa decimal
                if (!decimal.TryParse(value, out _)) isDecimal = false;

                // Testa número (decimal ou inteiro)
                if (!double.TryParse(value, out _)) isNumber = false;

                // Testa data
                if (!DateTime.TryParse(value, out _)) isDate = false;
            }

            if (isBool) return "BIT";
            if (isByte) return "TINYINT";
            if (isInt) return "INT";
            if (isDecimal || isNumber) return "DECIMAL(18,2)";
            return "NVARCHAR(MAX)";
        }

        static void InsertData(string tableName, JArray data)
        {
            if (tableName.ToLower().Equals("mainsub_civilian_course_training"))
            {
                //return;
            }
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            foreach (var record in data)
            {
                var props = ((JObject)record).Properties();

                if (props != null)
                {
                    IEnumerable<JProperty> enumerable = props as JProperty[] ?? props.ToArray();
                    var columnNames = enumerable.Select(p => $"[{p.Name}]").ToArray();

                    var valueStrings = enumerable.Select(p => FormatSqlValue(p.Value)).ToArray();
                    string whereClause = string.Join(" AND ", enumerable.Select(p =>
                        $"[{p.Name}] = {FormatSqlValue(p.Value)}"));

                    string checkSql = $"SELECT COUNT(*) FROM [{tableName}] WHERE {whereClause};";
                    try
                    {
                        using (var checkCmd = new SqlCommand(checkSql, conn))
                        {
                            int exists = (int)checkCmd.ExecuteScalar();
                            if (exists > 0)
                            {
                                //Console.WriteLine($"Registro já existe (baseado em todos os campos). Ignorado.");
                                continue;
                            }
                        }
                    }
                    catch (Exception )
                    {
                        //
                    }
                    try
                    {

                       
                        try
                        {
                            string sql = $"INSERT INTO [{tableName}] ({string.Join(",", columnNames)}) VALUES ({string.Join(",", valueStrings)});";
                            using var cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            string sql = $"INSERT INTO [{tableName}] ({string.Join(",", columnNames)}) VALUES ({string.Join(",", valueStrings)});";

                            //
                        }
                    }
                    catch (Exception ex)
                    {

                        //
                    }
                    string sqls = $"INSERT INTO [{tableName}] ({string.Join(",", columnNames)}) VALUES ({string.Join(",", valueStrings)});";
                }
            }
        }
        static string FormatSqlValue(JToken token)
        {
            try
            {
                if (token.Type == JTokenType.Null || token.Type == JTokenType.Undefined)
                    return "NULL";

                if (token.Type == JTokenType.Boolean)
                    return token.ToObject<bool>() ? "1" : "0";

                if (token.Type == JTokenType.Integer)
                    return token.ToString();

                if (token.Type == JTokenType.Float || (token.Type == JTokenType.String && decimal.TryParse(token.ToString(), out _)))
                {
                    // Substitui vírgula por ponto
                    var value = token.ToString().Replace(",", ".");
                    // Remove o caractere '+' após números
                    value = Regex.Replace(value, @"(\d)\+", "$1");
                    return value;
                }

                if (token.Type == JTokenType.Date)
                    return $"'{((DateTime)token):yyyy-MM-dd HH:mm:ss}'";

                if (token.Type == JTokenType.String)
                {
                    // Remove '+' após números e escapa aspas simples
                    var value = Regex.Replace(token.ToString(), @"(\d)\+", "$1");
                    return $"'{value.Replace("'", "''")}'";
                }

                // Outros tipos: trata como string
                return $"'{token.ToString().Replace("'", "''")}'";
            }
            catch (Exception)
            {

                throw;
            }
        }
        static string GetSqlType(string value)
        {
            if (int.TryParse(value, out _)) return "INT";
            if (DateTime.TryParse(value, out _)) return "DATETIME";
            return "NVARCHAR(255)";
        }

        //public static void ConvertJsonToSqlServer()
        //  {
        //      string jsonPath = @"C:\Users\CHICUANJO\Downloads\gecamo.json";
        //      string databaseName = "Gecamo";
        //      string connectionStringMaster = "Server=CHICUANJO\\SERVER19;Database=master;User ID=sa;Password=123;TrustServerCertificate=True;";
        //      string connectionString = $"Server=CHICUANJO\\SERVER19;Database={databaseName};User ID=sa;Password=123;TrustServerCertificate=True;";

        //      // 1. Cria o banco de dados se não existir
        //      using (var conn = new SqlConnection(connectionStringMaster))
        //      {
        //          conn.Open();
        //          var cmd = conn.CreateCommand();
        //          cmd.CommandText = $"IF DB_ID('{databaseName}') IS NULL CREATE DATABASE [{databaseName}]";
        //          cmd.ExecuteNonQuery();
        //      }

        //      // 2. Lê o JSON (espera um array de objetos)
        //      var json = File.ReadAllText(jsonPath);
        //      var root = JArray.Parse(json);

        //      using (var conn = new SqlConnection(connectionString))
        //      {
        //          conn.Open();

        //          foreach (var item in root)
        //          {
        //              if (item["type"]?.ToString() != "table") continue;
        //              string tableName = item["name"]?.ToString();
        //              var rows = item["data"] as JArray;
        //              if (string.IsNullOrEmpty(tableName) || rows == null || rows.Count == 0) continue;

        //              // 3. Cria a tabela se não existir
        //              var firstRow = rows[0] as JObject;
        //              var columns = new List<string>();
        //              foreach (var prop in firstRow.Properties())
        //              {
        //                  string sqlType = GetSqlType(prop.Value.Type);
        //                  columns.Add($"[{prop.Name}] {sqlType}");
        //              }
        //              string createTableSql = $"IF OBJECT_ID('{tableName}', 'U') IS NULL CREATE TABLE [{tableName}] ({string.Join(",", columns)})";
        //              using (var cmd = conn.CreateCommand())
        //              {
        //                  cmd.CommandText = createTableSql;
        //                  cmd.ExecuteNonQuery();
        //              }

        //              // 4. Insere os dados
        //              foreach (var row in rows)
        //              {
        //                  var colNames = new List<string>();
        //                  var paramNames = new List<string>();
        //                  var parameters = new List<SqlParameter>();
        //                  foreach (var prop in ((JObject)row).Properties())
        //                  {
        //                      colNames.Add($"[{prop.Name}]");
        //                      string paramName = "@" + prop.Name;
        //                      paramNames.Add(paramName);
        //                      parameters.Add(new SqlParameter(paramName, prop.Value.Type == JTokenType.Null ? DBNull.Value : prop.Value.ToObject<object>()));
        //                  }
        //                  string insertSql = $"INSERT INTO [{tableName}] ({string.Join(",", colNames)}) VALUES ({string.Join(",", paramNames)})";
        //                  using (var cmd = conn.CreateCommand())
        //                  {
        //                      cmd.CommandText = insertSql;
        //                      cmd.Parameters.AddRange(parameters.ToArray());
        //                      cmd.ExecuteNonQuery();
        //                  }
        //              }
        //          }
        //      }

        //      Console.WriteLine("Banco de dados, tabelas e dados importados com sucesso!");
        //  }


        //  static string GetSqlType(JTokenType type)
        //  {
        //      return type switch
        //      {
        //          JTokenType.Integer => "INT",
        //          JTokenType.Float => "FLOAT",
        //          JTokenType.Boolean => "BIT",
        //          JTokenType.Date => "DATETIME",
        //          JTokenType.String => "NVARCHAR(MAX)",
        //          _ => "NVARCHAR(MAX)"
        //      };
        //  }
    }




    /// <summary>
    /// Classe para configuração genérica do Entity Framework
    /// </summary>
    public static class EntityFrameworkConfigHelper
    {
        /// <summary>
        /// Método genérico para configurar ModelBuilder com delete cascade automático
        /// </summary>
        /// <param name="modelBuilder">O ModelBuilder do EF Core</param>
        public static void ConfigureGenericModelBuilder(ModelBuilder modelBuilder)
        {
            // Configuração genérica de string properties
            ConfigureStringProperties(modelBuilder);

            // Configuração de chaves primárias
            ConfigurePrimaryKeys(modelBuilder);

            // Configuração de delete cascade automático
            ConfigureDeleteCascade(modelBuilder);

            // Configuração de índices automáticos
            ConfigureIndexes(modelBuilder);
        }

        /// <summary>
        /// Configura delete cascade para todas as relações pai-filho
        /// </summary>
        private static void ConfigureDeleteCascade(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Obtém todas as foreign keys da entidade
                var foreignKeys = entityType.GetForeignKeys();

                foreach (var foreignKey in foreignKeys)
                {
                    // Configura delete cascade para cada foreign key
                    foreignKey.DeleteBehavior = DeleteBehavior.Cascade;

                    // Log da configuração (opcional)
                    Console.WriteLine($"Configurado delete cascade: {foreignKey.DeclaringEntityType.Name} -> {foreignKey.PrincipalEntityType.Name}");
                }

                // Configuração alternativa usando fluent API
                var clrType = entityType.ClrType;
                var navigationProperties = entityType.GetNavigations();

                foreach (var navigation in navigationProperties)
                {
                    if (navigation.IsCollection)
                    {
                        // Para relações 1:N (um pai para muitos filhos)
                        var principalType = navigation.DeclaringEntityType.ClrType;
                        var dependentType = navigation.TargetEntityType.ClrType;

                        modelBuilder.Entity(principalType)
                            .HasMany(dependentType)
                            .WithOne()
                            .OnDelete(DeleteBehavior.Cascade);
                    }
                }
            }
        }

        /// <summary>
        /// Configuração genérica para propriedades string
        /// </summary>
        private static void ConfigureStringProperties(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                foreach (var property in entityType.GetProperties())
                {
                    var memberInfo = property.PropertyInfo;
                    if (memberInfo == null) continue;

                    var stringLengthAttr = memberInfo
                        .GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.StringLengthAttribute), true)
                        .FirstOrDefault();

                    if (stringLengthAttr != null && property.ClrType == typeof(string))
                    {
                        bool isPrimaryKey = property.IsPrimaryKey();
                        bool isInIndex = entityType.GetIndexes().Any(idx => idx.Properties.Contains(property));

                        if (!isPrimaryKey && !isInIndex)
                        {
                            modelBuilder.Entity(clrType)
                                .Property(memberInfo.Name)
                                .HasColumnType("nvarchar(max)");
                        }
                    }

                    // Configuração adicional para strings sem StringLength
                    if (property.ClrType == typeof(string) && stringLengthAttr == null)
                    {
                        bool isPrimaryKey = property.IsPrimaryKey();

                        if (isPrimaryKey)
                        {
                            // Chaves primárias string com tamanho máximo de 450 caracteres
                            modelBuilder.Entity(clrType)
                                .Property(memberInfo.Name)
                                .HasMaxLength(450)
                                .IsRequired();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Configuração genérica para chaves primárias
        /// </summary>
        private static void ConfigurePrimaryKeys(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                var pk = entityType.FindPrimaryKey();

                if (pk != null)
                {
                    foreach (var keyProperty in pk.Properties)
                    {
                        modelBuilder.Entity(clrType)
                            .Property(keyProperty.Name)
                            .IsRequired();

                        // Para chaves string, garantir que não sejam vazias com tamanho máximo de 450
                        if (keyProperty.ClrType == typeof(string))
                        {
                            modelBuilder.Entity(clrType)
                                .Property(keyProperty.Name)
                                .HasMaxLength(450);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Configuração automática de índices para foreign keys
        /// </summary>
        private static void ConfigureIndexes(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                var foreignKeys = entityType.GetForeignKeys();

                foreach (var foreignKey in foreignKeys)
                {
                    // Cria índice automático para cada foreign key
                    var fkPropertyNames = foreignKey.Properties.Select(p => p.Name).ToArray();

                    modelBuilder.Entity(clrType)
                        .HasIndex(fkPropertyNames)
                        .HasDatabaseName($"IX_{clrType.Name}_{string.Join("_", fkPropertyNames)}");
                }

                // Índices para propriedades comuns de busca
                var commonSearchProperties = new[] { "nome", "descricao", "codigo", "stamp" };

                foreach (var property in entityType.GetProperties())
                {
                    var propertyName = property.Name.ToLower();

                    if (commonSearchProperties.Any(common => propertyName.Contains(common)) &&
                        property.ClrType == typeof(string) &&
                        !property.IsPrimaryKey())
                    {
                        modelBuilder.Entity(clrType)
                            .HasIndex(property.Name)
                            .HasDatabaseName($"IX_{clrType.Name}_{property.Name}");
                    }
                }
            }
        }

        /// <summary>
        /// Método específico para configurar delete cascade por convenção de nomes
        /// </summary>
        /// <param name="modelBuilder">O ModelBuilder do EF Core</param>
        /// <param name="conventionSuffixes">Sufixos que indicam foreign keys (ex: "Stamp", "Id")</param>
        public static void ConfigureDeleteCascadeByConvention(ModelBuilder modelBuilder, params string[] conventionSuffixes)
        {
            if (conventionSuffixes == null || !conventionSuffixes.Any())
            {
                conventionSuffixes = new[] { "Stamp", "Id" };
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                var properties = entityType.GetProperties();

                foreach (var property in properties)
                {
                    var propertyName = property.Name;

                    // Verifica se a propriedade segue a convenção de foreign key
                    if (conventionSuffixes.Any(suffix => propertyName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase)) &&
                        !property.IsPrimaryKey())
                    {
                        // Tenta encontrar a entidade principal baseada no nome
                        var principalEntityName = propertyName;
                        foreach (var suffix in conventionSuffixes)
                        {
                            if (propertyName.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                            {
                                principalEntityName = propertyName.Substring(0, propertyName.Length - suffix.Length);
                                break;
                            }
                        }

                        // Procura por uma entidade com nome similar
                        var principalEntityType = modelBuilder.Model.GetEntityTypes()
                            .FirstOrDefault(et => et.ClrType.Name.Equals(principalEntityName, StringComparison.OrdinalIgnoreCase) ||
                                                et.ClrType.Name.Contains(principalEntityName));

                        if (principalEntityType != null)
                        {
                            try
                            {
                                // Configura a relação com delete cascade
                                modelBuilder.Entity(clrType)
                                    .HasOne(principalEntityType.ClrType)
                                    .WithMany()
                                    .HasForeignKey(propertyName)
                                    .OnDelete(DeleteBehavior.Cascade);

                                Console.WriteLine($"Configurado delete cascade por convenção: {clrType.Name}.{propertyName} -> {principalEntityType.ClrType.Name}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Erro ao configurar delete cascade para {clrType.Name}.{propertyName}: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
    }



    public class EntityRequest
    {
        public string EntityStamp { get; set; }
        public string TableName { get; set; }
        public string StampColumnName { get; set; } = "Factstamp";
    }
    public class SqlConstring
    {
        public static string FormatSqlColumn(string columnName)
        {
            return $"[{columnName.Trim()}]";
        }
        public static bool HasSpaces(string columnName)
        {
            // Verifica se tem espaço no início, fim ou no meio
            return columnName != columnName.Trim() || columnName.Contains(" ");
        }
        public static string GetSqlConstring()
        {
            var str = "Server=CHICUANJO\\SERVER19;DataBase=SGPMWEB;User ID = sa;Password =123; MultipleActiveResultSets=True;TrustServerCertificate=True;";
            return str;
        }
        public static string GetSqlConstringGecamo()
        {
            var str = "Server=CHICUANJO\\SERVER19;DataBase=GECAMO;User ID = sa;Password =123; MultipleActiveResultSets=True;TrustServerCertificate=True;";
            return str;
        }
        public static string MapMySqlTypeToSqlServer(string mysqlType)
        {
            mysqlType = mysqlType.ToLower();
            if (mysqlType.StartsWith("int")) return "DECIMAL(18,4)";
            if (mysqlType.StartsWith("tinyint")) return "DECIMAL(18,4)"; // tinyint no SQL Server é SMALLINT
            if (mysqlType.StartsWith("smallint")) return "DECIMAL(18,4)";
            if (mysqlType.StartsWith("mediumint")) return "DECIMAL(18,4)";
            if (mysqlType.StartsWith("bigint")) return "DECIMAL(18,4)";
            if (mysqlType.StartsWith("varchar")) return "NVARCHAR(MAX)";
            if (mysqlType.StartsWith("char")) return "NVARCHAR(MAX)";
            if (mysqlType.StartsWith("datetime")) return "DATETIME";
            if (mysqlType.StartsWith("date")) return "DATE";
            if (mysqlType.StartsWith("text")) return "NVARCHAR(MAX)";
            if (mysqlType.StartsWith("float")) return "DECIMAL(18,4)";
            if (mysqlType.StartsWith("double")) return "DECIMAL(18,4)";
            if (mysqlType.StartsWith("decimal")) return "DECIMAL(18,4)";
            if (mysqlType.StartsWith("blob")) return "VARBINARY(MAX)";
            // Adicione outros tipos conforme necessário
            return "NVARCHAR(MAX)";
        }
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            // Tratamento genérico para tipos de propriedade string
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                foreach (var property in entityType.GetProperties())
                {
                    var memberInfo = property.PropertyInfo;
                    if (memberInfo == null) continue;

                    var stringLengthAttr = memberInfo
                        .GetCustomAttributes(typeof(StringLengthAttribute), true)
                        .FirstOrDefault();

                    if (stringLengthAttr != null && property.ClrType == typeof(string))
                    {
                        bool isPrimaryKey = property.IsPrimaryKey();
                        bool isInIndex = entityType.GetIndexes().Any(idx => idx.Properties.Contains(property));

                        if (!isPrimaryKey && !isInIndex)
                        {
                            modelBuilder.Entity(clrType)
                                .Property(memberInfo.Name)
                                .HasColumnType("nvarchar(max)");
                        }
                    }
                }

                var pk = entityType.FindPrimaryKey();
                if (pk != null)
                {
                    foreach (var keyProperty in pk.Properties)
                    {
                        modelBuilder.Entity(clrType)
                            .Property(keyProperty.Name)
                            .IsRequired();
                    }
                }
            }

           // ConfigureMilEntity(modelBuilder);

        }

        public static void ConfigureMilEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mil>(entity =>
            {
                // Configuração da chave primária
                entity.HasKey(m => m.milStamp);

                // Configuração da chave primária com tamanho máximo
                entity.Property(m => m.milStamp)
                      .HasMaxLength(450)
                      .IsRequired();

                // ===== RELAÇÕES 1:N (Um Mil para Muitos) =====

                // Email - Relação com ICollection<Email>
                entity.HasMany(m => m.Email)
                      .WithOne() // Assumindo que Email tem uma propriedade de navegação para Mil
                      .HasForeignKey("milStamp") // Assumindo que Email tem milStamp como FK
                      .OnDelete(DeleteBehavior.Cascade);

                // Fornecimento - Relação com ICollection<Fornecimento>
                entity.HasMany(m => m.Fornecimento)
                      .WithOne() // Assumindo que Fornecimento tem uma propriedade de navegação para Mil
                      .HasForeignKey("milStamp") // Assumindo que Fornecimento tem milStamp como FK
                      .OnDelete(DeleteBehavior.Cascade);

                // MilAgre - Relação com ICollection<MilAgre>
                entity.HasMany(m => m.MilAgre)
                      .WithOne(ma => ma.Mil)
                      .HasForeignKey(ma => ma.milStamp) // FK na tabela MilAgre
                      .OnDelete(DeleteBehavior.Cascade);

                // MilConde - Relação com ICollection<MilConde>
                entity.HasMany(m => m.MilConde)
                      .WithOne(mc => mc.Mil)
                      .HasForeignKey(mc => mc.milStamp) // FK na tabela MilConde
                      .OnDelete(DeleteBehavior.Cascade);

                // MilDoc - Relação com ICollection<MilDoc>
                entity.HasMany(m => m.MilDoc)
                      .WithOne(md => md.Mil)
                      .HasForeignKey(md => md.milStamp) // FK na tabela MilDoc
                      .OnDelete(DeleteBehavior.Cascade);

                // MilEmail - Relação com ICollection<MilEmail>
                entity.HasMany(m => m.MilEmail)
                      .WithOne(me => me.Mil)
                      .HasForeignKey(me => me.milStamp) // FK na tabela MilEmail
                      .OnDelete(DeleteBehavior.Cascade);

                // MilEmFor - Relação com ICollection<MilEmFor>
                entity.HasMany(m => m.MilEmFor)
                      .WithOne(mef => mef.Mil)
                      .HasForeignKey(mef => mef.milStamp) // FK na tabela MilEmFor
                      .OnDelete(DeleteBehavior.Cascade);

                // MilEspecial - Relação com ICollection<MilEspecial>
                entity.HasMany(m => m.MilEspecial)
                      .WithOne(me => me.Mil)
                      .HasForeignKey(me => me.milStamp) // FK na tabela MilEspecial
                      .OnDelete(DeleteBehavior.Cascade);

                // MilFor - Relação com ICollection<MilFor>
                entity.HasMany(m => m.MilFor)
                      .WithOne(mf => mf.Mil)
                      .HasForeignKey(mf => mf.milStamp) // FK na tabela MilFor
                      .OnDelete(DeleteBehavior.Cascade);

                // MilFot - Relação com ICollection<MilFot>
                entity.HasMany(m => m.MilFot)
                      .WithOne(mf => mf.Mil)
                      .HasForeignKey(mf => mf.milStamp) // FK na tabela MilFot
                      .OnDelete(DeleteBehavior.Cascade);

                // MilFuncao - Relação com ICollection<MilFuncao>
                entity.HasMany(m => m.MilFuncao)
                      .WithOne(mf => mf.Mil)
                      .HasForeignKey(mf => mf.milStamp) // FK na tabela MilFuncao
                      .OnDelete(DeleteBehavior.Cascade);

                // MilLice - Relação com ICollection<MilLice>
                entity.HasMany(m => m.MilLice)
                      .WithOne(ml => ml.Mil)
                      .HasForeignKey(ml => ml.milStamp) // FK na tabela MilLice
                      .OnDelete(DeleteBehavior.Cascade);

                // MilLingua - Relação com ICollection<MilLingua>
                entity.HasMany(m => m.MilLingua)
                      .WithOne(ml => ml.Mil)
                      .HasForeignKey(ml => ml.milStamp) // FK na tabela MilLingua
                      .OnDelete(DeleteBehavior.Cascade);

                // MilPeEmerg - Relação com ICollection<MilPeEmerg>
                entity.HasMany(m => m.MilPeEmerg)
                      .WithOne(mpe => mpe.Mil)
                      .HasForeignKey(mpe => mpe.milStamp) // FK na tabela MilPeEmerg
                      .OnDelete(DeleteBehavior.Cascade);

                // MilRea - Relação com ICollection<MilRea>
                entity.HasMany(m => m.MilRea)
                      .WithOne(mr => mr.Mil)
                      .HasForeignKey(mr => mr.milStamp) // FK na tabela MilRea
                      .OnDelete(DeleteBehavior.Cascade);

                // MilReco - Relação com ICollection<MilReco>
                entity.HasMany(m => m.MilReco)
                      .WithOne(mr => mr.Mil)
                      .HasForeignKey(mr => mr.milStamp) // FK na tabela MilReco
                      .OnDelete(DeleteBehavior.Cascade);

                // MilReg - Relação com ICollection<MilReg>
                entity.HasMany(m => m.MilReg)
                      .WithOne(mr => mr.Mil)
                      .HasForeignKey(mr => mr.milStamp) // FK na tabela MilReg
                      .OnDelete(DeleteBehavior.Cascade);

                // MilRetReaSal - Relação com ICollection<MilRetReaSal>
                entity.HasMany(m => m.MilRetReaSal)
                      .WithOne(mrrs => mrrs.Mil)
                      .HasForeignKey(mrrs => mrrs.milStamp) // FK na tabela MilRetReaSal
                      .OnDelete(DeleteBehavior.Cascade);

                // MilSa - Relação com ICollection<MilSa>
                entity.HasMany(m => m.MilSa)
                      .WithOne(ms => ms.Mil)
                      .HasForeignKey(ms => ms.milStamp) // FK na tabela MilSa
                      .OnDelete(DeleteBehavior.Cascade);

                // MilSit - Relação com ICollection<MilSit>
                entity.HasMany(m => m.MilSit)
                      .WithOne(ms => ms.Mil)
                      .HasForeignKey(ms => ms.milStamp) // FK na tabela MilSit
                      .OnDelete(DeleteBehavior.Cascade);

                // MilSitCrim - Relação com ICollection<MilSitCrim>
                entity.HasMany(m => m.MilSitCrim)
                      .WithOne(msc => msc.Mil)
                      .HasForeignKey(msc => msc.milStamp) // FK na tabela MilSitCrim
                      .OnDelete(DeleteBehavior.Cascade);

                // MilSitDisc - Relação com ICollection<MilSitDisc>
                entity.HasMany(m => m.MilSitDisc)
                      .WithOne(msd => msd.Mil)
                      .HasForeignKey(msd => msd.milStamp) // FK na tabela MilSitDisc
                      .OnDelete(DeleteBehavior.Cascade);

                // MilSitQPActivo - Relação com ICollection<MilSitQPActivo>
                entity.HasMany(m => m.MilSitQPActivo)
                      .WithOne(msqp => msqp.Mil)
                      .HasForeignKey(msqp => msqp.milStamp) // FK na tabela MilSitQPActivo
                      .OnDelete(DeleteBehavior.Cascade);

                // Telefone - Relação com ICollection<Telefone>
                entity.HasMany(m => m.Telefone)
                      .WithOne() // Assumindo que Telefone tem uma propriedade de navegação para Mil
                      .HasForeignKey("milStamp") // Assumindo que Telefone tem milStamp como FK
                      .OnDelete(DeleteBehavior.Cascade);

                // ===== RELAÇÕES 1:1 (Um Mil para Um) =====

                // MilFa - Relação 1:1
                entity.HasOne(m => m.MilFa)
                      .WithOne(mf => mf.Mil)
                      .HasForeignKey<MilFa>(mf => mf.milStamp) // FK na tabela MilFa
                      .OnDelete(DeleteBehavior.Cascade);

                // MilIDigital - Relação 1:1
                entity.HasOne(m => m.MilIDigital)
                      .WithOne(mid => mid.Mil)
                      .HasForeignKey<MilIDigital>(mid => mid.milStamp) // FK na tabela MilIDigital
                      .OnDelete(DeleteBehavior.Cascade);

                // MilMed - Relação 1:1
                entity.HasOne(m => m.MilMed)
                      .WithOne(mm => mm.Mil)
                      .HasForeignKey<MilMed>(mm => mm.milStamp) // FK na tabela MilMed
                      .OnDelete(DeleteBehavior.Cascade);

                // MilSalario - Relação 1:1
                entity.HasOne(m => m.MilSalario)
                      .WithOne(ms => ms.Mil)
                      .HasForeignKey<MilSalario>(ms => ms.milStamp) // FK na tabela MilSalario
                      .OnDelete(DeleteBehavior.Cascade);
                

                // ===== ÍNDICES PARA PERFORMANCE =====

                // Índice para NIM (importante para buscas)
                entity.HasIndex(m => m.nim)
                      .IsUnique()
                      .HasDatabaseName("IX_Mil_NIM");

                // Índice para nome (importante para buscas)
                entity.HasIndex(m => m.nome)
                      .HasDatabaseName("IX_Mil_Nome");

                // Índice para ramo
                entity.HasIndex(m => m.ramo)
                      .HasDatabaseName("IX_Mil_Ramo");

                // Índice composto para busca por data de nascimento
                entity.HasIndex(m => m.nascData)
                      .HasDatabaseName("IX_Mil_NascData");
            });

            Console.WriteLine("✅ Configuração completa da entidade Mil aplicada com Delete Cascade");
        }

    }

    public static class TypeScriptConverter
    {
        public static void Main()
        {
            string modelsPath = @"D:\DISCO G\Moz\Projecto FADM\SSD FORMATAR\PROJECTS\MELHOR\Facturacao\Model\Models\Facturacao";
            string outputPath = @"C:\Users\CHICUANJO\Desktop\TypescriptClasses\output.txt";

            var classFiles = Directory.GetFiles(modelsPath, "*.cs");

            var result = new StringBuilder();

            foreach (var file in classFiles)
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(file));
                var root = syntaxTree.GetRoot();
                var classes = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>();

                foreach (var classDecl in classes)
                {
                    var className = classDecl.Identifier.Text;
                    var props = classDecl.Members.OfType<Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax>();

                    result.AppendLine($"export interface {className} {{");

                    foreach (var prop in props)
                    {
                        string propName = char.ToLowerInvariant(prop.Identifier.Text[0]) + prop.Identifier.Text.Substring(1);
                        string typeScriptType = MapToTypeScriptType(prop.Type.ToString());
                        bool isRequired = prop.AttributeLists
                            .SelectMany(x => x.Attributes)
                            .Any(a => a.Name.ToString().Contains("Required"));

                        bool isNullable = !isRequired;
                        result.AppendLine($"  {propName}{(isNullable ? "?" : "")}: {typeScriptType};");
                    }

                    result.AppendLine("}\n");
                }
            }

            File.WriteAllText(outputPath, result.ToString());
            Console.WriteLine("Interfaces TypeScript geradas com sucesso.");
        }

        public static void Sjm()
        {
            string modelsPath = @"D:\DISCO G\Moz\Projecto FADM\SSD FORMATAR\PROJECTS\MELHOR\Facturacao\Model\Models\SJM";


            modelsPath = "D:\\Angular\\BLAZOR\\SGPM\\API SGPM\\Model\\Models\\SJM";
            string outputPath = @"C:\Users\CHICUANJO\Desktop\TypescriptClasses\sjm.txt";

            var classFiles = Directory.GetFiles(modelsPath, "*.cs");

            var result = new StringBuilder();

            foreach (var file in classFiles)
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(file));
                var root = syntaxTree.GetRoot();
                var classes = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>();

                foreach (var classDecl in classes)
                {
                    var className = classDecl.Identifier.Text;
                    var props = classDecl.Members.OfType<Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax>();

                    result.AppendLine($"export interface {className} {{");

                    foreach (var prop in props)
                    {
                        string propName = char.ToLowerInvariant(prop.Identifier.Text[0]) + prop.Identifier.Text.Substring(1);
                        string typeScriptType = MapToTypeScriptType(prop.Type.ToString());
                        bool isRequired = prop.AttributeLists
                            .SelectMany(x => x.Attributes)
                            .Any(a => a.Name.ToString().Contains("Required"));

                        bool isNullable = !isRequired;
                        result.AppendLine($"  {propName}{(isNullable ? "?" : "")}: {typeScriptType};");
                    }

                    result.AppendLine("}\n");
                }
            }

            File.WriteAllText(outputPath, result.ToString());
            Console.WriteLine("Interfaces TypeScript geradas com sucesso.");
        }
        public static void SGPM()
        {
            string modelsPath = @"D:\Angular\BLAZOR\SGPM\API SGPM\Model\Models\SGPM";

            var patfile = @"C:\Users\CHICUANJO\Desktop\TypescriptClasses";

            string outputPath = Path.Combine(patfile, "SGPM.txt");

            var classFiles = Directory.GetFiles(modelsPath, "*.cs");

            if (!Directory.Exists(modelsPath))
            {
                Directory.CreateDirectory(modelsPath);
            }
            if (!Directory.Exists(patfile))
            {
                Directory.CreateDirectory(patfile);
            }
            if (!File.Exists(outputPath))
            {
                File.Create(outputPath);
            }
            var result = new StringBuilder();
            foreach (var file in classFiles)
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(file));
                var root = syntaxTree.GetRoot();
                var classes = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>();
                foreach (var classDecl in classes)
                {
                    var className = classDecl.Identifier.Text;
                    var props = classDecl.Members.OfType<Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax>();
                    result.AppendLine($"export interface {className} {{");
                    foreach (var prop in props)
                    {
                        string propName = char.ToLowerInvariant(prop.Identifier.Text[0]) + prop.Identifier.Text.Substring(1);
                        string typeScriptType = MapToTypeScriptType(prop.Type.ToString());
                        bool isRequired = prop.AttributeLists
                            .SelectMany(x => x.Attributes)
                            .Any(a => a.Name.ToString().Contains("Required"));
                        bool isNullable = !isRequired;
                        result.AppendLine($"  {propName}{(isNullable ? "?" : "")}: {typeScriptType};");
                    }
                    result.AppendLine("}\n");
                }
            }
            File.WriteAllText(outputPath, result.ToString());
            Console.WriteLine("Interfaces TypeScript geradas com sucesso.");
        }
        public static void Pdv()
        {
            string modelsPath = @"D:\DISCO G\Moz\Projecto FADM\SSD FORMATAR\PROJECTS\MELHOR\Facturacao\Model\Models\PDV";
            string outputPath = @"C:\Users\CHICUANJO\Desktop\TypescriptClasses\Pdv.txt";

            var classFiles = Directory.GetFiles(modelsPath, "*.cs");

            var result = new StringBuilder();

            foreach (var file in classFiles)
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(file));
                var root = syntaxTree.GetRoot();
                var classes = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>();

                foreach (var classDecl in classes)
                {
                    var className = classDecl.Identifier.Text;
                    var props = classDecl.Members.OfType<Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax>();

                    result.AppendLine($"export interface {className} {{");

                    foreach (var prop in props)
                    {
                        string propName = char.ToLowerInvariant(prop.Identifier.Text[0]) + prop.Identifier.Text.Substring(1);
                        string typeScriptType = MapToTypeScriptType(prop.Type.ToString());
                        bool isRequired = prop.AttributeLists
                            .SelectMany(x => x.Attributes)
                            .Any(a => a.Name.ToString().Contains("Required"));

                        bool isNullable = !isRequired;
                        result.AppendLine($"  {propName}{(isNullable ? "?" : "")}: {typeScriptType};");
                    }

                    result.AppendLine("}\n");
                }
            }

            File.WriteAllText(outputPath, result.ToString());
            Console.WriteLine("Interfaces TypeScript geradas com sucesso.");
        }
        public static void Models()
        {
            string modelsPath = @"D:\DISCO G\Moz\Projecto FADM\SSD FORMATAR\PROJECTS\MELHOR\Facturacao\Model\Models";
            string outputPath = @"C:\Users\CHICUANJO\Desktop\TypescriptClasses\Model.txt";

            var classFiles = Directory.GetFiles(modelsPath, "*.cs");

            var result = new StringBuilder();

            foreach (var file in classFiles)
            {
                var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(file));
                var root = syntaxTree.GetRoot();
                var classes = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>();

                foreach (var classDecl in classes)
                {
                    var className = classDecl.Identifier.Text;
                    var props = classDecl.Members.OfType<Microsoft.CodeAnalysis.CSharp.Syntax.PropertyDeclarationSyntax>();

                    result.AppendLine($"export interface {className} {{");

                    foreach (var prop in props)
                    {
                        string propName = char.ToLowerInvariant(prop.Identifier.Text[0]) + prop.Identifier.Text.Substring(1);
                        string typeScriptType = MapToTypeScriptType(prop.Type.ToString());
                        bool isRequired = prop.AttributeLists
                            .SelectMany(x => x.Attributes)
                            .Any(a => a.Name.ToString().Contains("Required"));

                        bool isNullable = !isRequired;
                        result.AppendLine($"  {propName}{(isNullable ? "?" : "")}: {typeScriptType};");
                    }

                    result.AppendLine("}\n");
                }
            }

            File.WriteAllText(outputPath, result.ToString());
            Console.WriteLine("Interfaces TypeScript geradas com sucesso.");
        }
        private static string MapToTypeScriptType(string csharpType)
        {
            if (csharpType.StartsWith("List<") || csharpType.StartsWith("ICollection<") || csharpType.StartsWith("IEnumerable<"))
            {
                var innerType = csharpType.Substring(csharpType.IndexOf('<') + 1);
                innerType = innerType.TrimEnd('>');

                return $"{MapToTypeScriptType(innerType)}[]";
            }
            if (csharpType.StartsWith("Nullable<"))
            {
                var innerType = csharpType.Substring("Nullable<".Length).TrimEnd('>');
                return MapToTypeScriptType(innerType);
            }
            return csharpType switch
            {
                "int" or "long" or "float" or "double" or "decimal" => "number",
                "string" => "string",
                "bool" => "boolean",
                "DateTime" => "Date",
                _ => csharpType // Assume que é uma classe customizada já mapeada
            };
        }

    }


}
