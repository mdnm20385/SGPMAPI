using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Reflection;
using DAL.Classes;
using Microsoft.EntityFrameworkCore;
using Model.Models.SJM;
using static Dapper.SqlMapper;

namespace DAL.BL
{
    public static class Utilities
    {
        public static DateTime SqlDate2 { get; set; } = Pbl.SqlDate;
        public static string Login { get; set; }
        public static DataTable SetDefaultDateTime(DataTable dt, List<string> lista)
        {
            foreach (var r in dt.AsEnumerable())
            {
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    if (r[i] is DateTime)
                    {
                        try
                        {
                            var date = Convert.ToDateTime(r[i]);
                            if ((date < (DateTime)SqlDateTime.MinValue) || (date > (DateTime)SqlDateTime.MaxValue))
                            {
                                r[i] = SqlDate2;
                            }
                            else
                            {
                                r[i] = date;
                            }
                            if (dt.Columns[i].ColumnName == "qmadathora")
                            {
                                r[i] = SqlDate2;
                            }
                        }
                        catch
                        {
                            r[i] = (DateTime)SqlDateTime.MinValue;
                        }
                    }
                    if (dt.Columns[i].DataType != typeof(string)) continue;
                    var valor = r[i];
                    if (String.IsNullOrWhiteSpace(valor.ToString()))
                    {
                        if (dt.Columns[i].ColumnName != lista.FirstOrDefault(x => x.Equals(dt.Columns[i].ColumnName)))
                        {
                            r[i] = "";
                        }

                    }
                    if (dt.Columns[i].ColumnName == "qmc" && r.RowState == DataRowState.Added)
                        r[i] = Login;

                    if (dt.Columns[i].ColumnName == "qma")
                        r[i] = Login;
                }
            }
            if (lista == null) return dt;
            foreach (var r in dt.AsEnumerable())
            {
                for (var i = 0; i < dt.Columns.Count; i++)
                {
                    var nome = lista.FirstOrDefault(x => x.Equals(dt.Columns[i].ColumnName));
                    if (dt.Columns[i].ColumnName != nome) continue;
                    if (nome != null)
                    {
                        r[i] = DBNull.Value;
                    }
                }
            }
            return dt;
        }
        //public static T SetDefaultValue2<T>(T ef) where T : class, new()
        //{
        //    var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    var lista = GetNavKeyNames<T>();
        //    foreach (var p in properties.Where(p => p.Name != lista.FirstOrDefault(x => x.Equals(p.Name.Trim()))))
        //    {
        //        if (p.PropertyType == typeof(string) && p.GetValue(ef, null) == null)
        //        {
        //            var valor = p.GetValue(ef, null);
        //            if (valor == null)
        //            {
        //                if (p.PropertyType == typeof(string))
        //                {
        //                    p.SetValue(ef, "");
        //                }
        //            }
        //        }
        //        if (p.PropertyType != typeof(DateTime)) continue;
        //        try
        //        {
        //            var date = Convert.ToDateTime(p.GetValue(ef, null));
        //            p.SetValue(ef, date.Year < 1900 ? new DateTime(1900, 1, 1) : date);
        //        }
        //        catch
        //        {
        //            p.SetValue(ef, new DateTime(1900, 1, 1));
        //        }
        //    }
        //    foreach (var p in properties)
        //    {
        //        if (p.PropertyType != typeof(string)) continue;
        //        var valor = p.GetValue(ef, null);
        //        if (valor == null) continue;
        //        p.SetValue(ef, valor.ToString().Trim());
        //    }
        //    return ef;
        //}
        public static T AllTrim<T>(T ef) where T : class?, new()
        {

            EF.SanitizeObject(ef);
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



        public static (string pkName, string pkValue, string tbName) PkeyValues<T>(T ef, string stamp = "") where T : class
        {
            (string pkName, string pkValue, string tbName) xxx = ("", "", "");
            var nomeClasse = typeof(T).Name;
            xxx.tbName = nomeClasse;
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in properties.ToList())
            {
                if (stamp == "")
                {
                    if (p.Name.ToLower().Contains("stamp") && p.Name.Trim().ToLower().Contains(nomeClasse.ToLower().Trim()))
                    {
                        xxx.pkName = p.Name;
                        xxx.pkValue = p.GetValue(ef, null).ToString().Trim();
                        break;
                    }
                }
                else
                {
                    if (p.Name.ToLower().Trim().Equals(stamp))
                    {
                        xxx.pkName = p.Name;
                        xxx.pkValue = p.GetValue(ef, null).ToString().Trim();
                        break;
                    }
                }
            }
            return xxx;
        }


        public static string PkeyValue<T>(T ef, string stamp = "") where T : class
        {
            var valor = string.Empty;
         
            PropertyInfo? chavePrimaria = typeof(T).GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Any());
            if (chavePrimaria != null)
            {
                valor = chavePrimaria?.GetValue(ef, null)?.ToString();
            }
            else
            {
                valor = "";
            }
            return valor;
        }
        public static string GetValue<T>(T ef, string campo) where T : class
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var valor = String.Empty;
            foreach (var p in properties.ToList())
            {
                if (p.Name == campo)
                {
                    valor = p.GetValue(ef, null).ToString();
                }

            }
            return valor;
        }
        #region Limpa os Campos nulls de uma Tabela ......

        //public static DataTable SetDefault(DataTable dt)
        //  {
        //      foreach (var r in dt.AsEnumerable())
        //      {
        //          if (r.RowState == DataRowState.Deleted) continue;
        //          for (var i = 0; i < r.Table.Columns.Count; i++)
        //          {
        //              if (r.Table.Columns[i].DataType== typeof(DateTime))
        //              {
        //                  try
        //                  {
        //                      var date = Convert.ToDateTime(r[i]);
        //                      if (date.Year < 1900)
        //                      {
        //                          r[i] = new DateTime(1900, 1, 1);
        //                      }
        //                      else
        //                      {
        //                          r[i] = date;
        //                      }
        //                      if (dt.Columns[i].ColumnName == "qmadathora")
        //                      {
        //                          r[i] = Pbl.SqlDate;
        //                      }
        //                  }
        //                  catch
        //                  {
        //                      r[i] = new DateTime(1900, 1, 1);
        //                  }
        //              }
        //              if (r.Table.Columns[i].DataType == typeof(string))
        //              {
        //                  var valor = r[i];
        //                  if (string.IsNullOrWhiteSpace(valor.ToString()))
        //                  {
        //                      r[i] = "";
        //                  }
        //                  if (r.Table.Columns[i].ColumnName == "qmc" && r.RowState == DataRowState.Added)
        //                  {
        //                      r[i] = Login;
        //                  }

        //                  if (r.Table.Columns[i].ColumnName == "qma")
        //                  {
        //                      r[i] = Login;
        //                  }
        //              }

        //              if (r.Table.Columns[i].DataType == typeof(decimal))
        //              {
        //                  var valor = r[i];
        //                  if (string.IsNullOrWhiteSpace(valor.ToString()))
        //                  {
        //                      r[i] = 0;
        //                  }
        //              }
        //              if (r.Table.Columns[i].DataType == typeof(int))
        //              {
        //                  var valor = r[i];
        //                  if (string.IsNullOrWhiteSpace(valor.ToString()))
        //                  {
        //                      r[i] = 0;
        //                  }
        //              }
        //              if (r.Table.Columns[i].DataType == typeof(bool))
        //              {
        //                  var valor = r[i];
        //                  r[i] = valor.ToBool();
        //              }
        //          }

        //      }
        //      //var nomeClasse = dt.TableName;
        //      //var lista = SQL.GetGenDT($"SELECT column_name FROM INFORMATION_SCHEMA.COLUMNS WHERE table_name = '{nomeClasse.Trim()}' and IS_NULLABLE='YES'");
        //      //if (lista.Rows.Count == 0) return dt;
        //      //foreach (var row in dt.AsEnumerable())
        //      //{
        //      //    if (row.RowState == DataRowState.Deleted) continue;
        //      //    for (var i = 0; i < dt.Columns.Count; i++)
        //      //    {
        //      //        var r2 = lista.AsEnumerable().FirstOrDefault(x => x.Field<string>("column_name").Equals(dt.Columns[i].ColumnName));
        //      //        if (r2 == null) continue;
        //      //        if (string.IsNullOrWhiteSpace(row[i].ToString()))
        //      //        {
        //      //            row[i] = DBNull.Value;
        //      //        }
        //      //    }
        //      //}
        //      return dt;
        //  } 
        #endregion

        //public static List<string> GetNavKeyNames<T>(DmzDbContext context) where T : class
        //{
        //    var objectSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<T>();
        //    var keyNames = objectSet.EntitySet.ElementType.NavigationProperties.Select(k => k.Name).ToList();
        //    return keyNames;
        //}

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
            if (value != null && p != null && p.PropertyType == typeof(long))
            {
                p.SetValue(entity, Convert.ToInt64(value));
            }
            if (value != null && p != null && p.PropertyType == typeof(int))
            {
                p.SetValue(entity, value.ToInt());
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

        public static void SetToNull<TEntity, TProperty>(this TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty, DbContext context = null)
            where TEntity : class
            where TProperty : class
        {
            var pi = GetPropertyInfo(entity, navigationProperty);

            if (context != null)
            {
                //If DB Context is supplied, use Entry/Reference method to null out current value
                context.Entry(entity).Reference(navigationProperty).CurrentValue = null;
            }
            else
            {
                //If no DB Context, then lazy load first
                var prevValue = (TProperty)pi.GetValue(entity);
            }

            pi.SetValue(entity, null);
        }

        static PropertyInfo GetPropertyInfo<TSource, TProperty>(TSource source, Expression<Func<TSource, TProperty>> propertyLambda)
        {
            var type = typeof(TSource);

            var member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(String.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));

            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(String.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda));

            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(String.Format(
                    "Expression '{0}' refers to a property that is not from type {1}.",
                    propertyLambda,
                    type));

            return propInfo;
        }

        public static T DoAddline<T>() where T : class, new()
        {
            var t = new T();
            var nomeClasse = typeof(T).Name;
            var lista = SQL.GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{nomeClasse.Trim()}' and IS_NULLABLE='YES' ", " column_name ");
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                if (p.PropertyType == typeof(string))
                {
                    //p.SetValue(t, "");
                    if (p.Name.Trim().ToLower().Contains("stamp") && p.Name.Trim().ToLower().Contains(nomeClasse.ToLower().Trim()))
                    {
                        p.SetValue(t, Pbl.Stamp());
                    }
                    if (p.Name == "qmc")
                    {
                        p.SetValue(t, "");
                    }

                    if (lista.Rows.Count > 0)
                    {
                        var r = lista.AsEnumerable().FirstOrDefault(x => x.Field<string>("column_name").Equals(p.Name.ToString()));
                        if (r != null)
                        {
                            if (p.Name != "qmc")
                            {
                                p.SetValue(t, null);
                            }
                        }
                    }
                }
                if (p.PropertyType == typeof(DateTime))
                {
                    p.SetValue(t, new DateTime(1900, 1, 1));
                }
                if (p.Name == "qmadathora")
                {
                    p.SetValue(t, new DateTime(1900, 1, 1));
                }
                if (p.Name == "qmcdathora")
                {
                    p.SetValue(t, Pbl.SqlDate);
                }
            }
            return t;
        }

        public static string BuildCond(object cond, string campo, string type, string cond1, bool chk)
        {
            var buildCond = string.Empty;
            if (InList(type, new List<string> { "char", "nvarchar", "varchar", "text" }))
            {
                buildCond = string.Format(chk ? " {0} like '%{1}%' " : "{0} like '{1}%'", campo, cond);
            }
            if (type.Contains("datetime"))
            {
                buildCond = $" Convert(date,{campo}) ='{cond}' ";
            }
            if (InList(type, new List<string> { "decimal", "numeric" ,"bigint","int","float","double"}))
            {
                if (cond.ToDecimal()>0)
                {
                    buildCond = $" {campo} ={cond.ToDecimal()} and {cond1}";
                }
                else
                {
                    buildCond = $" {cond1} ";
                }
            }
            if (type == "bit")
            {
                buildCond = $" {campo} ={cond.ToInt()} ";
            }
            if (!string.IsNullOrEmpty(cond1))
            {

                if (!cond1.Equals(buildCond))
                {
                    buildCond = $" {cond1} and {buildCond}";
                }
            }
            return buildCond;
        }

        public static bool InList(decimal col, List<decimal> lista) => lista.Any(x => x.Equals(col));
        public static bool InList(string col, List<string> lista) => lista.Any(x => x.Equals(col));



        private static bool IsValidURL(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        static dynamic FindAll2()
        {
            return new dynamic[] {
                "Name 1", "Name 2", "Name 3", "Name 4"
            };
        }
    }
}
