using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API Tarefas: online");
        }
        [HttpGet("hello-world")] 
        public IActionResult GeHelloWorld() 
        { 
            return Ok("Hello World da Taynara");
        }
        [HttpGet("autor")]
        public IActionResult GetAutor() 
        {
            return Ok("Desenvolvido por Taynara");
        }
    }
}
