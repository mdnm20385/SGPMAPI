using DAL.BL;
using DevExpress.XtraReports.UI;

namespace SGPMAPI.Report
{
    public partial class RepPedidoDeJuntaMedicaMilitar : XtraReport
    {
        #region Constructor
        public RepPedidoDeJuntaMedicaMilitar(string _nomeDoPaciente)
        {
            InitializeComponent();
            EscreverCorpoDoTexto(_nomeDoPaciente);
            xrLabel19.Text = Acesso.NomeDirector;
            lbNomeChefe.Text = Acesso.NomeChefe;
            lbPatenteCategoria.Text = Acesso.PatenteCategoria;
        }
        #endregion

        #region Métodos
        void EscreverCorpoDoTexto(string _nomeDoPaciente)
        {
            xrLabel5.Text = $@"Nº          /MDN/DNSM/DAM/     /{DateTime.Now.Year}";
            xrLabel6.Text = $@"Maputo     de               de {DateTime.Now.Year}";
            tbTexto.Html = Helper.Formatacao + "O Departamento de Assistência Médica saúda a V.Excia e serve-se do presente " +
                       $"ofício para proceder o envio do(a) paciente " +
                       $"<b>{_nomeDoPaciente}</b>, para consulta de especialidade e " +
                       "posterior emissão de Junta Médica Militar.</p>";
        }
        #endregion
    }
}
