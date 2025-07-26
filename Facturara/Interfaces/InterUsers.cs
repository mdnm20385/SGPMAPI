namespace SGPMAPI.Interfaces
{
    public interface InterUsers
    {
        Task<Token> ValidarCredenciais(string login, string senha);
    }
}
