using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DAL.Conexao;
using System.Drawing;

namespace DAL.BL
{

    public class Conexsao
    {
        string _campos = string.Empty;
        string _valores = string.Empty;

        #region AQUI IREI COLOCAR OS DADOS DO SERVIDOR

        public Conexsao()
        {
           

        }
        #endregion
        #region METODOS
        public bool Executar(string qry)
        {

            using (_gc = new GCon())
            {
                var cmd = new SqlCommand(qry, _gc.NResult);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                  
                    return false;
                }

            }

            //var cmd = new SqlCommand(qry, Conn);

            //try
            //{
            //    Conn.Open();
            //    cmd.ExecuteNonQuery();

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    // bool dt=false;

            //  // MessageBox.Show(ex.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //    // throw new Exception(ex.Message);
            //}

            //finally
            //{
            //    Conn.Close();
            //}
        }
        public string ExecuteScalar(string qry)
        {
            try
            {
                var obj = Pesquisar(qry).Rows.Count > 0 ? Pesquisar(qry).Rows[0][0] : string.Empty;
                if (obj != null)
                {
                    return obj.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception e)
            {
              // MessageBox.Show(e.Message.ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
                // throw new Exception($"Erro do Servidor: {e.Message}", e);
            }

        }
        public DataTable Pesquisar(string sqlquery)
        {
            using (_gc=new GCon())
            {
                var cmd = new SqlCommand(sqlquery, _gc.NResult) { CommandTimeout = int.MaxValue };
                var dtResultado = new DataTable();

                try
                {
                    dtResultado.Load(cmd.ExecuteReader());
                    return dtResultado;
                }

                catch (SqlException ex)
                {
                    var dt = new DataTable();
                    // MessageBox.Show($"Erro do Servidor: {ex.Message}".ToUpper(), @"Informação do Sistema".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return dt;
                    //throw new Exception($"Erro do Servidor: {ex.Message}", ex);
                }
            }
           
           
        }

        public bool Inserir(string tabela, List<SqlParametros> campos)
        {
            foreach (var parametro in campos)
            {
                _campos += $"{parametro.Campo},";
                try
                {
                    _valores += $"'{parametro.Valor.ToString().Replace("'", "''")}',";

                }
                catch (Exception)
                {
                    _valores += $"'{parametro.Valor}',";
                }
            }
            _campos = _campos.Substring(0, _campos.Length - 1);
            _valores = _valores.Substring(0, _valores.Length - 1);
            string sql = $"INSERT INTO {tabela} ({_campos}) VALUES ({_valores});";
            _campos = string.Empty;
            _valores = string.Empty;
            return Executar(sql);
        }
        public bool Atualizar(string paramTabela, List<SqlParametros> paramCampos, string campo, string condicoes)
        {
            var campos = string.Empty;
            foreach (var parametro in paramCampos)
            {
                try
                {
                    campos += $"{parametro.Campo}='{parametro.Valor.ToString().Replace("'", "''")}',";

                }
                catch (Exception ex)
                {
                    campos += $"{parametro.Campo}='{parametro.Valor}',";
                }
            }
            campos = campos.Substring(0, campos.Length - 1);
            var qry = $"UPDATE {paramTabela} SET {campos} WHERE {campo}='{condicoes}'";
            return Executar(qry);
        }
        public bool Excluir(string tabela, string campo, string chave)
        {

            return Executar($"DELETE FROM {tabela} WHERE {campo}='{chave}'");
        }


        #endregion

        public DataTable Dados(string chave, string campo, string tabela)
        {
            return Geral.GetGen2Dt($"select * from {tabela} where {campo}='{chave}'");
        }

        public DataTable AtualizarSensao(string tabela, int hora, int min, int seg, string horaSaida, string campo, string chave)
        {
            return Geral.GetGen2Dt($"UPDATE {tabela} SET duracaoHora={hora},duracaoMin={min},duracaoSegundos={seg}, horaSessaoSaida='{horaSaida}' WHERE {campo}='{chave}'");
        }

        private GCon _gc;
        public bool GravarGeral(string tabela, object user)
        {
            using (_gc = new GCon())
            {
                string qryy;
                string camps = string.Empty;
                string valor = string.Empty;
                Type type = user.GetType();
                PropertyInfo[] props = type.GetProperties();
                foreach (var prop in props)
                {
                    if (string.IsNullOrEmpty(camps))
                    {
                        camps += prop.Name;
                    }
                    else
                    {
                        camps += $",{prop.Name}";
                    }
                    if (string.IsNullOrEmpty(valor))
                    {
                        valor += $"@{prop.Name}";
                    }
                    else
                    {
                        valor += $",@{prop.Name}";
                    }
                }
                qryy = $"insert into {tabela.Trim()} ({camps}) values ({valor})";


                var cmd = new SqlCommand();
                cmd.CommandText = qryy;
                cmd.Connection = _gc.NResult;
                foreach (var prop in props)
                {
                    if (prop.PropertyType == typeof(byte[]))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            var keyyy = new byte[0];
                            prop.SetValue(user, keyyy);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.VarBinary).Value = prop.GetValue(user);

                    }
                    if (prop.PropertyType == typeof(decimal))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Decimal).Value = prop.GetValue(user);

                    }
                    if (prop.PropertyType == typeof(int))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Int).Value = prop.GetValue(user);

                    }
                    if (prop.PropertyType == typeof(string))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, "");
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.NVarChar).Value = prop.GetValue(user);

                    }
                    if (prop.PropertyType == typeof(long))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.BigInt).Value = prop.GetValue(user);

                    }
                    if (prop.PropertyType == typeof(DateTime))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, Convert.ToDateTime("1900/01/01"));
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.DateTime).Value = prop.GetValue(user);

                    }
                }
                
                var resultado = cmd.ExecuteNonQuery();
                //con.Close();
                if (resultado > 0)
                {

                    return true;
                }
            }

            return false;
        }
        public bool UpdateGeral(string tabela, object user, string campo, string condicoes)
        {
            
            var cmd = new SqlCommand();
            string qryy;
            using (_gc = new GCon())
            {
                string camps = string.Empty;
                Type type = user.GetType();
                PropertyInfo[] props = type.GetProperties();
                foreach (var prop in props)
                {

                    if (!prop.Name.ToLower().Contains("inseriu"))
                    {
                        if (string.IsNullOrEmpty(camps))
                        {
                            camps += prop.Name + $"=@{prop.Name}";
                        }
                        else
                        {
                            camps += $",{prop.Name + $"=@{prop.Name}"}";
                        }
                    }

                }
                qryy = $"update {tabela.Trim()} set {camps} where {campo}=@{campo}";
                cmd.CommandText = qryy;
                foreach (var prop in props)
                {
                    if (!prop.Name.ToLower().Contains("inseriu"))
                    {
                        if (prop.PropertyType == typeof(byte[]))
                        {
                            if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                            {
                                var keyyy = new byte[0];
                                prop.SetValue(user, keyyy);
                            }
                            cmd.Parameters.Add($"@{prop.Name}", SqlDbType.VarBinary).Value = prop.GetValue(user);

                        }
                        if (prop.PropertyType == typeof(decimal))
                        {
                            if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                            {
                                prop.SetValue(user, 0);
                            }
                            cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Decimal).Value = prop.GetValue(user);

                        }
                        if (prop.PropertyType == typeof(int))
                        {
                            if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                            {
                                prop.SetValue(user, 0);
                            }
                            cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Int).Value = prop.GetValue(user);

                        }
                        if (prop.PropertyType == typeof(string))
                        {
                            if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                            {
                                prop.SetValue(user, "");
                            }
                            cmd.Parameters.Add($"@{prop.Name}", SqlDbType.NVarChar).Value = prop.GetValue(user);

                        }
                        if (prop.PropertyType == typeof(long))
                        {
                            if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                            {
                                prop.SetValue(user, 0);
                            }
                            cmd.Parameters.Add($"@{prop.Name}", SqlDbType.BigInt).Value = prop.GetValue(user);

                        }
                        if (prop.PropertyType == typeof(DateTime))
                        {
                            if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                            {
                                prop.SetValue(user, Convert.ToDateTime("1900/01/01"));
                            }
                            cmd.Parameters.Add($"@{prop.Name}", SqlDbType.DateTime).Value = prop.GetValue(user);

                        }
                    }
                }
                cmd.Connection = _gc.NResult;
                var resultado = cmd.ExecuteNonQuery();
                //con.Close();
                return resultado > 0;
            }
            
        }
        public bool InserirAlterarFoto(string tabela, string chave, string caminho, byte[] foto, string inserir, DateTime inseriuData, string alterar, DateTime alterarData, string milchave, int condicao)
        {
             var cmd = new SqlCommand();
            using (_gc = new GCon())
            {
                if (condicao == 0)
                {
                    //var qry = $"insert into {tabela} (milFotStamp,caminho,foto,inseriu,inseriuDataHora,alterou,alterouDataHora,milStamp) values (@milFotStamp,@caminho,@foto,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora,@milStamp)";
                    var qry = $"insert into {tabela} (milFotStamp,foto,inseriu,inseriuDataHora,alterou,alterouDataHora,milStamp) values (@milFotStamp,@foto,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora,@milStamp)";
                   // cmd = new SqlCommand(qry, _gc.NResult);
                    cmd.CommandText = qry;
                }
                else if (condicao == 1)
                {
                    //var qry = $"update {tabela} set caminho=@caminho,foto=@foto,alterou=@alterou,alterouDataHora=@alterouDataHora where milFotStamp=@milFotStamp";
                    var qry = $"update {tabela} set foto=@foto,alterou=@alterou,alterouDataHora=@alterouDataHora where milFotStamp=@milFotStamp";
                    //cmd = new SqlCommand(qry, _gc.NResult);
                    cmd.CommandText = qry;
                }
                cmd.Parameters.Add("@milFotStamp", SqlDbType.VarChar).Value = chave;
                // cmd.Parameters.Add("@caminho", SqlDbType.VarChar).Value = caminho;
                cmd.Parameters.Add("@foto", SqlDbType.Binary).Value = foto;
                cmd.Parameters.Add("@inseriu", SqlDbType.VarChar).Value = inserir;
                cmd.Parameters.Add("@inseriuDataHora", SqlDbType.DateTime).Value = inseriuData;
                cmd.Parameters.Add("@alterou", SqlDbType.VarChar).Value = alterar;
                cmd.Parameters.Add("@alterouDataHora", SqlDbType.DateTime).Value = alterarData;
                cmd.Parameters.Add("@milStamp", SqlDbType.VarChar).Value = milchave;
                cmd.Connection = _gc.NResult;
                var resultado = cmd.ExecuteNonQuery();
                if (resultado>0)
                {
                    return true;
                }

            }

            return false;

            //var con = new SqlConnection(connectionString);
            //con.Open();
            //var cmd = new SqlCommand();
            //if (condicao == 0)
            //{
            //    //var qry = $"insert into {tabela} (milFotStamp,caminho,foto,inseriu,inseriuDataHora,alterou,alterouDataHora,milStamp) values (@milFotStamp,@caminho,@foto,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora,@milStamp)";
            //    var qry = $"insert into {tabela} (milFotStamp,foto,inseriu,inseriuDataHora,alterou,alterouDataHora,milStamp) values (@milFotStamp,@foto,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora,@milStamp)";
            //    cmd.CommandText = qry;
            //}
            //else if (condicao == 1)
            //{
            //    //var qry = $"update {tabela} set caminho=@caminho,foto=@foto,alterou=@alterou,alterouDataHora=@alterouDataHora where milFotStamp=@milFotStamp";
            //    var qry = $"update {tabela} set foto=@foto,alterou=@alterou,alterouDataHora=@alterouDataHora where milFotStamp=@milFotStamp";
            //    cmd.CommandText = qry;
            //}
            //cmd.Parameters.Add("@milFotStamp", SqlDbType.VarChar).Value = chave;
            //// cmd.Parameters.Add("@caminho", SqlDbType.VarChar).Value = caminho;
            //cmd.Parameters.Add("@foto", SqlDbType.Binary).Value = foto;
            //cmd.Parameters.Add("@inseriu", SqlDbType.VarChar).Value = inserir;
            //cmd.Parameters.Add("@inseriuDataHora", SqlDbType.DateTime).Value = inseriuData;
            //cmd.Parameters.Add("@alterou", SqlDbType.VarChar).Value = alterar;
            //cmd.Parameters.Add("@alterouDataHora", SqlDbType.DateTime).Value = alterarData;
            //cmd.Parameters.Add("@milStamp", SqlDbType.VarChar).Value = milchave;
            //cmd.Connection = con;
            //var resultado = cmd.ExecuteNonQuery();
            //con.Close();
            //return resultado > 0;
        }

        public bool InserirAlterarDigital(string tabela, string milStamp, string caminhoPolegarE, byte[] polegarE, string caminhoIndicadorE, byte[] indicadorE, string caminhoPolegarD, byte[] polegarD, string caminhoIndicadorD, byte[] indicadorD, string inserir, string inseriuData, string alterar, string alterarData, int condicao)
        {

            var cmd = new SqlCommand();
            using (_gc = new GCon())
            {
               // var cmd = new SqlCommand();
                if (condicao == 0)
                {
                    var qry = $"insert into {tabela} (milStamp,polegarE,indicadorE,polegarD,indicadorD,inseriu,inseriuDataHora,alterou,alterouDataHora) values (@milStamp,@polegarE,@indicadorE,@polegarD,@indicadorD,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora)";
                    cmd.CommandText = qry;
                   // cmd = new SqlCommand(qry, _gc.NResult);
                }
                else if (condicao == 1)
                {
                    //var qry = $"update {tabela} set caminhoPolegarE=@caminhoPolegarE,polegarE=@polegarE,caminhoIndicadorE=@caminhoIndicadorE,indicadorE=@indicadorE,caminhoPolegarD=@caminhoPolegarD,polegarD=@polegarD,caminhoIndicadorD=@caminhoIndicadorD,indicadorD=@indicadorD,alterou=@alterou,alterouDataHora=@alterouDataHora where milStamp=@milStamp";
                    var qry = $"update {tabela} set polegarE=@polegarE,indicadorE=@indicadorE,polegarD=@polegarD,indicadorD=@indicadorD,alterou=@alterou,alterouDataHora=@alterouDataHora where milStamp=@milStamp";
                     cmd.CommandText = qry;
                  //  cmd = new SqlCommand(qry, _gc.NResult);
                }
                cmd.Parameters.Add("@milStamp", SqlDbType.VarChar).Value = milStamp;
                // cmd.Parameters.Add("@caminhoPolegarE", SqlDbType.VarChar).Value = caminhoPolegarE;
                cmd.Parameters.Add("@polegarE", SqlDbType.Binary).Value = polegarE;
                // cmd.Parameters.Add("@caminhoIndicadorE", SqlDbType.VarChar).Value = caminhoIndicadorE;
                cmd.Parameters.Add("@indicadorE", SqlDbType.Binary).Value = indicadorE;
                // cmd.Parameters.Add("@caminhoPolegarD", SqlDbType.VarChar).Value = caminhoPolegarD;
                cmd.Parameters.Add("@polegarD", SqlDbType.Binary).Value = polegarD;
                // cmd.Parameters.Add("@caminhoIndicadorD", SqlDbType.VarChar).Value = caminhoIndicadorD;
                cmd.Parameters.Add("@indicadorD", SqlDbType.Binary).Value = indicadorD;
                cmd.Parameters.Add("@inseriu", SqlDbType.VarChar).Value = inserir;
                cmd.Parameters.Add("@inseriuDataHora", SqlDbType.VarChar).Value = inseriuData;
                cmd.Parameters.Add("@alterou", SqlDbType.VarChar).Value = alterar;
                cmd.Parameters.Add("@alterouDataHora", SqlDbType.VarChar).Value = alterarData;
                cmd.Connection = _gc.NResult;
                var resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    return true;
                }
            }
            return false;
            //var connectionString = ConfigurationManager.ConnectionStrings["Dbsgpm"].ConnectionString;
            //var con = new SqlConnection(connectionString);
            //con.Open();
            //var cmd = new SqlCommand();
            //if (condicao == 0)
            //{
            //    var qry = $"insert into {tabela} (milStamp,polegarE,indicadorE,polegarD,indicadorD,inseriu,inseriuDataHora,alterou,alterouDataHora) values (@milStamp,@polegarE,@indicadorE,@polegarD,@indicadorD,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora)";
            //    cmd.CommandText = qry;
            //}
            //else if (condicao == 1)
            //{
            //    //var qry = $"update {tabela} set caminhoPolegarE=@caminhoPolegarE,polegarE=@polegarE,caminhoIndicadorE=@caminhoIndicadorE,indicadorE=@indicadorE,caminhoPolegarD=@caminhoPolegarD,polegarD=@polegarD,caminhoIndicadorD=@caminhoIndicadorD,indicadorD=@indicadorD,alterou=@alterou,alterouDataHora=@alterouDataHora where milStamp=@milStamp";
            //    var qry = $"update {tabela} set polegarE=@polegarE,indicadorE=@indicadorE,polegarD=@polegarD,indicadorD=@indicadorD,alterou=@alterou,alterouDataHora=@alterouDataHora where milStamp=@milStamp";

            //    cmd.CommandText = qry;
            //}
            //cmd.Parameters.Add("@milStamp", SqlDbType.VarChar).Value = milStamp;
            //// cmd.Parameters.Add("@caminhoPolegarE", SqlDbType.VarChar).Value = caminhoPolegarE;
            //cmd.Parameters.Add("@polegarE", SqlDbType.Binary).Value = polegarE;
            //// cmd.Parameters.Add("@caminhoIndicadorE", SqlDbType.VarChar).Value = caminhoIndicadorE;
            //cmd.Parameters.Add("@indicadorE", SqlDbType.Binary).Value = indicadorE;
            //// cmd.Parameters.Add("@caminhoPolegarD", SqlDbType.VarChar).Value = caminhoPolegarD;
            //cmd.Parameters.Add("@polegarD", SqlDbType.Binary).Value = polegarD;
            //// cmd.Parameters.Add("@caminhoIndicadorD", SqlDbType.VarChar).Value = caminhoIndicadorD;
            //cmd.Parameters.Add("@indicadorD", SqlDbType.Binary).Value = indicadorD;
            //cmd.Parameters.Add("@inseriu", SqlDbType.VarChar).Value = inserir;
            //cmd.Parameters.Add("@inseriuDataHora", SqlDbType.VarChar).Value = inseriuData;
            //cmd.Parameters.Add("@alterou", SqlDbType.VarChar).Value = alterar;
            //cmd.Parameters.Add("@alterouDataHora", SqlDbType.VarChar).Value = alterarData;
            //cmd.Connection = con;
            //var resultado = cmd.ExecuteNonQuery();
            //con.Close();
            //return resultado > 0;
        }

        public int AlterarSenha(string qry)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["Dbsgpm"].ConnectionString;

            using (_gc = new GCon())
            {
                //var con = new SqlConnection(connectionString);
                //con.Open();
                var cmd = new SqlCommand();
                cmd.CommandText = qry;
                cmd.Connection = _gc.NResult;
                int resultado = cmd.ExecuteNonQuery();
                //con.Close();
                return resultado;
            }

            return 0;
        }
    }

}
