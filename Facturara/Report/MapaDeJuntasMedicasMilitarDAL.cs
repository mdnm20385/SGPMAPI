using System.Data;
using DAL.BL;

namespace SGPMAPI.Report
{
    public class MapaDeJuntasMedicasMilitarDAL
    {
        public DataTable LerFiltrar(string cond)
        {
            string query = $"select * from vMapaJuntasMedicasMilitares {cond} order by DataEntrada desc";
            var dt = SQL.GetGenDt(query);
           return dt;
        }
    }
    public class MapaDeJuntaMedicaMilitarBLL
    {
        #region Instancias
        MapaDeJuntasMedicasMilitarDAL mapaDeJuntasMedicasMilitarDal = new();
        #endregion

        #region Metodos
        public DataTable ReadLerFiltrar(string cond)
        {
            return mapaDeJuntasMedicasMilitarDal.LerFiltrar(cond);
        }
        #endregion
    }
}
