using DAL.BL;
using DAL.Classes;
using DAL.Conexao;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Facturacao;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SGPMAPI.Interfaces;

namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public SGPMContext DbContext;
        private readonly IMenuService _menuService;
        public MenuController( SGPMContext dbContext,IMenuService menuService)
        {
            DbContext = dbContext;
            EF._dbContext = DbContext;
            _menuService = menuService;
        }
        [HttpPost("Salvar")]
        public async Task<IActionResult> SalvarMenu([FromBody] object obj)
        {
            var ddd = JsonConvert.SerializeObject(obj);
            JObject jObject = JObject.Parse(ddd);
            string? json = jObject["utilizadorStamps"]?.ToString();
            var menuss = jObject["menus"]?.ToString() ?? "[]";
            if (string.IsNullOrEmpty(menuss))
            {
                return BadRequest("enus não podem ser nulos ou vazios.");
            }
            var array = JsonConvert.DeserializeObject<List<string>>(json);
            if (array != null)
            {
                foreach (var ids in array)
                {
                    try
                    {
                        var registros = DbContext.Menuusr.Where(x => x.Userstamp.ToLower() == ids.ToLower());
                        if (registros.Any())
                        {
                            DbContext.Menuusr.RemoveRange(registros);
                            await DbContext.SaveChangesAsync();
                        }
                        var menuusr = new Menuusr();
                        menuusr.Menuusrstamp = Pbl.Stamp();
                        menuusr.Userstamp = ids;
                        menuusr.Menu = menuss;
                        menuusr.Activo = true;
                        var retorno = await EF.Save(menuusr);
                    }
                    catch (Exception ex)
                    {
                        // ignored
                    }
                }

                var menu = new MenuComUtilizadoresDTO();
                menu.Menu = JsonConvert.DeserializeObject<List<Menu>>(menuss);
                menu.UtilizadorStamps = array;
                menu.UtilizadorStamps = menu.UtilizadorStamps.Distinct().ToList();
                return Ok(menuss);
            }
            return BadRequest("usuário ou menus não podem ser nulos ou vazios.");
        }
        [HttpGet("por-utilizador/{utilizadorStamp}")]
        public async Task<IActionResult> GetMenus(string utilizadorStamp)
        {
            var menus = await _menuService.ObterMenusPorUtilizadorAsync(utilizadorStamp);
            return Ok(menus);
        }
    }
}