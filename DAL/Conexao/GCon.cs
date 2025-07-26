using System.Data;
using DAL.BL;
using DAL.Classes;
using Microsoft.Data.SqlClient;

namespace DAL.Conexao
{
    public class GCon : IDisposable
    {
        #region Conexao

        public SqlConnection? NResult { get; set; }
        public string? DatabaseName { get; set; }
        private void ACon()
        {
            try
            {
                var str = SqlConstring.GetSqlConstring();
                var builder = new SqlConnectionStringBuilder(str);
                Pbl.ConnectionString= builder.ConnectionString;
                NResult = new SqlConnection(Pbl.ConnectionString);
                NResult.Open();
                DatabaseName = builder.InitialCatalog;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha uma falha na Conecção com servidor!... " + ex);
            }
        }
        #endregion
        private void FCon()
        {
            if (NResult.State != ConnectionState.Closed)
            {
                NResult.Close();
                NResult.Dispose();
            }
            else
            {
                NResult.Dispose();
            }

        }
       
        public GCon()
        {
            ACon();
        }
        public void Dispose() => FCon();
    }

    public class GCon1 : IDisposable
    {
        #region Conexao

        public SqlConnection? NResult { get; set; }
        public string? DatabaseName { get; set; }
        private void ACon()
        {
            try
            {
               // var str = "Server=CHICUANJO\\SERVER19;DataBase=SGJM;User ID = sa;Password =123; MultipleActiveResultSets=True;TrustServerCertificate=True;";
                // var str = "Server=172.20.0.3\\SERVER;DataBase=SJMWEB;User ID = sa;Password =mdndticddssjm2021#; MultipleActiveResultSets=True;TrustServerCertificate=True;";
                var str = "Server=34.10.20.94\\SERVER19;DataBase=SGJM;User ID = sa;Password =mdndticddssjm2021#; MultipleActiveResultSets=True;TrustServerCertificate=True;";

                var builder = new SqlConnectionStringBuilder(str);
                Pbl.ConnectionString = builder.ConnectionString;
                NResult = new SqlConnection(Pbl.ConnectionString);
                NResult.Open();
                DatabaseName = builder.InitialCatalog;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha uma falha na Conecção com servidor!... " + ex);
            }
        }
      
        #endregion
        private void FCon()
        {
            if (NResult.State != ConnectionState.Closed)
            {
                NResult.Close();
                NResult.Dispose();
            }
            else
            {
                NResult.Dispose();
            }

        }
     
        public GCon1()
        {
            ACon();
        }
        public void Dispose() => FCon();
    }
}

