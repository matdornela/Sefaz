using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sefaz.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        // GET: api/<ProdutoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProdutoController>/5
        //[HttpGet("{id}")]
        //public string FindById(int id)
        //{
        //    try
        //    {
        //        var produto = new  object();
        //        if (produto == null) return NotFound("não existe esse registro ou o banco ainda não foi importado!");
        //        return Ok(produto);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
       

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