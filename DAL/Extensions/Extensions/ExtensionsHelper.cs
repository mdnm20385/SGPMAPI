using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using DAL.BL;
using DAL.Classes;

namespace DAL.Extensions.Extensions
{
    public static class ExtensionsHelper
    {
        private static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
        public static DataRow GetFirstOrDefault(this DataTable table,Type tipo,string campo,string valor)
        {
            DataRow dr = null;
            if (tipo.Name.ToLower().Equals("decimal"))
            {
                dr = table.AsEnumerable().FirstOrDefault(s => s.Field<decimal>(campo).Equals(valor.ToDecimal()));
            }
            if (tipo.Name.ToLower().Equals("string"))
            {
                dr = table.AsEnumerable().FirstOrDefault(s => s.Field<string>(campo).Equals(valor));
            }
            if (tipo.Name.ToLower().Equals(typeof(bool)))
            {
                dr = table.AsEnumerable().FirstOrDefault(s => s.Field<string>(campo).Equals(valor).ToBool());
            }
            if (tipo.Name.ToLower().Equals(typeof(int)))
            {
                dr = table.AsEnumerable().FirstOrDefault(s => s.Field<int>(campo).Equals(valor.ToInt()));
            }
            if (tipo.Name.ToLower().Equals(typeof(int)))
            {
                dr = table.AsEnumerable().FirstOrDefault(s => s.Field<int>(campo).Equals(valor.ToInt()));
            }
            return dr;
        }
        public static DataRow GetFirstOrDefault(this DataTable table, Func<DataRow, bool> qry)
        {
            var dr = table.AsEnumerable().FirstOrDefault(qry);
            return dr;
        }

        public static DataRow GetFirstOrDefault(this DataTable table, string condicao)
        {
            var drr= table.Select(condicao);

            if (drr.Length > 0)
            {
                var dr = drr[0];
                return dr;
            }
            return null;
        }
        public static bool DataRowIsNull(this DataRow dr)
        {
            return dr == null;
        }
        public static DataTable GetTable(this DataTable table, string condicao)
        {
            DataRow[] dt = null;
            if (table.HasRows())
            {
                dt = table.Select(condicao);
            }

            if (dt != null && dt.Length > 0)
            {
                return dt.CopyToDataTable();
            }

            return null;
        }
        public static DataTable Where(this DataTable table, Type tipo, string campo, string valor)
        {
            DataTable dt = null;
            switch (tipo.Name.ToLower())
            {
                case "decimal":
                    if (table.AsEnumerable().Any(s => s.Field<decimal>(campo).Equals(valor.ToDecimal())))
                    {
                        dt = table.AsEnumerable().Where(s => s.Field<decimal>(campo).Equals(valor.ToDecimal())).CopyToDataTable();
                    }                   
                    break;
                case "string":
                    if (table.AsEnumerable().Any(s => s.Field<string>(campo).Equals(valor)))
                    {
                        dt = table.AsEnumerable().Where(s => s.Field<string>(campo).Equals(valor)).CopyToDataTable();
                    }                   
                    break;
                case "boolean":
                    if (table.AsEnumerable().Any(s => s.Field<bool>(campo).Equals(valor.ToBool())))
                    {
                        dt = table.AsEnumerable().Where(s => s.Field<bool>(campo).Equals(valor.ToBool())).CopyToDataTable();
                    }                   
                    break;
                case "int":
                    if (table.AsEnumerable().Any(s => s.Field<int>(campo).Equals(valor.ToInt())))
                    {
                        dt = table.AsEnumerable().Where(s => s.Field<int>(campo).Equals(valor.ToInt())).CopyToDataTable();
                    }                    
                    break;
                case "datetime":
                    if (table.AsEnumerable().Any(s => s.Field<DateTime>(campo).Equals(valor.ToDateTimeValue())))
                    {
                        dt = table.AsEnumerable().Where(s => s.Field<DateTime>(campo).Equals(valor.ToDateTimeValue())).CopyToDataTable();
                    }                    
                    break;
            }
            return dt;
        }
        public static bool HasRows(this DataTable? table)
        {
            return table?.Rows.Count>0;
        }
        public static void AddRow(this DataTable table,DataRow dr)
        {
            table?.Rows.Add(dr);
        }
        public static object? RowZero(this DataTable table, string campo)
        {
            if (table.HasErrors)
            {
                return false;
            }
            try
            {
                return table.Rows[0][campo.Trim()];
            }
            catch
            {
                return null;
            }
        }
        public static bool HasColumns(this DataTable table)
        {
            return table?.Columns.Count > 0;
        }
        public static bool HasColumn([NotNull] this DataTable table, string campo)
        {
            return table.HasColumns() && table.Columns.Contains(campo.Trim());
        }
        public static int GetDecimalPart(this decimal valor)
        {
            return (int)((valor - (int)valor) * 100);
        }
        
        public static string ToFormatoDiaMesAno(this DateTime dt)
        {
            return dt.ToString("dd/MM/yyyy");
        }
        public static string? ToTrim(this object? obj)
        {
           return obj.ToString().Trim();
        }
        public static bool HasRows(this DataTable dt,string campo,bool valor=true)
        {
            if (!dt.HasRows()) return false;
            return dt.AsEnumerable().Any(x => x.Field<bool?>(campo).Equals(valor));
        }

        public static decimal Sum(this DataTable dt,string campoSomatorio, string campoCondicao, bool valor = true)
        {
            decimal ret = 0;
            if (dt.HasRows(campoCondicao, valor))
            {
                ret= dt.AsEnumerable().Where(x => x.Field<bool?>(campoCondicao).Equals(valor)).Sum(x => x.Field<decimal?>(campoSomatorio)).ToDecimal();
            }
            return ret;
        }
        public static decimal Sum(this DataTable dt, string campoSomatorio)
        {
            decimal ret = 0;
            if (dt.HasRows())
            {
                ret = dt.AsEnumerable().Sum(x => x.Field<decimal?>(campoSomatorio)).ToDecimal();
            }
            return ret;
        }
        public static bool HasOneRow(this DataTable dt, string campo, bool valor = true)
        {
            if (dt.HasRows(campo,valor))
            {
                return dt.HasRowsCopyToDataTable(campo, valor).Rows.Count == 1;
            }
            return false;
        }
        public static DataTable HasRowsCopyToDataTable(this DataTable dt, string campo, bool valor = true)
        {
            return dt?.AsEnumerable().Where(x => x.Field<bool?>(campo).Equals(valor)).CopyToDataTable();
        }
        // remove "this" if not on C# 3.0 / .NET 3.5
        public static DataTable ListToDataTable<T>(this List<T> data) where T : class
        {
            var props = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            for(var i = 0 ; i < props.Count ; i++)
            {
                var prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            var values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                    //values[i] = item;
                }
                table.Rows.Add(values);
            }
            return table;        
        }

        public static DataTable EntiyToDataTable<T>(this T items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            var item = items;
            var values = new object?[props.Length];
            for (int i = 0; i < props.Length; i++)
            {
                //inserting property values to datatable rows
                values[i] = props[i].GetValue(item, null);
            }
            dataTable.Rows.Add(values);
            return dataTable;
        }

        #region MyRegion

        public static double TotalDays(this DateTime data1, DateTime data2)
        {
            //var dtFromDate = DateTime.ParseExact(data1.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //var dtToDate = DateTime.ParseExact(data2.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //var difference = dtFromDate - dtToDate;
            //return difference.TotalDays;


            var difference = data2 - data1;
            return difference.TotalDays;
        }
        public static double TotallDays(this DateTime data1, DateTime data2)
        {
            //var dtFromDate = DateTime.ParseExact(data1.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //var dtToDate = DateTime.ParseExact(data2.ToShortDateString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var difference = data2 - data1;
            return difference.TotalDays;
        }
        public static double TotalDaysInMonth(this DateTime data1)
        {
            return DateTime.DaysInMonth(data1.Year, data1.Month);
        }


        public static List<DateTime> GetDatesInMonth(this DateTime data1)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(data1.Year, data1.Month))
                             // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(data1.Year, data1.Month, day))
                             // Map each day to a date
                             .ToList(); // Load dates into a list
        }
        public static List<int> GetDaysInMonth(this DateTime data1)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(data1.Year, data1.Month))
                             // Days: 1, 2 ... 31 etc.
                             .Select(day => new DateTime(data1.Year, data1.Month, day).Day)
                             // Map each day to a date
                             .ToList(); // Load dates into a list
        }


        //
        #endregion

       
      
        public static void PrevMonth(this DateTime data1)
        {
            data1= new DateTime(Pbl.SqlDate.Year,Pbl.SqlDate.Month - 1,Pbl.SqlDate.Day);
        }
        public static string RemoveLast(this string text)
        {
            if (text.Length < 1) return text;
            var len = text.Length;
            var xx = text.Substring(len - 1, 1);
            return text.Remove(text.LastIndexOf(xx, StringComparison.Ordinal), xx.Length);
        }
        public static string ToExtenso( this decimal valor, string moeda ="METICAL")
        {
            if (valor <= 0 | valor >= 1000000000000000)
            {
                return "Valor não suportado pelo sistema.";
            }
            else
            {
                var strValor = valor.ToString("000000000000000.00");
                var valor_por_extenso = string.Empty;
                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += escreva_parte(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " TRILHÃO" + (Convert.ToDecimal(strValor.Substring(3, 12)) > 0 ? " E " : String.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " TRILHÕES" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : String.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : String.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : String.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : String.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : String.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : String.Empty);
                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "BILHÃO" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                                valor_por_extenso += " DE";
                            else
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "BILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "TRILHÕES")
                                valor_por_extenso += " DE";
                            else
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "TRILHÕES")
                                valor_por_extenso += " DE";

                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                            valor_por_extenso += $" {moeda}";
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            if (moeda =="METICAL")
                            {
                                valor_por_extenso += " METICAIS"; 
                            }
                            else
                            {
                                valor_por_extenso += $" {moeda.ToUpper().Trim()}";     
                            }
                                    

                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != String.Empty)
                            valor_por_extenso += " E ";
                    }
                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += moeda =="METICAL"?" CENTAVO":" CENT";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += moeda =="METICAL"?" CENTAVOS":" CENTS";
                }
                if (valor_por_extenso.IndexOf("UM MIL") == 0)
                {
                    valor_por_extenso = valor_por_extenso.Replace("UM MIL", "MIL");
                }
                return valor_por_extenso;
            }
        }

        private static string escreva_parte(decimal valor) 
        {
            if (valor <= 0)
            {
                return string.Empty;
            }
            else
            {
                var montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));

                if (a == 1) montagem += b + c == 0 ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += (a > 0 ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += (a > 0 ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : String.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : String.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : String.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : String.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : String.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : String.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : String.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : String.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : String.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : String.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : String.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : String.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : String.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : String.Empty) + "NOVENTA";

                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != String.Empty) montagem += " E ";

                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "UM";
                    else if (c == 2) montagem += "DOIS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";

                return montagem;
            }
        }
        //Converte o numero em extenso em ingles ...
        public static string ToExtensoEng(this decimal amount, string moeda="METICAL")
        {
            var n = (int)amount;

            if (n == 0)
                return "";
            else if (n > 0 && n <= 19)
            {
                var arr = new[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                return arr[n - 1] + " ";
            }
            else if (n >= 20 && n <= 99)
            {
                var arr = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                return arr[n / 10 - 2] + " " + ToExtensoEng(n % 10);
            }
            else if (n >= 100 && n <= 199)
            {
                return "One Hundred " + ToExtensoEng(n % 100);
            }
            else if (n >= 200 && n <= 999)
            {
                return ToExtensoEng(n / 100) + "Hundred " + ToExtensoEng(n % 100);
            }
            else if (n >= 1000 && n <= 1999)
            {
                return "One Thousand " + ToExtensoEng(n % 1000);
            }
            else if (n >= 2000 && n <= 999999)
            {
                return ToExtensoEng(n / 1000) + "Thousand " + ToExtensoEng(n % 1000);
            }
            else if (n >= 1000000 && n <= 1999999)
            {
                return "One Million " + ToExtensoEng(n % 1000000);
            }
            else if (n >= 1000000 && n <= 999999999)
            {
                return ToExtensoEng(n / 1000000) + "Million " + ToExtensoEng(n % 1000000);
            }
            else if (n >= 1000000000 && n <= 1999999999)
            {
                return "One Billion " + ToExtensoEng(n % 1000000000);
            }
            else
            {
                return ToExtensoEng(n / 1000000000) + "Billion " + ToExtensoEng(n % 1000000000);
            }
        }
        //Retorna o Total de uma coluna numa tabela ....
        public static decimal Total(this DataTable dt, string campo)
        {
            var tipo=dt.Columns[$"{campo}"].DataType;
            return tipo.Name =="Int32" ? dt.AsEnumerable().Sum(x => x.Field<Int32?>($"{campo}")).ToString().ToDecimal() : dt.AsEnumerable().Sum(x => x.Field<decimal?>($"{campo}")).ToString().ToDecimal();
        }
        //Seta o status no campo em forms.....
       

        //Set Centro do Custo
      
      

       
    }
}
