namespace DAL.Reports
{
    public class Helper
    {
        #region Variáveis de formatação do texto
        static string fontSize = "16";
        static string textAlignment = "justify";
        static string lineSpacing = "1.5";
        static string formatacao = "<p style=\"text-align:" + textAlignment + "; " +
                                   "line-height:" + lineSpacing + ";margin-top: 0.5;margin-bottom: 0.5; font-size:" + fontSize + "px\">";
        #endregion

        public static string Formatacao = formatacao;
    }
}
