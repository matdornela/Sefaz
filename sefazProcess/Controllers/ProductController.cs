using Microsoft.AspNetCore.Mvc;
using Sefaz.Apresentacao.WorkServices;
using System.Diagnostics;

namespace sefazProcess.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProdutoWorkService _workService;

        public ProductController(IProdutoWorkService workService)
        {
            _workService = workService;
        }


        // GET api/product/import
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("import")]
        public IActionResult Import()
        {
            try
            {
                Process.Start("CreateImportDB.bat");
                return Ok("Importação realizada com sucesso!");
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}