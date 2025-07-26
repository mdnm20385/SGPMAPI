using Model.Models.Facturacao;

namespace SGPMAPI.Interfaces
{
    public interface IMenuService
    {
        //Task<List<Menu>> GetMenuAsync();
        //Task<Menu> SaveMenuAsync(Menu menu);
        //Task<Menu> UpdateMenuAsync(string id, Menu menu);

        Task<Menu> CriarOuAtualizarMenuAsync(Menu menu, List<string> utilizadorStamps);
        Task<List<Menu>> ObterMenusPorUtilizadorAsync(string utilizadorStamp);
    }
}
