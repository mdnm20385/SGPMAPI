using Model.Models.SJM;

namespace SGPMAPI.Report
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

        internal static string GetReferencia(string v)
        {
            var xx = "";
            var cumprimento = v.Length;
            switch (cumprimento)
            {
                case 1:
                    xx = $"000{v}";
                    break;
                case 2:
                    xx = $"00{v}";
                    break;
                case 3:
                    xx = $"0{v}";
                    break;
                case 4:
                    xx = $"{v}";
                    break;
            }
            return xx;
        }
    }

   public class ModeloRelatorio : Pa
   {
       public new string PaStamp { get; set; }
       public string DadosAnamense { get; set; }
       public string ExamesObjectivos { get; set; }
       public string ExamesClinicos { get; set; }
       public string DiaDef { get; set; }
       public string Conclusao { get; set; }
       public string ProcessoStamp { get; set; }
       public string EntradaStamp { get; set; }
       public string Remetente { get; set; }
       public string ProvProveniencia { get; set; }
       public string DataEntrada { get; set; }
       public string Destinatario { get; set; }
       public string Recebeu { get; set; }
       public string DataSaida { get; set; }
       public string Homologado { get; set; }
   }
}
