using ApiTarefas.Dtos;
using ApiTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [Route("tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        /*1- Get: Buscar Todos os registros (lista)*/
        List<Tarefa>listaTarefas = new List<Tarefa>();

        public TarefaController() 
        {
            var tarefa1 = new Tarefa()
            {
                Id = 1,
                Descricao = "Estudo de API part 1"
            };

            var tarefa2 = new Tarefa()
            {
                Id = 2,
                Descricao = "Estudo de API part 2"
            };

            var tarefa3 = new Tarefa()
            {
                Id = 3,
                Descricao = "Estudo de API part 3"
            };

            listaTarefas.Add(tarefa1);
            listaTarefas.Add(tarefa2);
            listaTarefas.Add(tarefa3);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaTarefas);
        }/*fim da 1*/

        /*2- GetById: Buscar um registro por id */
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();
            if(tarefa == null)
            {
                return NotFound();
            }
            return Ok(tarefa);
        }/*fim da 2*/

        /*3- Post: Criar um novo registro*/
        [HttpPost]
        public IActionResult Post([FromBody] TarefaDTO item)
        {
            var contador =  listaTarefas.Count();
            var tarefa = new Tarefa();

            tarefa.Id = contador + 1;
            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;

            listaTarefas.Add(tarefa);

            return StatusCode(StatusCodes.Status201Created, tarefa);
        
        }/*fim da 3*/

        [HttpPut]
        public IActionResult Put(int id, [FromBody] TarefaDTO item)
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

            if(tarefa == null) 
            {
                return NotFound();
            }

            tarefa.Descricao = item.Descricao;
            tarefa.Feito= item.Feito;
            return Ok(tarefa);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] Tarefa item)
        {
            var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

            if (tarefa == null)
            {
                return NotFound();
            }

            listaTarefas.Remove(tarefa);
            return Ok(tarefa);
        }

    }

}
