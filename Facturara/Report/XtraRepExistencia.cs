using System.Globalization;
using System.Text;
using DAL.BL;
using DevExpress.XtraReports.UI;

namespace SGPMAPI.Report
{
    public partial class XtraRepExistencia : XtraReport
    {
        public XtraRepExistencia()
        {
            InitializeComponent();
        }
        public int Contagem { get; set; }
        public void ImprimiroOrdemDeEntregaFornecimento(List<ModeloRelatorio> list,string estadojunta)
        {
            var dat = DateTime.Now;  txtRepublicaMocambique.Value = "REPÚBLICA DE MOÇAMBIQUE".ToUpper();
            txtMinisterio.Value = "Ministério da Defesa Nacional".ToUpper();
            txtFadm.Value = "DIRECÇÃO NACIONAL DE SAÚDE MILITAR".ToUpper();
            txtDepartamento.Value = "JUNTA MÉDICA MILITAR PRINCIPAL".ToUpper();
            var dtt = DateTime.Now;
            var cont = string.Empty;
            if (Contagem>0)
            {
                cont = Contagem.ToString();
            }
            txtTitulo.Value = $"PROTOCOLO Nº  {cont}/JMMP  {dtt:yyyy}    de {dtt.ToString("MMMM 'de' yyyy", new CultureInfo("PT-pt"))} ".ToUpper();

            
            txtDescricaJMM.Value = " ";

            var dt = SQL.GetGenDt("select * from Usuario where medico=1 and activopa=1  order by codUsuario asc");
          
            var sb2 = new StringBuilder();
            sb2.Append(@"{\rtf1\ansi");
            if (dt.Rows.Count>0)
            {
                string sss=  "A Junta Médica Militar Principal composta de: ";
                var composicao = Helper.Formatacao + $" {sss} </p>";
                var pref2 = string.Empty;
                var pref = string.Empty;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["sexo"].ToString()!.ToUpper().Equals("FEMININO"))
                    {
                        pref = $"{i+1}. Dra. {dt.Rows[i]["nome"]}";
                    }
                    if (!dt.Rows[i ]["sexo"].ToString()!.ToUpper().Equals("Feminino".ToUpper()))
                    {
                        pref = $"{i + 1}. Dr. {dt.Rows[i]["nome"]}";
                    }
                    if (i==0)
                    {
                        sb2.Append($@" \b ASSINATURAS: \b0 "); 
                        sb2.Append(@" \line  ");
                    }
                    pref2 += Helper.Formatacao + $" {pref} </p>";
                    sb2.Append($@" {i + 1}._________________________________________________________________________ ");
                    sb2.Append(@"\line\line");
                }
                sb2.Append(@"}");
                txtCmposJMM.Html = composicao+ pref2;
                txtRchAssinaturas.Rtf = sb2.ToString();
            }
            var dataImpressao = "Data de impressão: ".ToUpper() + dat.ToString("dd-MM-yyyy");
            txtDataImpressao.Value = dataImpressao;
            var localChave = list[0].PaStamp;
            var uni = $@"Observou: ".ToUpper();
            var uni1 = $@"Unidade: ".ToUpper();
            string? unidade;
            if (!string.IsNullOrEmpty(list[0].Orgao))
            {
                if (!string.IsNullOrEmpty(list[0].Unidade))
                {
                    if (!string.IsNullOrEmpty(list[0].Subunidade))
                    {
                        unidade = list[0].Subunidade;
                    }
                    else
                    {

                        unidade = list[0].Unidade;
                    }
                }
                else
                {
                    unidade = list[0].Orgao;
                }
            }
            else
            {
                unidade = "";
            }
            var formata = Helper.Formatacao + $" <b>{uni}{list[0].Nome.ToUpper()} - {list[0].Patente}</b> </p>" +
                          Helper.Formatacao + $" <b>{uni1}</b>{unidade}  </p>";
            var dclinc=  SQL.GetGenDt($"select * from DClinicos " +
                                           $"where paStamp='{localChave}'");
            if (dclinc.Rows.Count>0)
            {
                var nome = "Dados de Anamnese: ".ToUpper();
                var nome2 = "Exames Objectivos: ".ToUpper();
               var nom3 = "Exames para Clínicos: ".ToUpper();
                var nom4 = "Diagnóstico Definitivo: ".ToUpper();
               var nome5 = "Conclusão Especta: ".ToUpper();
               formata += Helper.Formatacao + $" <b>{nome}</b>{dclinc.Rows[0]["dadosAnamense"]} </p>" +
                          Helper.Formatacao + $" <b>{nome2}</b>{dclinc.Rows[0]["examesObjectivos"]} </p>" +
                          Helper.Formatacao + $" <b>{nom3}</b>{dclinc.Rows[0]["examesClinicos"]} </p>" +
                          Helper.Formatacao + $" <b>{nom4}</b>{dclinc.Rows[0]["diaDef"]} </p>" +
                          Helper.Formatacao + $" <b>{nome5}</b>{dclinc.Rows[0]["conclusao"]} </p>";
            }
            xrRichText1.Html = formata;
            txtEspacoVisto.Value = "";
            txtRecebeu.Value = ""; txtEntregou.Value = "";
            objectDataSource1.DataSource = list;
            
        }

        private void xrLabel5_BeforePrint(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var dtt = DateTime.Now;
            if (Contagem >= 0)
            {
                string numd;
                if (Contagem.ToString().Length == 1)
                {
                    numd = $"0{Contagem}";
                }
                else
                {
                    numd = $"{Contagem}";
                }
                xrLabel5.Text = $@"PROTOCOLO Nº {numd}/JMMP/{dtt:yyyy} de {dtt.ToString("dd 'de' MMMM", new CultureInfo("PT-pt"))} ".ToUpper();

            }
        }
    }
}
