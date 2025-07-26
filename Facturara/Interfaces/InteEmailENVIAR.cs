using Microsoft.AspNetCore.Mvc;
using Model.Models.Gene;
using Model.Models.SJM;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Interfaces
{
    public interface InteEmailEnviar
    {
        Task<ServiceResponse<RecPassword>> verificaPass(string email, string nome);

        Task<bool> SendEmail(string body, string DDDD, string nome,string tempo);


        Task<ServiceResponse<DadosRecuperacao>> RecuperarEmail(string usuario, string senha, string confirmarSenha);

        Task<ServiceResponse<List<Usuario>>> GetUsers();
        Task<ServiceResponse<List<Usuario>>> GetUsersFromUsrTb();
        Task<ServiceResponse<Usuario>> TiposUsuarios(String usuario, string id, String Tipoperfil);
        Task<ServiceResponse<int>> Getreferece(string campo, string tabela, string condicao);
        Task<ServiceResponse<Usuario>> FirstLogin([FromBody] FirstLogin primeiro);

        Task<ServiceResponse<Usuario>> CheckexistLog([FromBody] LoginModel logado);




    }
   
}
