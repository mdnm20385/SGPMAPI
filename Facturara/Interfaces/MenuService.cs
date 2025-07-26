using DAL.Classes;
using DAL.Conexao;
using Microsoft.EntityFrameworkCore;
using Model.Models.Facturacao;

namespace SGPMAPI.Interfaces
{
    public class MenuService : IMenuService
    {
        private readonly SGPMContext _context;

        public MenuService(SGPMContext context)
        {
            _context = context;
        }
      


        /////
        public async Task<Menu> CriarOuAtualizarMenuAsync(Menu menu, List<string> utilizadorStamps)
        {
            var utilizadores = await _context.Set<UsuarioMenu>()
                .Where(u => utilizadorStamps.Contains(u.PaStamp))
                .ToListAsync();
            if (menu.MenuStamp.IsNullOrEmpty())
            {
                menu.MenuStamp = Pbl.Stamp();
            }

            if (menu.MenuPermissionsStamp.IsNullOrEmpty())
            {
                menu.MenuPermissionsStamp = Pbl.Stamp();
            }
            //MenuPermissions

            foreach (var child in menu.Children)
            {
                child.ParentMenuStamp = menu.MenuStamp;
                if (child.MenuChildrenItemStamp.IsNullOrEmpty())
                {
                    child.MenuChildrenItemStamp = Pbl.Stamp();
                }
                if (child.MenuPermissionsStamp.IsNullOrEmpty())
                {
                    child.MenuChildrenItemStamp = Pbl.Stamp();
                }
            }
            var menuExistente = await _context.Menu
                .Include(m => m.UsuarioMenus)
                .FirstOrDefaultAsync(m => m.MenuStamp == menu.MenuStamp);

            if (menuExistente == null)
            {
                // Novo menu
                menu.UsuarioMenus = utilizadores;
                _context.Menu.Add(menu);
            }
            else
            {
                // Atualizar menu existente
                _context.Entry(menuExistente).CurrentValues.SetValues(menu);
                menuExistente.UsuarioMenus = utilizadores;
            }

            await _context.SaveChangesAsync();
            return menu;
        }

        public async Task<List<Menu>> ObterMenusPorUtilizadorAsync(string utilizadorStamp)
        {
            return await _context.Menu
                .Where(m => m.UsuarioMenus.Any(u => u.PaStamp == utilizadorStamp))
                .Include(m => m.Children)
                .ToListAsync();
        }


      


    }

}
