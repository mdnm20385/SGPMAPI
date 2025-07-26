using System.Data;
using System.Drawing.Imaging;
using System.Globalization;
using System.Net.Mime;
using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using DAL.Extensions.Extensions;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Mvc;
using Model.Models;
using Model.Models.Gene;
using Model.Models.SJM;
using Newtonsoft.Json;
using SGPMAPI.Interfaces;
using SGPMAPI.Procura;
using SGPMAPI.Report;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public SGPMContext _dbContext;
        private readonly InterGeral _serviGeral;
        private readonly InterfaceProcura procura;
        public ReportController(IWebHostEnvironment webHost, SGPMContext dbContext,
            InterGeral serviGeral, InterfaceProcura _procura)
        {
            _serviGeral = serviGeral;
            _dbContext = dbContext;
            DAL.BL.EF._dbContext = _dbContext;
            _webHost = webHost;
            procura = _procura;
        }

        [Route("ImportarDados")]
        [HttpGet]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> ImportarDados()
        {
            try
            {
                SQL.SqlCmd($"delete pa;\r\ndelete Processo;\r\ndelete EntradaProcesso;\r\ndelete SaidaProcesso;");
                ServiceResponse<Selects> rsp = new ServiceResponse<Selects>();
             
                rsp.Sucesso = true;
                rsp.Mensagem = "";
                return Ok(rsp);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao executar a operação, Código do erro {ex.Message}");
            }
        }

        private static DataTable DataTable(string tabela)
        {
            DataTable rett;
            DataTable dt;
            rett = SQL.GetGen2DtLocal($"Select * from  {tabela}");
            dt = SQL.Initialize(tabela);
            foreach (DataRow row in rett.Rows)
            {
                var newrow = dt.NewRow().Inicialize();
                foreach (DataColumn col in dt.Columns)
                {
                    if (rett.Columns.Cast<DataColumn>()
                        .Any(c => c.ColumnName.Equals(col.ColumnName, StringComparison.OrdinalIgnoreCase)))
                    {
                        if (col.DataType == typeof(DateTime))
                        {
                            // Fazer o parse corretamente com formato americano
                            try
                            {
                                DateTime data;
                                var s = row[col.ColumnName].ToString();

                                if (
                                    DateTime.TryParseExact(s, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out data)
                                    ||
                                    DateTime.TryParseExact(s, "yyyy-MM-dd HH:mm:ss.000", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out data)
                                    ||
                                    DateTime.TryParseExact(s, "MM/dd/yyyy HH:mm:ss HH:mm:ss.000", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out data)
                                    ||
                                    DateTime.TryParseExact(s, "MM/dd/yyyy HH:mm:ss HH:mm:ss", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out data)
                                    ||
                                    DateTime.TryParseExact(s, "dd/MM/yyyy HH:mm:ss HH:mm:ss.000", CultureInfo.InvariantCulture,
                                        DateTimeStyles.None, out data)
                                    ||
                                    DateTime.TryParseExact(s, "dd/MM/yyyy HH:mm:ss HH:mm:ss",
                                        CultureInfo.InvariantCulture, DateTimeStyles.None, out data)
                                )
                                {
                                    //data = DateTime.ParseExact(row[col.ColumnName].ToString(), "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                                    newrow[col.ColumnName] = data;
                                }
                            }
                            catch (Exception)
                            {
                                //
                            }
                        }
                        else
                        {
                            newrow[col.ColumnName] = row[col.ColumnName];
                        }
                    }
                }

                dt.Rows.Add(newrow);
            }

            return dt;
        }

        private readonly IWebHostEnvironment _webHost;
        [HttpGet]
        [Route("Filevis")]
        public async Task<object> Filevis(string ficheiro = "Pdf")
        {
            try
            {
                var prt = $"{_webHost.ContentRootPath}Reports";
                var pt1 = System.IO.Path.Combine(System.IO.Path.Combine
                    (System.IO.Path.Combine(prt, "rcl"), "Pdf"), ficheiro);
                var btes = await System.IO.File.ReadAllBytesAsync($"{pt1}");
                if (System.IO.File.Exists($"{pt1}"))
                {
                    System.IO.File.Delete($"{pt1}");
                }
                return File(btes, MediaTypeNames.Application.Pdf);
            }
            catch (Exception ex)
            {
                //
            }

            return null;
        }
        private string Path { get; set; } = "";
        private readonly MapaDeJuntaMedicaMilitarBLL _mapaDeJuntaMedicaMilitar = new();

        [Route("RelatorioPri1")]
        [HttpPost]
        public async Task<object> RelatorioPri1([FromBody] Trabalho busca)
        {
            var mss = new MemoryStream();
            var prt = $"{_webHost.ContentRootPath}Reports";
            var pts1 = System.IO.Path.Combine(prt, "rcl", "Pdf");

            var pa = busca.Pa;
            if (!Directory.Exists(pts1))
            {
                Directory.CreateDirectory(pts1);
            }
            Pbl.Usuario = busca.Usuario;
            var orige = busca.numTabela.ToLower();
            switch (orige)
            {
                case "1":
                    if (pa.Nome != null)
                    {
                        var report1 = new RepPedidoDeJuntaMedicaMilitar(pa.Nome);
                        await report1.ExportToPdfAsync(mss, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                    }

                    break;
                case "2":
                    var report2 = new RepMapaDeJuntasMedicasMilitares();
                    var condicaoProcura = $" where OrgaoUtilizador='{Pbl.Usuario.Orgao}' and DirecUtilizador='{Pbl.Usuario.Direcao}'";
                    condicaoProcura += $" and Recebido=1";
                    var dataTable = _mapaDeJuntaMedicaMilitar.ReadLerFiltrar(condicaoProcura);
                    dataTable.Columns.Add("No", typeof(int));
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        dataTable.Rows[i]["No"] = i + 1;
                    }
                    var emtrami = dataTable.GetTable("Homologado='EM TRAMITAÇÃO'");
                    var homo = dataTable.GetTable("Homologado='TRAMITADO'");
                    var naohomo = dataTable.GetTable("Homologado=''");
                    var togera = dataTable.Rows.Count;
                    var listMil = dataTable.DtToList<AcessoTeste>();
                    var emtramitacao = emtrami?.Rows.Count;
                    if (emtramitacao == null)
                    {
                        emtramitacao = 0;
                    }
                    var homologados = homo?.Rows.Count;
                    if (homologados == null)
                    {
                        homologados = 0;
                    }
                    var nhomologous = naohomo?.Rows.Count;
                    if (nhomologous == null)
                    {
                        nhomologous = 0;
                    }
                    var totalGe = togera;
                    if (totalGe == null)
                    {
                        totalGe = 0;
                    }
                    report2.TotaisLista(listMil, emtramitacao, homologados, nhomologous, totalGe);
                    await report2.ExportToPdfAsync(mss, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                    break;
                case "3":
                    var report3 = new TestReport();
                    await report3.ExportToPdfAsync(mss, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                    break;
                case "4":
                    var report4 = new TestReport();
                    await report4.ExportToPdfAsync(mss, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                    break;
                case "5":
                    var report5 = new TestReport();
                    await report5.ExportToPdfAsync(mss, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                    break;
            }
            return File(mss.ToArray(), MediaTypeNames.Application.Pdf);
        }

    

        [HttpPost]
        [Route("RelatorioPri")] //FrmPrintRlt
        public async Task<ActionResult<ServiceResponse<Filepdf>>> RelatorioPri([FromBody] Trabalho tr)
        {
            Filepdf flFilepdf = new Filepdf();
            ServiceResponse<Filepdf> serviceResponse = new ServiceResponse<Filepdf>();
            var writeReport = "";
            var rptname = "";
            string mimtype = "";
            try
            {
                var condicaoProcura = string.Empty;
                Path = "";
                var prt = $"{_webHost.ContentRootPath}Reports";
                Path = System.IO.Path.Combine(prt, "rcl");
                var xmlStringss = "";
                string filenammme = "";
                string filepathe = "";
                var hhh = false;
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                try
                {
                    var stamp = Pbl.Rdlcstamp();
                    filenammme = $"report{stamp}";
                    using (MemoryStream ms = new MemoryStream())
                    {

                        Pbl.Usuario = tr.Usuario;
                        var orige = tr.numTabela.ToLower();
                        switch (orige)
                        {
                            case "1":
                                var report1 = new TestReport();
                                await report1.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                            case "2":
                                var report2 = new RepMapaDeJuntasMedicasMilitares();
                                var dtini = tr.Path.ToDateTimeValue().Year;
                                var dtfi = tr.Path1.ToDateTimeValue().Year;
                                if (dtini > 1900 && dtfi > 1900)
                                {
                                    if (dtfi >= dtini)
                                    {
                                        condicaoProcura =
                                            $" where DataEntrada between '{tr.Path.ToDateTimeValue():yyyy-MM-dd}' and '{tr.Path1.ToDateTimeValue():yyyy-MM-dd}'";
                                    }
                                }
                                if (!string.IsNullOrEmpty(tr.Clstamp))
                                {
                                    if (string.IsNullOrEmpty(condicaoProcura))
                                    {
                                        condicaoProcura = $" where homologado='{tr.Clstamp}' ";
                                    }
                                    else
                                    {
                                        condicaoProcura += $" and homologado='{tr.Clstamp}' ";
                                    }
                                }
                                var dataTable = _mapaDeJuntaMedicaMilitar.ReadLerFiltrar(condicaoProcura);
                                dataTable.Columns.Add("No", typeof(int));
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    dataTable.Rows[i]["No"] = i + 1;
                                }
                                var emtrami = dataTable.GetTable("Homologado='EM TRAMITAÇÃO'");
                                var homo = dataTable.GetTable("Homologado='TRAMITADO'");
                                var naohomo = dataTable.GetTable("Homologado=''");
                                var togera = dataTable.Rows.Count;
                                var listMil = dataTable.DtToList<AcessoTeste>();
                                var emtramitacao = emtrami?.Rows.Count;
                                if (emtramitacao == null)
                                {
                                    emtramitacao = 0;
                                }
                                var homologados = homo?.Rows.Count;
                                if (homologados == null)
                                {
                                    homologados = 0;
                                }
                                var nhomologous = naohomo?.Rows.Count;
                                if (nhomologous == null)
                                {
                                    nhomologous = 0;
                                }
                                var totalGe = togera;
                                if (totalGe == null)
                                {
                                    totalGe = 0;
                                }
                                report2.TotaisLista(listMil, emtramitacao, homologados, nhomologous, totalGe);
                                await report2.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                            case "3":
                                var report3 = new TestReport();
                                await report3.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                            case "4":
                                var report4 = new TestReport();
                                await report4.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                            case "5":
                                var report5 = new TestReport();
                                await report5.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                        }
                        var file = File(ms.ToArray(), "application/pdf", $"{filenammme}.pdf");

                        if (System.IO.File.Exists($"{Path}\\Pdf\\{filenammme}.pdf"))
                        {
                            System.IO.File.Delete($"{Path}\\Pdf\\{filenammme}.pdf");
                        }
                        await System.IO.File.WriteAllBytesAsync($"{Path}\\Pdf\\{filenammme}.pdf", file.FileContents);
                        flFilepdf.Filename = $"{filenammme}.pdf";
                        serviceResponse.Sucesso = true;
                        serviceResponse.Dados = flFilepdf;
                        serviceResponse.Mensagem = "sucesso";
                    }

                }
                catch (Exception ex)
                {

                    flFilepdf.Filename = "vazio";
                    serviceResponse.Sucesso = false;
                    serviceResponse.Dados = flFilepdf;
                    serviceResponse.Mensagem = $"erro, Erro de formatação do ficheiro, Contacte o administrador.";
                }


            }
            catch (Exception ex)
            {
                flFilepdf.Filename = "vazio";
                serviceResponse.Sucesso = false;
                serviceResponse.Dados = flFilepdf;
                serviceResponse.Mensagem = $"erro, {ex.Message}";
            }

            return serviceResponse;
            // return null;
        }

        [HttpPost]
        [Route("Ficheirostemp")] //FrmPrintRlt
        public async Task<ActionResult<ServiceResponse<Filepdf>>> Ficheirostemp([FromBody] object obj)
        {


            var ddd = JsonConvert.SerializeObject(obj);
            var tr = JsonConvert.DeserializeObject<Trabalho>(ddd);
            // var jObject = JObject.Parse(ddd);
            Filepdf flFilepdf = new Filepdf();
            ServiceResponse<Filepdf> serviceResponse = new ServiceResponse<Filepdf>();
            var writeReport = "";
            var rptname = "";
            string mimtype = "";
            try
            {
                var condicaoProcura = string.Empty;
                Path = "";
                var prt = $"{System.IO.Path.Combine(_webHost.ContentRootPath, "Reports")}";
                Path = System.IO.Path.Combine(prt, "rcl");
                var xmlStringss = "";
                string filenammme = "";
                string filepathe = "";
                var hhh = false;
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }

                var pas = tr.Pa;
                try
                {
                    var stamp = Pbl.Rdlcstamp();
                    filenammme = $"report{stamp}";
                    using (MemoryStream ms = new MemoryStream())
                    {

                        Pbl.Usuario = tr.Usuario;
                        var orige = tr.numTabela.ToLower();
                        switch (orige)
                        {
                            case "1":
                                if (pas.Nome != null)
                                {
                                    var report1 = new RepPedidoDeJuntaMedicaMilitar(pas.Nome);
                                    await report1.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                }
                                break;
                            case "2":
                                var report2 = new RepMapaDeJuntasMedicasMilitares();
                                var dtini = tr.Path.ToDateTimeValue().Year;
                                var dtfi = tr.Path1.ToDateTimeValue().Year;
                                if (dtini > 1900 && dtfi > 1900)
                                {
                                    if (dtfi >= dtini)
                                    {
                                        condicaoProcura =
                                            $" where DataEntrada between '{tr.Path.ToDateTimeValue():yyyy-MM-dd}' and '{tr.Path1.ToDateTimeValue():yyyy-MM-dd}'";
                                    }
                                }
                                if (!string.IsNullOrEmpty(tr.Clstamp))
                                {
                                    if (string.IsNullOrEmpty(condicaoProcura))
                                    {
                                        condicaoProcura = $" where homologado='{tr.Clstamp}' ";
                                    }
                                    else
                                    {
                                        condicaoProcura += $" and homologado='{tr.Clstamp}' ";
                                    }
                                }
                                var dataTable = _mapaDeJuntaMedicaMilitar.ReadLerFiltrar(condicaoProcura);
                                dataTable.Columns.Add("No", typeof(int));
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    dataTable.Rows[i]["No"] = i + 1;
                                }
                                var emtrami = dataTable.GetTable("Homologado='EM TRAMITAÇÃO'");
                                var homo = dataTable.GetTable("Homologado='TRAMITADO'");
                                var naohomo = dataTable.GetTable("Homologado=''");
                                var togera = dataTable.Rows.Count;
                                var listMil = dataTable.DtToList<AcessoTeste>();
                                var emtramitacao = emtrami?.Rows.Count;
                                if (emtramitacao == null)
                                {
                                    emtramitacao = 0;
                                }
                                var homologados = homo?.Rows.Count;
                                if (homologados == null)
                                {
                                    homologados = 0;
                                }
                                var nhomologous = naohomo?.Rows.Count;
                                if (nhomologous == null)
                                {
                                    nhomologous = 0;
                                }
                                var totalGe = togera;
                                if (totalGe == null)
                                {
                                    totalGe = 0;
                                }
                                report2.TotaisLista(listMil, emtramitacao, homologados, nhomologous, totalGe);
                                await report2.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                            case "3":
                                var report3 = new XtraRepExistencia();
                                var dttMil = pas.EntiyToDataTable();

                                var listMils = (from item in dttMil.AsEnumerable()
                                                select new ModeloRelatorio
                                                {
                                                    PaStamp = item.Field<string>("PaStamp"),
                                                    Nome = item.Field<string>("nome"),
                                                    Patente = item.Field<string>("Patente"),
                                                    Unidade = item.Field<string>("Unidade"),
                                                    Sexo = item.Field<string>("sexo"),
                                                    Subunidade = item.Field<string>("Subunidade"),
                                                    Orgao = item.Field<string>("Orgao")
                                                }).ToList();
                                var qrrr = $"select top 1 isnull(protocolo,0)protocolo,Pa.paStamp,sd.destinatario " +
                                           $"from SaidaProcesso sd inner join EntradaProcesso e on " +
                                           $"sd.entradaStamp=e.entradaStamp inner join Processo p on" +
                                           $" p.processoStamp=e.processoStamp inner join Pa on " +
                                           $"Pa.paStamp=p.paStamp where" +
                                           $" Pa.paStamp='{pas.PaStamp}'" +
                                           $" and sd.destinatario='médico' " +
                                           $"order by convert(date,dataSaida) desc";

                                var dt = SQL.GetGenDt(qrrr);
                                int contage = 0;
                                if (dt.HasRows())
                                {
                                    contage = dt.RowZero("protocolo").ToInt();
                                }
                                //foreach (DevExpress.XtraReports.Parameters.Parameter parameter in report3.Parameters)
                                //{
                                //    parameter.Visible = false;
                                //}
                                report3.Contagem = contage;
                                var estadojunta = Pbl.EstadosDeProcesso.Pendente;
                                var doc = "SELECT Top 1 homologado, convert(datetime,[inseriuDataHora]) " +
                                          $"FROM Processo where [paStamp] = '{pas.PaStamp}' " +
                                          "order by convert(datetime,[inseriuDataHora])  desc";
                                var dtEstadoProcesso = SQL.GetGenDt(doc);
                                if (pas != null)
                                {

                                    //var primeiroValor = pas.Processo
                                    //    .OrderByDescending(p => p.AlterouDataHora) // se quiser garantir uma ordem
                                    //    .FirstOrDefault()?.Estado;
                                }
                                if (dt.HasRows())
                                {
                                    if (dtEstadoProcesso.Rows.Count == 0)
                                    {
                                        estadojunta = Pbl.EstadosDeProcesso.Pendente;
                                    }
                                    else
                                    {
                                        string? estadoProcesso = dtEstadoProcesso.RowZero("homologado")?.ToString();
                                        switch (estadoProcesso)
                                        {
                                            case "SIM":
                                                estadojunta = Pbl.EstadosDeProcesso.Homologada;
                                                break;
                                            case "NÃO":
                                                estadojunta = Pbl.EstadosDeProcesso.NaoHomologada;
                                                break;
                                            default:
                                                estadojunta = Pbl.EstadosDeProcesso.EmTramitacao;
                                                break;
                                        }
                                    }
                                }

                                report3.ImprimiroOrdemDeEntregaFornecimento(listMils, estadojunta);
                                await report3.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                            case "4":
                                var report4 = new TestReport();
                                await report4.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                            case "5":
                                var report5 = new TestReport();
                                await report5.ExportToPdfAsync(ms, new PdfExportOptions { ShowPrintDialogOnOpen = true });
                                break;
                        }
                        var file = File(ms.ToArray(), "application/pdf", $"{filenammme}.pdf");
                        var directory = System.IO.Path.Combine(Path, "Pdf");
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }

                        var ficheiroreal = System.IO.Path.Combine(directory, $"{filenammme}.pdf");
                        if (System.IO.File.Exists(ficheiroreal))
                        {
                            System.IO.File.Delete(ficheiroreal);
                        }
                        await System.IO.File.WriteAllBytesAsync(ficheiroreal, file.FileContents);
                        flFilepdf.Filename = $"{filenammme}.pdf";
                        serviceResponse.Sucesso = true;
                        serviceResponse.Dados = flFilepdf;
                        serviceResponse.Mensagem = "sucesso";
                    }

                }
                catch (Exception ex)
                {

                    flFilepdf.Filename = "vazio";
                    serviceResponse.Sucesso = false;
                    serviceResponse.Dados = flFilepdf;
                    serviceResponse.Mensagem = $" Erro de formatação do ficheiro, Contacte o administrador.";
                }


            }
            catch (Exception ex)
            {
                flFilepdf.Filename = "vazio";
                serviceResponse.Sucesso = false;
                serviceResponse.Dados = flFilepdf;
                serviceResponse.Mensagem = $"erro, {ex.Message}";
            }

            return serviceResponse;
            // return null;
        }

        [HttpGet]
        [Route("LeituraDeFicheirostemp")]
        public async Task<object> LeituraDeFicheirostemp(string ficheiro = "Pdf")
        {
            try
            {
                var prt = $"{System.IO.Path.Combine(_webHost.ContentRootPath, "Reports")}";
                var pt1 = System.IO.Path.Combine(System.IO.Path.Combine
                    (System.IO.Path.Combine(prt, "rcl"), "Pdf"), ficheiro);
                var exte = System.IO.Path.GetExtension(ficheiro);
                if (System.IO.File.Exists($"{pt1}"))
                {
                    var btes = await System.IO.File.ReadAllBytesAsync($"{pt1}");
                    switch (exte.ToLower())
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
        [HttpGet]
        [Route("ApagarFicheirostemp")]
        public async Task<ActionResult<ServiceResponse<Filepdf>>> ApagarFicheirostemp(string ficheiro = "Pdf")
        {
            var respos = new ServiceResponse<Filepdf>();
            var f = new Filepdf();
            try
            {
                f.Filename = "";
                var prt = $"{System.IO.Path.Combine(_webHost.ContentRootPath, "Reports")}";
                var pt1 = System.IO.Path.Combine(System.IO.Path.Combine
                    (System.IO.Path.Combine(prt, "rcl"), "Pdf"), ficheiro);
                if (System.IO.File.Exists($"{pt1}"))
                {
                    try
                    {
                        System.IO.File.Delete(pt1);
                        f.Filename = "sucesso";
                        respos.Mensagem = "sucesso";
                        respos.Sucesso = true;
                    }
                    catch (Exception ex)
                    {
                        respos.Mensagem = "erro";
                        respos.Sucesso = false;
                    }
                }
            }
            catch (Exception ex)
            {
                respos.Mensagem = "erro";
                respos.Sucesso = false;
            }
            respos.Dados = f;
            return Ok(respos);
        }

        [HttpPost("[action]")]
        public IActionResult GerarRelatorio(Trabalho dto)
        {
            XtraReport report = new XtraReport();
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Relatorios", $"{Guid.NewGuid()}.pdf");

            if (!Directory.Exists(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Relatorios")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Relatorios"));
            }
            report.ExportToPdf(filePath);

            return Ok(new { filePath });
        }
        [HttpGet("[action]")]
        public ActionResult Export(string format = "pdf")
        {
            format = format.ToLower();
            XtraReport report = new TestReport();
            string contentType = string.Format("application/{0}", format);
            using (MemoryStream ms = new MemoryStream())
            {
                switch (format)
                {
                    case "pdf":
                        contentType = "application/pdf";
                        report.ExportToPdf(ms);
                        break;
                    case "docx":
                        contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        report.ExportToDocx(ms);
                        break;
                    case "xls":
                        contentType = "application/vnd.ms-excel";
                        report.ExportToXls(ms);
                        break;
                    case "xlsx":
                        contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        report.ExportToXlsx(ms);
                        break;
                    case "rtf":
                        report.ExportToRtf(ms);
                        break;
                    case "mht":
                        contentType = "message/rfc822";
                        report.ExportToMht(ms);
                        break;
                    case "html":
                        contentType = "text/html";
                        report.ExportToHtml(ms);
                        break;
                    case "txt":
                        contentType = "text/plain";
                        report.ExportToText(ms);
                        break;
                    case "csv":
                        contentType = "text/plain";
                        report.ExportToCsv(ms);
                        break;
                    case "png":
                        contentType = "image/png";
                        report.ExportToImage(ms, new ImageExportOptions() { Format = ImageFormat.Png });
                        break;
                }
                return File(ms.ToArray(), contentType);
            }
        }
        [HttpGet]
        [Route("LeituraDeFicheiros")]
        public async Task<object> LeituraDeFicheiros(string ficheiro = "Pdf")
        {
            try
            {
                var prt = $"{_webHost.ContentRootPath}Reports";
                var pt1 = System.IO.Path.Combine(System.IO.Path.Combine
                    (System.IO.Path.Combine(prt, "rcl"), "Pdf"), ficheiro);
                var exte = System.IO.Path.GetExtension(ficheiro);
                if (System.IO.File.Exists($"{pt1}"))
                {
                    var btes = await System.IO.File.ReadAllBytesAsync($"{pt1}");
                    switch (exte.ToLower())
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
        [HttpGet]
        [Route("LeituraDeImagens")]
        public async Task<object> LeituraDeImagens(string ficheiro = "Pdf")
        {
            try
            {
                var folderName = System.IO.Path.Combine("reports", "pdf");
                var pt1 = System.IO.Path.Combine(_webHost.ContentRootPath, folderName, ficheiro);
                var exte = System.IO.Path.GetExtension(ficheiro);
                if (System.IO.File.Exists($"{pt1}"))
                {
                    var btes = await System.IO.File.ReadAllBytesAsync($"{pt1}");
                    switch (exte.ToLower())
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

    }
}
