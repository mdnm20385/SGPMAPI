using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using ArpLookup;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Reporting.NETCore;
using Model.Models;
using Model.Models.Facturacao;
using Model.Models.SJM;
using Model.Reports;

namespace DAL.BL
{

    public static class Acesso
    {
        public static string Login { get; set; } = string.Empty;
        public static string? Nome { get; set; } = string.Empty;
        public static DateTime Data { get; set; }
        public static string ParteInicial { get; set; } = string.Empty;
        public static bool UserAdmin { get; set; }
        public static bool PriEntrada { get; set; }
        public static bool ActivoMil { get; set; }
        public static string Perfil { get; set; } = string.Empty;
        public static bool RtiConta { get; set; }
        public static bool RtiCadastro { get; set; } = false;
        public static bool RtiProgramas { get; set; } = false;
        public static bool RtiTabela { get; set; } = false;
        public static bool RtiRelatorios { get; set; } = false;
        public static bool RtiAdministrador { get; set; } = false;
        public static bool AfectoNoArnazem { get; set; } = false;
        public static bool EdoPessoal { get; set; } = false;
        public static bool EdasFinancas { get; set; } = false;
        public static bool EdaSic { get; set; } = false;
        public static string MilStamp { get; set; } = string.Empty;

        public static DataTable PermissaoMainForm { get; set; }
        public static DataTable Teste { get; set; }
        public static string Test { get; set; }
        public static string Testinho { get; set; }
        public static string? Orgao { get; set; } = string.Empty;
        public static string Departamento { get; set; } = string.Empty;
        public static string Direccao { get; set; } = string.Empty;
        public static string? OrgaoEntradaProcura { get; set; } = string.Empty;
        public static string? OrgaoStamprr { get; set; } = string.Empty;
        public static string? DirecaoEntradaProcura { get; set; } = string.Empty;
        public static string Nomecampo { get; set; } = string.Empty;
        public static string ValorCampo { get; set; } = string.Empty;
        public static string OrgaoProcessoProcura { get; set; } = string.Empty;
        public static string DepartamentoProcessoProcura { get; set; } = string.Empty;
        public static string DirecaoProcessoProcura { get; set; } = string.Empty;
        public static string? UnidadeStamprr { get; set; } = string.Empty;
        public static string? DepartamentoEntradaProcura { get; set; } = string.Empty;
        public static string? SubUnidadeStamprr { get; set; } = string.Empty;






        public static string OrgaofuncaoDest { get; set; } = string.Empty;
        public static string? OrgaoStampDest { get; set; } = string.Empty;
        public static string OrgaoStamprrDest { get; set; } = string.Empty;
        public static string UnidadefuncaoDest { get; set; } = string.Empty;
        public static string? DirecaoDestinoProcura { get; set; } = string.Empty;
        public static string UnidadeStamprrDest { get; set; } = string.Empty;
        public static string SubUnidadefuncaoDest { get; set; } = string.Empty;
        public static string? DepartamentoSaidaProcura { get; set; } = string.Empty;
        public static string SubUnidadeStamprrDest { get; set; } = string.Empty;






        public static DataTable Testinho2 { get; set; }
        public static DataTable DttMilSalMess { get; set; }
        public static bool RtiVencimento { get; set; } = false;
        public static bool RtLogistica { get; set; } = false;
        public static bool VerSitClass { get; set; } = false;
        public static string? SicDoUtilizador { get; set; } = string.Empty;
        public static string Path { get; set; } = string.Empty;
        public static string Path2 { get; set; } = string.Empty;
        public static string? NomeDirector { get; set; } = string.Empty;
        public static string? NomeChefe { get; set; } = string.Empty;
        public static string? PatenteCategoria { get; set; } = string.Empty;
    }
    public struct MacIpPair
    {
        public string MacAddress;
        public string IpAddress;
    }


    public static class SQL
    {

        
        public static string UnidadDirecDiferenteDaMinha(Usuario us)
        {
            if (!string.IsNullOrEmpty(us.Orgao))
            {
                if (!string.IsNullOrEmpty(us.Direcao))
                {
                    if (!string.IsNullOrEmpty(us.Departamento))
                    {
                        return $"where descricao <>'{us.Departamento}'";
                    }

                    return $"where descricao <>'{us.Direcao}'";
                }

                return $"where descricao <>'{us.Orgao}'";
            }

            return "";
        }

        #region Região para atribuir as condições de procura


        public static  string? _orgao;
         public static  string _direccao, _departamento;
         public static  string? _orgaoStam;
         public static  string? _direccaoStam;
         public static  string? _departamentoStam;

         public static void UnidadCodicao()
        {
            Acesso.Direccao = string.Empty;
            Acesso.Orgao = _direccao = string.Empty;
            Acesso.DirecaoEntradaProcura = string.Empty;
            if (!string.IsNullOrEmpty(Pbl.Usuario.Orgao))
            {
                _orgao = Pbl.Usuario.Orgao;
                _orgaoStam = Pbl.Usuario.Orgaostamp;
                Acesso.Orgao = _orgao;
                Acesso.SicDoUtilizador = _orgao;
                Acesso.EdaSic = Pbl.Usuario.EdaSic;
                Acesso.OrgaoEntradaProcura = $"e.OrgaoUtilizador ='{_orgao}'";
                Acesso.OrgaoProcessoProcura = $"p.Orgao ='{_orgao}'";
                Acesso.OrgaoStampDest = $"sd.orgaoDest ='{_orgao}'";
                Acesso.Orgao = _orgao;
                Acesso.OrgaoStamprr = _orgaoStam;
                Acesso.Nomecampo = $"e.OrgaoUtilizador=";
                Acesso.ValorCampo = $"'{_orgao}'";
                if (!string.IsNullOrEmpty(Pbl.Usuario.Direcao))
                {
                    _direccao = Pbl.Usuario.Direcao;
                    _direccaoStam = Pbl.Usuario.Direcaostamp;
                    Acesso.Direccao = _direccao;
                    Acesso.SicDoUtilizador = _direccao;
                    Acesso.UnidadeStamprr = _direccaoStam;
                    Acesso.DirecaoEntradaProcura = $"e.DirecUtilizador ='{_direccao}'";
                    Acesso.DirecaoProcessoProcura = $"p.Direcao ='{_direccao}'";
                    Acesso.Nomecampo = $"e.DirecUtilizador=";
                    Acesso.ValorCampo = $"'{_direccao}'";
                    Acesso.DirecaoDestinoProcura = $"sd.direcDest ='{_direccao}'";
                    if (!string.IsNullOrEmpty(Pbl.Usuario.Departamento))
                    {
                        _departamentoStam = Pbl.Usuario.Departamentostamp;
                        _departamento = Pbl.Usuario.Departamento;
                        Acesso.Departamento = _departamento;
                        Acesso.DepartamentoEntradaProcura = $"e.DepUtilizador='{_departamento}'";
                        Acesso.DepartamentoProcessoProcura = $"p.Departamento ='{_departamento}'";
                        Acesso.DepartamentoSaidaProcura = $"sd.depDest ='{_direccao}'";
                        Acesso.SubUnidadeStamprr = _departamentoStam;
                        Acesso.Nomecampo = $"e.DepUtilizador=";
                        Acesso.ValorCampo = $"'{_departamento}'";
                        Acesso.SicDoUtilizador = _departamento;
                    }
                }
            }


        }
        #endregion
        
        public static Usuario SetUser(Usuario usr)
        {
            Pbl.SetDefaultSave(usr);
            var u = new Usuario()
            {
                CodUsuario = 1,
                Sexo = usr.Sexo,
                Nome = usr.Nome,
                Login = usr.Login,
                EdaSic = usr.EdaSic
            };
            u.PaStamp = usr.PaStamp;
            //var senhacryptografada = _objCrypto.Crypto(usr.senha.Trim(), true);
            //u.senha = senhacryptografada;
            u.EdaSic = usr.EdaSic;
            u.TipoPerfil = usr.TipoPerfil;
            u.Orgao = usr.Orgao;
            u.Direcao = usr.Direcao;
            u.Departamento = usr.Departamento;
            u.Orgaostamp = usr.Orgaostamp;
            u.Direcaostamp = usr.Direcaostamp;
            u.Departamentostamp = usr.Departamentostamp;
            u.PriEntrada = "1";
            u.Activopa = usr.Activopa;
            u.Inseriu = usr.Inseriu;
            u.InseriuDataHora = usr.InseriuDataHora;
            u.Alterou = usr.Alterou;
            u.VerSitClass = usr.VerSitClass;
            u.AlterouDataHora = usr.AlterouDataHora;
            u.PathPdf = usr.PathPdf;
            return u;
        }
        public static string CondicaoProcurasdr { get; set; }

        public static string CondicaoProcura { get; set; }
        public static string UnidadCondicaoProcura()
        {
            CondicaoProcura = "";
            if (!string.IsNullOrEmpty(Acesso.OrgaoEntradaProcura))
            {
                if (!string.IsNullOrEmpty(Acesso.DirecaoEntradaProcura))
                {
                    if (!string.IsNullOrEmpty(Acesso.DepartamentoEntradaProcura))
                    {
                        CondicaoProcura = Acesso.DepartamentoEntradaProcura;
                    }
                    else
                    {
                        CondicaoProcura = Acesso.DirecaoEntradaProcura;
                    }
                }
                else
                {
                    CondicaoProcura = Acesso.OrgaoEntradaProcura;
                }
            }

            return CondicaoProcura;
        }
        public static void Unidadsr()
        {
            UnidadCondicaoProcura();
            if (Acesso.EdaSic)
            {
                if (!string.IsNullOrEmpty(Acesso.OrgaoStampDest))
                {
                    if (!string.IsNullOrEmpty(Acesso.DirecaoDestinoProcura))
                    {
                        if (!string.IsNullOrEmpty(Acesso.DepartamentoSaidaProcura))
                        {
                            CondicaoProcurasdr = Acesso.DepartamentoSaidaProcura;
                        }
                        else
                        {
                            CondicaoProcurasdr = Acesso.DirecaoDestinoProcura;
                        }
                    }
                    else
                    {
                        CondicaoProcurasdr = Acesso.OrgaoStampDest;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Acesso.OrgaoStampDest))
                {
                    if (!string.IsNullOrEmpty(Acesso.DirecaoDestinoProcura))
                    {
                        if (!string.IsNullOrEmpty(Acesso.DepartamentoSaidaProcura))
                        {
                            CondicaoProcurasdr = Acesso.DepartamentoSaidaProcura;
                        }
                        else
                        {
                            CondicaoProcurasdr = Acesso.DirecaoDestinoProcura;
                        }
                    }
                    else
                    {
                        CondicaoProcurasdr = Acesso.OrgaoStampDest;
                    }
                }
            }
        }

        public static int OrigemProcess { get; set; }
        public static DataTable DtTotasEntrdas { get; set; }
        public static DataTable DtTotasSaidas { get; set; }

        public static DataTable _DataTable { get; set; }
        public static DataTable LoadGrid(int origem, string conselhos = "", string cbxFiltro = "Todos", string cbxSituacao = "Todos")
        {
            OrigemProcess = origem;
            UnidadCondicaoProcura();
            DtTotasEntrdas = null;
            string qry;
            string qryfiltro = string.Empty;
            string qryfiltrositu = string.Empty;
            if (!string.IsNullOrEmpty(cbxFiltro) && !cbxFiltro.Equals("Todos"))
            {
                qryfiltro = $" and Estado='{cbxFiltro}'";
            }
            if (!string.IsNullOrEmpty(cbxSituacao) && !cbxSituacao.Equals("Todos"))
            {
                if (cbxSituacao.Equals("Arquivado"))
                {
                    //qryfiltrositu = $" and Arquivo<>'Em uso' ";
                }
                if (!cbxSituacao.Equals("Arquivado"))
                {
                    // qryfiltrositu = $" and Arquivo='Em uso'";
                }
            }
            qryfiltrositu += $" Destruido='Arquivado'";

            if (!Acesso.VerSitClass)
            {
                if (string.IsNullOrEmpty(qryfiltrositu))
                {
                    qryfiltrositu += $" GrauClassifi not in('SEGREDO DO ESTADO','SECRETO')";
                }
                else
                {
                    qryfiltrositu += $" and GrauClassifi not in('SEGREDO DO ESTADO','SECRETO')";
                }
            }
            //  lblText.Text = $@"REGISTO DE SAÍDAS";
            if (OrigemProcess == 25)
            {
                Unidadsr();
                var qry1 = ",sd.*";
                qry = QueryEntradas(qry1, qryfiltro, qryfiltrositu, 0);
                //  Arquivo.Visible = false;
            }
            else if (OrigemProcess == 27)
            {
                if (!qryfiltrositu.IsNullOrEmpty())
                {
                    qryfiltrositu += $" {conselhos}";
                }
                //lblText.Text = $@"REGISTO DE ENTRADAS";
                Unidadsr();
                var qry1 = ",sd.*";
                // supertabcontrolGeral.Text = @"ENTRADAS";
                // Alocar.HeaderText = @"Alocar";
                qry = QueryEntradas(qry1, qryfiltro, qryfiltrositu, 1);
                // Arquivo.Visible = false;
            }
            else if (OrigemProcess == 26)
            {
                //lblText.Text = $@"REGISTO DE ENTRADAS";
                Unidadsr();
                var qry1 = ",sd.*";
                // supertabcontrolGeral.Text = @"ENTRADAS";
                // Alocar.HeaderText = @"Alocar";
                var CondicaDiferente = "";
                if (!string.IsNullOrEmpty(Pbl.Usuario.Orgaostamp))
                {

                    CondicaDiferente = $" and OrgaoProcedencia<>'{Pbl.Usuario.Orgao}'";
                    if (!string.IsNullOrEmpty(Pbl.Usuario.Direcaostamp))
                    {
                        //unidade = Pbl.Usuario.Direcao;
                        //orgao = Pbl.Usuario.Direcao;
                        //cond += $" and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                        CondicaDiferente = $"  and direcaoProcedencia<>'{Pbl.Usuario.Direcao}'";
                        //if (!string.IsNullOrEmpty(Pbl.Usuario.departamentostamp))
                        //{
                        //    subunidade = Pbl.Usuario.Departamento;
                        //    cond += $" and DepUtilizador='{Pbl.Usuario.Departamento}'";
                        //    orgao = Pbl.Usuario.Departamento;
                        //}
                    }
                }

                qryfiltrositu += CondicaDiferente;

                qry = QueryEntradas(qry1, qryfiltro, qryfiltrositu, 1);
                // Arquivo.Visible = false;
            }
            else
            {
                if (Acesso.EdaSic)
                {
                    if (!string.IsNullOrEmpty(qryfiltrositu))
                    {
                        qryfiltrositu = $" and {qryfiltrositu}";
                    }
                }
                else
                {
                    //qryfiltrositu = $" and Destruido='Arquivado'  AND NumeroOrdem=0";


                    if (!string.IsNullOrEmpty(qryfiltrositu))
                    {
                        qryfiltrositu += $" and Destruido='Arquivado' ";
                    }
                    else
                    {

                        qryfiltrositu = $"  Destruido='Arquivado'  AND NumeroOrdem=1";
                    }


                    //qryfiltrositu = $" and Destruido='Arquivado'  AND NumeroOrdem=0";
                }
                //qry = Qry(qryfiltrositu);
                //Arquivo.Visible = true;


                Unidadsr();
                var qry1 = ",sd.*";
                // supertabcontrolGeral.Text = @"ENTRADAS";
                // Alocar.HeaderText = @"Alocar";
                qry = QueryEntradasaidas(qry1, qryfiltro, qryfiltrositu, 1);

            }
            if (OrigemProcess == 25)
            {
                // Alocar.Visible = true;
            }
            qry = qry.Replace("dataEntrada<>''  and ", "");
            _DataTable = GetGenDt(qry);
            //dgvprocessos.AutoGenerateColumns = false;
            //dgvprocessos.DataSource = _dtGrid;
            //lblTotal.Text = $@"Dados Encontrados: {_dtGrid.Rows.Count}";
            //RefreshTimer?.Invoke();
            //txtPesquisa.ReadOnly = false;
            //MakegridReadonlyRow();
            //Arquivo.Visible = false;
            return _DataTable;
        }


        public static string QueryEntradas(string qry1, string qryfiltro, string qryfiltrositu, int estado)
        {
            return "select processoStamp,tipoDoc,numeroSaida Numero,GrauClassifi,NvlUrgencia,remetente,d as Assunto,entradaStamp,saidaStamp,numeroSaida," +
                   "docPDF,destinatario,orgaoDest,direcDest," +
                   $"PathPdf, " +
                   "depDest,Convert(date,dataSaida)dataSaida,inseriu,inseriuDataHora,alterou,alterouDataHora,Classificador,Entregue,DirecaoOrigem," +
                   "Orgaoorigem,NumeroOrdem," +
                   "Despacho,OrgaoProcedencia,direcaoProcedencia,DepartamentoProcedencia," +
                   "Convert(date,DataDocumento)DataDocumento,Endereco,Observacao,Assunto assprc," +
                   "QtdFolhas,QtdExemplares,QtdAnexo,DetalhesAssunto,Estado,Visado,remetente,dataEntrada,ConselhoColectivos " +
                   $"from (select p.processoStamp{qry1},numero,e.remetente,p.Visado, p.tipoDoc, p.assunto d, Orgao," +
                   " Direcao, Departamento, Estado, e.direcaostamp,e.NvlUrgencia,e.GrauClassifi, OrgaoUtilizador OrgaoProcedencia," +
                   "e.DirecUtilizador direcaoProcedencia, e.depUtilizador DepartamentoProcedencia," +
                   " e.departamentostamp,e.OrgaoUtilizador,e.DirecUtilizador, e.depUtilizador, e.orgaostamp," +
                   $"Arquivo = isnull((select top 1 'arquivo' localizacao from Arquivo ar inner join EntradaProcesso e on " +
                   $" ar.processoStamp = e.entradaStamp where p.processoStamp = p.processoStamp and " +
                   $" {CondicaoProcura} {qryfiltro}  order by dataEntrada desc),'Em processo') ," +
                   $"Destruido = isnull((select 'destruido' localizacao from Destruicao dest inner join Arquivo ar on" +
                   $" dest.arquivoStamp=ar.arquivoStamp where ar.processoStamp = p.processoStamp and ar.Activo=0),'Arquivado') ," +
                   "p.Usrstamp,e.DetalhesAssunto,e.dataEntrada,E.ConselhoColectivos from processo p " +
                   "inner join EntradaProcesso e on p.processoStamp" +
                   $" = e.processoStamp  inner join SaidaProcesso sd on sd.entradaStamp= e.entradaStamp where {CondicaoProcurasdr}" +
                   $" and sd.Entregue={estado} {qryfiltro})temp  where  {qryfiltrositu} " +
                   $"order by dataSaida desc ";
        }



        public static string QueryEntradasaidas(string qry1, string qryfiltro, string qryfiltrositu, int estado)
        {


            return "select processoStamp,tipoDoc,numeroSaida Numero,GrauClassifi,NvlUrgencia,remetente,d as Assunto,entradaStamp,saidaStamp,numeroSaida," +
                   "docPDF,destinatario,orgaoDest,direcDest," +
                   $"PathPdf, " +
                   "depDest,Convert(date,dataSaida)dataSaida,inseriu,inseriuDataHora,alterou,alterouDataHora,Classificador,Entregue,DirecaoOrigem," +
                   "Orgaoorigem,NumeroOrdem," +
                   "Despacho,OrgaoProcedencia,direcaoProcedencia,DepartamentoProcedencia," +
                   "Convert(date,DataDocumento)DataDocumento,Endereco,Observacao,Assunto assprc," +
                   "QtdFolhas,QtdExemplares,QtdAnexo,DetalhesAssunto,Estado,Visado,remetente,dataEntrada,ConselhoColectivos " +
                   $"from (select p.processoStamp{qry1},numero,e.remetente,p.Visado, p.tipoDoc, p.assunto d, Orgao," +
                   " Direcao, Departamento, Estado, e.direcaostamp,e.NvlUrgencia,e.GrauClassifi, OrgaoUtilizador OrgaoProcedencia," +
                   "e.DirecUtilizador direcaoProcedencia, e.depUtilizador DepartamentoProcedencia," +
                   " e.departamentostamp,e.OrgaoUtilizador,e.DirecUtilizador, e.depUtilizador, e.orgaostamp," +
                   $"Arquivo = isnull((select top 1 'arquivo' localizacao from Arquivo ar inner join EntradaProcesso e on " +
                   $" ar.processoStamp = e.entradaStamp where p.processoStamp = p.processoStamp and " +
                   $" {CondicaoProcura} {qryfiltro}  order by dataEntrada desc),'Em processo') ," +
                   $"Destruido = isnull((select 'destruido' localizacao from Destruicao dest inner join Arquivo ar on" +
                   $" dest.arquivoStamp=ar.arquivoStamp where ar.processoStamp = p.processoStamp and ar.Activo=0),'Arquivado') ," +
                   "p.Usrstamp,e.DetalhesAssunto,e.dataEntrada,E.ConselhoColectivos from processo p " +
                   "inner join EntradaProcesso e on p.processoStamp" +
                   $" = e.processoStamp  inner join SaidaProcesso sd on sd.entradaStamp= e.entradaStamp where {CondicaoProcurasdr.Replace("sd.direcDest =", "sd.direcDest <>")}" +
                   $"  {qryfiltro})temp  where  {qryfiltrositu} " +
                   $"order by dataSaida desc ";
        }
       
        public static string WriteFilenamepdf(byte[] anexo, string path, string filename)
        {
            var spathfile = path;
            try
            {
                if (!Directory.Exists(spathfile))
                {
                    Directory.CreateDirectory(spathfile);
                }
                var filenams = $"{DateTime.Now.Second.ToString() }{ DateTime.Now.Millisecond}{filename}";
                spathfile = Path.Combine(spathfile, filenams);
                File.WriteAllBytes(spathfile, anexo);

                return filenams;
            }
            catch (Exception ex)
            {
            }
            return spathfile;

        }

        public static void RetorProprieties(PropertyInfo[] properties, Usuario dmzuser)
        {
            foreach (var p in properties)
            {
                var valor = p.GetValue(dmzuser);
                if (p.PropertyType == typeof(DateTime))
                {
                    if (valor is DBNull)
                    {
                        valor = new DateTime(1900, 1, 1);
                    }

                    if (valor == null || valor.ToString()!.Contains("0001"))
                    {
                        valor = new DateTime(1900, 1, 1);
                    }

                    valor = valor.ToDateTimeValue();
                }

                if (p.PropertyType == typeof(string))
                {
                    try
                    {
                        if (valor == null || valor.ToString()!.IsNullOrEmpty())
                        {
                            valor = "";
                        }
                    }
                    catch (Exception)
                    {
                        valor = "";
                    }
                    //else if (valor.ToString()!.IsNullOrEmpty() )
                    //{

                    //    valor = "";
                    //}
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

                p.SetValue(dmzuser, valor);


                // var result =  _userManager.CreateAsync(user, "Teste1324#");
            }




        }

        public static string getMacByIp(string ip)
        {
            var mac =  Arp.LookupAsync(IPAddress.Parse(ip));

            var macIpPairs = GetAllMacAddressesAndIppairs();
            int index = macIpPairs.FindIndex(x => x.IpAddress == ip);
            if (index >= 0)
            {
                return macIpPairs[index].MacAddress.ToUpper();
            }
            else
            {
                return null;
            }
        }

        public static List<MacIpPair> GetAllMacAddressesAndIppairs()
        {
            List<MacIpPair> mip = new List<MacIpPair>();
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a ";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string cmdOutput = pProcess.StandardOutput.ReadToEnd();
            string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";

            foreach (Match m in Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase))
            {
                mip.Add(new MacIpPair()
                {
                    MacAddress = m.Groups["mac"].Value,
                    IpAddress = m.Groups["ip"].Value
                });
            }

            return mip;
        }
        
        
        #region Salvar CC
      
        public static DataRowView DtEntidade { get; set; }
        public static DataRowView Dtv { get; set; }
        public static string Numinterno { get; set; }
        #endregion



       

    
        public static string GetValueByMascara(string sigla, string mascara, DataTable dt)
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
        public static string GetUploadedFileName(IFormFile ProfilePhoto, string path)
        {
            string uniqueFileName = null;
            if (ProfilePhoto != null)
            {


                string uploadsFolder = path;
                uniqueFileName = Guid.NewGuid() + "_" + ProfilePhoto.FileName;
                string filePath = System.IO.Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    ProfilePhoto.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }



        public static void SetDatasourcerpt(LocalReport localReport, string xmlstring="", DataTable dtprint=null
        ,DS _ds=null)
        {
            localReport.EnableExternalImages = true;
            //localReport.ReportPath = writeReport;
            var rds = new ReportDataSource();
            // var rltViews = rlts?.Rltview;
            if (!xmlstring.IsNullOrEmpty() && !string.IsNullOrWhiteSpace(xmlstring))
            {
                //ReportParameter Name="Data"
                if (xmlstring.ToLower().Contains("DataSet Name=\"DataSet1\"".ToLower()))
                {

                    rds = new ReportDataSource();
                    rds.Name = "DataSet1";
                    rds.Value = _ds.Tables[dtprint.TableName];
                    localReport.DataSources.Add(rds);
                    //localReport.DataSources.Add(new ReportDataSource("DataSet1", _ds.Tables[dtprint.TableName]));
                    //localReport.AddDataSource("DataSet1", _ds.Tables[dtprint.TableName]);
                }
                if (xmlstring.ToLower().Contains("DataSet Name=\"Entidade\"".ToLower()))
                {

                    rds = new ReportDataSource();
                    rds.Name = "Entidade";
                    rds.Value = _ds.Tables["Empresa"];
                    localReport.DataSources.Add(rds);
                }
                if (xmlstring.ToLower().Contains("DataSet Name=\"Formasp\"".ToLower()))
                {
                    rds = new ReportDataSource();
                    rds.Name = "Formasp";
                    rds.Value = _ds.Tables["Formasp"];
                    localReport.DataSources.Add(rds);
                    //localReport.DataSources.Add(new ReportDataSource("Formasp", _ds.Tables["Formasp"]));
                }
                if (dtprint.TableName.ToLower().Trim().Equals("fact") || dtprint.TableName.ToLower().Trim().Equals("facc"))
                {
                    rds = new ReportDataSource();
                    rds.Name = "TabIvas";
                    rds.Value = _ds.Tables["DMZ"];
                    localReport.DataSources.Add(rds);
                    rds = new ReportDataSource();
                    rds.Name = "Contas";
                    rds.Value = _ds.Tables["Contas"];
                    localReport.DataSources.Add(rds);
                }

                if (xmlstring.ToLower().Contains("DataSet Name=\"Horario\"".ToLower()))
                {
                    rds = new ReportDataSource();
                    rds.Name = "Horario";
                    rds.Value = _ds.Tables["Horario"];
                    localReport.DataSources.Add(rds);
                    //localReport.DataSources.Add(new ReportDataSource("Horario", _ds.Tables["Horario"]));
                }
                if (xmlstring.ToLower().Contains("DataSet Name=\"Turmadisc\"".ToLower()))
                {
                    rds = new ReportDataSource();
                    rds.Name = "Turmadisc";
                    rds.Value = _ds.Tables["Turmadisc"];
                    localReport.DataSources.Add(rds);
                    //localReport.DataSources.Add(new ReportDataSource("Turmadisc", _ds.Tables["Turmadisc"]));
                }
            }

        }
        public static (string moedadesc, decimal total) BuildExtenso(string tabela, DS? ds)
        {
            (string moedadesc, decimal total) xx = ("", 0);
            if (ds != null)
            {
                string? moeda = ds?.Tables[$"{tabela.Trim()}"]?.Rows[0]["moeda"].ToString();
                if (moeda.IsNullOrEmpty())
                {
                    moeda = "MZN";
                }
                if (moeda != null && moeda.Equals("MZN"))
                {
                    if (ds != null) xx.total = ds.Tables[$"{tabela.Trim()}"]!.Rows[0]["Total"].ToDecimal();
                    xx.moedadesc = "Metical";
                }
                else
                {
                    xx.total = ds.Tables[$"{tabela.Trim()}"].Rows[0]["MTotal"].ToDecimal();
                    xx.moedadesc =GetValue("Descricao", "moedas", $"moeda='{ds.Tables[$"{tabela.Trim()}"]!.Rows[0]["moeda"]}'");
                }
            }
            return xx;
        }
        public static string ConvertByteToPdf(byte[] anexo,string path)
        {
            var spathfile = path + "\\PDFFiles";
            try
            {
                if (!Directory.Exists(spathfile))
                {
                    Directory.CreateDirectory(spathfile);
                }
                spathfile = spathfile + $"\\Ficheiro1{DateTime.Now.Second.ToString() + DateTime.Now.Millisecond}";
                File.WriteAllBytes(spathfile, anexo);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return spathfile;

        }
        public static void SetParamente(LocalReport reportViewer1,DS _ds,DataTable DtMemo)
        {

            var ListaParam = new List<ReportParameter>();
            foreach (var p in reportViewer1.GetParameters())
            {
                switch (p.Name)
                {
                    case "SoftwareVersion":
                        ListaParam.Add(new ReportParameter("SoftwareVersion", Pbl.Info));
                        break;
                    case "Data":
                        ListaParam.Add(new ReportParameter("Data", Pbl.SqlDate.ToString()));
                        //ListaParam.Add(new ReportParameter("Data", Pbl.SqlDate.ToLongDateString()));
                        break;
                    case "Statusdocumento":
                        ListaParam.Add(new ReportParameter("Statusdocumento", "Original"));
                        break;
                    case "MoedaNacional":
                        ListaParam.Add(new ReportParameter("MoedaNacional", Pbl.MoedaBase));
                        break;
                    case "LinguaNacional"://
                        ListaParam.Add(new ReportParameter("LinguaNacional", "PT"));
                        break;
                    case "Filtro":
                        ListaParam.Add(new ReportParameter("Filtro", ""));
                        break;
                    case "cTituloRelatorio":
                        ListaParam.Add(new ReportParameter("cTituloRelatorio", ""));
                        break;
                    case "Login":
                        ListaParam.Add(new ReportParameter("Login", ""));
                        break;
                    case "Mostranib":
                        ListaParam.Add(new ReportParameter("Mostranib", true.ToString().ToLower()));
                        break;
                    case "Entidade":
                        ListaParam.Add(new ReportParameter("Entidade", ""));
                        break;
                    case "pUtilizador":
                        ListaParam.Add(new ReportParameter("pUtilizador", ""));
                        break;
                    case "DataDoccc":
                        ListaParam.Add(new ReportParameter("DataDoccc", Pbl.SqlDate.ToLongDateString()));
                        break;
                    case "Intervalo":
                        ListaParam.Add(new ReportParameter("Intervalo", ""));
                        break;
                    case "NomeProduto":
                        ListaParam.Add(new ReportParameter("NomeProduto", ""));
                        break;
                    // 
                    case "Docgravacao":
                        ListaParam.Add(new ReportParameter("Docgravacao", false ? "Previsão - (Documento não gravado)" : ""));
                        break;
                    case "Extenso":
                        if (_ds.Tables[DtMemo.TableName.Trim()].Columns.Contains("Total"))
                        {
                            if (_ds.Tables[DtMemo.TableName.Trim()].Rows[0]["Total"].ToString().ToDecimal() != 0)
                            {
                                var extenso = BuildExtenso(DtMemo.TableName.Trim(), _ds);
                                ListaParam.Add(new ReportParameter("Extenso", extenso.total.ToExtenso(extenso.moedadesc.ToUpper().Trim())));

                                //if (Pbl.Lingua.Equals("PT"))
                                //{
                                //    ListaParam.Add(new ReportParameter("Extenso", extenso.total.ToExtenso(extenso.moedadesc.ToUpper().Trim())));
                                //}
                                //else
                                //{
                                //    ListaParam.Add(new ReportParameter("Extenso", $"{extenso.total.ToExtensoEng()} {extenso.moedadesc.ToUpper().Trim()}"));
                                //}
                            }
                            else
                            {
                                ListaParam.Add(new ReportParameter("Extenso", "ZERRO"));
                            }
                        }
                        else
                        {
                            try
                            {
                                ListaParam.Add(new ReportParameter("Extenso", 0.ToDecimal().ToExtenso("Metical".ToUpper().Trim())));

                                //if (Ps.LinguaNacional.Equals("PT"))
                                //{
                                //    ListaParam.Add(new ReportParameter("Extenso", 0.ToDecimal().ToExtenso("Metical".ToUpper().Trim())));
                                //}
                                //else
                                //{
                                //    ListaParam.Add(new ReportParameter("Extenso", $"{0.ToDecimal().ToExtensoEng()} {"Dollar".ToUpper().Trim()}"));
                                //}
                            }
                            catch (Exception ex)
                            {

                                //throw;
                            }

                        }
                        break;

                }
            }
            //if (Ps.ListaParam != null)
            //{
            //    foreach (ReportParameter p in Ps.ListaParam)
            //    {
            //        if (p != null)
            //        {
            //            switch (p.Name)
            //            {
            //                case "valorareceber":
            //                    ListaParam.Add(p);
            //                    break;
            //            }
            //        }
            //    }
            //}
            reportViewer1.SetParameters(ListaParam);
        }

        public static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
        public static (DataTable dtPrint, DataTable fp) FillData(DataTable dtPai, DataTable dtFilha, DataTable formasp, DataTable dtPrincipal, DataTable dtformasp)
        {
            (DataTable dtPrint, DataTable fp) ret = (null, null);
            if (dtFilha.HasRows())
            {
                dtPrincipal.PrimaryKey = null;
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
                            if (dtPrincipal.TableName == "DMZ")
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
        public static string GetXmlReport(string rptName)
        {
            return GetField($"select Xmlstring from Rdlcxml where Rdlcname = '{rptName}'")?.ToString();
        }
        public static (string reporpat, string filename1) WriteRDLCReport(string report,string _path)
        {
            var tempReportFullPath = "";
            var fileName1 = "";
            //_path = _webHost.WebRootPath;
            if (!report.IsNullOrEmpty())
            {
                var fileName = _path + "\\Temp";
                var stamp = Pbl.Rdlcstamp();
                if (!Directory.Exists(fileName))
                {
                    Directory.CreateDirectory(fileName);
                    System.IO.File.WriteAllText(_path + $"\\Temp\\report{stamp}.rdlc", report);
                }
                else
                {
                    System.IO.File.WriteAllText(_path + $"\\Temp\\report{stamp}.rdlc", report);
                }

                var pet = Path.Combine(_path, "Temp");
                tempReportFullPath = Path.Combine(pet, $"report{stamp}.rdlc");
                fileName1 = $"report{stamp}";
            }

            return (tempReportFullPath,fileName1);
        }

        public static (DataTable dtPrint, DataTable fp, string CLocalStamp, bool inserido, string labe, string semtexto,
            string reportname, string origem, string XmlString, bool tr, DS ds, string sems, string sms) ImprimirListagem<T>
            (string reportname, string origem, DataTable gridUiAlunos, T turma)
            where T : class, new()
        {
            DS ds = new DS();
            //var alunos = gridUiAlunos;
            //var XmlString = GetXmlReport(reportname.Trim());
            //Utilities.AllTrim(turma);
            //var ret = Imprimir.FillData(turma.FromEntityToDataTable(), 
            //    alunos, null, ds.Turma, null);
            //ret.dtPrint = ret.dtPrint.DefaultView.ToTable();
            //return (ret.dtPrint, ret.fp, "", false, "", "", reportname, origem, XmlString, true, ds, "", "");
            return (null, null, "", false, "", "", reportname, origem, null, true, ds, "", "");
        }
        public static (int numero, string messagem) Save(DataTable dt, string tableName, bool adding, string clocalstamp, string ctabela)
        {
            _retorno = 0;
            var _linhaspagada = false;
            if (!(dt?.Rows.Count > 0)) return (-1, $"A tabela {tableName} não tem registos!..");
            _linhaspagada = dt.AsEnumerable().Any(x => x.RowState == DataRowState.Deleted);
            if (_linhaspagada && dt.Rows.Count == 1) return (_retorno, $"Todos registos na tabela {tableName} foram apagados!..");
            try
            {
                using (_gc = new GCon())
                {
                    using (var adapter = new SqlDataAdapter($" SELECT * FROM {tableName} where 1=0 ", _gc.NResult))
                    {
                        using (new SqlCommandBuilder(adapter))
                        {
                            if (dt.AsEnumerable().Any(x => x.RowState == DataRowState.Deleted))
                            {
                                dt = dt.AsEnumerable().Where(x => x.RowState != DataRowState.Deleted).CopyToDataTable();
                            }

                            SetDefault(dt);

                            adapter.Fill(dt);
                            adapter.Update(dt);
                            _retorno = 1;
                        }
                    }
                }
                return (_retorno, "Dados Gravados com sucesso!..");
            }
            catch (Exception ex)
            {
                if (adding && !string.IsNullOrEmpty(ctabela))
                {
                    SqlCmd($"delete from {ctabela} where ltrim(rtrim({ctabela}stamp)) ='{clocalstamp.Trim()}'");
                }
                return (_retorno, ex.Message);
            }
        }



        public static (int numero, string messagem) OnGravarFilhas(string tabelafilha, bool adding, string ctabela, string clocalstamp,
            DataTable? Formaspdt)
        {
            (int numero, string messagem) retorno = (20, null);
            if (Formaspdt?.Rows.Count > 0)
            {
                retorno = Save(Formaspdt, tabelafilha, adding, clocalstamp, ctabela);
            }
            return retorno;
        }
        public static (DataTable tab, string msg) EntityToDataTable<T>(T? entity,DataTable tab) where T : class, new()
        {
            DataTable dt = null;
            try
            {
                if (entity == null) return (dt, "");
                var tabeName = entity.GetType().Name.Trim();
                var pros = entity.GetType().GetProperties();
                if (!tab.HasRows())
                {
                    dt = Initialize(entity.GetType().Name);
                    var dr = dt.NewRow().Inicialize();
                    foreach (var p in pros)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (p.Name.Trim().ToLower()== col.ColumnName.Trim().ToLower())
                            {
                                dr[p.Name.Trim()] = p.GetValue(entity);
                            }
                        }
                    }
                    dt.Rows.Add(dr);
                    return (dt, "Sucesso");
                }

                var dtdsMemory = Pbl.DS?.Tables[tabeName];

                if (dtdsMemory.HasRows())
                {

                    foreach (DataRow dr in dtdsMemory?.Rows)
                    {
                        int i = 0;
                        foreach (DataRow dr2 in tab.Rows)
                        {
                            i += 1 - 1;
                            if (dr.ItemArray.SequenceEqual(dr2.ItemArray))//Equal
                            {
                                var sta = dr2.ItemArray[0];
                                var stamp = dr2[$"{tabeName}stamp"].ToString();
                               
                            }
                        }
                    }

                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        bool va = false;
                        foreach (DataColumn col in tab.Columns)
                        {
                            for (int j = 0; j < dtdsMemory.Rows.Count; j++)
                            {
                                foreach (DataColumn col2 in dtdsMemory.Columns)
                                {
                                    if (col2.ColumnName.Trim().ToLower().Equals(col.ColumnName.ToTrim().ToLower()))
                                    {
                                        if (tab.Rows[i][col.ColumnName].ToTrim().Equals(dtdsMemory.Rows[i][col.ColumnName].ToTrim()))
                                        {
                                            va=true;
                                        }
                                    }
                                }
                                
                            }
                        }

                        if (!va)
                        {
                            //tab.Rows[i] = tab.Rows[i];
                        }
                       
                    }
                }
                List<string> list = new List<string>();
                foreach (var p in pros)
                {
                    list.Add(p.Name.Trim());
                }
                string[] str = list.ToArray();
                return (tab, "Sucesso");
            }
            catch (Exception dbEx)
            {
                return (null, dbEx.Message);

            }
        }

        public static T InstanciaInserir<T>(T set) where T : class, new()
        { var nomeClasse = typeof(T).Name;
            var ents = typeof(T).GetType();
            var lista = SQL.GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{nomeClasse.Trim()}' ", " column_name ");
            var entradpt = new T();
            var properties = entradpt.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propertiesx = set.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);


            foreach (var p in properties)
            {
                if (lista?.Rows.Count > 0)
                {
                    var nome = p.Name;

                    foreach (DataRow dr in lista.Rows)
                    {
                        if (dr["column_name"].ToString().ToLower().Equals(nome.ToLower()))
                        {
                            var matchingProperty = propertiesx.FirstOrDefault(p2 =>
                                p.Name.Trim().ToLower() == p2.Name.Trim().ToLower());

                            if (matchingProperty != null)
                            {
                                var valor = matchingProperty.GetValue(set); // Get value from entraPr
                                p.SetValue(entradpt, valor); // Set value in pp
                            }
                        }
                    }


                }


            }
            //EF.Save(entradpt);
            return entradpt;
        }

        public static T DoAddline<T>() where T : class, new()
        {
            var t = new T();
            var nomeClasse = typeof(T).Name;
            if (Ctabela.IsNullOrEmpty())
            {
                Ctabela = nomeClasse;
            }
            if (Ctabela.Contains("nota1"))
            {
                Ctabela = nomeClasse.Replace("nota1", "nota");
            }
            var lista = GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{nomeClasse.Trim()}' and IS_NULLABLE='YES' ", " column_name ");
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                if (p.PropertyType == typeof(string))
                {
                    p.SetValue(t, "");
                    if (!Ctabela.IsNullOrEmpty())
                    {
                        if (p.Name.Trim().ToLower().Contains("stamp") && p.Name.Trim().ToLower().Contains(Ctabela.ToLower().Trim()))
                        {
                            CLocalStamp = Pbl.Stamp();
                            PrimaryKeyName = p.Name.Trim();
                            p.SetValue(t, CLocalStamp);
                        }
                    }
                    else if (p.Name == "qmc")
                    {
                        p.SetValue(t, "");
                    }
                    if (lista.Rows.Count > 0)
                    {
                        try
                        {
                            var r = lista.AsEnumerable().FirstOrDefault(x => x.Field<string>("column_name").Equals(p.Name));
                            if (r != null)
                            {
                                if (p.Name != "qmc")
                                {
                                    p.SetValue(t, null);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            //
                        }
                    }
                }
                if (p.PropertyType == typeof(decimal))
                {
                    
                    p.SetValue(t, 0.ToDecimal());
                }
                if (p.PropertyType == typeof(int))
                {
                    p.SetValue(t, 0.ToInt());
                }
                if (p.PropertyType == typeof(long))
                {
                    p.SetValue(t, 0);
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



        public static T CorrecaoNulls<T>(T f)
        {
            var t = f;
            var nomeClasse = typeof(T).Name;

            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {

                var propType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                var dataType = propType.Name.ToLower();
                var valor = p.GetValue(t);

                try
                {
                    if (dataType.Equals("DateTime".ToLower()) || p.PropertyType == typeof(DateTime))
                    {
                        if (valor is DBNull || valor is null)
                        {
                            valor = new DateTime(1900, 1, 1);
                        }

                        if (valor.ToString().Contains("0001"))
                        {
                            valor = new DateTime(1900, 1, 1);
                        }
                        valor = valor.ToDateTimeValue();

                    }
                    if (dataType.Equals("string".ToLower()) || p.PropertyType == typeof(string))
                    {
                        if (string.IsNullOrEmpty(valor?.ToString()))
                        {
                            valor = "";
                        }
                    }

                   
                    if (dataType.Equals("decimal".ToLower()) || p.PropertyType == typeof(decimal))
                    {
                        if (valor is DBNull || valor is null)
                        {
                            valor = 0.ToDecimal();
                        }
                    }
                    if (dataType.Equals("int".ToLower()) || p.PropertyType == typeof(int))
                    {
                        if (valor is DBNull || valor is null)
                        {
                            valor = 0.ToInt();
                        }
                    }
                    if (dataType.Equals("bool".ToLower()) || p.PropertyType == typeof(bool))
                    {
                        if (valor is DBNull || valor is null)
                        {
                            valor = false;
                        }
                    }
                    if (dataType.Equals("byte[]".ToLower()) || p.PropertyType == typeof(byte[]))
                    {
                        if (valor is DBNull || valor is null)
                        {
                            valor = 0;
                        }
                    }
                    if (dataType.ToLower().Equals("datetimeoffset".ToLower()) || p.PropertyType == typeof(DateTimeOffset))
                    {
                        if (valor is DBNull || valor is null)
                        {
                            valor = new DateTimeOffset(1900, 1, 1, 8, 6, 32, 545,
                                new TimeSpan(1, 0, 0));
                            //p.SetValue(t, dateAndTime);
                        }
                    }
                    p.SetValue(t, valor);
                }
                catch (Exception)
                {
                    var fff = p.Name;
                    throw;
                }
            }
            return t;
        }




        public static T InicializarDados<T>() where T : class, new()
        {
            var t = new T();
            
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                var propType = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;
                var dataType = propType.Name;

                if (dataType.ToLower().Equals("string"))
                {
                    p.SetValue(t, "");
                }
                if (dataType.ToLower().Equals("decimal"))
                {
                    p.SetValue(t, 0.ToDecimal());
                }
                if (dataType.ToLower().Equals("int"))
                {
                    p.SetValue(t, 0.ToInt());
                }
                if (dataType.ToLower().Equals("long"))
                {
                    p.SetValue(t, 0);
                }
                if (dataType.ToLower().Equals("bool")|| dataType.ToLower().Equals("bit"))
                {
                    p.SetValue(t, false);
                }
                if (dataType.ToLower().Equals("DateTime".ToLower()))
                {
                    p.SetValue(t, new DateTime(1900, 1, 1));
                }
                if (dataType.ToLower().Equals("datetimeoffset".ToLower()))
                {
                    var dateAndTime = new DateTimeOffset(1900, 1, 1, 8, 6, 32, 545,
                        new TimeSpan(1, 0, 0));
                    p.SetValue(t, dateAndTime);
                }
                if (dataType.Equals("byte[]".ToLower()) || p.PropertyType == typeof(byte[]))
                {
                    byte[] bytes = BitConverter.GetBytes(0);
                    p.SetValue(t, bytes);
                }
            }
            return t;
        }
        [Description("Stamp do cabeçalho")]
        public static string? CLocalStamp { get; set; } = string.Empty;

        public static string PrimaryKeyName { get; set; }
        public static string Ctabela { get; set; }
        static int _retorno;
        public static decimal ExecCambio(string moeda)
        {
            return GetField("top 1 Venda", "cambio", $" Moeda='{moeda}' order by data desc").ToDecimal();
        }

        public static T Entiti<T>(T entidademae, T entidadeasetar) where T : new()
        {
            var prso = entidademae?.GetType().GetProperties();
            if (entidadeasetar != null)
            {
                SetDefaultSave(entidadeasetar);
                var prow1 = entidadeasetar.GetType().GetProperties();
                if (prso != null)
                    foreach (var p in prso)
                    {
                        var valor = p.GetValue(entidademae, null);
                        foreach (var p2 in prow1)
                        {
                            if (p.Name == p2.Name)
                            {
                                p2.SetValue(entidadeasetar, valor);
                            }
                        }
                    }

            }
            return entidadeasetar;

        }
        public static (string messa, string quer) ConvertToUpdateSql<T>(T obj, string tabe = "",string pkvalue="")
        {
            SetDefaultSave(obj);
            var nomeClasse = typeof(T).Name;
            var lista = GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{nomeClasse.Trim()}'",
                " DATA_TYPE,LOWER(column_name) column_name,IS_NULLABLE");
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var tableName = nomeClasse;
            var sql = "update " + tableName + " set ";
            var values = new List<object>();
            foreach (var propertyInfo in properties)
            {
                if (lista?.Rows.Count > 0)
                {
                    var row = lista.Select().Where(x => x.Field<string>("column_name").ToLower().Trim().
                            Equals(propertyInfo.Name.ToLower().Trim()))
                        .FirstOrDefault();
                    if (row != null)
                    {
                        var ro = row["IS_NULLABLE"].ToString();
                        var valor = propertyInfo.GetValue(obj);
                        var columnName = propertyInfo.Name;

                        if (propertyInfo.PropertyType.Name == "String" || propertyInfo.PropertyType.Name == "Boolean")
                        {
                            if (!row["IS_NULLABLE"].ToBool())
                            {
                                if (!string.IsNullOrEmpty(tabe))
                                {
                                    if (columnName.ToLower().Contains("stamp") &&
                                        !columnName.ToLower().Equals("formaspstamp".ToLower()))
                                    {
                                        if (string.IsNullOrEmpty(valor.ToString()))
                                        {
                                            propertyInfo.SetValue(obj, null);
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(valor.ToString()))
                                    {
                                        propertyInfo.SetValue(obj, "");
                                        values.Add($@"{columnName}='{propertyInfo.GetValue(obj)}'");
                                        continue;
                                    }
                                }
                            }
                            else
                            {

                                if (string.IsNullOrEmpty(valor.ToString()))
                                {
                                    propertyInfo.SetValue(obj, null);
                                    continue;
                                }
                            }
                            if (columnName.ToLower().Contains("stamp") &&
                                !columnName.ToLower().Equals("Formaspstamp".ToLower()))
                            {
                                if (!string.IsNullOrEmpty(valor.ToString()))
                                {
                                    values.Add($@"{columnName}='{propertyInfo.GetValue(obj)}'");
                                    //values.Add($@"'{propertyInfo.GetValue(obj)}'");
                                }
                            }
                            else
                            {
                                values.Add($@"{columnName}='{propertyInfo.GetValue(obj)}'");
                            }

                        }
                        else if (propertyInfo.PropertyType.Name == "DateTime")
                        {
                            if (!row["IS_NULLABLE"].ToBool())
                            {
                                if (string.IsNullOrEmpty(valor?.ToString()) || valor.ToString()!.Contains("0001-"))
                                {
                                    propertyInfo.SetValue(obj, new DateTime(1900, 1, 1));
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(valor.ToString()))
                                {
                                    propertyInfo.SetValue(obj, null);
                                }
                            }
                            var dateTime = (DateTime)propertyInfo.GetValue(obj);

                            values.Add($@"{columnName}='{dateTime.ToString("yyyy-MM-dd")}'");
                        }
                        else
                        {
                            if (!row["IS_NULLABLE"].ToBool())
                            {
                                if (propertyInfo.PropertyType == typeof(byte[]))
                                {
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(valor?.ToString()))
                                    {
                                        propertyInfo.SetValue(obj, 0);
                                    }
                                    values.Add($@"{columnName}='{propertyInfo.GetValue(obj)}'");
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(valor?.ToString()))
                                {
                                    propertyInfo.SetValue(obj, null);
                                }
                                else
                                {
                                    values.Add($@"{columnName}='{propertyInfo.GetValue(obj)}'");
                                }
                            }
                        }
                    }

                }
            }
            sql += $" {string.Join(", ", values)} where {nomeClasse}stamp='{pkvalue}'";
            return ("update", sql);

        }

        public static (T ent, string quer) ConvertToInsertIntoSql<T>(T obj,string tabe="")
        {
            SetDefaultSave(obj);
            var nomeClasse = typeof(T).Name;
            var lista = GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{nomeClasse.Trim()}'",
                " DATA_TYPE,LOWER(column_name) column_name,IS_NULLABLE");
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);


            var tableName = nomeClasse;
            var sql = "insert into " + tableName + "(";
            var columns = new List<string>();
            var values = new List<object>();
            foreach (var propertyInfo in properties)
            {
                //var item = GetItem<T>(row);
                if (lista?.Rows.Count > 0)
                {
                    var row = lista.Select().Where(x => x.Field<string>("column_name").ToLower().Trim().
                            Equals(propertyInfo.Name.ToLower().Trim()))
                        .FirstOrDefault();
                    if (row != null)
                    {
                        var ro = row["IS_NULLABLE"].ToString();
                        var valor = propertyInfo.GetValue(obj);
                        var columnName = propertyInfo.Name;
                        if (columnName.ToLower().Contains("stamp") &&
                            !columnName.ToLower().Equals("Formaspstamp".ToLower()))
                        {
                            if (!string.IsNullOrEmpty(valor.ToString()))
                            {
                                columns.Add(columnName);
                            }
                        }
                        else
                        {
                            columns.Add(columnName);
                        }
                        if (propertyInfo.PropertyType.Name == "String" 
                            || propertyInfo.PropertyType.Name == "Boolean")
                        {
                            if (!row["IS_NULLABLE"].ToBool())
                            {
                                if (!string.IsNullOrEmpty(tabe))
                                {
                                    if (columnName.ToLower().Contains("stamp")&& 
                                        !columnName.ToLower().Equals("formaspstamp".ToLower()))
                                    {
                                        if (string.IsNullOrEmpty(valor.ToString()))
                                        {
                                            propertyInfo.SetValue(obj, null);
                                        }
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(valor.ToString()))
                                    {
                                        propertyInfo.SetValue(obj, "");
                                    }
                                }
                            }
                            else
                            {

                                if (string.IsNullOrEmpty(valor.ToString()))
                                {
                                    propertyInfo.SetValue(obj, null);
                                }
                            }
                            if (columnName.ToLower().Contains("stamp") &&
                                !columnName.ToLower().Equals("Formaspstamp".ToLower()))
                            {
                                if (!string.IsNullOrEmpty(valor.ToString()))
                                {
                                    values.Add($@"'{propertyInfo.GetValue(obj)}'");
                                }
                            }
                            else
                            {
                                values.Add($@"'{propertyInfo.GetValue(obj)}'");
                            }

                        }
                        else if (propertyInfo.PropertyType.Name == "DateTime")
                        {
                            if (!row["IS_NULLABLE"].ToBool())
                            {
                                if (string.IsNullOrEmpty(valor?.ToString()) || valor.ToString()!.Contains("0001-"))
                                {
                                    propertyInfo.SetValue(obj, new DateTime(1900, 1, 1));
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(valor.ToString()))
                                {
                                    propertyInfo.SetValue(obj, null);
                                }
                            }
                            var dateTime = (DateTime)propertyInfo.GetValue(obj);

                            values.Add($@"'{dateTime.ToString("yyyy-MM-dd")}'");
                        }
                        else
                        {
                            if (!row["IS_NULLABLE"].ToBool())
                            {
                                if (propertyInfo.PropertyType == typeof(byte[]))
                                {
                                   
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(valor?.ToString()))
                                    {
                                        propertyInfo.SetValue(obj, 0);
                                    }
                                }
                            }
                            else
                            {
                                if (string.IsNullOrEmpty(valor?.ToString()))
                                {
                                    propertyInfo.SetValue(obj, null);
                                }
                            }
                            
                            values.Add(propertyInfo.GetValue(obj));
                        }
                    }

                }
            }
            sql += string.Join(", ", columns) + ") values(";
            sql += string.Join(", ", values) + ")";
            return (obj, sql);
            
        }
        
        public static T SetDefaultSave<T>(T f)
        {
            var t = f;
            var nomeClasse = typeof(T).Name;
            var lista = GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                $" WHERE table_name = '{nomeClasse.Trim()}' and IS_NULLABLE='YES' ", " column_name ");
            var properties = typeof(T).GetProperties();
            foreach (var p in properties)
            {
                var valor = p.GetValue(t);
                var stamp = $"{nomeClasse}stamp".ToLower();
                if (stamp.Equals(p.Name.ToLower()))
                {
                    if (valor != null)
                    {
                        if (valor.ToString().IsNullOrEmpty())
                        {
                            valor = Pbl.Stamp();
                        }
                    }
                    else if (valor == null)
                    {
                        valor = Pbl.Stamp();
                    }
                }
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
                    valor=valor.ToDateTimeValue();
                   
                }
                if (p.PropertyType == typeof(string))
                {
                    var r = lista?.AsEnumerable().FirstOrDefault(x => x.Field<string>("column_name").Equals(p.Name.Trim()));
                    if (r != null)
                    {
                        if (string.IsNullOrEmpty(valor?.ToString()))
                        {
                            valor = "";
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(valor?.ToString()))
                        {
                            valor = "";
                        }
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
                p.SetValue(t,valor);
            }
            return t;
        }



        public static Usr SetValoresCl(Usr r, Usr f) 
        {
            var t = f;

            var properties = typeof(Usr).GetProperties();
            var propertiesss = properties;

            foreach (var p in properties)
            {
                foreach (var campsls in propertiesss)
                {
                    if (campsls.Name.ToLower().Equals(p.Name.ToLower()))
                    {
                        var valor = p.GetValue(r);
                        p.SetValue(t, valor);
                    }
                }
            }
            return t;
        }



        public static void SetDefault(DataTable? dt)
        {
            if (dt?.Rows.Count > 0)
            {
                foreach (var dr in dt.AsEnumerable())
                {
                    try
                    {
                        var ctabela = dr.Table.TableName.ToLower();
                        var lista = GetGenDT(" INFORMATION_SCHEMA.COLUMNS ",
                            $" WHERE table_name = '{ctabela.Trim()}' and IS_NULLABLE='YES' ", " column_name ");
                        foreach (DataColumn col in dr.Table.Columns)
                        {
                            if (col.DataType == typeof(DateTime))
                            {
                                if (dr[col.ColumnName.Trim()] is DBNull)
                                {
                                    dr[col.ColumnName.Trim()] = new DateTime(1900, 1, 1);
                                }
                                if (dr[col.ColumnName.Trim()].ToString().Contains("0001"))
                                {
                                    dr[col.ColumnName.Trim()] = new DateTime(1900, 1, 1);
                                }
                            }
                            if (col.DataType == typeof(string))
                            {
                                var r = lista?.AsEnumerable().FirstOrDefault(x => x.Field<string>("column_name").Equals(col.ColumnName.Trim()));
                                if (r != null)
                                {
                                    if (string.IsNullOrWhiteSpace(dr[col.ColumnName.Trim()].ToString()))
                                    {
                                        dr[col.ColumnName.Trim()] = null;
                                    }
                                    else if (dr[col.ColumnName.Trim()].ToString() == "")
                                    {
                                        dr[col.ColumnName.Trim()] = null;
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(dr[col.ColumnName.Trim()].ToString()))
                                    {
                                        dr[col.ColumnName.Trim()] = "";
                                    }
                                }
                                dr[col.ColumnName.Trim()] = EF.RemoveHtmlTags(dr[col.ColumnName.Trim()].ToString());

                            }
                            if (col.DataType == typeof(decimal))
                            {
                                if (dr[col.ColumnName.Trim()] is DBNull)
                                {
                                    dr[col.ColumnName.Trim()] = 0;
                                }
                            }
                            if (col.DataType == typeof(int))
                            {
                                if (dr[col.ColumnName.Trim()] is DBNull)
                                {
                                    dr[col.ColumnName.Trim()] = 0;
                                }
                            }
                            if (col.DataType == typeof(bool))
                            {
                                if (dr[col.ColumnName.Trim()] is DBNull)
                                {
                                    dr[col.ColumnName.Trim()] = false;
                                }
                            }
                            if (col.DataType == typeof(byte[]))
                            {
                                if (dr[col.ColumnName.Trim()] is DBNull)
                                {
                                    dr[col.ColumnName.Trim()] = 0;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        private static GCon _gc;
        private static GCon1 _gc1;
        private static SqlCommand _cmd;
        public static int Apagar(string Ctabela, string? CLocalStamp)
        {
            var qry = $@"DECLARE @chave varchar(30);
                            DECLARE @Tabela varchar(30);
                            SET @Tabela='{Ctabela}'
                            SELECT @chave=column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
                                                WHERE table_name = @Tabela and CONSTRAINT_NAME like('PK%');;
                            DECLARE @qry varchar(200) ;
                            SET @qry= N'delete FROM '+@Tabela+ '  where '+@chave+ '=''{CLocalStamp.Trim()}''';
                            EXEC (@qry)";
            using (_gc = new GCon())
            {
                _cmd = new SqlCommand(qry, _gc.NResult);
                return _cmd.ExecuteNonQuery();
            }
        }
        public static ArrayList ToArrayList(this DataTable dt, string columnName)
        {
            var data = new ArrayList();
            foreach (DataRow row in dt.Rows)
            {
                if (row == null) continue;
                data.Add(row[columnName].ToString());
            }
            return data;
        }

        public static int SqlCmd(string str)
        {
            using (_gc = new GCon())
            {
                _cmd = new SqlCommand(str, _gc.NResult);
                var r = _cmd.ExecuteNonQuery();
                return r;
            }
        }
       

        public static DataTable GetGenDT(string tabela, string orderbyOrWhere, string select = null)
        {
            using (_gc = new GCon())
            {
                if (select == null)
                {
                    select = "*";
                }
                var query = $"SELECT {select} FROM {tabela}  {orderbyOrWhere}";
                return GetGen2DT(query);
            }
        }

        public static DataTable GetDT(string tabela, string campos = null, string filtro = null, string orderby = null)
        {
            using (_gc = new GCon())
            {
                if (campos == null)
                {
                    campos = "*";
                }

                if (filtro != null)
                {
                    filtro = $" where {filtro} ";
                }

                if (orderby != null)
                {
                    orderby = $" Order by {orderby} ";
                }
                var query = $"SELECT {campos} FROM {tabela}  {filtro} {orderby}";
                var sqlComando = new SqlCommand(query, _gc.NResult);
                return GetReturnTable(sqlComando, tabela);
            }
        }
        public static DataTable GetDT(string tabela, string filtro = null)
        {
            using (_gc = new GCon())
            {
                if (filtro != null)
                {
                    filtro = $"where {filtro}";
                }
                var query = $"SELECT * FROM {tabela}  {filtro}";
                var sqlComando = new SqlCommand(query, _gc.NResult);
                return GetReturnTable(sqlComando, tabela);
            }
        }
        public static DataRow GetRow(string tabela, string filtro = null)
        {
            DataRow dr = null;
            using (_gc = new GCon())
            {
                if (filtro != null)
                {
                    filtro = $"where {filtro}";
                }
                else
                {
                    filtro = "";
                }
                var query = $"SELECT * FROM {tabela}  {filtro}";
                var sqlComando = new SqlCommand(query, _gc.NResult);
                var dt = GetReturnTable(sqlComando, tabela);
                if (dt?.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                }
                return dr;
            }

        }
        public static DataRow GetRow(string campos, string tabela, string filtro = null)
        {
            DataRow dr = null;
            using (_gc = new GCon())
            {
                if (filtro != null)
                {
                    filtro = $"where {filtro}";
                }
                else
                {
                    filtro = "";
                }
                var query = $"SELECT {campos} FROM {tabela}  {filtro}";
                var sqlComando = new SqlCommand(query, _gc.NResult);
                var dt = GetReturnTable(sqlComando, tabela);
                if (dt?.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                }
                return dr;
            }

        }
        public static DataRow GetRow(string querry)
        {
            DataRow dr = null;
            var dt = GetGen2DT(querry);
            if (dt?.Rows.Count > 0)
            {
                dr = dt.Rows[0];
            }
            return dr;
        }
        public static string GenerateSelectQuery<T>(params string[] excludedProperties)
        {
            var type = typeof(T);
            var properties = type.GetProperties()
                .Where(p =>
                    // Exclui propriedades explicitamente informadas
                    !excludedProperties.Contains(p.Name, StringComparer.OrdinalIgnoreCase)
                    // Exclui byte[]
                    && p.PropertyType != typeof(byte[])
                    // Exclui ICollection<T> e List<T>
                    && !(p.PropertyType.IsGenericType &&
                         (p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) ||
                          p.PropertyType.GetGenericTypeDefinition() == typeof(List<>)))
                    // Exclui entidades (classes definidas pelo usuário, exceto string e tipos primitivos)
                    && (p.PropertyType.IsValueType || p.PropertyType == typeof(string))
                )
                .Select(p => p.Name);

            var columns = string.Join(", ", properties);
            return $"SELECT {columns} FROM {typeof(T).Name}";
        }
        public static T GetRowToEnt<T>(string condicao = null, string join = "") where T : class, new()
        {
            var tabela = new T().GetType().Name;
            string cond = "";
            if (!string.IsNullOrEmpty(condicao))
            {
                cond = $"where {condicao}";
            }
            var querry = $"select * from {tabela} {join} {cond}";
            var dt = GetGen2DT(querry);
            if (dt?.Rows.Count > 0)
            {
                return dt.Rows[0].DrToEntity<T>();
            }
            return null;
        }
        public static T GetRowToEnt<T>(string condicao = null) where T : class, new()
        {
            var tabela = new T().GetType().Name;
            string cond = "";
            if (!string.IsNullOrEmpty(condicao))
            {
                cond = $"where {condicao}";
            }
            var querry = $"select * from {tabela} {cond}";
            var dt = GetGen2DT(querry);
            if (dt?.Rows.Count > 0)
            {
                return dt.Rows[0].DrToEntity<T>();
            }
            return null;
        }

        public static DataTable GetGenDt(string qry)
        {
            using (_gc = new GCon())
            {
                var dtable = new DataTable();
                try
                {
                    var sqlComando = new SqlCommand(qry, _gc.NResult);
                    var sqlDataAdapter = new SqlDataAdapter(sqlComando);
                    sqlDataAdapter.Fill(dtable);
                    return dtable;
                }
                catch (Exception)
                {
                    return dtable;
                }
            }
        }
        public static DataTable GetGenOutraEstancia(string qry, SqlConnection con)
        {
            con.Open();
            var sqlComando = new SqlCommand(qry, con);
            var sqlDataAdapter = new SqlDataAdapter(sqlComando);
            var dtable = new DataTable();
            sqlDataAdapter.Fill(dtable);
            con.Close();
            return dtable;
        }
        public static bool CheckExist(string select)
        {
            var retorno = false;
            if (GetGen2DT(select)?.Rows.Count > 0)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool CheckExist(string campos, string tabela, string condicao = null)
        {
            var retorno = false;
            var select = $"select {campos} from {tabela}";
            if (!string.IsNullOrEmpty(condicao))
            {
                select += $" where {condicao}";
            }
            if (GetGen2DT(select)?.Rows.Count > 0)
            {
                retorno = true;
            }
            return retorno;
        }
        public static DataTable GetTableFromField(string campo, string tabela, string cond = null)
        {
            var qry = $"select {campo} from {tabela} ";
            if (cond != null)
            {
                qry = $"{qry} where {cond}";
            }
            using (_gc = new GCon())
            {
                var dtable = new DataTable();
                try
                {
                    var sqlComando = new SqlCommand(qry, _gc.NResult);
                    var sqlDataAdapter = new SqlDataAdapter(sqlComando);
                    sqlDataAdapter.Fill(dtable);
                    return dtable;
                }
                catch (Exception)
                {
                    return dtable;
                }
            }
        }

        
        public static DataTable GetGen2DT(string querry)
        {
            var dtable = new DataTable();
            try
            {
                if (querry == null) return null;
                using (_gc = new GCon())
                {
                    try
                    {
                        var sqlComando = new SqlCommand(querry, _gc.NResult);
                        var sqlDataAdapter = new SqlDataAdapter(sqlComando);
                        sqlDataAdapter.Fill(dtable);
                        return dtable;
                    }
                    catch (Exception)
                    {
                        return dtable;
                    }
                }
            }
            catch (Exception ex)
            {
                
                return dtable;
            }
        }

        public static DataTable GetGen2DtLocal(string querry)
        {
            var dtable = new DataTable();
            try
            {
                if (querry == null) return null;
                using (_gc1 = new GCon1())
                {
                    try
                    {
                        var sqlComando = new SqlCommand(querry, _gc1.NResult);
                        var sqlDataAdapter = new SqlDataAdapter(sqlComando);
                        sqlDataAdapter.Fill(dtable);
                        return dtable;
                    }
                    catch (Exception)
                    {
                        return dtable;
                    }
                }
            }
            catch (Exception ex)
            {

                return dtable;
            }
        }
        internal static DataTable GetReturnTable(SqlCommand cmd, string tabela)
        {
            var sqlDataAdapter = new SqlDataAdapter(cmd);
            var dtable = new DataTable { TableName = tabela };
            sqlDataAdapter.Fill(dtable);
            return dtable;
        }



        public static DataRow InicializeEnty(this DataRow dr)
        {
            var ctabela = dr.Table.TableName.ToLower();
            foreach (DataColumn col in dr.Table.Columns)
            {
                if (col.DataType == typeof(DateTime))
                {
                    dr[col.ColumnName.Trim()] = Pbl.SqlDate;
                }
                if (col.DataType == typeof(string))
                {

                    dr[col.ColumnName.Trim()] = "";
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

        public static DataTable ParaDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }



        public static DataTable ToDataTable<T>(this T entity) where T : class
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
        public static DataTable FillDataEnt(
         DataTable dtFilha,  DataTable dtPrincipal)
        {
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
                    dtFilha.TableName = "DMZ";
                    for (var j = 0; j < colReais; j++)
                    {
                        dtFilha.Columns[j].ColumnName = $"Col{j + 1}";
                    }
                    dtPrincipal = dtFilha.Clone();
                    foreach (DataRow row in dtFilha.Rows)
                    {
                        dtPrincipal.ImportRow(row);
                    }


                }
                
            }
            var ret = dtPrincipal;
            ret.TableName = dtPrincipal.TableName;
            return ret;
        }



        #region Convert DataTable to List of Entity..... 
        public static List<T?> DtToList<T>(this DataTable? dt) where T : class
        {

            var data = new List<T>();
            if (!dt.HasRows())
            {
                return data;
            }
            if (!(dt?.Rows.Count > 0)) return data;
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                var item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr) where T : class
        {
            var entity = Activator.CreateInstance<T>();
            if (dr != null)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    foreach (DataColumn cln in dr.Table.Columns)
                    {
                        if (cln == null) continue;
                        var p = Utilities.GetProperty(cln.ColumnName, entity);
                        if (p == null) continue;
                        Utilities.BindValue(entity, p, dr[cln.ColumnName] is DBNull ? "" : dr[cln.ColumnName]);
                    }
                }
            }
            return entity;
        }

        public static List<string> ToList(this DataTable dt, string columnName)
        {
            var data = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                if (row == null) continue;
                data.Add(row[columnName].ToString());
            }
            return data;
        }
        public static T DrToEntity<T>(this DataRow row) where T : class, new()
        {
            var data = GetItem<T>(row);
            return data;
        }
        public static void DataFromEntity<T>(this DataRow dr, T entity) where T : class
        {
            if (dr == null) return;
            foreach (DataColumn cln in dr.Table.Columns)
            {
                if (cln == null) continue;
                var p = Utilities.GetProperty(cln.ColumnName, entity);
                if (p == null) continue;
                dr[cln.ColumnName] = p.GetValue(entity, null);
            }
        }
        public static void AddNewRow<T>(this DataTable dt, T entity) where T : class
        {
            var dr = dt.NewRow();
            foreach (DataColumn cln in dr.Table.Columns)
            {
                if (cln == null) continue;
                var p = Utilities.GetProperty(cln.ColumnName, entity);
                if (p == null) continue;
                dr[cln.ColumnName] = p.GetValue(entity, null);
                // BindValue(entity, p, dr[cln.ColumnName]);
            }

            dt.Rows.Add(dr);

        }
        public static void AddRow<T>(this DataTable dt, T entity) where T : class
        {
            var dr = dt.Rows.Count > 0 ? dt.Rows[dt.Rows.Count - 1] : dt.NewRow();

            foreach (DataColumn cln in dr.Table.Columns)
            {
                if (cln == null) continue;
                var p = Utilities.GetProperty(cln.ColumnName, entity);
                if (p == null) continue;
                dr[cln.ColumnName] = p.GetValue(entity, null);
                // BindValue(entity, p, dr[cln.ColumnName]);
            }

            if (dt.Rows.Count == 1)
            {
                dt.Rows.Add(dr);
            }
        }
       
        public static IQueryable<T> Search<T>(this IQueryable<T> source, Expression<Func<T, string>> stringProperty, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return source;
            }

            //Create expression to represent x.[property] != null
            var isNotNullExpression = Expression.NotEqual(stringProperty.Body,
                                                          Expression.Constant(null));

            //Create expression to represent x.[property].Contains(searchTerm)
            var searchTermExpression = Expression.Constant(searchTerm);
            var checkContainsExpression = Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);

            //Join not null and contains expressions
            var notNullAndContainsExpression = Expression.AndAlso(isNotNullExpression, checkContainsExpression);

            var methodCallExpression = Expression.Call(typeof(Queryable), "Where", new[] { source.ElementType },
                                                       source.Expression,
                                                       Expression.Lambda<Func<T, bool>>(notNullAndContainsExpression, stringProperty.Parameters));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
        //public static DataTable? ToDataTable<T>(this T entity) where T : class
        //{
        //    var properties = typeof(T).GetProperties();
        //    var table = new DataTable { TableName = entity.GetType().Name };

        //    foreach (var property in properties)
        //    {
        //        var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        //        table.Columns.Add(property.Name, type);
        //    }
        //    table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
        //    return table;
        //}
        #endregion

        public static string _sql;
        #region Retorna o Maximo de uma tabela ......

       
        public static decimal VMax(string campo, string tabela, string cond = null)
        {

            using (_gc = new GCon())
            {
                var condicao = "";
                if (cond != null)
                {
                    condicao = $" where {cond}";
                }

                var qry = $"select ISNULL(max({campo}),0) +1 as {campo} from {tabela} {condicao}";
                var adp = new SqlDataAdapter(new SqlCommand(qry, _gc.NResult));
                var dtable = new DataTable();
                adp.Fill(dtable);
                return dtable.Rows[0][0].ToDecimal();
            }

        }
        #endregion
        public static int Maximo(string tabela, string campo, string condicao="")
        {
            var number = 0;
            if (!string.IsNullOrEmpty(condicao))
            {
                condicao = $"and {condicao}";
            }
            _sql = $"select ISNULL(max(convert(int,{campo})),0) +1 as {campo.Replace("p.","")} from {tabela}" +
                   $" where isnumeric({campo}) = 1 {condicao}";
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand(_sql, _gc.NResult);
                var sqlDataAdapter = new SqlDataAdapter(sqlComando);
                var dtable = new DataTable();
                sqlDataAdapter.Fill(dtable);
                if (dtable.Rows.Count > -1)
                {
                    number = Convert.ToInt32(dtable.Rows[0][0]);
                }
            }

            return number;
        }

        public static string GetValue(string s)
        {
            var dt = GetGen2DT(s);
            var str = "";
            if (dt?.Rows.Count > 0)
            {
                str = dt.Rows[0][0].ToString();
            }
            return str;
        }

        public static string GetValue(string campo, string tabela, string cond = null)
        {
            var qry = $"select {campo} from {tabela} ";
            if (cond != null)
            {
                qry = $"{qry} where {cond}";
            }
            var dt = GetGen2DT(qry);
            var str = "";
            if (dt?.Rows.Count > 0)
            {
                str = dt.Rows[0][0].ToString();
            }
            return str;
        }
        #region Carregamento de ListView.....
        #endregion


        public static SqlDataReader _dr;
        public static SqlCommand _cmdSql;
        public static string _type;
        public static string GetTipo(string tabela, string campo)
        {
            _sql = $"select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME ='{tabela.Trim()}' and COLUMN_NAME='{campo}' " +
                   "order by ORDINAL_POSITION ";
            var dt = GetGenDt(_sql);
            if (!dt.HasRows())
            {
                return "nvarchar";
            }

            _type = dt.RowZero("DATA_TYPE").ToString();
            return _type;
            //using (_gc = new GCon())
            //{



            //    _cmdSql = new SqlCommand(_sql, _gc.NResult);
            //    _dr = _cmdSql.ExecuteReader();
            //    while (_dr.Read())
            //    {
            //        _type = _dr[0].ToString();
            //    }
            //    return _type;
            //}
        }
        public static DataTable SqlSP(string spName, List<SqlParameter> sqlParameter = null)
        {
            using (_gc = new GCon())
            {
                var sqlComando = new SqlCommand(spName, _gc.NResult);
                sqlComando.CommandType = CommandType.StoredProcedure;
                if (sqlParameter != null)
                {
                    sqlComando.Parameters.AddRange(sqlParameter.ToArray());
                }
                var sqlDataAdapter = new SqlDataAdapter(sqlComando);
                var dtable = new DataTable();
                sqlDataAdapter.Fill(dtable);
                return dtable;
            }
        }
        public static object GetField(string qry)
        {
            object ret = null;
            var dt = GetGenDt(qry);
            if (dt?.Rows.Count > 0)
            {
                ret = dt.Rows[0][0];
            }

            return ret;
        }
        public static object GetField(string campo, string tabela, string condicao = null)
        {
            string qry;
            object ret = null;
            qry = condicao == null ? $"select {campo} from {tabela}" : $"select {campo} from {tabela} where {condicao}";

            var dt = GetGenDt(qry);
            if (dt?.Rows.Count > 0)
            {
                ret = dt.Rows[0][0];
            }

            return ret;
        }

        public static DataTable Initialize(string tabela)
        {
            return GetGen2DT($"Select * from {tabela} where 1=0");
        }
        public static DataTable Initialize<T>() where T : class, new()
        {
            var ent = new T();
            DataTable dt = new DataTable(ent.GetType().Name);
            var props = ent.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                if (prop != null)
                {
                    var col = new DataColumn
                    {
                        ColumnName = prop.Name,
                        DataType = prop.PropertyType
                    };
                    dt.Columns.Add(col);
                }
            }
            return dt;
        }




        #region Salvar CC
        public static DataRowView DtPlanovView { get; set; }
        public static DataTable _falctl { get; set; }
        public static DataTable DtTurmanota { get; set; }
        public static TdocMat TmpTdocMat;
        public static async void AfterSave(MatriculaAluno mtAluno, SGPMContext _dbContext)
        {
            DataTable dtpar;

            TmpTdocMat = GetRowToEnt<TdocMat>($"TdocMatstamp='{mtAluno.Refonecedor}'");
            if (TmpTdocMat.Inscricao)
            {
                var quer = $@"select getdate() Data,sts.Preco ValorTotal,Parecela=1 ,Descricao,st.Ststamp Planopagstamp
from st inner join  stprecos sts on st.ststamp=sts.ststamp  
where TipoProduto=1 and Descricao like '%{TmpTdocMat.Descricao.Trim()}%'";
                dtpar = GetGenDt(quer);
            }
            else
            {
                if (TmpTdocMat.Matricula)
                {

                    var niv = 1;
                    var qyrmulta = "";
                    var quer = $@"select Planopagstamp,Descricao,descanosem,Cursostamp,AnoSemstamp,DataFim,Datapartida  
from Planopag where descanosem='{mtAluno.AnoSem}'";
                    var dtplano = GetGenDt(quer);
                    if (dtplano.HasRows())
                    {
                        if (mtAluno.Curso.ToLower().Contains("lic"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%lic%'");
                        }
                        else if (mtAluno.Curso.ToLower().Contains("mestr"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%mestr%'");

                        }
                        else if (mtAluno.Curso.ToLower().Contains("pos"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%pos%'");

                        }
                        else if (mtAluno.Curso.ToLower().Contains("dou"))
                        {
                            dtplano = dtplano.GetTable($"Descricao like '%dou%'");

                        }

                        if (dtplano.HasRows())
                        {
                            var dr = dtplano.Rows[0];
                            DtPlanovView = dr.Table.DefaultView[dtplano.Rows.IndexOf(dr)];
                        }
                    }

                    if (DtPlanovView != null)
                    {
                        var fim = DtPlanovView["DataFim"].ToDateTimeValue();
                        if (fim < DateTime.Now)
                        {
                            if (mtAluno.Curso.ToLower().Contains("licenciatura"))
                            {
                                niv = 1;
                            }
                            if (mtAluno.Curso.ToLower().Contains("mestrado"))
                            {
                                niv = 2;
                            }
                            qyrmulta = $@" union all select distinct Data=GETDATE(),stp.Preco ValorTotal,Parcela=10,
st.Descricao,st.Ststamp Planopagpstamp from st inner join StPrecos stp 
on st.Ststamp=stp.Ststamp where Servico=1 and TipoProduto=1 and Multa=1 and st.tara={niv}";
                        }
                    }
                    var qry = $@"select Data,ValorTotal,
                                       Parecela,descricao,
                                       Planopagpstamp from Planopagp where 
                                       Planopagstamp='{mtAluno.Planopagstamp}' 
                                            {qyrmulta}
                                       order by Parecela";
                    dtpar = GetGenDt(qry);
                }
                else
                {
                    dtpar = GetGenDt($@"select Data,ValorTotal,
                                       Parecela,descricao,
                                       Planopagpstamp from Planopagp where 
                                       Planopagstamp='{mtAluno.Planopagstamp}' 
                                       order by Parecela");
                }
            }
            if (dtpar.HasRows())
            {
                var TmpTdoc = GetRowToEnt<Tdoc>("ft=1");
                var _turmap = GetRowToEnt<Turma>($"turmastamp='{mtAluno.Turmastamp}'");
                if (_turmap != null)
                {
                    var dt = _turmap.ToDataTable();
                    var campos = new[]
                    {
                       "Turmastamp", "Codigo","Descanoaem", "Descurso", "Cursostamp","Etapa"
                   };
                    if (dt.HasRows())
                    {
                        dt = dt.DefaultView.
                            ToTable(true, campos);
                    }

                    if (dt.HasRows())
                    {
                        var dr = dt.Rows[0];
                        Dtv = dr.Table.DefaultView[dt.Rows.IndexOf(dr)];
                    }
                }
                var entidade = GetGenDt($"select * from contas where Contasstamp='{mtAluno.Codfac}'");

                if (entidade.HasRows())
                {
                    var dr = entidade.Rows[0];
                    DtEntidade = dr.Table.DefaultView[entidade.Rows.IndexOf(dr)];
                }
                else
                {
                    entidade = GetGenDt($"select top 1 * from contas");
                    if (entidade.HasRows())
                    {
                        var dr = entidade.Rows[0];
                        DtEntidade = dr.Table.DefaultView[entidade.Rows.IndexOf(dr)];
                    }

                }

                if (mtAluno.Inscricao || mtAluno.Matricula)
                {
                    Numinterno = mtAluno.Planopagstamp;
                }
                else
                {
                    Numinterno = $@"Exameespecial_{DateTime.Now.ToShortDateString()}";
                }
                foreach (var item in dtpar.AsEnumerable())
                {
                    if (item != null)
                    {
                        var ckexist = CheckExist($@"
select fact.factstamp from fact inner join factl
on fact.Factstamp=factl.Factstamp
where
Turmastamp='{mtAluno.Turmastamp.Trim()}'
and clstamp='{mtAluno.Clstamp}'
and Anosem='{mtAluno.AnoSem}'
and factl.descricao='{item["descricao"]}'");
                        if (!ckexist)
                        {

                            var ft = Utilities.DoAddline<Fact>();
                            var Cl = GetRowToEnt<Cl>($"Clstamp='{mtAluno.Clstamp}'");
                            HelperFact.FillFactura(ft, Cl, item["Data"].ToDateTimeValue(), TmpTdoc,
                                DtEntidade, Dtv, Numinterno);
                            ft.Ft = true;
                            ft.Movcc = true;
                            var ftl = Initialize("factl");
                            var dr = ftl.NewRow().Inicialize();
                            HelperFact.FillFactl(item, dr, ft.Factstamp);
                            ftl.Rows.Add(dr);
                            HelperFact.TotaisFt(ft, ftl);
                            ft.MatriculaAluno = mtAluno.Matricula;
                            ft.Inscricao = mtAluno.Inscricao;
                            ft.Nomedoc = TmpTdoc.Descricao;
                            EF._dbContext = _dbContext;
                            Utilities.AllTrim(ft);
                            var dt = ft.EntiyToDataTable();

                            var ddd = Save(dt, "fact", true, ft.Factstamp, "fact"); ;
                            if (ddd.numero > 0)
                            {
                                Save(ftl, "factl", true, ft.Factstamp, "fact");
                            }

                        }
                    }
                }
            }

            if (mtAluno.MatriculaTurmaAlunol != null)
            {
                var dtturmas = mtAluno.MatriculaTurmaAlunol.ToList().ParaDataTable();
                var camposs = new[]
                {
                "MatriculaTurmaAlunolstamp", "Turmastamp"
            };
                if (dtturmas.HasRows())
                {
                    dtturmas = dtturmas.DefaultView.
                        ToTable(true, camposs);
                    dtturmas.Columns.Add("Clstamp", typeof(string));
                    dtturmas.Columns.Add("Nome", typeof(string));
                    dtturmas.Columns.Add("No", typeof(string));
                    dtturmas.Columns["MatriculaTurmaAlunolstamp"].ColumnName = "Turmalstamp";
                    dtturmas.AcceptChanges();
                    var dd = dtturmas.DtToList<Turmal>();
                    foreach (var tml in dd)
                    {
                        var ddss = GetGenDt($@"select Turmalstamp from Turmal where Turmalstamp='{tml.Turmalstamp.Trim()}'");
                        if (!ddss.HasRows())
                        {
                            tml.Clstamp = tml.Clstamp;
                            tml.No = tml.No;
                            tml.Nome = tml.Nome;
                            Utilities.AllTrim(tml);
                            var dt = tml.EntiyToDataTable();
                            var ddd = Save(dt, "Turmal", true, tml.Turmalstamp, "Turmal"); ;

                        }
                    }

                    var dtturmass = mtAluno.MatriculaTurmaAlunol;
                    foreach (var tml in dtturmass)
                    {
                        //Inserção na tabela de disciplinas da turma
                        if (mtAluno.DisciplinaTumra != null)
                        {

                            dtturmas = mtAluno.DisciplinaTumra.ToList().ParaDataTable();
                            try
                            {
                                dtturmas.Columns["DisciplinaTumrastamp"].ColumnName = "Turmadiscstamp";
                            }
                            catch (Exception)
                            {
                                //
                            }
                            dtturmas.AcceptChanges();

                            var ddsc = dtturmas.DtToList<Turmadisc>();
                            DtTurmanota = Initialize("Turmanota");
                            foreach (var tmsl in ddsc)
                            {
                                var dl = GetGenDt($@"select Turmadiscstamp 
from Turmadisc where Turmadiscstamp='{tmsl.Turmadiscstamp.Trim()}'");
                                if (!dl.HasRows())
                                {
                                    Utilities.AllTrim(tmsl);
                                    var dt = tmsl.EntiyToDataTable();
                                    var ddd = Save(dt, "Turmadisc", true, tmsl.Turmadiscstamp, "Turmadisc"); ;


                                }
                                //Adicionar Este aluno na tabela de lançamento de notas
                                var rw = DtTurmanota.NewRow().Inicialize();
                                rw["Turmastamp"] = tml.Turmastamp;
                                rw["Alunostamp"] = mtAluno.Clstamp;
                                rw["AlunoNome"] = mtAluno.Nome;
                                rw["No"] = mtAluno.No;
                                rw["Coddis"] = tmsl.Ststamp;
                                rw["Disciplina"] = tmsl.Disciplina;
                                rw["Anosem"] = tml.Descanoaem;
                                rw["Sem"] = tml.Etapa;
                                rw["Cursostamp"] = mtAluno.Codcurso;
                                var professor = GetGenDt($"select Pestamp,Nome from Turmadiscp " +
                                                                                 $"where Ststamp='{tmsl.Ststamp.Trim()}'");
                                if (professor.HasRows())
                                {
                                    rw["Pestamp"] = professor.Rows[0]["Pestamp"];
                                    rw["Profnome"] = professor.Rows[0]["Nome"];
                                }
                                if (professor.Rows.Count == 2)
                                {
                                    rw["Pestamp2"] = professor.Rows[1]["Pestamp"];
                                    rw["Profnome2"] = professor.Rows[1]["Nome"];
                                }
                                DtTurmanota.Rows.Add(rw);
                            }
                        }
                    }
                }


            }

            if (DtTurmanota.HasRows())
            {

                foreach (var item in DtTurmanota.DtToList<Turmanota>())
                {
                    var qry = $"select Turmanotastamp from Turmanota where " +
                        $" Cursostamp='{item.Cursostamp}' and Turmastamp ='{item.Turmastamp}' and " +
                        $"Anosem='{item.Anosem}' and Coddis='{item.Coddis}' and alunostamp='{item.Alunostamp}'";

                    var dl = GetGenDt(qry);
                    //var ss =ConvertToInsertIntoSql(item);
                    if (!dl.HasRows())
                    {

                        Utilities.AllTrim(item);
                        var dt = item.EntiyToDataTable();
                        var ddd = Save(dt, "Turmanota", true, item.Turmanotastamp, "Turmanota"); ;

                    }
                }
            }
        }
        
        public static Fact _fact;

        public static Tdoc TmpTdoc;
        public static void InicializaLinhasdeFactura(MatriculaAluno Cls)
        {
            if (Cls != null)
            {
                if (TmpTdoc == null)
                {
                    TmpTdoc = GetRowToEnt<Tdoc>("ft=1");
                }
                //o problema estava aqui
                _fact = null;
                var fact = GetGenDt($@"select f.* from ClCCF() c inner join factl f
on c.ccstamp=f.Factstamp
where Clstamp='{Cls.Clstamp}'
order by f.ref");
                if (fact.HasRows())
                {
                    _fact =
                        fact.DtToList<Fact>().FirstOrDefault();//SQL.GetRowToEnt<Fact>(
                }                               //$"clstamp='{Cl.Clstamp.Trim()}'");
                if (_fact != null)
                {
                    _fact.Obs = _fact.Referencia;


                    _falctl = GetGenDt($"select fl.* from factl fl inner join ClCCF() f " +
                                                               $"on fl.Factstamp=f.ccstamp" +
                                                               $" where clstamp='{Cls.Clstamp.Trim()}'" +
                                                               $" order by fl.ref" +
                                                               $" ");//ate aqui

                    if (_falctl.HasRows())
                    {
                        foreach (DataRow row in _falctl.Rows)
                        {
                            row["Armazemstamp"] = _fact.Entidadebanc;
                            row["Obs"] = _fact.Referencia;
                            //row["descricao"] = "Matrícula";
                        }
                    }
                }
            }
        }
        #endregion

    }

    public class PrintSetup
    {
        public bool Inserindo { get; set; }
        public string OrigemlabelText { get; set; }
        public string CLocalStamp { get; set; }
        public string No { get; set; }
        public string Nomfile { get; set; }
        public string Origem { get; set; }
       // public Form MdiForm { get; set; }
        public string XmlString { get; set; }
        public DataTable DtPrint { get; internal set; }
        public DataTable Formasp { get; internal set; }
      //  public DS Ds { get; internal set; }
        public bool UseFormasp { get; internal set; }
        public string Filtro { get; set; }
        public string CTituloRelatorio { get; set; }
        public string Impressora { get; internal set; }
        public decimal NrCopias { get; internal set; }
        public List<string> ListaTipodoc { get; internal set; }
        public string LinguaNacional { get; internal set; }
        public string Intervalo { get; internal set; }
        public string NomeProduto { get; internal set; }
        public string EntidadePrint { get; internal set; }
       // public List<ReportParameter> ListaParam { get; internal set; }

        public string DataSource2 { get; internal set; }
        public string DataSource3 { get; internal set; }
        public string DataSource4 { get; internal set; }
        public string DataSource5 { get; internal set; }
        public string DatasetName { get; set; } = "DataSet1";
        public string Horario { get; internal set; }
        public string Turmadisc { get; internal set; }
    }
}
