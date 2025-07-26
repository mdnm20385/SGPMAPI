using DAL.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model.Models.SJM;
using Model.Models;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using ArrayToPdf;
using DAL.Conexao;
using Model.Models.Facturacao;
using Param = Model.Models.Param;
using Processo = Model.Models.SJM.Processo;
using Usr = Model.Models.Usr;

namespace DAL.Classes
{

    public static class Pbl
    {
        #region JUNTAS
        
        public static void Anexo<T>(List<T> lista, string assunto = "", string corpo = "")
        {
            try
            {
                ListtoDataTableConverter vv = new ListtoDataTableConverter();
                var nome = typeof(T).Name.ToLower();
                var campos = new[]
                {
                "Datafim","Datain","Descricao","Numero",
                    "Situacao","Prazo"
                };





                var dt = vv.ToDataTable(lista);
                var pdf = dt.AsEnumerable().ToPdf();
                if (nome.Equals("tarefa"))
                {
                    pdf = vv.ToDataTable(lista).DefaultView.ToTable(true, campos).AsEnumerable()
                        .CopyToDataTable().ToPdf();
                }
                Thread.Sleep(10);
                var dr = DateTime.Now;
                var conca = dr.Year + dr.Month + dr.Day + dr.Hour + dr.Minute + dr.Second + dr.Millisecond.ToString();
                if (!Directory.Exists(@"C:\invoices"))
                {
                    Directory.CreateDirectory(@"C:\invoices");
                }
                var path = $"C:\\invoices\\result{conca}" + ".pdf";
                File.WriteAllBytes(path, pdf);
                if (!File.Exists(path))
                {
                    return;
                }
                //System.IO.File.Copy("","",true);
                string[] columnNames = { path };
                var aAnexosEmail = new ArrayList();
                aAnexosEmail.AddRange(columnNames);
                if (aAnexosEmail.Count > 0)
                {
                    if (Applicantss != null)
                        for (int i = 0; i < Applicantss.Count; i++)
                        {
                            if (Applicantss[i].Outgoingemail.ToLower().Contains("zuca"))
                            {
                                continue;
                            }
                            Outgoingemail = Applicantss[i].Outgoingemail;
                            Outgoingpassword = Applicantss[i].Outgoingpassword;
                            Smtpserver = Applicantss[i].Smtpserver;
                            Classes.EnviarEmail.EnviaEmail.EnviaMensagemComAnexos(Outgoingemail,
                                assunto, corpo,
                                aAnexosEmail);
                        }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        public static string roopah = string.Empty;
        public static void EnviarEmail(List<EmailClass> email = null, string path = "", string assunto = "", string corpo = "")
        {
            try


            {
                //System.IO.File.Copy("","",true);


                string filePath = Path.Combine(roopah, path);
                string[] columnNames = { filePath };
                var aAnexosEmail = new ArrayList();
                aAnexosEmail.AddRange(columnNames);
                if (aAnexosEmail.Count > 0)
                {

                    if (email != null && Applicantss.Count > 0)
                    {
                        Outgoingpassword = Applicantss?[0].Outgoingpassword;
                        Smtpserver = Applicantss[0].Smtpserver;
                    }


                    if (email != null)
                        for (int i = 0; i < email.Count; i++)
                        {
                            if (email[i].RecebeEmailTare)
                            {
                                Outgoingemail = email[i].Email;

                                var ret = Classes.EnviarEmail.EnviaEmail.EnviaMensagemEmail(Outgoingemail, Outgoingemail, assunto, corpo);


                                //EnviaEmail.EnviaMensagemComAnexos(Outgoingemail,
                                //    assunto, corpo,
                                //    aAnexosEmail);
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                //
            }

        }
        //Sigex
        public static string Encrypta(string encodeMe)
        {
            if (encodeMe.IsNullOrEmpty())
            {
                encodeMe = "";
            }
            encodeMe = Keys + encodeMe;
            byte[] encoded = global::System.Text.Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }
        //Sigex
        public static string Decrypta(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            var getter = Encoding.UTF8.GetString(encoded).Replace(Keys, "");
            return getter;
        }
        public static T SetDefaultSave<T>(T f)
        {
            var t = f;
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {

                var valor = p.GetValue(t);
                if (p.PropertyType == typeof(DateTime))
                {
                    if (valor is DBNull)
                    {
                        valor = new DateTime(1900, 1, 1);
                    }
                    if (valor.ToString().Contains("0001"))
                    {
                        valor = new DateTime(1900, 1, 1);
                    }
                }
                if (p.PropertyType == typeof(string))
                {
                    if (string.IsNullOrEmpty(valor?.ToString()))
                    {
                        valor = "";
                    }

                }
                if (p.PropertyType == typeof(decimal))
                {
                    if (valor is DBNull)
                    {
                        valor = 0;
                    }
                }
                if (p.PropertyType == typeof(int))
                {
                    if (valor is DBNull)
                    {
                        valor = 0;
                    }
                }
                if (p.PropertyType == typeof(bool))
                {
                    if (valor is DBNull)
                    {
                        valor = false;
                    }
                }
                if (p.PropertyType == typeof(byte[]))
                {

                    if (valor is DBNull)
                    {
                        valor = 0;
                    }
                }
                p.SetValue(t, valor);
            }
            return t;
        }


        #region Variáveis de formatação do texto
        static string fontSize = "16";
        static string textAlignment = "justify";
        static string lineSpacing = "1.5";
        static string formatacao { get; set; } = "<p style=\"text-align:" + textAlignment + "; " +
                                                 "line-height:" + lineSpacing + ";margin-top: 0.5;margin-bottom: 0.5; font-size:" + fontSize + "px\">";
        #endregion

        public static string Formatacao { get; set; } = formatacao;

        public static void MyStringBuilder(DataTable dt)
        {
            string st = string.Empty;
            var sb2 = new StringBuilder();
            sb2.Append(@"{\rtf1\ansi");
            if (dt.Rows.Count > 0)
            {
                string sss = "A Junta Médica Militar Principal composta de: ";
                var composicao = Formatacao + $" {sss} </p>";
                var pref2 = string.Empty;
                var pref = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["sexo"].ToString().ToUpper().Equals("FEMININO"))
                    {
                        pref = $"{i + 1}. Dra. {dt.Rows[i]["nome"]}";
                    }
                    if (!dt.Rows[i]["sexo"].ToString().ToUpper().Equals("Feminino".ToUpper()))
                    {
                        pref = $"{i + 1}. Dr. {dt.Rows[i]["nome"]}";
                    }
                    if (i == 0)
                    {
                        sb2.Append($@" \b ASSINATURAS: \b0 ");
                        sb2.Append(@" \line  ");
                    }
                    pref2 += Formatacao + $" {pref} </p>";
                    sb2.Append($@" {i + 1}._________________________________________________________________________ ");
                    sb2.Append(@"\line\line");
                }
                sb2.Append(@"}");
                st = composicao + pref2;
                var drt = sb2.ToString();
            }
        }


        private static Classes.Conexao conexao = new Classes.Conexao();
        public static List<SelectListItem> ListaDire()
        {
            List<SelectListItem> selectgender = conexao.Pesquisar("Select * from Dir order by Descricao").DtToList<Dir>().Select(n =>
                new SelectListItem
                {
                    Value = n.Dirstamp.ToString(),
                    Text = n.Descricao
                }).ToList();
            return selectgender;
        }
        public static List<SelectListItem> ListaDirDep()
        {
            List<SelectListItem> selectgender = conexao.Pesquisar("Select * from Dirdep order by Descricao").DtToList<Dirdep>().OrderBy(n => n.Descricao).Select(n =>
                new SelectListItem
                {
                    Value = n.Dirdepstamp,
                    Text = n.Descricao
                }).ToList();

            return selectgender;
        }
        public static List<SelectListItem> ListaPerf()
        {
            List<SelectListItem> selectgender = conexao.Pesquisar("Select * from UserType order by UserTypeDescription").DtToList<UserType>().OrderBy(n => n.UserTypeDescription).Select(n =>
                new SelectListItem
                {
                    Value = n.UserTypeDescription,
                    Text = n.UserTypeDescription
                }).ToList();

            return selectgender;
        }
        public static SGPMContext _context;
        public static List<Param>? Applicantss;


      
        public static string Encode(string encodeMe)
        {
            encodeMe = Keys + encodeMe;
            byte[] encoded = global::System.Text.Encoding.UTF8.GetBytes(encodeMe);
            return Convert.ToBase64String(encoded);
        }
        public static string Decode(string decodeMe)
        {
            byte[] encoded = Convert.FromBase64String(decodeMe);
            var getter = Encoding.UTF8.GetString(encoded).Replace(Keys, "");
            return getter;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        #region SJM Tables


        public static DClinicos Pasa { get; set; }
        public static List<ParamAno> ParamAno { get; set; }
        public static Usuario Usuario { get; set; }
        public static List<Busca> Busca { get; set; }
        public static List<DClinicos> DClinico { get; set; }
        public static List<Orgao1> Orgao { get; set; }
        public static List<Unidade> Unidade { get; set; }
        public static List<Subunidade> Subunidade { get; set; }
        public static List<Pa> Pa { get; set; }
        public static List<paDoc> paDoc { get; set; }

        public static List<Provincia> Provincia { get; set; }
        public static List<Distrito> Distrito { get; set; }
        public static List<PostAdm> PostAdm { get; set; }//UserType
        public static List<Localidade> Localidade { get; set; }//UserType
        public static List<Permissao> Permissao { get; set; }//UserType
        public static List<PermForm> PermForm { get; set; }
        public static List<Ramo1> Ramo { get; set; }
        public static List<UsuarioSessao> UsuarioSessao { get; set; }
        public static List<Cat> Cat { get; set; }
        public static List<Processo> Processo { get; set; }
        public static List<Pais> Pai { get; set; }

        public static string? SexoDirector { get; set; }
        public static string? SexoChefe { get; set; }
        public static Processo procs { get; set; }

        #endregion
        #endregion

        public static DataTable ContasEmpresa { get; set; }


        public static List<SelectListItem> GetProducts()
        {
            var dtIva = SQL.GetGenDt("SELECT   Ststamp,Descricao from St");
            return dtIva.GetComboItens("Escolha o produto");

        }
        public static List<SelectListItem> GetTaxaIva2(string? selected = "")
        {
            var dtIva = SQL.GetGenDt("select   Codigo,Descricao from Auxiliar where tabela = 5 order by Codigo");
            return dtIva.GetComboItens("", "", selected);
        }
        public static List<SelectListItem> GetTaxaIva(string? selected = "")
        {
            var dtIva = SQL.GetGenDt("select   Descricao,Descricao from Auxiliar where tabela = 5 order by Codigo");
            return dtIva.GetComboItens("", "", selected);
        }
        public static List<SelectListItem> GetCcusto(string? selected = "")
        {
            var dtIva = SQL.GetGenDt("SELECT   Ccustamp,Descricao from CCu");
            return dtIva.GetComboItens("", "", selected);
        }

        public static List<SelectListItem> GetGeralTabela(string tabela, string campos = "",
            string condicao = "", string? selected = "", string selecionaespacovaziopadrao = "")
        {
            if (!condicao.IsNullOrEmpty())
            {
                condicao = $" where {condicao}";
            }
            if (!string.IsNullOrEmpty(campos))
            {
                campos = $"{campos}";
            }
            else
            {
                campos = $"{tabela}stamp,Descricao{campos}";
            }
            var names = SQL.GetGenDt($@"Select  {campos} from {tabela} {condicao}");
            return names.GetComboItens(selecionaespacovaziopadrao, "sele", selected);
        }

        public static string ConnectionString { get; set; }

        public static List<SelectListItem> Getwithownquery(string qry, string? selected = "")
        {

            var dt = SQL.GetGenDt(qry);
            return dt.GetComboItens("Nao selecionanda", "sele", selected);
        }
        public static List<SelectListItem> GetTdoc(string tabela = "", string? selected = "")
        {
            if (string.IsNullOrEmpty(tabela))
            {
                tabela = "Tdoc";
            }
            var names = SQL.GetGenDt($@"Select  {tabela}stamp,Descricao from {tabela}");
            return names.GetComboItens("", "sele", selected);
        }

        public static List<SelectListItem> GetTRcl(string tabela = "")
        {
            var con = "sele";
            if (string.IsNullOrEmpty(tabela))
            {
                tabela = "TRcl";
            }
            else
            {
                con = tabela;
            }
            var names = SQL.GetGenDt($"Select   {tabela}stamp,Descricao from {tabela}");
            return names.GetComboItens("", con = tabela);
        }
        public static List<SelectListItem> GetCList()
        {
            var selectgender = SQL.GetGenDt("Select   Clstamp,Nome from cl").GetComboItens("Meticais");

            return selectgender;
        }
        public static List<SelectListItem> GetPoCurrencies()
        {
            var selectgender = SQL.GetGenDt("Select   descricao,descricao from moedas").GetComboItens("Meticais", "moedas");

            return selectgender;
        }
        public static List<SelectListItem> GetBaseCurrencies()
        {
            var selectgender = SQL.GetGenDt("Select   descricao,descricao from moedas").GetComboItens("Meticais");

            return selectgender;
        }
        public static List<SelectListItem> GetExchangeRate()
        {
            var selectgender = SQL.GetGenDt("Select   descricao,descricao from moedas").GetComboItens("Meticais");

            return selectgender;
        }
        
        public static List<Tdoc> Tdoc { get; set; } //= new List<Tdoc>();
        #region Região de Definição de Propriedades Públicas 

        public static string ToSqlDate(this DateTime value)
        {
            var sqldata = value.ToString("yyyy-MM-dd");
            return sqldata.Trim();//2019-05-01
        }

        public static string ToSqlDate104(this DateTime value)
        {
            var sqldata = value.ToString("dd.MM.yyyy");
            return sqldata.Trim();
        }
        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));
        }
        #endregion
        public static Usr? Usr { get; set; } = SQL.GetRowToEnt<Usr>("usrstamp='635D20197DMZ4121045'");



        public static string Info2 = "DMZ SOFTWARE 2022";
        public static string Info = "DMZ Software v.2022";
        public static bool MYSQLMode;
        public static DataSet? DS;
        public static string? Id { get; set; }
        public static SGPMContext? Context { get; set; }
        [Display(Name = "Ficheiro")]
        [NotMapped]
        public static IFormFile ProfilePhoto { get; set; }
        public static string DescricaoGeral;
        public static class EstadosDeProcesso
        {
            public static string Homologada => "Homologada";
            public static string NaoHomologada => "Não Homologada";
            public static string EmTramitacao => "Em Tramitação";
            public static string Pendente => "Pendente";
        }
        public static string? LimiteDecimal { get; set; } = "Invalid Target Price; Max 18 digits";
        public static string? ConString { get; set; } = string.Empty;
        public static string Outgoingpassword { get; set; } = "siupmexnfdpgedzi";
        public static string Outgoingemail { get; set; } = "dmzprogect@gmail.com";
        public static string Outgoingpassword1 { get; set; } = "siupmexnfdpgedzi";
        public static string Outgoingemail1 { get; set; } = "dmzprogect@gmail.com";
        public static string? Smtpserver { get; set; } = "smtp.gmail.com";
        public static int Smtpport { get; set; } = 587;
        public static string TarefasStamp { get; set; }
        public static string DirecaoGeral { get; set; }
        public static string? DocGeral { get; set; }
        public static string? NomeTarefa { get; set; }
        public static string? DirDepStamp { get; set; }
        public static string? DirStamp { get; set; }
        public static string? UserTypeDescription { get; set; }
        public static bool Visualizainformaclassificada { get; set; }
        public static Usuario UsuarioLogado { get; set; }
        public static Pa Pessoa { get; set; }
        static string Keys = "MAKV2SPBNI99212Aniva18356Hoje";
        public static string pathpadra;
        public static string EstadoJunta { get; set; }
        public static string ProcessoStamp { get; set; }
        public static string Mensagem { get; set; }
        public static string? NomeChefe { get; set; }
        public static string? PatenteCategoria { get; set; }
        public static string? NomeDirector { get; set; }
        public static string CorpoMensagem { get; set; }
        public static string TextJuntas { get; set; }
        public static string AssinaturaHtml { get; set; }
        public static string DclinicosCorpoMensagem { get; set; }
        public static string? Protocolo { get; set; }
        public static string NomeUserLogado { get; set; }
        public static bool ConselhoTenico { get; set; } = false;
        public static bool VerSitClass { get; set; }
        public static DataTable? DtProcessosPendetes { get; set; }
        public static string CaminhoRota { get; set; } = "";
        public static string? Rota { get; set; }
        public static string? RotaId { get; set; }
        public static List<Unidade> SaidaProcesso1224242 { get; set; }
        public static string Entradastamp { get; set; }
        public static string Rdlcstamp()
        {
            Thread.Sleep(10);
            var moment = DateTime.Now;
            // Year gets 1999.
            var year = moment.Year;
            // Month gets 1 (January).
            var month = moment.Month;
            // Day gets 13.
            var day = moment.Day;
            // Second gets 32.
            var second = moment.Second;
            // Millisecond gets 11.
            var millisecond = moment.Millisecond;

            var stamp = millisecond + "" + year + month + day + second;
            return stamp;
        }
        public static string? MoedaBase { get; set; } = "MZN";
        public static bool CtExpirado { get; set; }
        //public static bool GesExpirado { get; set; } 
        public static bool RhsExpirado { get; set; }
        public static string VersaoActivo { get; set; } = "MZN";
        public static decimal URh { get; set; }
        public static decimal UCt { get; set; }
        public static decimal UGes { get; set; }
        public static DataTable DtContas { get; set; }
        public static DataTable Impressoras { get; set; }
        public static DataTable DtTirps { get; set; }
        public static string CCondicao { get; set; }
        public static string Numdoc { get; set; }
        public static string? Factstamp { get; set; } = "teste";
        public static DataTable Tabela { get; set; }
        public static DataTable DtSt { get; set; }
        public static DataTable DtStPrecos { get; set; }
        public static bool EditMode { get; set; }
        public static decimal NumeroDoc { get; set; }
        public static bool Inserindo { get; set; }
        public static bool Procurou { get; set; }
        public static bool Servico { get; set; }
        public static string Filename { get; set; }
        public static string NomeTabela { get; set; }
        public static string TdocXml { get; set; }
        public static string TdocNomFile { get; set; }
        public static string Moeda { get; set; }
        public static string TipoDocumento { get; set; }
        public static string? Codigo { get; set; }
        public static string? Disciplina { get; set; }
        public static string? Turmastamp { get; set; }
        public static string? AnoSemstamp { get; internal set; }
        public static string? Etapa { get; internal set; }
        public static string? Descurso { get; internal set; }
        public static string? Ststamp { get; internal set; }
        public static string? Cursostamp { get; set; }
        public static string? Anosem { get; set; }
        public static DataTable PlanoCurricular { get; set; }
        public static DataTable Horario { get; set; }
        public static DataTable MinhasNotasNestadisciplina { get; set; }
        public static DataTable DtAgendadivida { get; set; }
        public static DataTable DtturmaCl { get; set; }
        public static DataTable DtTurmas { get; set; }
        public static DataTable ProfessoresPorDisciplina { get; set; }
        public static string? Nivel { get; set; }
        public static string DescricaoTeste { get; set; }
        public static string? Rptname { get; set; }
        public static bool Academia { get; set; } = true;
        public static DateTime SqlDate { get; set; }
       
        public static DateTime PrevMonthData()
        {
            var mes = 1;
            if (SqlDate.Month > 1)
            {
                mes = SqlDate.Month - 1;
            }
            var diasMesAnterior = DateTime.DaysInMonth(SqlDate.Year, mes);
            var diasMesActual = DateTime.DaysInMonth(SqlDate.Year, SqlDate.Month);
            var dia = diasMesAnterior < diasMesActual ? 28 : SqlDate.Day;
            var dt = new DateTime(SqlDate.Year, mes, dia);
            return dt;
        }

        public static string Stamp(string origem = "MDN")
        {
            Thread.Sleep(10);
            var moment = DateTime.Now;
            // Year gets 1999.
            var year = moment.Year;
            // Month gets 1 (January).
            var month = moment.Month;
            // Day gets 13.
            var day = moment.Day;
            // Hour gets 3.
            var hour = moment.Hour;
            // Minute gets 57.
            var minute = moment.Minute;
            // Second gets 32.
            var second = moment.Second;
            // Millisecond gets 11.
            var millisecond = moment.Millisecond;

            var stamp = millisecond + "D" + year + month + origem + day + hour + minute + second;
            return stamp;
        }


        public static decimal AnoContabil()
        {
            return SQL.GetValue("select ano from param").ToDecimal();
        }
        public static DateTime GetDate(int i)
        {
            var dt = SqlDate.AddDays(i);
            return dt;
        }
        public static DataTable AgendaDivida(string? id)
        {
            var xx = $@"select descricao,valorreg,ccstamp,convert(date,Fact.data)data,convert(date,Fact.Dataven)dataven,tmp1.Referencia,fact.Numero,tmp1.Entidadebanc from (
                                select* from ClCCF() where Clstamp = '{id}')tmp1 join fact on tmp1.ccstamp = fact.Factstamp order by Numero";
            var dtcc = SQL.GetGenDt(xx);
            return dtcc;
        }

        public static DataTable Turmas(string? id)
        {
            var xx = $@"select Turma.Codigo Codtur,Turma.Descanoaem Turma,Turma.Turmastamp,Turma.Descanoaem Anolect,Sala,Turma.Turno Periodo from Turma 
                                join Turmal on Turma.Turmastamp=Turmal.Turmastamp where Clstamp='{id.Trim()}' and Turma.Descanoaem=(select AnoSem from param) order by Turma.codigo";
            return SQL.GetGenDt(xx);
        }


        public static Model.Models.Facturacao.Param Param { get; set; } = new();
        public static Empresa Empresa { get; set; }
    }
}
