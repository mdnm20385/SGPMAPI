using Model.Models.Gene;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Email
{
    public interface InteEmail
    {
        Task<ServiceResponse<RecPassword>> verificaPass(string email, string number);

        Task SendEmail(string body, string DDDD);


        Task<ServiceResponse<DadosRecuperacao>> RecuperarEmail(string usuario, string senha, string confirmarSenha);

       




    }
}
