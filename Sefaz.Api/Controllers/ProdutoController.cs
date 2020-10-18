using Microsoft.AspNetCore.Mvc;
using Sefaz.Apresentacao.DTOs;
using Sefaz.Apresentacao.WorkServices;
using Sefaz.Dominio.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sefaz.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoWorkService _workService;

        public ProdutoController(IProdutoWorkService workService)
        {
            _workService = workService;
        }

        // GET api/produto/ImportarDados
        [ProducesResponseType(200)]
        [HttpGet]
        [Route("ImportarDados")]
        public IActionResult ImportarDados()
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

        // GET /api/v1/Produto/?CodigoGtin=
        [ProducesResponseType((200), Type = typeof(List<ProdutoDTO>))]
        [HttpGet, Route("Produtos")]
        public IActionResult GetProdutos([FromQuery] long CodigoGtin, string inputLatitude = null, string inputLongitude = null)
        {
            if (CodigoGtin != 0)
                try
                {
                    var produtos = _workService.ObterProdutos(CodigoGtin, inputLatitude, inputLongitude);
                    return Ok(produtos);
                }
                catch (SefazException)
                {
                    return NotFound("Registro não encontrado");
                }

            return BadRequest();
        }
    }
}