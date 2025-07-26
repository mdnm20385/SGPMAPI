using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DAL.Conexao;
using Microsoft.Data.SqlClient;

namespace DAL.BL
{
    public static class Geral
    {
        private static string Sql { get; set; }
        private static GCon _gc;
        private static SqlCommand _cmd;
        public static string Login { get; set; }
        #region Limpa os Campos nulls de uma Tabela ......
        public static int VerificaProv()
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand("select isnull(count(codProv),0) codProv from Provincia ", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }
        public static int VerificaProvLeave(string stampprov)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count(codProv),0) codProv from Provincia where paisStamp= '{stampprov}'", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }
        public static int VerificaPPaisLeave()
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count(codPais),0) codPais from Pais ", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }
        public static DataTable GetGenDT(string v)
        {
            try
            {

                using (_gc = new GCon())
                {
                    var sqlComando = new SqlCommand(v, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);

                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

            }
        }


        public static DataTable SetDefaultDateTime(DataTable dt)
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
                        }
                        catch
                        {
                            r[i] = (DateTime)SqlDateTime.MinValue;
                        }
                    }
                    if (dt.Columns[i].DataType == typeof(string))
                    {
                        var valor = r[i];
                        if (string.IsNullOrWhiteSpace(valor.ToString()))
                        {
                            r[i] = "";
                        }
                    }

                    if (dt.Columns[i].DataType == typeof(bool))
                    {
                        var valor = r[i];
                        if (string.IsNullOrWhiteSpace(valor.ToString()))
                        {
                            r[i] = false;
                        }
                    }
                    if (dt.Columns[i].DataType == typeof(decimal))
                    {
                        var valor = r[i];
                        if (string.IsNullOrWhiteSpace(valor.ToString()))
                        {
                            r[i] = 0;
                        }
                    }
                }
            }
            return dt;
        }

        #endregion

        public static void GravaTabela(DataTable dt, string tableName)
        {
            using (_gc = new GCon())
            {
                using (var adapter = new SqlDataAdapter($" SELECT * FROM {tableName} where 1=0 ", _gc.NResult))

                using (new SqlCommandBuilder(adapter))
                {
                    SetDefaultDateTime(dt);
                    adapter.Fill(dt);
                    adapter.Update(dt);
                }
            }
        }
        public static int ActualizarPWord(string login, string pw1, string pw2)
        {
            try
            {
                using (_gc = new GCon())
                {
                    Sql = $"update usuario set password = '{pw2}', selPriEntrada=1 where login= '{login}'";
                    _cmd = new SqlCommand(Sql, _gc.NResult);
                    var i = _cmd.ExecuteNonQuery();
                    return i;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void InsertOrUpdate(string query)
        {
            using (_gc = new GCon())
            {
                _cmd = new SqlCommand(query, _gc.NResult);
                _cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetGenDt(string tabela, string orderbyOrWhere, string select)
        {
            try
            {
                using (_gc = new GCon())
                {
                    var query = $"SELECT {select} FROM {tabela}  {orderbyOrWhere}";
                    var sqlComando = new SqlCommand(query, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {

                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
                //throw new Exception(ex.Message);
            }
        }
        public static DataTable GetGen2Dt(string querry)
        {
            try
            {
                using (_gc = new GCon())
                {
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;
            }
        }

        internal static DataTable GetReturnTable(SqlCommand cmd)
        {
            var sqlDataAdapter = new SqlDataAdapter(cmd);
            var dtable = new DataTable();
            sqlDataAdapter.Fill(dtable);
            return dtable;
        }
        public static int Delete(string tabela, string campochave, string localchave)
        {
            using (_gc = new GCon())
            {
                var qry = $"delete from {tabela} where {campochave.Trim()} = '{localchave.Trim()}'";
                var sqlComando = new SqlCommand(qry, _gc.NResult);
                return sqlComando.ExecuteNonQuery();
            }
        }


        public static T AllTrim<T>(T ef) where T : class, new()
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in properties)
            {
                if (p.PropertyType != typeof(string)) continue;
                var valor = p.GetValue(ef, null);
                if (valor == null) continue;
                p.SetValue(ef, valor.ToString().Trim());
            }
            return ef;
        }



        #region Convert DataRow para object e objecto to DataRow qualquer .....
        public static T ConvertDataRowToEntity<T>(DataRow dataRow, T entity)
        {
            //--- o type é necessário para obter as propriedades do objecto
            var t = entity.GetType();

            //--- obtem as propriedades o objecto
            var propertiesList = t.GetProperties();

            foreach (var properties in propertiesList)
            {
                try
                {
                    //--- coloca o valor da datarow na propriedade correcta do objecto
                    t.InvokeMember(properties.Name, BindingFlags.SetProperty, null,
                                    entity,
                                    new[] { dataRow[properties.Name] });
                }
                catch (Exception)
                {
                    //--- Se deu erro é porque a propriedade não existe na datarow ou porque o valor é nulo
                }
            }
            return entity;
        }

        #endregion




        #region Convert Entity para DataTable.....
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));
            var table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        #endregion

        #region Convert DataTable to List of Entity..... 
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                var list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            var propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.ToString());
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Retorna o Maximo de uma tabela ......

        public static decimal VMax(string tabela, decimal numdoc, decimal ano)
        {
            try
            {
                var qry = numdoc != 0 ?
                    $"select ISNULL(max(numero),0) +1 as numero from {tabela} where numdoc={numdoc} and year(data)={ano}"
                    : $"select ISNULL(max(numero),0) +1 as numero from {tabela} where year(data)={ano}";
                var adp = new SqlDataAdapter(new SqlCommand(qry, _gc.NResult));
                var dtable = new DataTable();
                adp.Fill(dtable);
                return (decimal)dtable.Rows[0][0];
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        #endregion


        public static DateTime SqlDate2 { get; set; }
        #region Limpa os Nulls nas entidades antes de Gravar......
        public static T SetDefaultValue<T>(T ef)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in properties)
            {
                if (p.PropertyType == typeof(string))
                {
                    p.SetValue(ef, "");
                }
                if (p.PropertyType == typeof(DateTime))
                {
                    p.SetValue(ef, DateTime.Now);
                }

            }
            return ef;
        }

        #endregion

        public static void Controlo(string stamp, string login, DateTime sqlDate, string form, string obsev, string usuarchav)
        {

        }
        public static int VerificaLocalidadeLeave(string postAdminChave)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count(codLocalidade),0) codLocalidade from Localidade  where postAdmStamp= '{postAdminChave}'", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }
        public static int VerificaPostoAdminLeave(string DistritoChave)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count(codPostoAdm),0) codPostoAdm from PostAdm  where distritoStamp= '{DistritoChave}'", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }
        public static string SelectTop1(string tabela)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select top 1 (descricao) from {tabela}", _gc.NResult);
                return (sqlComando.ExecuteScalar().ToString());
            }
        }
        public static int VerificaCodPostoAdmin()
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand("select isnull(count(codPostoAdm),0) codPostoAdm from PostAdm ", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }

        public static int VerificaCodLocalid()
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand("select isnull(count(codLocalidade),0) codLocalidade from Localidade ", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }

        public static int VerificaCodDistrito()
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand("select isnull(count(codDistrito),0) codDistrito from Distrito ", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }

        public static int VerificaDistritoLeave(string ProvinciaChave)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count(codDistrito),0) codDistrito from Distrito  where provinciaStamp= '{ProvinciaChave}'", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }
        public static int VerificaNomePais(string nomePais)
        {
            int r = 0;//0= nao existe
            using (_gc = new GCon())
            {
                try
                {
                    var sqlComando = new SqlCommand($"select * from Pais where descricao= '{nomePais.Trim()}'", _gc.NResult);
                    SqlDataReader registro = sqlComando.ExecuteReader();
                    if (registro.HasRows)
                    {
                        registro.Read();
                        r = Convert.ToInt32(registro["codPais"]);
                    }
                }
                catch
                {


                }
                return r;
            }
        }
        public static int VerificaCurso(string nome, string tabela, string camporetorno, string numero)
        {
            int r = 0;//0= nao existe
            using (_gc = new GCon())
            {
                try
                {
                    var qry = $"select* from {tabela} where descricao = '{nome.Trim()}' and {camporetorno}='{numero}'";
                    var sqlComando = new SqlCommand(qry, _gc.NResult);
                    SqlDataReader registro = sqlComando.ExecuteReader();
                    if (registro.HasRows)
                    {
                        registro.Read();
                        r = Convert.ToInt32(registro[camporetorno]);
                    }
                }
                catch
                {
                    // ignored
                }
                return r;
            }
        }

        public static int VerificaBusca(string nomeBusca)
        {
            int r = 0;//0= nao existe
            using (_gc = new GCon())
            {
                try
                {
                    var sqlComando = new SqlCommand($"select * from Busca where descricao= '{nomeBusca.Trim()}'", _gc.NResult);
                    SqlDataReader registro = sqlComando.ExecuteReader();
                    if (registro.HasRows)
                    {
                        registro.Read();
                        r = Convert.ToInt32(registro["NumTabela"]);
                    }
                }
                catch
                {
                    // ignored
                }
                return r;
            }
        }
        public static int VerificaNomeProvincia(string nomeProvincia, string stampPais)
        {
            int r = 0;//0= nao existe
            using (_gc = new GCon())
            {
                try
                {
                    var sqlComando = new SqlCommand($"select * from Provincia where descricao= '{nomeProvincia.Trim()}' and paisStamp= '{stampPais.Trim()}' ", _gc.NResult);
                    SqlDataReader registro = sqlComando.ExecuteReader();
                    if (registro.HasRows)
                    {
                        registro.Read();
                        r = Convert.ToInt32(registro["codProv"]);

                    }
                }
                catch
                {


                }
                return r;
            }
        }


        public static int VerificaNomeDistrito(string nomeDistrito, string stampProv)
        {
            int r = 0;//0= nao existe
            using (_gc = new GCon())
            {
                try
                {
                    var sqlComando = new SqlCommand($"select * from Distrito where descricao= '{nomeDistrito.Trim()}' and provinciaStamp= '{stampProv.Trim()}'", _gc.NResult);
                    SqlDataReader registro = sqlComando.ExecuteReader();
                    if (registro.HasRows)
                    {
                        registro.Read();
                        r = Convert.ToInt32(registro["codDistrito"]);

                    }
                }
                catch
                {


                }
                return r;
            }
        }
        public static int VerificaNomePostAdmin(string nomePostoAdm, string stampDistr)
        {
            int r = 0;//0= nao existe
            using (_gc = new GCon())
            {
                try
                {
                    var sqlComando = new SqlCommand($"select * from PostAdm where descricao= '{nomePostoAdm.Trim()}' and distritoStamp= '{stampDistr.Trim()}'", _gc.NResult);
                    SqlDataReader registro = sqlComando.ExecuteReader();
                    if (registro.HasRows)
                    {
                        registro.Read();
                        r = Convert.ToInt32(registro["codPostoAdm"]);

                    }
                }
                catch
                {


                }
                return r;
            }
        }
        public static int VerificaNomeLocalidade(string nomeLocalidad, string stampPostAmd)
        {
            int r = 0;//0= nao existe
            using (_gc = new GCon())
            {
                try
                {
                    var sqlComando = new SqlCommand($"select * from Localidade where descricao= '{nomeLocalidad.Trim()}' and postAdmStamp= '{stampPostAmd.Trim()}'", _gc.NResult);
                    SqlDataReader registro = sqlComando.ExecuteReader();
                    if (registro.HasRows)
                    {
                        registro.Read();
                        r = Convert.ToInt32(registro["codLocalidade"]);

                    }
                }
                catch
                {


                }
                return r;
            }
        }

        public static int ValidaNumeroNormal(string codCampo, string tabela)
        {
            using (_gc = new GCon())
            {
                var qry = $"select isnull(count({codCampo.Trim()}),0) {codCampo.Trim()} from {tabela.Trim()} ";
                var sqlComando = new SqlCommand(qry, _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }
        public static int VerificaCodBusca(string campoSelecao, string tabela, string campo, int numTabela)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count({campoSelecao}),0) {campoSelecao} from {tabela} where {campo}={numTabela}", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }

        public static int VerificaCodigo(string campoSelecao, string tabela)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count({campoSelecao}),0) {campoSelecao} from {tabela}", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }


        public static int VerificaArtigo(string tabela, string artigogeralstamp, string grupoartigo, string sexoartigo, string armazem, string orgao,
            string tamanho, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen,
            bool ofsup, bool ofsub, bool sargto, bool praca, bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool despor, bool fuzileiro)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand($"select isnull(count(artigoStamp),0) artigoStamp from Artigo where artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                                                $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                                                $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                                                $" and unifTrabalho='{unftrabalho}' and desportivo='{despor}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                                                $" and fuzileiro='{fuzileiro}' and piloto='{piloto}' and complementar='{complementar}'" +
                                                $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                                                $"  and praca='{praca}' and sargento='{sargto}'", _gc.NResult);
                return Int32.Parse(sqlComando.ExecuteScalar().ToString());
            }
        }

        public static string VerificaTabelaStamp(string selecionado, string tabela, string campo, string codigo)
        {
            using (_gc = new GCon())
            {
                var qry = $"SELECT {selecionado} FROM {tabela} WHERE {campo}='{codigo}'";
                var sqlComando = new SqlCommand(qry, _gc.NResult);
                var retorno = sqlComando.ExecuteScalar().ToString();
                return string.IsNullOrEmpty(retorno) ? "" : retorno;

            }
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }








        public static DataTable VerificaNomeDataTable(string tabela, string artigogeralstamp, string grupoartigo, string sexoartigo, string armazem,
            string orgao, string tamanho, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen, bool ofsup, bool ofsub, bool sargto, bool praca,
            bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool desporto, bool fuzil)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry =
                        $"select isnull(count(artigoStamp),0) artigoStamp from Artigo where artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                        $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                        $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                        $" and unifTrabalho='{unftrabalho}' and desportivo='{desporto}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                        $" and fuzileiro='{fuzil}' and piloto='{piloto}' and complementar='{complementar}'" +
                        $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                        $"  and praca='{praca}' and sargento='{sargto}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

                // throw new Exception(ex.Message);
            }
        }
        public static DataTable VerificaNomeDataTableArtigo(string norma, string artigogeralstamp, string grupoartigo, string sexoartigo, string temputil,
            string orgao, string tempoutilMesesAnos, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen, bool ofsup, bool ofsub, bool sargto, bool praca,
            bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool desporto, bool fuzil)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry =
                        $"select * from Artigo  where artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                        $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                        $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                        $" and unifTrabalho='{unftrabalho}' and desportivo='{desporto}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                        $" and fuzileiro='{fuzil}' and piloto='{piloto}' and complementar='{complementar}'" +
                        $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                        $"  and praca='{praca}' and norma='{norma}' AND tempoUtil='{temputil}' AND tempoutilMesesAnos='{tempoutilMesesAnos}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

                // throw new Exception(ex.Message);
            }
        }


        public static DataTable VerificaNomeDataTableArtigoT(string norma, string artigogeralstamp, string grupoartigo, string sexoartigo, string temputil,
            string orgao, string tempoutilMesesAnos, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen, bool ofsup, bool ofsub, bool sargto, bool praca,
            bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool desporto, bool fuzil, string nrContato)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry =
                        $"select * from Artigo a INNER JOIN dbo.ArtigoContrato ac ON a.artigoStamp = ac.artigoStamp INNER JOIN dbo.Contrato c ON ac.contratoStamp = c.contratoStamp" +
                        $" where artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                        $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                        $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                        $" and unifTrabalho='{unftrabalho}' and desportivo='{desporto}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                        $" and fuzileiro='{fuzil}' and piloto='{piloto}' and complementar='{complementar}'" +
                        $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                        $"  and praca='{praca}' and norma='{norma}' AND tempoUtil='{temputil}' AND tempoutilMesesAnos='{tempoutilMesesAnos}' AND c.nrContrato='{nrContato}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

                // throw new Exception(ex.Message);
            }
        }


        public static DataTable VerificaNomeDataTable2(string artigogeralstamp, string grupoartigo, string sexoartigo, string armazem,
            string orgao, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen, bool ofsup, bool ofsub, bool sargto, bool praca,
            bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool desporto, bool fuzil)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry =
                        $"select * from Artigo where artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                        $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                        $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                        $" and unifTrabalho='{unftrabalho}' and desportivo='{desporto}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                        $" and fuzileiro='{fuzil}' and piloto='{piloto}' and complementar='{complementar}'" +
                        $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                        $"  and praca='{praca}' and sargento='{sargto}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

                // throw new Exception(ex.Message);
            }
        }
        public static DataTable VerificaNomeDataTableExistencia(string armazemstamp, string artigogeralstamp, string grupoartigo, string sexoartigo, string armazem,
            string orgao, string tamanho, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen, bool ofsup, bool ofsub, bool sargto, bool praca,
            bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool desporto, bool fuzil)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry =
                        $"select ag.descricao artigomae,ag.u_m,a.artigoStamp,a.artigoGeralStamp,a.orgao,a.grupo,a.sexo,a.policiaMilitar," +
                        $" a.unidCerimonial,a.unifTrabalho,a.desportivo,a.domando,a.daraquedista,a.fuzileiro,a.piloto,a.complementar,a.ofGen,a.ofSup,a.ofSub,a.sargento," +
                        $" a.praca,a.norma,e.tamanho ,a.tempoUtil,a.tempoutilMesesAnos,e.existenciaStamp,e.tamanho,e.quantidadeActual qtdactual,e.armazemStamp,a.codArtigo " +
                        $" from dbo.Existencia e  INNER JOIN dbo.Artigo a ON e.artigoStamp = a.artigoStamp INNER  JOIN dbo.Armazem a2 ON e.armazemStamp = a2.armazemStamp " +
                        $" INNER JOIN dbo.ArtigoGeral ag ON a.artigoGeralStamp = ag.artigoGeralStamp " +
                        $" where a.artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                        $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                        $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                        $" and unifTrabalho='{unftrabalho}' and desportivo='{desporto}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                        $" and fuzileiro='{fuzil}' and piloto='{piloto}' and complementar='{complementar}'" +
                        $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                        $"  and praca='{praca}' and sargento='{sargto}' and tamanho='{tamanho}' and e.armazemStamp='{armazemstamp}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

                // throw new Exception(ex.Message);
            }
        }




        public static DataTable VerificaNomeDataTableExistenciaParaFornecimento(string tabela, string artigogeralstamp, string grupoartigo, string sexoartigo, string armazem,
           string orgao, string tamanho, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen, bool ofsup, bool ofsub, bool sargto, bool praca,
           bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool desporto, bool fuzil)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry =
                        $"select a.codArtigo,ag.descricao artigomae,ag.u_m,a.artigoStamp,a.artigoGeralStamp,a.orgao,a.grupo,a.sexo,a.policiaMilitar," +
                        $" a.unidCerimonial,a.unifTrabalho,a.desportivo,a.domando,a.daraquedista,a.fuzileiro,a.piloto,a.complementar,a.ofGen,a.ofSup,a.ofSub,a.sargento," +
                        $" a.praca,a.norma,e.tamanho ,a.tempoUtil,a.tempoutilMesesAnos,e.existenciaStamp,e.tamanho,e.quantidadeActual qtdactual,e.armazemStamp " +
                        $" from dbo.Existencia e  INNER JOIN dbo.Artigo a ON e.artigoStamp = a.artigoStamp INNER  JOIN dbo.Armazem a2 ON e.armazemStamp = a2.armazemStamp " +
                        $" INNER JOIN dbo.ArtigoGeral ag ON a.artigoGeralStamp = ag.artigoGeralStamp " +
                        $" where a.artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                        $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                        $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                        $" and unifTrabalho='{unftrabalho}' and desportivo='{desporto}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                        $" and fuzileiro='{fuzil}' and piloto='{piloto}' and complementar='{complementar}'" +
                        $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                        $"  and praca='{praca}' and sargento='{sargto}' and e.tamanho='{tamanho}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;


                // throw new Exception(ex.Message);
            }
        }

        public static DataTable VerificaNomeDataTableExistenciaFornecimento(string armazemStamp, string artigogeralstamp, string grupoartigo, string sexoartigo, string armazem, string orgao, string tamanho, bool piloto, bool unicerimonia, bool polimilitar, bool ofgen, bool ofsup, bool ofsub, bool sargto, bool praca, bool comando, bool paraquedista, bool unftrabalho, bool complementar, bool desporto, bool fuzil)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry =
                        $"select a.codArtigo,ag.descricao artigomae,ag.u_m,a.artigoStamp,a.artigoGeralStamp,a.orgao,a.grupo,a.sexo,a.policiaMilitar," +
                        $" a.unidCerimonial,a.unifTrabalho,a.desportivo,a.domando,a.daraquedista,a.fuzileiro,a.piloto,a.complementar,a.ofGen,a.ofSup,a.ofSub,a.sargento," +
                        $" a.praca,a.norma,e.tamanho ,a.tempoUtil,a.tempoutilMesesAnos,e.existenciaStamp,e.tamanho,e.quantidadeActual qtdactual,e.armazemStamp " +
                        $" from dbo.Existencia e  INNER JOIN dbo.Artigo a ON e.artigoStamp = a.artigoStamp INNER  JOIN dbo.Armazem a2 ON e.armazemStamp = a2.armazemStamp " +
                        $" INNER JOIN dbo.ArtigoGeral ag ON a.artigoGeralStamp = ag.artigoGeralStamp " +
                        $" where a.artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                        $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                        $" and policiaMilitar='{polimilitar}' and unidCerimonial='{unicerimonia}'" +
                        $" and unifTrabalho='{unftrabalho}' and desportivo='{desporto}' and domando='{comando}' and daraquedista='{paraquedista}'" +
                        $" and fuzileiro='{fuzil}' and piloto='{piloto}' and complementar='{complementar}'" +
                        $" and ofgen='{ofgen}' and ofsup='{ofsup}' and ofsub='{ofsub}' and sargento='{sargto}'" +
                        $"  and praca='{praca}' and sargento='{sargto}' and e.tamanho='{tamanho}' and e.armazemStamp='{armazemStamp}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

                // throw new Exception(ex.Message);
            }
        }

        public static DataTable VerificaNomeDataTableExistenciaFornecimentoFinal(string armazemStamp,
            string artigogeralstamp, string grupoartigo, string sexoartigo, string orgao,
            string tamanho, string nomeespecificacaouniforme, bool especicacaouniforme)
        {
            try
            {
                using (_gc = new GCon())
                {
                    string querry = $"select e.existenciaStamp,a.codArtigo,ag.descricao artigomae,ag.u_m,a.artigoStamp,a.artigoGeralStamp,a.orgao,a.grupo,a.sexo,a.policiaMilitar," +
                                    $" a.unidCerimonial,a.unifTrabalho,a.desportivo,a.domando,a.daraquedista,a.fuzileiro,a.piloto,a.complementar,a.ofGen,a.ofSup,a.ofSub,a.sargento," +
                                    $" a.praca,a.norma,e.tamanho ,a.tempoUtil,a.tempoutilMesesAnos,e.existenciaStamp,e.tamanho,e.quantidadeActual qtdactual,e.armazemStamp " +
                                    $" from dbo.Existencia e  INNER JOIN dbo.Artigo a ON e.artigoStamp = a.artigoStamp INNER  JOIN dbo.Armazem a2 ON e.armazemStamp = a2.armazemStamp " +
                                    $" INNER JOIN dbo.ArtigoGeral ag ON a.artigoGeralStamp = ag.artigoGeralStamp " +
                                    $" where a.artigoGeralStamp='{artigogeralstamp}' and grupo='{grupoartigo}'" +
                                    $" and sexo='{sexoartigo}' and orgao='{orgao}'" +
                                    $" and {nomeespecificacaouniforme}='{especicacaouniforme}' and " +
                                    $" e.tamanho='{tamanho}' and e.armazemStamp='{armazemStamp}'";
                    var sqlComando = new SqlCommand(querry, _gc.NResult);
                    return GetReturnTable(sqlComando);
                }
            }
            catch (Exception ex)
            {
                var dt = new DataTable();

               //// MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return dt;

                //throw new Exception(ex.Message);
            }
        }
    }

}
