using System.Data;
using DAL.BL;
using DAL.Extensions.Extensions;

namespace DAL.Classes
{
    public static class Imprimir
    {
        public static void FillDt3(DataTable dt2, string tbName, DataSet Ds)
        {
            if (dt2 != null)
            {
                var dt = Ds?.Tables[$"{tbName}"];
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

        #region MyRegion
        //public static (DataTable dtPrint, DataTable fp) FillData(DataTable dtPai, DataTable dtFilha, DataTable formasp, 
        //    DataTable dtPrincipal, DataTable dtformasp)
        //{
        //    (DataTable dtPrint, DataTable fp) ret = (null, null);
        //    if (dtFilha.HasRows())
        //    {
        //        dtPrincipal.PrimaryKey = null;
        //        int colReais = 0;
        //        if (dtPrincipal.TableName == "DMZ")
        //        {
        //            if (dtPrincipal.Columns.Count > dtFilha.Columns.Count)
        //            {
        //                colReais = dtPrincipal.Columns.Count - (dtPrincipal.Columns.Count - dtFilha.Columns.Count);
        //            }
        //            else
        //            {
        //                colReais = dtPrincipal.Columns.Count;
        //            }
        //            for (var j = 0; j < colReais; j++)
        //            {
        //                dtPrincipal.Columns[j].DataType = dtFilha.Columns[j].DataType;
        //            }
        //        }
        //        for (var i = 0; i < dtFilha.Rows.Count; i++)
        //        {
        //            if (dtFilha.Rows[i] != null)
        //            {
        //                if (dtFilha.Rows[i].RowState != DataRowState.Deleted)
        //                {
        //                    var rw = dtPrincipal.NewRow().Inicialize();
        //                    if (dtPrincipal.TableName == "DMZ")
        //                    {
        //                        for (var j = 0; j < colReais; j++)
        //                        {
        //                            var tipo = dtFilha.Rows[i][j].GetType();
        //                            if (tipo == typeof(DateTime))
        //                            {
        //                                rw[j] = ((DateTime)dtFilha.Rows[i][j]).ToShortDateString();
        //                            }
        //                            else if (tipo == typeof(decimal))
        //                            {
        //                                rw[j] = dtFilha.Rows[i][j].ToDecimal();
        //                            }
        //                            else if (tipo == typeof(DBNull))
        //                            {
        //                                rw[j] = dtFilha.Rows[i][j];
        //                            }
        //                            else
        //                            {
        //                                rw[j] = dtFilha.Rows[i][j].ToString();
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        foreach (DataColumn col in dtPrincipal.Columns)
        //                        {
        //                            if (dtFilha.Columns.Contains(col.ColumnName))
        //                            {
        //                                rw[col.ColumnName] = dtFilha.Rows[i][col.ColumnName];
        //                            }
        //                            if (dtPai.HasRows())
        //                            {
        //                                if (dtPai.Columns.Contains(col.ColumnName))
        //                                {
        //                                    if (dtPai.TableName.ToLower() == "di")
        //                                    {
        //                                        if (col.ColumnName.ToLower() == "nuit")
        //                                        {
        //                                            rw[col.ColumnName] = dtPai.Rows[0][col.ColumnName].ToDecimal();
        //                                        }
        //                                        else
        //                                        {
        //                                            rw[col.ColumnName] = dtPai.Rows[0][col.ColumnName];
        //                                        }

        //                                    }
        //                                    else
        //                                    {
        //                                        rw[col.ColumnName] = dtPai.Rows[0][col.ColumnName];
        //                                    }

        //                                }
        //                            }
        //                        }
        //                    }
        //                    dtPrincipal.Rows.Add(rw);
        //                }
        //            }
        //        }
        //    }
        //    ret.fp = Helper.FillFormasP(formasp, dtformasp);
        //    ret.fp = dtformasp;
        //    ret.dtPrint = dtPrincipal;
        //    ret.dtPrint.TableName = dtPrincipal.TableName;
        //    return ret;
        //}

        #endregion
        public static (DataTable dtPrint, DataTable fp) FillData(DataTable dtPai,
            DataTable dtFilha, DataTable formasp, DataTable dtPrincipal, DataTable dtformasp)
        {
            (DataTable dtPrint, DataTable fp) ret = (null, null);
            if (dtFilha.HasRows())
            {
                dtPrincipal.PrimaryKey = null;
                if (dtPrincipal.HasRows())
                {
                    dtPrincipal.Rows.Clear();
                }
                int colReais = 0;
                if (dtPrincipal.TableName == "DMZ")
                {
                    if (dtPrincipal.Columns.Count > dtFilha.Columns.Count)
                    {
                        colReais = dtPrincipal.Columns.Count - (dtPrincipal.Columns.Count - dtFilha.Columns.Count);
                    }
                    else
                    {
                        colReais = dtPrincipal.Columns.Count;
                    }
                    for (var j = 0; j < colReais; j++)
                    {
                        dtPrincipal.Columns[j].DataType = dtFilha.Columns[j].DataType;
                    }
                }
                for (var i = 0; i < dtFilha.Rows.Count; i++)
                {
                    if (dtFilha.Rows[i] != null)
                    {
                        if (dtFilha.Rows[i].RowState != DataRowState.Deleted)
                        {
                            var rw = dtPrincipal.NewRow().Inicialize();
                            if (dtPrincipal.TableName == "DMZ" || dtPrincipal.TableName == "DMZ1")
                            {
                                for (var j = 0; j < colReais; j++)
                                {
                                    var tipo = dtFilha.Rows[i][j].GetType();
                                    if (tipo == typeof(DateTime))
                                    {
                                        rw[j] = ((DateTime)dtFilha.Rows[i][j]).ToShortDateString();
                                    }
                                    else if (tipo == typeof(decimal))
                                    {
                                        rw[j] = dtFilha.Rows[i][j].ToDecimal();
                                    }
                                    else if (tipo == typeof(DBNull))
                                    {
                                        rw[j] = dtFilha.Rows[i][j];
                                    }
                                    else
                                    {
                                        rw[j] = dtFilha.Rows[i][j].ToString();
                                    }
                                }
                            }
                            else
                            {
                                foreach (DataColumn col in dtPrincipal.Columns)
                                {
                                    if (dtFilha.Columns.Contains(col.ColumnName))
                                    {
                                        rw[col.ColumnName] = dtFilha.Rows[i][col.ColumnName];
                                    }
                                    if (dtPai.HasRows())
                                    {
                                        if (dtPai.Columns.Contains(col.ColumnName))
                                        {
                                            if (dtPai.TableName.ToLower() == "di")
                                            {
                                                if (col.ColumnName.ToLower() == "nuit")
                                                {
                                                    rw[col.ColumnName] = dtPai.Rows[0][col.ColumnName].ToDecimal();
                                                }
                                                else
                                                {
                                                    rw[col.ColumnName] = dtPai.Rows[0][col.ColumnName];
                                                }

                                            }
                                            else
                                            {
                                                rw[col.ColumnName] = dtPai.Rows[0][col.ColumnName];
                                            }

                                        }
                                    }
                                }
                            }
                            dtPrincipal.Rows.Add(rw);
                        }
                    }
                }
            }
            ret.fp = Helper.FillFormasP(formasp, dtformasp);
            ret.fp = dtformasp;
            ret.dtPrint = dtPrincipal;
            ret.dtPrint.TableName = dtPrincipal.TableName;
            return ret;
        }




        public static void DoPrint(string cLocalStamp, bool inserindo, string text, string no, string nomfile,
            string origem,  Linguas lingua)
        {
            if (!string.IsNullOrEmpty(cLocalStamp))
            {
                if (!inserindo)
                {
                    //var f = new FrmReport
                    //{
                    //    label1 = { Text = $@"Imprimir {text}" },
                    //    Printstamp = cLocalStamp,
                    //    Origem = origem,
                    //    No = no
                    //};
                    //f.LinguaNacional = lingua.ToString();
                    //f.ReportName = nomfile;
                    //f.ShowForm(mdiForm);
                }
                else
                {
                    Messagem.DoDontPrintMessagem();
                }
            }
            else
            {
                Messagem.DoNothingPrintMensagem();
            }
        }
    }
}
