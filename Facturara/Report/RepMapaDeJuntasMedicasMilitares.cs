using DAL.BL;
using DAL.Extensions.Extensions;
using Model.Models;

namespace SGPMAPI.Report
{
    public partial class RepMapaDeJuntasMedicasMilitares : DevExpress.XtraReports.UI.XtraReport
    {
        public RepMapaDeJuntasMedicasMilitares()
        {
            InitializeComponent();
        }
        public void TotaisLista(List<AcessoTeste> listMil, int? emtramitacao, int? homologados,
            int? nhomologous, int? totalGe)
        {
            if (nhomologous == null)
            {
                nhomologous = 0;
            }
            if (emtramitacao == null)
            {
                emtramitacao = 0;
            }
            if (homologados == null)
            {
                homologados = 0;
            }
            if (totalGe == null)
            {
                totalGe = 0;
            }

            Acesso.NomeChefe = Acesso.PatenteCategoria = "";
           var aaaaaaa = SQL.GetGen2DT($@"select nome,tipoPerfil,patentetegoria 
from usuario where tipoperfil in('DIRECTOR','CHEFE')   and activopa=1");
            if (aaaaaaa.HasRows())
            {
                var dir = aaaaaaa.GetTable("tipoPerfil='DIRECTOR'");
                if (dir.HasRows())
                {
                    Acesso.NomeDirector = dir.RowZero("nome")?.ToString();
                }
                var dirnomche = aaaaaaa.GetTable("tipoPerfil='CHEFE'");
                if (dirnomche.HasRows())
                {
                    Acesso.NomeChefe = dirnomche.RowZero("nome")?.ToString();
                    Acesso.PatenteCategoria = dirnomche.RowZero("patentetegoria")?.ToString();
                }
            }
            lbNomeChefe.Text = Acesso.NomeChefe;
            lbPatenteCategoria.Text = Acesso.PatenteCategoria;
            txtEmTramitacaco.Text = emtramitacao.ToString();
            txthomol.Text = homologados.ToString();
            txtNaoHomo.Text = nhomologous.ToString();
            txtTogaeral.Text = totalGe.ToString();
            foreach (var da in listMil)
            {
                try
                {
                    da.DataEntrada = Convert.ToDateTime(da.DataEntrada).ToString("dd-MM-yyyy");
                }
                catch (Exception)
                {
                    da.DataEntrada = "";
                }
                try
                {
                    da.DataSaida = Convert.ToDateTime(da.DataSaida).ToString("dd-MM-yyyy");
                }
                catch (Exception)
                {
                    da.DataSaida = "";
                }
            }
            objectDataSource1.DataSource = listMil;
        }
    }
}
