using DAL.BL;
using Model.Models;

namespace SGPMAPI
{
    public partial class TestReport : DevExpress.XtraReports.UI.XtraReport
    {
        public TestReport()
        {
            InitializeComponent();
            Bind();
        }
        public void Bind()
        {
            var list = SQL.GetGenDt($"select nome Descricao, login Codigo, tipoPerfil Dirstamp,Activopa from Usuario ").DtToList<Dir>();
            objectDataSource1.DataSource = list;
        }
    }
}
