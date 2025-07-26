using DAL.Classes;
using Model.Models.SJM;

namespace SGPMAPI.Interfaces
{
   public class  Token {
       public object Any { get; set; }
       public string? access_token { get; set; } = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyIjp7ImlkIjoxLCJ1c2VybmFtZSI6Im5nLW1hdGVybyIsIm5hbWUiOiJab25nYmluIiwiZW1haWwiOiJuemIzMjlAMTYzLmNvbSIsImF2YXRhciI6Ii4vYXNzZXRzL2ltYWdlcy9hdmF0YXIuanBnIn19."+Pbl.Encrypt(DateTime.Now.ToString());
        public string? token_type { get; set; } = "bearer";
        public decimal? expires_in { get; set; } = 3600;
       public decimal? exp { get; set; } = 3600;
       public bool? Sucesso { get; set; } = true;
        public string? Mensagem { get; set; } = "";
        public string? refresh_token { get; set; } = "eJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VyIjp7ImlkIjoxLCJ1c2VybmFtZSI6Im5nLW1hdGVybyIsIm5hbWUiOiJab25nYmluIiwiZW1haWwiOiJuemIzMjlAMTYzLmNvbSIsImF2YXRhciI6Ii4vYXNzZXRzL2ltYWdlcy9hdmF0YXIuanBnIn19." + Pbl.Encrypt(DateTime.Now.ToString());
        public Usuario? Usuario { get; set; }
    }
    public class CampoSessoes
    {
        public string? Usrstamp { get; set; } = "";
        public string? Login { get; set; } = "";
        public string? Nome { get; set; } = "";
        public string? Email { get; set; } = "";
        public bool Retorno { get; set; } = true;
        public decimal Totalprofesso { get; set; } = 0;
        public decimal Totalalunos { get; set; } = 0;
        public decimal Totalcurso { get; set; } = 0;
        public decimal TotalTurmas { get; set; } = 0;
        public decimal TotalRh { get; set; } = 0;
        public decimal Tipo { get; set; }//2=Professor,1=Aluno,3=Rh
        public Token Token { get; set; }
       
    }
}
