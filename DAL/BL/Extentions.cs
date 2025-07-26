using System.Data;
using System.Globalization;
using System.Text;
using DAL.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DAL.BL
{
    public static class Extensions
    {
        public static DataTable FromEntityToDataTable<T>(this T entity) where T : class
        {
            var properties = typeof(T).GetProperties();
            var table = new DataTable { TableName = entity.GetType().Name };

            foreach (var property in properties)
            {
                var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                table.Columns.Add(property.Name, type);
            }
            table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
            return table;
        }
        public static string GetUntilOrEmpty(this string text, char stopAt = ',')
        {
            int charLocation = text.IndexOf(stopAt);
            if (charLocation >= 0)
            {
                return text.Substring(charLocation, text.Length- charLocation);
            }
            return string.Empty;
        }
        public static string RemoverAcentuacao(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
        public static List<SelectListItem> GetComboItens(this DataTable dt, string xxx,string tabela="",string? selected="")
        {
            var lista = new List<SelectListItem>();
            foreach (var dr in dt.AsEnumerable())
            {
                var item = new SelectListItem
                {
                    Value = dr[0].ToString(),
                    Text = dr[1].ToString(),
                };
                if (selected.IsNullOrEmpty())
                {
                    if (tabela.Equals("moedas"))
                    {

                        if (dr[1].ToString().Trim().ToLower().Contains("Meticais".ToLower().Trim()))
                        {
                            item.Selected = true;
                        }
                    }
                    else if (tabela.ToLower().Trim().Equals("tpgf"))
                    {
                        if (dr[1].ToString().ToLower().Equals("Pagamento a Fornecedores".ToLower()))
                        {
                            item.Selected = true;
                        }
                    }
                    else
                    {
                        if (dr[1].ToString().ToLower().Equals("Factura".ToLower())
                           )
                        {
                            item.Selected = true;
                        }
                    }
                }
                else
                {
                    if (dr[1].ToString().ToLower().Equals(selected.ToLower())
                       )
                    {
                        item.Selected = true;
                    }
                }
                lista.Add(item);
            }
            if (!xxx.IsNullOrEmpty()&& !tabela.IsNullOrEmpty())
            {
                if (xxx.ToLower().Contains("nao")|| xxx.ToLower().Contains("não"))
                {
                    bool selec = selected.IsNullOrEmpty();
                    var selitem = new SelectListItem
                    {
                        Value = "",
                        Text = "",
                        Selected = selec
                    };
                    lista.Insert(0, selitem);
                }
                else
                {
                    bool selec = selected.IsNullOrEmpty();
                    var selitem = new SelectListItem
                    {
                        Value = "",
                        Text = xxx,
                        Selected = selec
                    };
                    lista.Insert(0, selitem);
                }
            }
            return lista;
        }
        public static decimal ToRound(this decimal valor)
        {
            return true ? ToTruncate(valor) : Math.Round(valor,2);
        }
        public static decimal ToTruncate(this decimal valor)
        {
            return valor.ToString("0.00").ToDecimal();
        }
        public static int ToInt(this decimal valor)
        {
            return valor > 0 ? valor.ToString(CultureInfo.InvariantCulture).ToInt32() : 0;
        }
        public static decimal ToRound(this decimal valor, int casas)
        {
            return Math.Round(valor, casas);
        }
        public static int ToInt(this string str) => CToI(str);
        public static decimal ToDecimal(this string? str) => CToD(str);//ToMask()
        public static string ToMask(this decimal str) => str.ToString("N2");
        public static decimal ToDecimal(this object? str) => CToD(str);
        public static int ToInt(this object str) => CToI(str.ToString());
        
        public static long ToLong(this object str) => CTLong(str.ToString());
        public static DateTime ToDateTimeValue(this object str)
        {
            DateTime saida;
            try
            {
                saida = Convert.ToDateTime(str);
            }
            catch (Exception)
            {
                saida = new DateTime(1900, 1, 1);
            }
            return saida;
        }
        public static int ToInt32(this string txt)
        {
            var saida = 0;
            try
            {
                if (!string.IsNullOrEmpty(txt))
                {
                    // Try integer parse first
                    if (!int.TryParse(txt, out saida))
                    {
                        // Try decimal parse and convert to int (truncates)
                        if (decimal.TryParse(txt, out var dec))
                        {
                            saida = (int)dec;
                        }
                    }
                }
            }
            catch (Exception)
            {
                //
            }
            return saida;
        }
        public static int ToInt(this bool valor) => valor ? 1 : 0;

        public static bool ToBool(this object? str)
        {
            bool saida=false;
            try
            {
                if (str == null)
                {
                    saida = false;
                }
                else
                {
                    bool.TryParse(str.ToString(), out saida);
                }
            }
            catch (Exception)
            {
                //
            }

            return saida;
        }

        public static string SetMask(this string? txt)
        {
            var valor = CToD(txt);
            var formatedString = $"{valor:#,###,###,###,###,0.00}";
            if (formatedString == "0.00")
            {
                formatedString = "";
            }
            return formatedString;
        }
        public static decimal CToD(object? obj)
        {
            decimal saida=0;
            try
            {
                if (obj != null)
                {
                    decimal.TryParse(obj.ToString(), out saida);
                }
                else
                {
                    saida = 0;
                }
            }
            catch (Exception)
            {
                //
            }
            return saida;
        }

        public static int CToI(string txt)
        {
            int saida = 0;
            try
            {
                if (!string.IsNullOrEmpty(txt))
                {
                    int.TryParse(txt, out saida);
                }
            }
            catch (Exception)
            {
                //
            }
            return saida;
        }



        public static long CTLong(string txt)
        {
            long saida = 0;
            try
            {
                if (!string.IsNullOrEmpty(txt))
                {
                    long.TryParse(txt, out saida);
                }
            }
            catch (Exception)
            {
                //
            }
            return saida;
        }
        public static bool ToBool(this string txt)
        {
            var saida = false;
            try
            {
                if (!string.IsNullOrEmpty(txt))
                {
                    bool.TryParse(txt, out saida);
                }
            }
            catch (Exception)
            {
                //
            }
            return saida;
        }

        public static double ToDouble(this string txt)
        {
            double saida = 0;
            try
            {
                if (!string.IsNullOrEmpty(txt))
                {
                    double.TryParse(txt, out saida);
                }
            }
            catch (Exception)
            {
                //
            }
            return saida;
        }
    }
}
