using Microsoft.AspNetCore.Mvc;
using SGPMAPI.Interfaces;

namespace SGPMAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly GenericService<TEntity> _service;
        public GenericController(GenericService<TEntity> service)
        {
            _service = service;
        }
        [HttpGet("{entityName}/with-children/{id}")]
        public async Task<IActionResult> GetWithChildren(string entityName, string id)
        {
            var result = await _service.GetWithChildrenAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }

}