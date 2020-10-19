using Microsoft.AspNetCore.Mvc;
using Sefaz.Apresentacao.Exceptions;
using Sefaz.Apresentacao.WorkServices;
using Sefaz.Dominio.Exceptions;
using System.Diagnostics;

namespace Sefaz.Api.Controllers
{
    [Route("v1/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoWorkService _workService;

        public ProdutoController(IProdutoWorkService workService)
        {
            _workService = workService;
        }

        // GET /v1/produtos/importar
        [HttpGet]
        [Route("importar")]
        public IActionResult Importar()
        {
            try
            {
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"ImportarDados.bat",
                        Arguments = @"",
                        UseShellExecute = false,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    }
                };
                proc.Start();
                proc.WaitForExit();
                return Ok("Importação realizada com sucesso!");
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET /v1/produtos/?CodigoGtin=
        [HttpGet]
        public IActionResult GetProdutos([FromQuery] long codigoGtin, string inputLatitude, string inputLongitude)
        {
            try
            {
                var produtos = _workService.ObterListaUltimoProdutoVendidoPorEstabelecimento(codigoGtin, inputLatitude, inputLongitude);
                return Ok(produtos);
            }
            catch (SefazException)
            {
                return NotFound("Registro não encontrado");
            }
            catch (UIException)
            {
                return BadRequest();
            }
        }
    }
}