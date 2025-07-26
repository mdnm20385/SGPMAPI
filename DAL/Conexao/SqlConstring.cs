using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace DAL.Conexao
{

    public class EntityRequest
    {
        public string EntityStamp { get; set; }
        public string TableName { get; set; }
        public string StampColumnName { get; set; } = "Factstamp";
    }
    public class SqlConstring
    {

        public static string GetSqlConstring()
        {
            var str = "Server=CHICUANJO\\SERVER19;DataBase=SGPMWEB;User ID = sa;Password =123; MultipleActiveResultSets=True;TrustServerCertificate=True;";
            return str;
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
