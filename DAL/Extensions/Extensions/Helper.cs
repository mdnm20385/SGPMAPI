using System.Data;
using System.Text.RegularExpressions;
using DAL.BL;
using DAL.Classes;
using Model.Models;
using Model.Reports;

namespace DAL.Extensions.Extensions
{
    public static class Helper
    {

        public static void FillContas(DS ds)
        {
            FillDt3(Pbl.ContasEmpresa, "Contas", ds);
        }
        public static void FillDt3(DataTable dt2, string tbName, DataSet Ds)
        {
            if (dt2 != null)
            {
                var dt = Ds?.Tables[$"{tbName}"];
                if (dt.HasRows())
                {
                    dt.Rows.Clear();
                }
                foreach (var row in dt2.AsEnumerable())
                {
                    if (row != null)
                    {
                        var r = dt.NewRow();
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (dt2.Columns.Contains(col.ColumnName))
                            {
                                r[col.ColumnName] = row[col.ColumnName];
                            }
                        }
                        dt.Rows.Add(r);
                    }
                }
            }
            else
            {
                //MsBox.Show("A pesquisa não encontrou nada para os parametros indicados");
                //Cancelado = true;
            }
        }


        public static DataTable FillFormasP(DataTable formasp, DataTable dtformasp)
        {
            if (formasp.HasRows())
            {
                foreach (var r in formasp.AsEnumerable())
                {
                    if (r != null)
                    {
                        var rw = dtformasp.NewRow().Inicialize();
                        foreach (DataColumn col in dtformasp.Columns)
                        {
                            if (formasp.Columns.Contains(col.ColumnName))
                            {
                                rw[col.ColumnName] = r[col.ColumnName];
                            }
                        }
                        dtformasp.Rows.Add(rw);
                    }

                }
            }
            return dtformasp;
        }

        internal static string GetReferencia(string v)
        {
            var xx = "";
            var cumprimento = v.Length;
            switch (cumprimento)
            {
                case 1:
                    xx = $"000{v}";
                    break;
                case 2:
                    xx = $"00{v}";
                    break;
                case 3:
                    xx = $"0{v}";
                    break;
                case 4:
                    xx = $"{v}";
                    break;
            }
            return xx;
        }
        public static object GetField(string campo, string tabela, string condicao = null)
        {
            string qry;
            object ret = null;
            qry = condicao == null ? $"select {campo} from {tabela}" : $"select {campo} from {tabela} where {condicao}";

            var dt = SQL.GetGenDt(qry);
            if (dt?.Rows.Count > 0)
            {
                ret = dt.Rows[0][0];
            }

            return ret;
        }
        internal static (bool ret, string ms) CheckStstamp(DataTable gridUIFt1)
        {
            var linhas = gridUIFt1;
            (bool ret, string ms) retorno = (true, "");
            if (linhas?.Rows.Count > 0)
            {
                foreach (var row in linhas.AsEnumerable())
                {
                    if (row == null) continue;
                    if (row.RowState == DataRowState.Deleted) continue;
                    if (row["servico"].ToBool()) continue;
                    if (row["Entidadestamp"].ToString().IsNullOrEmpty())
                    {
                        break;
                        retorno.Item1 = false;
                        retorno.Item2 = $"O artigo {row["descricao"]} não possui o ststamp na linha, O software não irá movimentar o stock";

                    }
                }
            }
            return retorno;
        }

       
        internal static string GetValueByMascara(string? sigla, string mascara, DataTable dt)
        {
            var refec = "";
            var numero = dt.Rows[0][0].ToDecimal();
            switch (numero.ToString().Length)
            {
                case 1:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 1) + numero;
                    break;

                case 2:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 2) + numero;
                    break;
                case 3:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 3) + numero;
                    break;
                case 4:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 4) + numero;
                    break;
                case 5:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 5) + numero;
                    break;
                case 6:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 6) + numero;
                    break;
                case 7:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 7) + numero;
                    break;
                case 8:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 8) + numero;
                    break;
                case 9:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 9) + numero;
                    break;
                case 10:
                    refec = sigla.Trim() + mascara.Substring(0, mascara.Length - 10) + numero;
                    break;
            }

            return refec;
        }
        private static void NewMethod(DataRow r, DataRow r2, decimal cambiousd)
        {
            r2["valordoc"] = r["valordoc"].ToDecimal() * cambiousd;
            r2["valorpreg"] = r["valorpreg"].ToDecimal() * cambiousd;
            r2["valorreg"] = r["valorreg"].ToDecimal() * cambiousd;
            r2["valorPend"] = (r["valorpreg"].ToDecimal() - r["valorreg"].ToDecimal()).ToDecimal() * cambiousd;
        }
        public static void FillRcl(DataTable rcll, DataRow r, string rclstamp, string tabela)
        {
            var r2 = rcll.NewRow();
            var cambiousd = r["Cambiousd"].ToDecimal();
            if (r["moeda"].ToString().Equals(Pbl.MoedaBase.Trim()))
            {
                NewMethod(r, r2, 1);
            }
            else
            {
                try
                {
                    r2["mvalorpreg"] = r["mvalorpreg"];
                    r2["mvalorreg"] = r["mvalorreg"];
                    r2["mvalorPend"] = r["mvalorpreg"].ToDecimal() - r["mvalorreg"].ToDecimal();
                    r2["mvalordoc"] = r["mvalordoc"];
                    NewMethod(r, r2, 1);
                }
                catch (Exception)
                {
                    NewMethod(r, r2, cambiousd);
                    r2["mvalorpreg"] = r["valorpreg"];
                    r2["mvalorreg"] = r["valorreg"];
                    r2["mvalorPend"] = r["valorpreg"].ToDecimal() - r["valorreg"].ToDecimal();
                    r2["mvalordoc"] = r["valordoc"];
                }
            }
            r2["descricao"] = r["descricao"];
            r2["data"] = r["data"];
            if (tabela.ToLower().Equals("rcl"))
            {
                r2["Ccstamp"] = r["Ccstamp"];
            }
            else
            {
                r2["fccstamp"] = r["fccstamp"];
            }
            r2[$"{tabela.Trim()}lstamp"] = Pbl.Stamp();
            r2[$"{tabela.Trim()}stamp"] = rclstamp;
            r2["Rcladiant"] = r["Rcladiant"];
            r2["nrdoc"] = r["nrdoc"];
            rcll.Rows.Add(r2);
        }

        public static DataRow Inicialize(this DataRow dr)
        {
            var ctabela = dr.Table.TableName.ToLower();
            var lista = SQL.GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{ctabela.Trim()}' and IS_NULLABLE='YES' ", " column_name ");
            foreach (DataColumn col in dr.Table.Columns)
            {
                if (col.DataType == typeof(DateTime))
                {
                    dr[col.ColumnName.Trim()] = Pbl.SqlDate;
                }
                if (col.DataType == typeof(string))
                {
                    var r = lista?.AsEnumerable().FirstOrDefault(x => x.Field<string>("column_name").Equals(col.ColumnName.Trim()));
                    if (r != null)
                    {
                        dr[col.ColumnName.Trim()] = null;
                    }
                    else
                    {
                        dr[col.ColumnName.Trim()] = "";
                    }
                }
                if (col.DataType == typeof(decimal))
                {
                    dr[col.ColumnName.Trim()] = 0;
                }
                if (col.DataType == typeof(int))
                {
                    dr[col.ColumnName.Trim()] = 0;
                }
                if (col.DataType == typeof(bool))
                {
                    dr[col.ColumnName.Trim()] = false;
                }
                if (col.DataType == typeof(byte[]))
                {
                    dr[col.ColumnName.Trim()] = 0;
                }
                if (col.ColumnName.Trim().ToLower().Contains("stamp") && col.ColumnName.Trim().ToLower().Contains(ctabela.ToLower().Trim()))
                {
                    dr[col.ColumnName.Trim()] = Pbl.Stamp();
                }
            }
            return dr;
        }
        internal static string GetArmazemQry(string desc)
        {
            //where Ccustamp ='{Pbl.Usr.Ccustamp}'
            return $"select Codarm,Descricao,Armazemstamp from Ccu_Arm where Descricao like '%{desc.Trim()}%'";
        }
        public static string GetTypeName(string fullTypeName)
        {
            string retString = "";

            try
            {
                int lastIndex = fullTypeName.LastIndexOf('.') + 1;
                retString = fullTypeName.Substring(lastIndex, fullTypeName.Length - lastIndex);
            }
            catch 
            {
                retString = fullTypeName;
            }

            retString = retString.Replace("]","");

            return retString;        
        }
        public static List<Dmz> FillDtDMZ(DataTable dt2)
        {
            List<Dmz> Ds = new List<Dmz>();
            if (dt2 != null)
            {
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    if (dt2.Rows[i] == null) continue;
                    var r = SQL.DoAddline<Dmz>();
                    for (var j = 0; j < dt2.Columns.Count; j++)
                    {
                        var tipo = dt2.Columns[j].DataType;
                        
                        var nome = dt2.Columns[j].ColumnName.Trim();
                        var properties = r.GetType().GetProperties();
                        
                        foreach (var p in properties)
                        {   
                            
                            var indi=  Regex.Match(p.Name, @"\d+").Value.ToInt();
                            if (p.Name.ToLower().Equals("descricao".ToLower()))
                            {
                                if (p.Name.ToLower().Equals(nome.ToLower()))
                                {
                                    r.Descricao = dt2.Rows[i][j].ToString();
                                }
                            }
                            if (p.Name.ToLower().Equals("rltstamp".ToLower()))
                            {
                                if (p.Name.ToLower().Equals(nome.ToLower()))
                                {
                                    r.Rltstamp = dt2.Rows[i][j].ToString();
                                }
                            }
                            if (p.Name.ToLower().Equals("ClnTab".ToLower()))
                            {
                                if (p.Name.ToLower().Equals(nome.ToLower()))
                                {
                                    r.Clntab = dt2.Rows[i][j].ToString();
                                }
                            }
                            if (indi==j)
                            {
                                switch (j)
                                {
                                    case 0:
                                        r.Col0 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 1:
                                        r.Col1 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 2:
                                        r.Col2 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 3:
                                        r.Col3 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 4:
                                        r.Col4 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 5:
                                        r.Col5 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 6:
                                        r.Col6 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 7:
                                        r.Col7 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 8:
                                        r.Col8 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 9:
                                        r.Col9 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 10:
                                        r.Col10 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 11:
                                        r.Col11 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 12:
                                        r.Col12= dt2.Rows[i][j].ToString();
                                        break;
                                    case 13:
                                        r.Col13 = dt2.Rows[i][j].ToString();
                                        break;

                                    case 14:
                                        r.Col14 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 15:
                                        r.Col16 = dt2.Rows[i][j].ToString();
                                        break;

                                    case 16:
                                        r.Col16 = dt2.Rows[i][j].ToString();
                                        break;

                                    case 17:
                                        r.Col17 = dt2.Rows[i][j].ToString();
                                        break;

                                    case 18:
                                        r.Col18 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 19:
                                        r.Col19 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 20:
                                        r.Col20 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 21:
                                        r.Col21 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 22:
                                        r.Col22 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 23:
                                        r.Col23 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 24:
                                        r.Col24 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 25:
                                        r.Col25 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 26:
                                        r.Col26 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 27:
                                        r.Col27 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 28:
                                        r.Col28 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 29:
                                        r.Col28 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 30:
                                        r.Col30 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 31:
                                        r.Col31 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 32:
                                        r.Col32 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 33:
                                        r.Col33 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 34:
                                        r.Col34 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 35:
                                        r.Col35 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 36:
                                        r.Col36 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 37:
                                        r.Col37 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 38:
                                        r.Col38 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 39:
                                        r.Col39 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 40:
                                        r.Col40 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 41:
                                        r.Col41 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 42:
                                        r.Col42 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 43:
                                        r.Col43 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 44:
                                        r.Col44 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 45:
                                        r.Col45 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 46:
                                        r.Col46 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 47:
                                        r.Col47 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 48:
                                        r.Col48 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 49:
                                        r.Col49 = dt2.Rows[i][j].ToString();
                                        break;
                                    case 50:
                                        r.Col50 = dt2.Rows[i][j].ToString();
                                        break;
                                }
                            }

                        }
                        
                    }
                    Ds.Add(r);
                }
            }
            return Ds;
        }


        public static void FillDtEmpresa(DataTable dt2, string tbName, DataSet Ds)
        {
            if (dt2 != null)
            {

                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    if (dt2.Rows[i] == null) continue;
                    var r = Ds.Tables[$"{tbName}"].NewRow();
                    //r = dt2.Rows[i];
                    for (var j = 0; j < dt2.Columns.Count; j++)
                    {
                        var tipo = dt2.Columns[j].DataType;
                        var nome = dt2.Columns[j].ColumnName.Trim();
                        //if (tipo == typeof(DateTime) && string.IsNullOrEmpty(dt2.Rows[i][j].ToString()))
                        //{

                        //    r[j] = ((DateTime)dt2.Rows[i][j]).ToShortDateString();
                        //}
                        //else if (tipo == typeof(decimal))
                        //{
                        //    r[j] = dt2.Rows[i][j].ToString().ToDecimal();
                        //}
                        r[nome] = dt2.Rows[i][nome];
                    }
                    Ds.Tables[$"{tbName}"].Rows.Add(r);
                }
            }
            else
            {
            }
        }

        public static void FillDt2(DataTable dt2, string tbName, DataSet? Ds)
        {
            if (dt2 != null)
            {
                int colReais;
                if (Ds.Tables[$"{tbName}"].Columns.Count > dt2.Columns.Count)
                {
                    colReais = Ds.Tables[$"{tbName}"].Columns.Count - (Ds.Tables[$"{tbName}"].Columns.Count - dt2.Columns.Count);
                }
                else
                {
                    colReais = Ds.Tables[$"{tbName}"].Columns.Count;
                }
                for (var j = 0; j < colReais; j++)
                {
                    Ds.Tables[$"{tbName}"].Columns[j].DataType = dt2.Columns[j].DataType;
                }
                for (var i = 0; i < dt2.Rows.Count; i++)
                {
                    if (dt2.Rows[i] == null) continue;
                    var r = Ds.Tables[$"{tbName}"].NewRow();
                    for (var j = 0; j < colReais; j++)
                    {
                        var tipo = dt2.Rows[i][j].GetType();
                        if (tipo == typeof(DateTime))
                        {
                            r[j] = ((DateTime)dt2.Rows[i][j]).ToShortDateString();
                        }
                        else if (tipo == typeof(Decimal))
                        {
                            r[j] = (dt2.Rows[i][j]).ToString().ToDecimal();
                        }
                        else if (tipo == typeof(DBNull))
                        {
                            r[j] = (dt2.Rows[i][j]).ToString().ToDecimal();
                        }
                        else
                        {
                            r[j] = dt2.Rows[i][j].ToString();
                        }

                    }
                    Ds.Tables[$"{tbName}"].Rows.Add(r);
                }

                var dtj = Ds;
            }
            else
            {
            }
        }
    }
}
