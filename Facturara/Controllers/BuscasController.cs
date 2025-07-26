using DAL.BL;
using DAL.Conexao;
using Microsoft.AspNetCore.Mvc;
using Model.Models.Gene;
using Model.Models.SJM;
using Newtonsoft.Json;
using SGPMAPI.Interfaces;
using SGPMAPI.Procura;
using SGPMAPI.SharedClasses;

namespace SGPMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscasController : ControllerBase
    {
        public SGPMContext _dbContext;

        private readonly InterfBusca _usrService;
        private readonly InterGeral _serviGeral;
        private readonly InterfaceProcura _interfaceProcura;
        private readonly IGenericRepository<object> _peRepository;
        private readonly GenericSearchService _searchService;
        public BuscasController(InterfBusca usrService, SGPMContext dbContext, InterGeral serviGeral, InterfaceProcura interfaceProcura,
            IGenericRepository<object> peRepository, GenericSearchService searchService)
        {
            _serviGeral = serviGeral;
            _usrService = usrService;
            _dbContext = dbContext;
            EF._dbContext = _dbContext;
            _interfaceProcura = interfaceProcura;
            _peRepository = peRepository;
            _searchService = searchService;
        }

        [HttpGet("GetMenu")]
        public IActionResult GetMenuForUser(string _t)
        {
            object? menu = new
            {
                menu = new object[] {
                    new {
                        route = "dashboard",
                        name = "dashboard",
                        type = "link",
                        icon = "dashboard"
                    },
                    new {
                        route = "juntas",
                        name = "juntas",
                        type = "sub",
                        icon = "book",
                        children = new[] {
                            new { route = "listaProcesso", name = "listaProcesso", type = "link" },
                            new { route = "vendas", name = "vendas", type = "link" },
                            new { route = "menu", name = "menu", type = "link" }
                        }
                    }
                }
            };
            var registros = _dbContext.Menuusr.Where(x => x.Userstamp.ToLower() == _t.ToLower());
            if (registros.Any())
            {
                var menuusr = registros.FirstOrDefault();
                if (menuusr != null && !string.IsNullOrEmpty(menuusr.Menu))
                {
                    menu = new
                    {
                        menu = JsonConvert.DeserializeObject<object[]>(menuusr.Menu) // Fix: Use JsonConvert from Newtonsoft.Json
                    };

                    return Ok(menu);
                }
            }
            else
            {
                return NotFound("Nenhum menu encontrado para o usuário especificado.");
            }
            return Ok(menu);
        }



        [HttpGet("{entityName}/{id}")]
        public async Task<IActionResult> GetWithChildren(string entityName, string id)
        {
            var result = await _searchService.GetEntityWithChildrenAsync(entityName, id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //[HttpPost("{tipo}")]
        //[DisableRequestSizeLimit]
        //public async Task<IActionResult> getcomnomes(string tipo, [FromBody] object objk)
        //{

        //    string json = JsonConvert.SerializeObject(objk);
        //    JObject jObject = JObject.Parse(json);
        //    string? id = jObject["id"]?.ToString();
        //    await _peRepository.GetEntitywithChildrens(id, tipo);
        //    return NotFound("Entidade não encontrada.");


        //    //    var entityType = AppDomain.CurrentDomain
        //    //        .GetAssemblies()
        //    //        .SelectMany(a => a.GetTypes())
        //    //        .FirstOrDefault(t => t.Name.Equals(entityName, StringComparison.OrdinalIgnoreCase));

        //    //    if (entityType == null)
        //    //        return NotFound("Entidade não encontrada.");

        //    //    var keyProp = entityType.GetProperties()
        //    //        .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null)
        //    //        ?? entityType.GetProperty("Id")
        //    //        ?? entityType.GetProperty(entityType.Name + "Id");

        //    //    if (keyProp == null)
        //    //        return BadRequest("Chave primária não encontrada.");

        //    //    var dbSet = _dbContext.GetType().GetMethod("Set")!.MakeGenericMethod(entityType).Invoke(_dbContext, null);

        //    //    var queryable = (IQueryable<object>)dbSet!;
        //    //    var modelType = _dbContext.Model.FindEntityType(entityType)!;

        //    //    foreach (var nav in modelType.GetNavigations())
        //    //    {
        //    //        queryable = queryable.Include(nav.Name);
        //    //    }

        //    //    // Converte o ID para o tipo correto
        //    //    var typedId = Convert.ChangeType(id, keyProp.PropertyType);
        //    //    var parameter = Expression.Parameter(entityType, "e");
        //    //    var body = Expression.Equal(
        //    //        Expression.Property(parameter, keyProp),
        //    //        Expression.Constant(typedId));
        //    //    var lambda = Expression.Lambda(body, parameter);

        //    //    var method = typeof(EntityFrameworkQueryableExtensions)
        //    //        .GetMethods()
        //    //        .First(m => m.Name == "FirstOrDefaultAsync" && m.GetParameters().Length == 2)
        //    //        .MakeGenericMethod(entityType);

        //    //    var task = (Task)method.Invoke(null, new object[] {
        //    //    queryable, lambda
        //    //})!;

        //    //    await task.ConfigureAwait(false);
        //    //    var resultProp = task.GetType().GetProperty("Result");
        //    //    var result = resultProp!.GetValue(task);

        //    //    if (result == null)
        //    //        return NotFound();

        //    //    return Ok(result);
        //}


        [HttpPost]
        [Route("GetAuxiliares")]
        public async Task<IActionResult> GetAuxiliares(ModeloPaginacao model)
        {
            PaginationResponseBl<List<Busca>> rsp = null;
            try
            {
                rsp = await _usrService.GetGrades(model);
                rsp.Msg = "Sucesso";
                rsp.Status = true;
            }
            catch (Exception ex)
            {
                rsp.Status = false;
                rsp.Msg = ex.Message;
            }
            IActionResult manc = Ok(rsp);
            return manc;
        }
        [Route("Save")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Save(IFormCollection formdata)
        {
            var resultss = JsonConvert.DeserializeObject<Busca>(formdata["Busca"]);
            try
            {
                var cl = resultss;
                EF._dbContext = _dbContext;
                if (cl != null) await EF.Save(cl);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(string id)
        {
            ServiceResponse<bool> rsp = new ServiceResponse<bool>();
            try
            {
                rsp.Sucesso = true;
                ServiceResponse<bool> response = rsp;
                response.Dados = await _usrService.Eliminar(id);
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult actionResult = Ok(rsp);
            rsp = null;
            return actionResult;
        }
        [HttpPost]
        [Route("EliminarGeralPost")]
        public async Task<IActionResult> EliminarGeralPost([FromBody] Camposeliminar set)
        {
            var id = set.Id; var tabela = set.Tabela;
            var nomecampochave = set.Nomecampochave;
            ServiceResponse<bool> rsp = new ServiceResponse<bool>();
            try
            {
                ServiceResponse<bool> response = rsp;
                var ffff = await _usrService.Eliminargradel(id, tabela, nomecampochave);
                response.Dados = ffff;
                rsp.Sucesso = ffff;
            }
            catch (Exception ex)
            {
                rsp.Sucesso = false;
                rsp.Mensagem = ex.Message;
            }
            IActionResult actionResult = Ok(rsp);
            rsp = null;
            return actionResult;
        }

        [HttpGet]
        [Route("Comboboxes")]
        public async Task<ActionResult<ServiceResponse<Selectview>>> Comboboxes(string tabela, string campo1, string campo2,
            string condicao = "")
        {
            var txt = await _serviGeral.Comboboxes(tabela, campo1, campo2, condicao);
            return Ok(txt);
        }
        [HttpPost]
        [Route("ComboboxesPost")]
        public async Task<ActionResult<ServiceResponse<Selectview>>> ComboboxesPost([FromBody] Condicoesprocura set)
        {
            var tabela = set.Tabela;
            var campo1 = set.Campo1;
            var campo2 = set.Campo2;
            var condicao = set.Condicao;
            var txt = await _serviGeral.Comboboxes(tabela, campo1, campo2, condicao);
            return Ok(txt);
        }
        #region Comentado
        /*     // GET: Buscas
             public async Task<IActionResult> Index(string id)
             {
                 Pbl.TextJuntas = "";

                 var str = Pbl.Decrypta(id);
                 var nume = Regex.Match(str, @"\d+").Value;
                 Pbl.DescricaoGeral = str.Replace($"{nume},", "");
                 Pbl.ProcessoStamp = nume;
                 var bus = _dbContext.Busca.Where(x => x.numTabela.Equals(Pbl.ProcessoStamp)).OrderBy(x => x.descricao).ToList();

                 return View(bus);
             }

             // GET: Buscas/Details/5
             public async Task<IActionResult> Details(string id)
             {
                 if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                 {
                     return RedirectToAction("Login", "Home");
                 }
                 if (id == null || _dbContext.Busca == null)
                 {
                     return NotFound();
                 }

                 var busca = await _dbContext.Busca
                     .FirstOrDefaultAsync(m => m.buscaStamp == id);
                 if (busca == null)
                 {
                     return NotFound();
                 }

                 return View(busca);
             }

             private Conexao _conexao = new();
             // GET: Buscas/Create
             public IActionResult Create(string id)
             {
                 if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                 {
                     return RedirectToAction("Login", "Home");
                 }
                 id = Pbl.Decrypta(id);
                 var Numero = Convert.ToInt32(id);
                 var busca = new Busca();
                 busca.numTabela = id;
                 busca.buscaStamp = Pbl.Stamp();
                 busca.codBusca = _conexao.Maximo("codBusca", "Busca", "numTabela", Numero).ToInt() == 0 ?
                     (_conexao.Maximo("codBusca", "Busca", "numTabela", Numero) + 1).ToString().ToInt() :
                     (_conexao.Maximo("codBusca", "Busca", "numTabela", Numero) + 1).ToString().ToInt();
                 return View(busca);
             }

             // POST: Buscas/Create
             // To protect from overposting attacks, enable the specific properties you want to bind to.
             // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
             [HttpPost]
             [ValidateAntiForgeryToken]
             public async Task<IActionResult> Create([Bind("buscaStamp,codBusca,descricao,numTabela,inseriu,inseriuDataHora,alterou,alterouDataHora")] Busca busca)
             {
                 busca.codBusca = HttpContext.Request.Form["nome"].ToInt();
                 busca.descricao = HttpContext.Request.Form["tipodoc"].ToString();
                 if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                 {
                     return RedirectToAction("Login", "Home");
                 }

                 if (!string.IsNullOrEmpty(busca.descricao))
                 {
                     _conexao.GravarGeral("Busca", busca);
                     return RedirectToAction("Index", "Buscas", new { id = Pbl.Encrypta(Pbl.ProcessoStamp + "," + Pbl.DescricaoGeral) });
                 }
                 return View(busca);
             }

             // GET: Buscas/Edit/5
             public async Task<IActionResult> Edit(string id)
             {
                 id = Pbl.Decrypta(id);
                 if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                 {
                     return RedirectToAction("Login", "Home");
                 }
                 if (id == null || _dbContext.Busca == null)
                 {
                     return NotFound();
                 }
                 var busca = await _dbContext.Busca.FindAsync(id);
                 if (busca == null)
                 {
                     return NotFound();
                 }
                 return View(busca);
             }

             // POST: Buscas/Edit/5
             // To protect from overposting attacks, enable the specific properties you want to bind to.
             // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
             [HttpPost]
             [ValidateAntiForgeryToken]
             public async Task<IActionResult> Edit(string id, [Bind("buscaStamp,codBusca,descricao,numTabela,inseriu,inseriuDataHora,alterou,alterouDataHora")] Busca busca)
             {
                 id = Pbl.Decrypta(id);
                 if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                 {
                     return RedirectToAction("Login", "Home");
                 }
                 if (id != busca.buscaStamp)
                 {
                     return NotFound();
                 }
                 busca.codBusca = HttpContext.Request.Form["nome"].ToInt();
                 busca.descricao = HttpContext.Request.Form["tipodoc"].ToString();
                 if (!string.IsNullOrEmpty(busca.descricao))
                 {
                     try
                     {
                         if (!string.IsNullOrEmpty(busca.descricao))
                         {
                             var pr = new PaNegocios();
                             var ret = pr.AlterarObject("Busca", busca, "buscaStamp", busca.buscaStamp);
                             return RedirectToAction("Index", "Buscas", new { id = Pbl.Encrypta(Pbl.ProcessoStamp + "," + Pbl.DescricaoGeral) });
                         }
                     }
                     catch (DbUpdateConcurrencyException)
                     {
                         if (!BuscaExists(busca.buscaStamp))
                         {
                             return NotFound();
                         }
                         else
                         {
                             throw;
                         }
                     }
                     return RedirectToAction("Index", "Buscas", new { id = Pbl.Encrypta(Pbl.ProcessoStamp + "," + Pbl.DescricaoGeral) });
                 }
                 return View(busca);
             }

             // GET: Buscas/Delete/5
             public async Task<IActionResult> Delete(string id)
             {
                 id = Pbl.Decrypta(id);
                 if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                 {
                     return RedirectToAction("Login", "Home");
                 }
                 if (id == null || _dbContext.Busca == null)
                 {
                     return NotFound();
                 }

                 var busca = await _dbContext.Busca
                     .FirstOrDefaultAsync(m => m.buscaStamp == id);
                 if (busca == null)
                 {
                     return NotFound();
                 }

                 return View(busca);
             }

             // POST: Buscas/Delete/5
             [HttpPost, ActionName("Delete")]
             [ValidateAntiForgeryToken]
             public async Task<IActionResult> DeleteConfirmed(string id)
             {
                 id = Pbl.Decrypta(id);
                 if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
                 {
                     return RedirectToAction("Login", "Home");
                 }
                 if (_dbContext.Busca == null)
                 {
                     return Problem("Problema encontrado.");
                 }
                 var busca = await _dbContext.Busca.FindAsync(id);
                 if (busca != null)
                 {
                     _conexao.SqlCmd($"delete Busca where buscaStamp='{id}'");
                 }
                 return RedirectToAction("Index", "Buscas", new { id = Pbl.Encrypta(Pbl.ProcessoStamp + "," + Pbl.DescricaoGeral) });
             }

             private bool BuscaExists(string id)
             {

                 return _dbContext.Busca.Any(e => e.buscaStamp == id);
             }*/
        #endregion

    }

}
