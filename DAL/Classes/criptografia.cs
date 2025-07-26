using System.Security.Cryptography;
using System.Text;

namespace DAL.Classes
{
    public class Criptografia
    {
        /// <summary>     
        /// Vetor de bytes utilizados para a criptografia (Chave Externa)     
        /// </summary>     
        private static byte[] bIV =
        { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>     
        /// Representação de valor em base 64 (Chave Interna)    
        /// O Valor representa a transformação para base64 de     
        /// um conjunto de 32 caracteres (8 * 32 = 256bits)    
        /// A chave é: *Idata12#     
        /// </summary>     
        private const string CryptoKey = "KklkYXRhMTIj";

        /// <summary>     
        /// Metodo de criptografia de valor     
        /// </summary>     
        /// <param name="text">valor a ser criptografado</param>     
        /// <returns>valor criptografado</returns>
        public static string Encrypt(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    byte[] bKey = Convert.FromBase64String(CryptoKey);
                    byte[] bText = new UTF8Encoding().GetBytes(text);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor criptografado:                
                    var mStream = new MemoryStream();
                    // Instancia o encriptador                 
                    var encryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateEncryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    encryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    encryptor.FlushFinalBlock();
                    // Pega o vetor de bytes da memória e gera a string criptografada                
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    // Se a string for vazia retorna nulo                
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção            
                throw new ApplicationException("Erro ao criptografar", ex);
            }
        }

        /// <summary>     
        /// Pega um valor previamente criptografado e retorna o valor inicial 
        /// </summary>     
        /// <param name="text">texto criptografado</param>     
        /// <returns>valor descriptografado</returns>     
        public static string Decrypt(string text)
        {
            try
            {
                // Se a string não está vazia, executa a criptografia           
                if (!string.IsNullOrEmpty(text))
                {
                    // Cria instancias de vetores de bytes com as chaves                
                    var bKey = Convert.FromBase64String(CryptoKey);
                    var bText = Convert.FromBase64String(text);

                    // Instancia a classe de criptografia Rijndael                
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"                
                    // Lembre-se: chaves possíves:                
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor DEScriptografado:               
                    var mStream = new MemoryStream();

                    // Instancia o Decriptador                 
                    var decryptor = new CryptoStream(
                        mStream,
                        rijndael.CreateDecryptor(bKey, bIV),
                        CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória   
                    decryptor.Write(bText, 0, bText.Length);
                    // Despeja toda a memória.                
                    decryptor.FlushFinalBlock();
                    // Instancia a classe de codificação para que a string venha de forma correta         
                    var utf8 = new UTF8Encoding();
                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8       
                    return utf8.GetString(mStream.ToArray());
                }

                // Se a string for vazia retorna nulo                
                return text;
            }
            catch (Exception ex)
            {
                // Se algum erro ocorrer, dispara a exceção            
                return text;
            }
        }
    }
}
