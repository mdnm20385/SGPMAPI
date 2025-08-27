using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Model.Models.Facturacao;
using Model.Models.Gene;
using Model.Models.SJM;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SGPMAPI.Procura;
using SGPMAPI.SharedClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using DataColumn = System.Data.DataColumn;
using DataTable = System.Data.DataTable;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;

namespace SGPMAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Proc2Controller : ControllerBase
    {
        private readonly InterfaceProcura _usrService;
        private readonly SGPMContext _dbContext;
        private readonly IWebHostEnvironment _webHost;
        public Proc2Controller(InterfaceProcura usrService, SGPMContext dbContext, IWebHostEnvironment webHost)
        {
            _usrService = usrService;
            _dbContext = dbContext;
            _webHost = webHost;
        }

        [HttpGet]
        [Route("CopiaDados")]
        public async Task<ActionResult<ServiceResponse<Selectview>>> CopiaDados()
        {
            ServiceResponse<Selectview> serviceResponse = new ServiceResponse<Selectview>();
            string mysqlConnStr = "Server=127.0.0.1;Database=gecamo;User Id=root;Password=;Charset=utf8mb4;";
            using var mysqlConn = new MySqlConnection(mysqlConnStr);
            mysqlConn.Open();
            using var sqlConn = new Microsoft.Data.SqlClient.SqlConnection(SqlConstring.GetSqlConstringGecamo());
            sqlConn.Open();

            // 1. Obter todos os nomes das tabelas do MySQL
            var tablesCmd = new MySqlCommand("SHOW TABLES", mysqlConn);
            var tableNames = new List<string>();
            using (var tablesReader = tablesCmd.ExecuteReader())
            {
                while (tablesReader.Read())
                {
                    tableNames.Add(tablesReader.GetString(0));
                }
            }

            foreach (var tableName in tableNames)
            {
                try
                {
                    if (!tableName.Equals("personal", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // 2. Verifica se a tabela já existe no SQL Server
                    var checkTableCmd = new Microsoft.Data.SqlClient.SqlCommand(
                        $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{tableName}'", sqlConn);
                    int tableExists = (int)checkTableCmd.ExecuteScalar();

                    // 3. Obtenha os nomes das colunas e tipos
                    var columnNames = new List<string>();
                    var columnsInfo = new List<(string Name, string Type, string Nullable)>();
                    var columnsCmd = new MySqlCommand($"SHOW COLUMNS FROM `{tableName}`", mysqlConn);
                    using (var columnsReader = columnsCmd.ExecuteReader())
                    {
                        while (columnsReader.Read())
                        {
                            string colName = columnsReader["Field"].ToString().Normalize(System.Text.NormalizationForm.FormC);
                            columnNames.Add(colName);
                            if (tableExists == 0)
                            {
                                string colType = columnsReader["Type"].ToString();
                                string nullable = columnsReader["Null"].ToString() == "NO" ? "NOT NULL" : "NULL";
                                string sqlType = SqlConstring.MapMySqlTypeToSqlServer(colType);
                                columnsInfo.Add((colName, sqlType, nullable));
                            }
                        }
                    } // columnsReader fechado aqui!

                    // 4. Cria a tabela no SQL Server se não existir
                    if (tableExists == 0)
                    {
                        string createTableSql = $"CREATE TABLE [{tableName}] (";
                        for (int i = 0; i < columnsInfo.Count; i++)
                        {
                            var col = columnsInfo[i];
                            if (i > 0) createTableSql += ",";
                            // Adiciona collation Unicode para colunas texto
                            string collation = col.Type.StartsWith("NVARCHAR", StringComparison.OrdinalIgnoreCase) || col.Type.StartsWith("NCHAR", StringComparison.OrdinalIgnoreCase)
                                ? "COLLATE Latin1_General_100_CI_AI_SC"
                                : "";
                            createTableSql += $"\n  [{col.Name.Trim()}] {col.Type} {collation} {col.Nullable}";
                        }
                        createTableSql += "\n);";
                        using var sqlCmd = new Microsoft.Data.SqlClient.SqlCommand(createTableSql, sqlConn);
                        sqlCmd.ExecuteNonQuery();
                        Console.WriteLine($"Tabela {tableName} criada no SQL Server.");
                    }

                    // 5. Importa os dados, evitando duplicidade por todas as colunas
                    var selectCmd = new MySqlCommand($"SELECT * FROM `{tableName}`", mysqlConn);
                    var selectCmds = new MySqlCommand($"SELECT COUNT(*) total FROM `{tableName}`", mysqlConn);
                    int total = Convert.ToInt32(selectCmds.ExecuteScalar());

                    int totals = 0;

                    using (var dataReader = selectCmd.ExecuteReader())
                    {



                        while (dataReader.Read())
                        {
                            totals++;
                            try
                            {
                                var whereClauses = new List<string>();
                                for (int i = 0; i < dataReader.FieldCount; i++)
                                {
                                    var col = dataReader.GetName(i).Normalize(System.Text.NormalizationForm.FormC);
                                    object value = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
                                    string valueSql;

                                    if (value is sbyte || value is byte || value is ushort || value is short || value is int || value is long || value is float || value is double || value is decimal)
                                        valueSql = value.ToString();
                                    else if (value is DateTime)
                                        valueSql = $"'{((DateTime)value):yyyy-MM-dd HH:mm:ss}'";
                                    else if (value is bool)
                                        valueSql = ((bool)value) ? "1" : "0";
                                    else if (value == null)
                                        valueSql = "NULL";
                                    else
                                        valueSql = $"'{value.ToString().Replace("'", "''")}'";

                                    whereClauses.Add($"[{col.Trim()}] = {valueSql}");
                                }

                                string whereSql = string.Join(" AND ", whereClauses);
                                string checkSql = $"SELECT COUNT(*) FROM [{tableName}] WHERE {whereSql}";

                                int exists = 0;
                                using (var checkCmd = new Microsoft.Data.SqlClient.SqlCommand(checkSql, sqlConn))
                                {
                                    try
                                    {
                                        exists = (int)checkCmd.ExecuteScalar();
                                    }
                                    catch (Exception ex)
                                    {
                                        // Trate erro de verificação
                                    }
                                }

                                if (exists == 0)
                                {
                                    var columnsSql = string.Join(",", Enumerable.Range(0, dataReader.FieldCount).Select(i => $"[{dataReader.GetName(i).Trim()}]"));
                                    var valuesList = new List<string>();
                                    for (int i = 0; i < dataReader.FieldCount; i++)
                                    {
                                        object value = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);

                                        if (value is sbyte || value is byte || value is ushort)
                                            value = Convert.ToInt32(value);
                                        else if (value is short || value is int || value is long || value is float || value is double || value is decimal)
                                            value = Convert.ToDecimal(value);
                                        else if (value is bool)
                                            value = ((bool)value) ? 1 : 0;
                                        else if (value is byte[])
                                        {
                                            // Converte byte[] para hexadecimal (exemplo para SQL Server)
                                            var bytes = (byte[])value;
                                            value = "0x" + BitConverter.ToString(bytes).Replace("-", "");
                                        }
                                        else if (value == null)
                                            value = "NULL";
                                        else if (value is string || value is DateTime)
                                        {
                                            string strValue = value?.ToString();
                                            if (value is DateTime)
                                            {
                                                if (strValue != null && int.TryParse(strValue.Substring(0, 2), out int prefix) && prefix >= 10 && prefix <= 18)
                                                {
                                                    value = "20" + strValue.Substring(2);
                                                }
                                                value = value.ToDateTimeValue();
                                            }
                                            if (strValue != null && strValue.Length >= 5 && int.TryParse(strValue.Substring(0, 4), out _) && strValue[4] == '-')
                                            {
                                                if (int.TryParse(strValue.Substring(0, 2), out int prefix) && prefix >= 10 && prefix <= 18)
                                                {
                                                    value = "20" + strValue.Substring(2);
                                                }
                                            }
                                            value = $"'{value.ToString().Replace("'", "''")}'";
                                        }
                                        else
                                            value = $"'{value.ToString().Replace("'", "''")}'"; // trata outros tipos como string

                                        valuesList.Add(value.ToString());
                                    }
                                    var valuesSql = string.Join(",", valuesList);
                                    var insertSql = $"INSERT INTO [{tableName}] ({columnsSql}) VALUES ({valuesSql})";
                                    using var insertCmd = new Microsoft.Data.SqlClient.SqlCommand(insertSql, sqlConn);
                                    try
                                    {
                                        var ret = insertCmd.ExecuteNonQuery();
                                        if (ret > 0)
                                        {
                                            // Sucesso
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // Trate erro de insert
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Dados importados para {ex.Message}.");
                            }
                        }
                    }
                    Console.WriteLine($"Dados importados para {tableName}.");
                }
                catch (Exception ex)
                {
                    // Trate erro da tabela
                }
            }
            return Ok(serviceResponse);
        }
        [HttpPost("GetEntityWithChildrenfgfgfg")]
        public async Task<IActionResult> GetEntityWithChildrenfgfgfg([FromBody] EntityRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.EntityStamp) || string.IsNullOrWhiteSpace(request.TableName))
                return BadRequest("Request inválido.");

            // Descobre o tipo pelo nome da tabela
            var assembly = typeof(Exemplo).Assembly;
            Type? type = assembly.GetTypes().FirstOrDefault(t => t.Name.Equals(request.TableName, StringComparison.OrdinalIgnoreCase));
            if (type == null)
                return BadRequest(new { error = "Tipo não encontrado." });

            // Descobre o nome do campo de chave primária
            PropertyInfo? pkProp = type.GetProperties()
                .FirstOrDefault(p => p.GetCustomAttributes(typeof(KeyAttribute), true).Any());
            if (pkProp == null)
                return BadRequest(new { error = "Chave primária não encontrada na entidade." });
            string pkColumn = pkProp.Name;
            object? entity;
            using (var connection = new SqlConnection(SqlConstring.GetSqlConstring()))
            {
                await connection.OpenAsync();
                // Busca o registro principal
                var mainQuery = $"SELECT * FROM {request.TableName} WHERE {pkColumn} = @entityStamp";
                entity = connection.QueryFirstOrDefault(type, mainQuery, new { entityStamp = request.EntityStamp });
                if (entity == null)
                    return NotFound($"Entidade não encontrada na tabela {request.TableName} com stamp {request.EntityStamp}");

                // Busca coleções relacionadas dinamicamente
                foreach (var property in type.GetProperties())
                {
                    // Suporta ICollection<T>, IEnumerable<T>, List<T>
                    if (property.PropertyType.IsGenericType)
                    {
                        var genericDef = property.PropertyType.GetGenericTypeDefinition();
                        if (genericDef == typeof(ICollection<>) ||
                            genericDef == typeof(IEnumerable<>) ||
                            genericDef == typeof(List<>))
                        {
                            var collectionType = property.PropertyType.GetGenericArguments()[0];
                            var collectionTableName = collectionType.Name;

                            //Procura o atributo[ForeignKey] OU por convenção(ex: Factstamp)
                            var fkProp = collectionType.GetProperties()
                                .FirstOrDefault(p =>
                                    p.GetCustomAttributes(typeof(ForeignKeyAttribute), true)
                                        .Cast<ForeignKeyAttribute>()
                                        .Any(attr => attr.Name.Equals(type.Name, StringComparison.OrdinalIgnoreCase)) ||
                                    p.Name.Equals(pkColumn, StringComparison.OrdinalIgnoreCase) ||
                                    p.Name.Equals(type.Name + "stamp", StringComparison.OrdinalIgnoreCase) ||
                                    p.Name.Equals(type.Name + "Id", StringComparison.OrdinalIgnoreCase)
                                );
                            //PropertyInfo? fkProp = collectionType.GetProperty(pkColumn, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            if (fkProp == null)
                                continue; // Não encontrou FK, pula

                            string fkColumn = fkProp.Name;
                            var collectionQuery = $"SELECT * FROM {collectionTableName} WHERE {fkColumn} = @entityStamp";
                            var rawCollection = connection.Query(collectionType, collectionQuery, new { entityStamp = request.EntityStamp }).ToList();

                            // Faz o cast para o tipo correto
                            var castMethod = typeof(Enumerable).GetMethod(nameof(Enumerable.Cast))!
                                .MakeGenericMethod(collectionType);
                            var casted = castMethod.Invoke(null, new object[] { rawCollection });

                            // Cria a lista do tipo correto
                            var listCtor = typeof(List<>).MakeGenericType(collectionType)
                                .GetConstructor(new[] { typeof(IEnumerable<>).MakeGenericType(collectionType) });
                            var castedCollection = listCtor!.Invoke(new[] { casted });

                            property.SetValue(entity, castedCollection);
                        }
                    }
                }

            }

            return Ok(entity);
        }
        
        [HttpGet("GetFacts")]
        public async Task<ActionResult<IEnumerable<Fact>>> GetFacts()
        {
            try
            {
                var facts = await _usrService.GetFactsAsync();
                return Ok(facts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar os dados: {ex.Message}");
            }
        }
        [HttpPost("CreateFact")]
        public async Task<ActionResult<IEnumerable<Fact>>> CreateFact([FromBody] object obj)
        {
            try
            {
                var facts = await _usrService.GetFactsAsync();
                return Ok(facts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar os dados: {ex.Message}");
            }
        }
        [HttpGet("{factstamp}")]
        public async Task<ActionResult<Fact>> GetFactWithChildren(string factstamp)
        {
            try
            {
                var fact = await _usrService.GetFactWithChildrenAsync(factstamp);
                if (fact == null)
                {
                    return NotFound($"Fact com stamp '{factstamp}' não encontrado.");
                }
                return Ok(fact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar o Fact: {ex.Message}");
            }
        }
        [HttpGet]
        [Route("GetStWithChildren")]
        public async Task<ActionResult<St>> GetStWithChildren(string ststamp)
        {
            try
            {
                string[] excludedProperties = { "Imagem", "Codigobarra", "CodigoQr" };
                // Exemplo para a entidade Fact, ignorando "Fax" e "Email"
                string query = SQL.GenerateSelectQuery<St>(excludedProperties);
                // Resultado: SELECT Factstamp, Numdoc, Tdocstamp, Sigla, Numero, Data, Dataven, DataAprovacao, No, Nome, Morada, Telefone, Nuit FROM Fact

                var fact = SQL.GetGenDt($"{query} where ststamp='{ststamp}'").DtToList<St>().FirstOrDefault();
                if (fact == null)
                {
                    return NotFound($"St com stamp '{ststamp}' não encontrado.");
                }
                return Ok(fact);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar o Fact: {ex.Message}");
            }
        }
        [HttpDelete("{factstamp}")]
        public async Task<IActionResult> DeleteFact(string factstamp)
        {
            try
            {
                var result = await _usrService.DeleteFactAsync(factstamp);
                if (!result)
                {
                    return NotFound($"Fact com stamp '{factstamp}' não encontrado.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar o Fact: {ex.Message}");
            }
        }
        [HttpGet("getfield")]
        public async Task<IActionResult> GetFieldArray([FromQuery] string campo, [FromQuery] string tabela, [FromQuery] string condicao = "")
        {
            try
            {
                ServiceResponse<object> rsp = new ServiceResponse<object>();
                string qry = string.IsNullOrWhiteSpace(condicao)
                    ? $"SELECT {campo} FROM {tabela}"
                    : $"SELECT {campo} FROM {tabela} WHERE {condicao}";
                var dt = SQL.GetGenDt(qry);

                if (!dt.HasRows())
                    return Ok(rsp);

                var resultados = new List<object>();
                foreach (DataRow row in dt.Rows)
                {
                    var dict = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        dict[col.ColumnName] = row[col];
                    }
                    resultados.Add(dict);
                }
                rsp.Dados = resultados;
                rsp.Mensagem = "";
                rsp.Sucesso = true;
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha");
            }
        }
        
        [HttpPost]
        [Route("GetCc")]
        public async Task<ActionResult<ServiceResponse<Mdnviewgrelha>>> GetCc([FromBody] Selects item)
        {

            var campos = item.Descricao;
            var tabela = item.Ordem;//clstamp
            var condicoes = item.Chave;//trclstamp
            var txt = await _usrService.ComboboxesMdn(campos, tabela, condicoes);
            return Ok(txt);
        }
        [HttpPost]
        [Route("GenDt")]
        public async Task<ActionResult<DataTable>> GenDt([FromBody] Selects item)
        {

            var txt = SQL.GetGenDt(item.Descricao);
            return Ok(txt);
        }
        [HttpPost]
        [Route("Procurar")]
        public async Task<IActionResult> Procurar([FromBody] SharedClasses.Procura pro)
        {

            PaginationResponseBl<List<SharedClasses.Procura>> rsp = null;
            try
            {
                rsp = await _usrService.Procurar(pro.Tabela, pro.Campo, pro.Campo1,
                    pro.Camposseleccionados, pro.Valorprocurado,
                    pro.CurrentNumber, pro.Pagesize, pro.Condicoes); ;
                rsp.Status = true;
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            IActionResult manc = Ok(rsp);
            rsp = null;
            return manc;
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<ActionResult<ServiceResponse<Selects>>> Delete([FromBody] Condicoesprocura set)
        {
            var respos = new ServiceResponse<Selects>();
            var tabela = set.Tabela;
            var condicao = set.Condicao;
            try
            {

                var txst = SQL.SqlCmd($"delete {tabela} where {condicao}");
                if (txst > 0)
                {
                    respos.Dados = new Selects();
                    respos.Dados.Ordem = respos.Dados.Descricao = respos.Dados.Chave = "";
                    respos.Sucesso = true;
                    respos.Mensagem = "";
                    return Ok(respos);
                }
                respos.Dados = new Selects();
                respos.Sucesso = false;
                respos.Mensagem = "";
                return Ok(respos);
            }
            catch (Exception ex)
            {
                respos.Dados = new Selects();
                respos.Sucesso = false;
                respos.Mensagem = ex.Message;
                return Ok(respos);
            }
        }
        [HttpPost]
        [Route("GetMax")]
        public async Task<ActionResult<ServiceResponse<Selects>>> GetMax([FromBody] Condicoesprocura set)
        {
            var respos = new ServiceResponse<Selects>();
            var tabela = set.Tabela;
            var campo1 = set.Campo1;
            var condicao = set.Condicao;
            try
            {
                var txt = SQL.VMax(campo1, tabela, condicao);
                respos.Dados = new Selects();
                respos.Dados.Ordem = txt.ToString(CultureInfo.InvariantCulture);
                respos.Dados.Descricao = respos.Dados.Chave = "";
                respos.Sucesso = true;
                respos.Mensagem = "";
                return Ok(respos);
            }
            catch (Exception ex)
            {
                respos.Dados = new Selects();
                respos.Sucesso = false;
                respos.Mensagem = ex.Message;
                return Ok(respos);
            }
        }


        [HttpPost]
        [Route("ComboboxesPost")]
        public async Task<ActionResult<ServiceResponse<Selectview>>> ComboboxesPost([FromBody] Condicoesprocura set)
        {
            var tabela = set.Tabela;
            var campo1 = set.Campo1;
            var campo2 = set.Campo2;
            var condicao = set.Condicao;
            var txt = await _usrService.Comboboxes(tabela, campo1, campo2, condicao, set.Campochave);
            return Ok(txt);
        }
        [HttpPost]
        [Route("ComboboxesPost17")]
        public async Task<ActionResult<ServiceResponse<Selectview>>> ComboboxesPost17([FromBody] Condicoesprocura set)
        {
            var tabela = set.Tabela;
            var campo1 = set.Campo1;
            var campo2 = set.Campo2;
            var condicao = set.Condicao;
            var campochave = set.Campochave;
            var txt = await _usrService.Comboboxes17(tabela, campo1, campo2, condicao, campochave);
            return Ok(txt);
        }

       
        [HttpPost]
        [Route("MetodoGenerico")]
        public async Task<IActionResult> MetodoGenerico([FromBody] SharedClasses.Procura pro)
        {
            PaginationResponseBl<object> rsp = null;
            try
            {
                var entradastamp = pro.Referencia;
                var orderby = pro.Alunoestamp;
                rsp = await _usrService.MetodoGenerico(pro.Tabela, pro.Campo, pro.Campo1,
                    pro.Camposseleccionados, pro.Valorprocurado,
                    pro.CurrentNumber, pro.Pagesize, pro.Usuario, pro.Condicoes, orderby, entradastamp);

                rsp.Status = true;
            }
            catch (Exception ex)
            {
                rsp = new PaginationResponseBl<object>(0, null, 1, 5);
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            IActionResult manc = Ok(rsp);
            rsp = null;
            return manc;
        }
        [HttpPost]
        [Route("ObterDestinatarios")]
        public async Task<IActionResult> ObterDestinatarios([FromBody] object logins)
        {

            var pro = new Usuario();
            try
            {
                var ddd = JsonConvert.SerializeObject(logins);
                pro = JsonConvert.DeserializeObject<Usuario>(ddd);
            }
            catch (Exception)
            {
                //
            }
            ServiceResponse<List<Unidade>> rsp = new ServiceResponse<List<Unidade>>();
            try
            {

                var Condivvv = SQL.UnidadDirecDiferenteDaMinha(pro);
                var qry = $@"select distinct * from(
                          select distinct 
                          descricao,upper('MINISTÉRIO DA DEFESA NACIONAL') orgao,convert(bit,0)cibm from busca sd  where numTabela=47
                           )temp 
                          group by orgao,descricao,cibm order by descricao asc";
                rsp.Dados = SQL.GetGenDt(qry).DtToList<Unidade>();
                if (rsp.Dados == null)
                {
                    var proe = SQL.DoAddline<Unidade>();
                    var lista = new List<Unidade> { proe };
                    rsp.Dados = lista;
                }
                rsp.Sucesso = true;
                rsp.Mensagem = "";
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult manc = Ok(rsp);
            rsp = null;
            return manc;
        }


        [HttpPost]
        [Route("ObterProcssss")]
        public async Task<IActionResult> ObterProcssss([FromBody] object logins)
        {

            var pro = new Usuario();
            try
            {
                var ddd = JsonConvert.SerializeObject(logins);
                pro = JsonConvert.DeserializeObject<Usuario>(ddd);
            }
            catch (Exception)
            {
                //
            }
            ServiceResponse<List<Processo>> rsp = new ServiceResponse<List<Processo>>();
            try
            {
                var qry = $"select distinct * from vProcessos where PaStamp='{pro.Alterou}' order by Assunto asc";
                rsp.Dados = SQL.GetGenDt(qry).DtToList<Processo>();
                if (rsp.Dados == null)
                {
                    var proe = SQL.DoAddline<Processo>();
                    var lista = new List<Processo> { proe };
                    rsp.Dados = lista;
                }
                rsp.Sucesso = true;
                rsp.Mensagem = "";
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult manc = Ok(rsp);
            rsp = null;
            return manc;
        }




        
        [HttpPost]
        [Route("GetTotais")]
        public async Task<IActionResult> GetTotais([FromBody] object logins)
        {
            Usuario login = new Usuario();
            try
            {
                var ddd = JsonConvert.SerializeObject(logins);
                login = JsonConvert.DeserializeObject<Usuario>(ddd);
            }
            catch (Exception)
            {
                //
            }

            List<ISelectsProcura> rsp = new List<ISelectsProcura>();
            try
            {
                var condicaoentrdaa = "1=1";
                var conmdicapsaida = "1=1";
                if (!login.Orgao.IsNullOrEmpty())
                {
                    // condicaoentrdaa += $" OrgaoUtilizador='{login.Orgao}'";
                    // conmdicapsaida += $" OrgaoorigemNaSaida='{login.Orgao}'";
                    if (!login.Direcao.IsNullOrEmpty())
                    {
                        //conmdicapsaida += $" and DirecaoOrigemNaSaida='{login.Direcao}'";
                        //condicaoentrdaa += $" and DirecUtilizador='{login.Direcao}'";
                    }
                }
                else
                {
                    //conmdicapsaida = condicaoentrdaa = "1=0";
                }
                var query = $@"select * from vDashboard";
               // var dt = SQL.GetGenDt(query);
                List<ISelectsProcura> list = new List<ISelectsProcura>();
                var dados = SQL.InicializarDados<ISelectsProcura>();
                dados.Amount = 0;// dt.RowZero("naohomologadas").ToDecimal();
                dados.Color = "bg-red-500";
                dados.Title = "Total não homologadas";
                dados.Progress.Value = 0;// dt.RowZero("naohomologadas").ToDecimal();
                list.Add(dados);

                dados = SQL.InicializarDados<ISelectsProcura>();
                dados.Amount = 0;// dt.RowZero("pendentes").ToDecimal();
                dados.Color = "bg-red-500";
                dados.Title = "Total pendentes";
                dados.Progress.Value = 0;//dt.RowZero("pendentes").ToDecimal();
                list.Add(dados);

                dados = SQL.InicializarDados<ISelectsProcura>();
                dados.Amount = 0;// dt.RowZero("emtramitacao").ToDecimal();
                dados.Color = "bg-blue-500";
                dados.Title = "Total em tramitação";
                dados.Progress.Value = 0;//dt.RowZero("emtramitacao").ToDecimal();
                list.Add(dados);
                dados = SQL.InicializarDados<ISelectsProcura>();
                dados.Amount = 0;// dt.RowZero("homologadas").ToDecimal();
                dados.Color = "bg-indigo-500";
                dados.Title = "Total homologadas";
                dados.Progress.Value = 0;// dt.RowZero("homologadas").ToDecimal();
                list.Add(dados);
                rsp = list;
                IActionResult manc = Ok(rsp);
                rsp = null;
                return manc;

            }
            catch (Exception ex)
            {
            }
            return Ok(rsp);

        }
        [HttpGet]
        [Route("LeituraDeFicheiros")]
        public async Task<object> LeituraDeFicheiros(string ficheiro = "Pdf")
        {

            try
            {
                var prt = $"{_webHost.ContentRootPath}";
                var pt1 = Path.Combine(prt, "Ficheiros", ficheiro);
                if (System.IO.File.Exists($"{pt1}"))
                {
                    var btes = await System.IO.File.ReadAllBytesAsync($"{pt1}");
                    string extension = Path.GetExtension(ficheiro);
                    switch (extension.ToLower())
                    {
                        case ".jpeg":
                        case ".jpg":
                        case ".png":
                            return File(btes, MediaTypeNames.Image.Jpeg);
                        case ".tiff":
                            return File(btes, MediaTypeNames.Image.Tiff);
                        case ".gif":
                            return File(btes, MediaTypeNames.Image.Gif);
                        case ".pdf":
                            return File(btes, MediaTypeNames.Application.Pdf);
                        default:
                            return File(btes, MediaTypeNames.Application.Octet);
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
            return null;
        }



        static readonly Cryptografia _objCrypto = new();
        [HttpPost]
        [Route("GetPreencheCampos")]
        public async Task<ActionResult<ServiceResponse<object>>> GetFact([FromBody] object logins)
        {

            var item = new Usuario();
            try
            {
                var ddd = JsonConvert.SerializeObject(logins);
                item = JsonConvert.DeserializeObject<Usuario>(ddd);
            }
            catch (Exception)
            {
                //
            }
            ServiceResponse<object> rsp = new ServiceResponse<object>();
            if (item.Senha != null)
            {

                var senha = "";
                //var senhacripta = _objCrypto.Crypto("Alda3.".Trim(), true);
                //SQL.SqlCmd($"update Usuario set senha='{senhacripta}' where senha='Alda3.'");

                try
                {
                    senha = _objCrypto.Crypto(item.Senha.Trim(), false);
                }
                catch (Exception e)
                {
                    senha = item.Senha.Trim();
                }
                rsp.Sucesso = true;
                rsp.Mensagem = "";
                item.Senha = senha;
            }
            rsp.Dados = item;
            return await Task.FromResult(rsp);
        }



    }
}
