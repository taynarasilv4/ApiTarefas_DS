using ApiTarefas.Dtos;
using ApiTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [Route("veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        List<Veiculo> listaVeiculos = new List<Veiculo>();

        public VeiculoController()
        {
            var veiculo1 = new Veiculo()
            {
                Marca = "X",
                Modelo = "Y",
                AnoFab = 'F',
                AnoModelo = 'M',
                Placa = "AAA-1234",

            };

            var veiculo2 = new Veiculo()
            {
                Marca = "X",
                Modelo = "Y",
                AnoFab = 'F',
                AnoModelo = 'M',
                Placa = "AAA-1342",
            };

            var veiculo3 = new Veiculo()
            {
                Marca = "X",
                Modelo = "Y",
                AnoFab = 'F',
                AnoModelo = 'M',
                Placa = "AAA-4234",
            };

            var veiculo4 = new Veiculo()
            {
                Marca = "X",
                Modelo = "Y",
                AnoFab = 'F',
                AnoModelo = 'M',
                Placa = "AAA-1422",
            };

            listaVeiculos.Add(veiculo1);
            listaVeiculos.Add(veiculo2);
            listaVeiculos.Add(veiculo3);
            listaVeiculos.Add(veiculo4);

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaVeiculos);
        }/*fim da 1*/

        /*2- GetById: Buscar um registro por id */
        [HttpGet("{Marca}")]
        public IActionResult GetById(string marca)
        {
            var veiculo = listaVeiculos.Where(item => item.Marca == marca).FirstOrDefault();
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }/*fim da 2*/

        /*3- Post: Criar um novo registro*/
        [HttpPost]
        public IActionResult Post([FromBody] VeiculoDTO item)
        {
            var contador = listaVeiculos.Count();
            var veiculo = new Veiculo();

            veiculo.Marca = item.Marca;
            veiculo.Modelo = item.Modelo;
            veiculo.AnoFab = item.AnoFab;
            veiculo.AnoModelo = item.AnoModelo;
            veiculo.Placa = item.Placa;


            listaVeiculos.Add(veiculo);

            return StatusCode(StatusCodes.Status201Created, veiculo);

        }/*fim da 3*/

        [HttpPut]
        public IActionResult Put(string marca, [FromBody] VeiculoDTO item)
        {
            var veiculo = listaVeiculos.Where(item => item.Marca == marca).FirstOrDefault();

            if (veiculo == null)
            {
                return NotFound();
            }
            veiculo.Marca = item.Marca;
            veiculo.Modelo = item.Modelo;
            veiculo.AnoFab = item.AnoFab;
            veiculo.AnoModelo = item.AnoModelo;
            veiculo.Placa = item.Placa;
     
            return Ok(veiculo);
        }
        [HttpDelete("{Marca}")]
        public IActionResult Delete(string marca, [FromBody] Veiculo item)
        {
            var veiculo = listaVeiculos.Where(item => item.Marca == marca).FirstOrDefault();

            if (veiculo == null)
            {
                return NotFound();
            }

            listaVeiculos.Remove(veiculo);
            return Ok(veiculo);
        }
    }
}
