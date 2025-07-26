using System.Text.RegularExpressions;

namespace DAL.Classes
{
    public static class VPN
    {
        public static List<string> ListaVPN()
        {
            List<string> lista=new List<string>();

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData) +
                          @"\Microsoft\Network\Connections\Pbk\rasphone.pbk";
            const string pattern = @"\[(.*?)\]";
            var matches = Regex.Matches(System.IO.File.ReadAllText(path), pattern);

            foreach (Match m in matches)
            { 
                lista.Add(m.ToString());
            }
            return lista;
        }
    }
}
