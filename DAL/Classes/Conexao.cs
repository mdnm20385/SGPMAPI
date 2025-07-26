using System.Data;
using System.Drawing;
using System.Reflection;
using DAL.BL;
using DAL.Conexao;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DAL.Classes
{
    public class Conexao
    {
        


      
        public void GravarFilhas<T>(List<T> tarefa)
        {
            for (int i = 0; i < tarefa.Count; i++)
            {
                var  tabe = tarefa.GetType().Name;
                GravarGeral(tabe, tarefa[i]);
            }
           
        }
        public static class DataStorage
        {
            public static List<InvoiceViewModel> GetAllEmployees() =>
                new List<InvoiceViewModel>
                {
                    new InvoiceViewModel { CreatedAt= DateTime.Now, Due = DateTime.Now, Id=35, AddressLine= "Male",City = "City",ZipCode = "Zip",CompanyName = "CompanyName",
                        PaymentMethod ="PaymentMethod" },
                };
        }
        public class InvoiceViewModel
        {
            public DateTime CreatedAt { get; set; }
            public DateTime Due { get; set; }
            public int Id { get; set; }
            public string AddressLine { get; set; }
            public string City { get; set; }
            public string ZipCode { get; set; }
            public string CompanyName { get; set; }
            public string PaymentMethod { get; set; }
            public decimal Amount => Items.Sum(i => i.Amount);
            public ICollection<InvoiceItemViewModel> Items { get; set; }
        }

        public class InvoiceItemViewModel
        {
            public string Name { get; set; } = "Name";
            public decimal Amount { get; set; } = 123;

            public InvoiceItemViewModel(string name, decimal amount)
            {
                Name = name;
                Amount = amount;
            }
        }

        public SqlConnection Conn;
        public SqlCommand Cmdgeral;
        string _campos = string.Empty;
        string _valores = string.Empty;
        #region AQUI IREI COLOCAR OS DADOS DO SERVIDOR
        public Conexao(bool conselhotecno=false)
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            //configurationBuilder.AddJsonFile(path, false);
            master_ConnectionString = configurationBuilder.Build().GetSection("ConnectionStrings:TASKContextConnection").Value;
            var conn =master_ConnectionString;
            if (conselhotecno)
            {
                conn=conn.Replace($"Initial Catalog=Teste", "Initial Catalog=SIGEX");
            }
            Conn = new SqlConnection(conn);
            

            Cmdgeral = new SqlCommand { Connection = Conn };


        }
        #endregion
        #region METODOS
        public bool Executar(string qry)
        {
            var cmd = new SqlCommand(qry, Conn);
            try
            {
                Conn.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

            finally
            {
                Conn.Close();
            }
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
                return string.Empty;
                // throw new Exception($"Erro do Servidor: {e.Message}", e);
            }

        }
        public DataTable Pesquisar(string sqlquery)
        {

            var builder = new SqlConnectionStringBuilder(SqlHelper.GetConString());
            Conn = new SqlConnection(SqlHelper.GetConString());
            var cmd = new SqlCommand(sqlquery, Conn)
            {
                CommandTimeout = int.MaxValue
            };
            var dtResultado = new DataTable();
            try
            {
                Conn.Open();
                dtResultado.Load(cmd.ExecuteReader());
                return dtResultado;
            }
            catch (SqlException)
            {
                var dt = new DataTable();
                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }


        public DataTable PesquisarCominico(string tabela, string condicoes="")
        {
            var cond=string.Empty;
            if (string.IsNullOrEmpty(tabela))
            {
                return null;
            }
            if (!string.IsNullOrEmpty(condicoes))
            {
                cond = $" where {condicoes}";
            }

            var qry = $"Select * from {tabela} {cond}";
            var cmd = new SqlCommand(qry, Conn) { CommandTimeout = int.MaxValue };
            var dtResultado = new DataTable();

            try
            {
                Conn.Open();
                dtResultado.Load(cmd.ExecuteReader());
                return dtResultado;
            }
            catch (SqlException)
            {
                var dt = new DataTable();
                return dt;
            }
            finally
            {
                Conn.Close();
            }
        }
        private static bool VerificaCampos(PropertyInfo prop)
        {
            //
            return !prop.Name.ToLower().Equals("datapagamento") && !prop.Name.ToLower().Equals("Tarefadi".ToLower()) && !prop.Name.ToLower().Equals("Tarefajob".ToLower()) && !prop.Name.ToLower().Equals("Tarefa".ToLower())
                   && !prop.Name.ToLower().Equals("Tarefajob".ToLower()) && !prop.Name.ToLower().Equals("EmailClass".ToLower()) && !prop.Name.ToLower().Contains("ProfilePhoto".ToLower())
                   && !prop.Name.ToLower().Equals("pa".ToLower()) && !prop.Name.ToLower().Equals("Processo".ToLower())
                   && !prop.Name.ToLower().Equals("TarefaDoc".ToLower()) 
                   && !prop.Name.ToLower().Equals("tdocAniva".ToLower())
                   && !prop.Name.ToLower().Equals("Customers".ToLower())
                   && !prop.Name.ToLower().Equals("SaidaProcesso1224242".ToLower())
                   && !prop.Name.ToLower().Equals("Tarefadep".ToLower()
                   );
        }

        public bool GravarGeral(string tabela, object user)
        {
            var con = new SqlConnection(master_ConnectionString);
            con.Open();
            var cmd = new SqlCommand();
            string qryy;
            string camps = string.Empty;
            string valor = string.Empty;
            Type type = user.GetType();
            PropertyInfo[] props = type.GetProperties();
            foreach (var prop in props)
            {
                
                if (VerificaCampos(prop))
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
            }
            qryy = $"insert into {tabela.Trim()} ({camps}) values ({valor})";
            if (qryy.ToLower().Contains("--") || qryy.ToLower().Contains("update into") || qryy.ToLower().Contains("drop") || qryy.ToLower().Contains("1=1")
                || qryy.ToLower().Contains("select") || qryy.ToLower().Contains("delete") 
                || qryy.ToLower().Contains("<") || qryy.ToLower().Contains(">"))
            {
                return false;
            }
            cmd.CommandText = qryy;

            foreach (var prop in props)
            {
                if (VerificaCampos(prop))
                {
                    var typ = Tipo(tabela, prop.Name);
                    if (typ.Equals("bit"))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, false);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Bit).Value = prop.GetValue(user);
                    }
                    if (typ.Contains("binary"))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            var keyyy = new byte[0];
                            prop.SetValue(user, keyyy);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.VarBinary).Value = prop.GetValue(user);

                    }
                    if (typ == "decimal" || typ == "smallint")
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, Convert.ToDecimal(0));
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Decimal).Value = prop.GetValue(user);

                    }
                    if (typ == "int")
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Int).Value = prop.GetValue(user);

                    }
                    if (typ == "time")
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, Convert.ToDateTime("1920/01/01 00:00:00").TimeOfDay);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Time).Value = prop.GetValue(user);

                    }
                    if (typ == "varchar"
                                                            || typ == "nchar"
                                                            || typ == "ntext"
                                                            || typ == "text"
                                                            || typ.Contains("char")
                                                            )
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, "");
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.NVarChar).Value = prop.GetValue(user);

                    }

                    if (typ == "bigint")
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.BigInt).Value = prop.GetValue(user);

                    }
                    if (typ.Contains("date"))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull ||
                            prop.GetValue(user).ToString().Contains("0001-01-01") ||
                            prop.GetValue(user).ToString().Contains("0001"))
                        {
                            prop.SetValue(user, Convert.ToDateTime("1920/01/01"));
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.DateTime).Value = prop.GetValue(user);
                    }
                }
            }
            cmd.Connection = con;
            var resultado = cmd.ExecuteNonQuery();
            con.Close();
            return resultado > 0;
        }


        private static string? master_ConnectionString = Pbl.ConString;

        public bool UpdateGeral(string tabela, object user, string campo, string condicoes)
        {
            using (var dd=new GCon())
            {
                var cmd = new SqlCommand();
                string qryy;
                string camps = string.Empty;
                Type type = user.GetType();
                PropertyInfo[] props = type.GetProperties();
                foreach (var prop in props)
                {
                    if (VerificaCampos(prop))
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

                if (qryy.ToLower().Contains("--") || qryy.ToLower().Contains("insert into") || qryy.ToLower().Contains("drop") || qryy.ToLower().Contains("1=1")
                 || qryy.ToLower().Contains("select") || qryy.ToLower().Contains("delete"))
                {
                    return false;
                }
                cmd.CommandText = qryy;
                bool veri = false;
                foreach (var prop in props)
                {

                    var typ = Tipo(tabela, prop.Name);
                    if (typ.Equals("bit"))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, false);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Bit).Value = prop.GetValue(user);

                    }
                    if (typ == "time")
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, Convert.ToDateTime("1920/01/01 00:00:00").TimeOfDay);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Time).Value = prop.GetValue(user);

                    }
                    if (typ.Contains("binary"))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            var keyyy = new byte[0];
                            prop.SetValue(user, keyyy);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.VarBinary).Value = prop.GetValue(user);

                    }
                    if (typ == "decimal"
                                                             || typ == "smallint")
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Decimal).Value = prop.GetValue(user);

                    }
                    if (typ == "int"
                                                        )
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.Int).Value = prop.GetValue(user);

                    }
                    if (typ == "varchar"
                                                            || typ == "nchar"
                                                            || typ == "ntext"
                                                            || typ == "text"
                                                            || typ.Contains("char")
                                                            )
                    {


                        if (prop.Name.ToLower().Equals("path"))
                        {
                            if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                            {
                                veri = true;
                            }
                        }
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, "");
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.NVarChar).Value = prop.GetValue(user);

                    }

                    if (typ == "bigint")
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull)
                        {
                            prop.SetValue(user, 0);
                        }
                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.BigInt).Value = prop.GetValue(user);

                    }
                    if (typ.Contains("date"))
                    {
                        if (prop.GetValue(user) == null || prop.GetValue(user) is DBNull
                                                        || prop.GetValue(user).ToString().Contains("0001-01-01") ||
                                                        prop.GetValue(user).ToString().Contains("0001"))
                        {
                            prop.SetValue(user, Convert.ToDateTime("1920/01/01"));
                        }

                        cmd.Parameters.Add($"@{prop.Name}", SqlDbType.DateTime).Value = prop.GetValue(user);
                    }
                }
                cmd.Connection = _gc.NResult;
                if (veri)
                {
                    cmd.CommandText = cmd.CommandText.Replace(",Path=@Path", "");
                }
                var resultado = cmd.ExecuteNonQuery();
                return resultado > 0;
            }

           
        }
        private GCon _gc;
        private SqlCommand _cmd;
    
        public string Tipo(string tabela, string campo)
        {
            try
            {
                string sql = $"select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME ='{tabela.Trim()}' and COLUMN_NAME='{campo}' " +
                                 "order by ORDINAL_POSITION ";
                return Pesquisar(sql).Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
        }
    
     

        #endregion

       

        public bool InserirAlterarFoto(string tabela, string chave, string caminho, byte[] foto, string inserir, DateTime inseriuData, string alterar, DateTime alterarData, string milchave, int condicao)
        {
            var con = new SqlConnection(master_ConnectionString);
            con.Open();
            var cmd = new SqlCommand();
            if (condicao == 0)
            {
                //var qry = $"insert into {tabela} (milFotStamp,caminho,foto,inseriu,inseriuDataHora,alterou,alterouDataHora,milStamp) values (@milFotStamp,@caminho,@foto,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora,@milStamp)";
                var qry = $"insert into {tabela} (milFotStamp,foto,inseriu,inseriuDataHora,alterou,alterouDataHora,milStamp) values (@milFotStamp,@foto,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora,@milStamp)";
                cmd.CommandText = qry;
            }
            else if (condicao == 1)
            {
                //var qry = $"update {tabela} set caminho=@caminho,foto=@foto,alterou=@alterou,alterouDataHora=@alterouDataHora where milFotStamp=@milFotStamp";
                var qry = $"update {tabela} set foto=@foto,alterou=@alterou,alterouDataHora=@alterouDataHora where milFotStamp=@milFotStamp";
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
            cmd.Connection = con;
            var resultado = cmd.ExecuteNonQuery();
            con.Close();
            return resultado > 0;
        }

        public bool InserirAlterarDigital(string tabela, string milStamp, string caminhoPolegarE,
            byte[] polegarE, string caminhoIndicadorE, byte[] indicadorE, string caminhoPolegarD, byte[] polegarD,
            string caminhoIndicadorD, byte[] indicadorD, string inserir, DateTime inseriuData,
            string alterar, DateTime alterarData, int condicao)
        {
            var con = new SqlConnection(master_ConnectionString);
            con.Open();
            var cmd = new SqlCommand();
            if (condicao == 0)
            {
                var qry = $"insert into {tabela} (milStamp,polegarE,indicadorE,polegarD,indicadorD,inseriu,inseriuDataHora,alterou,alterouDataHora) values (@milStamp,@polegarE,@indicadorE,@polegarD,@indicadorD,@inseriu,@inseriuDataHora,@alterou,@alterouDataHora)";
                cmd.CommandText = qry;
            }
            else if (condicao == 1)
            {
                //var qry = $"update {tabela} set caminhoPolegarE=@caminhoPolegarE,polegarE=@polegarE,caminhoIndicadorE=@caminhoIndicadorE,indicadorE=@indicadorE,caminhoPolegarD=@caminhoPolegarD,polegarD=@polegarD,caminhoIndicadorD=@caminhoIndicadorD,indicadorD=@indicadorD,alterou=@alterou,alterouDataHora=@alterouDataHora where milStamp=@milStamp";
                var qry = $"update {tabela} set polegarE=@polegarE,indicadorE=@indicadorE,polegarD=@polegarD,indicadorD=@indicadorD,alterou=@alterou,alterouDataHora=@alterouDataHora where milStamp=@milStamp";

                cmd.CommandText = qry;
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
            cmd.Connection = con;
            var resultado = cmd.ExecuteNonQuery();
            con.Close();
            return resultado > 0;
        }

        public int AlterarSenha(string qry)
        {
            var connectionString = master_ConnectionString;
            var con = new SqlConnection(connectionString);
            con.Open();
            var cmd = new SqlCommand();
            cmd.CommandText = qry;
            cmd.Connection = con;
            int resultado = cmd.ExecuteNonQuery();
            con.Close();
            return resultado;
        }

    }
}

