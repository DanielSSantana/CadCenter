using APICadCenter.Data;
using APICadCenter.Servico;
using APICadCenter.Servico.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace APICadCenter.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;
        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("GetByPessoa/{id}")]
        public IActionResult GetByPessoa(int id)
        {
            var retorno = _enderecoService.BuscarPorPessoa(id);

            if (!retorno.Any())
                return NotFound();

            return Ok(retorno);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var retorno = _enderecoService.BuscarPorId(id);

            if (retorno == null)
                return NotFound();

            return Ok(retorno);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EnderecoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(EnderecoCriarDTO endereco)
        {
            long id = _enderecoService.Criar(endereco);
            return CreatedAtAction(nameof(Get), new { id = id }, endereco);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _enderecoService.Apagar(id);
            return Ok();
        }

        [HttpPut("{id}/Ativar")]
        public IActionResult Ativar(int id)
        {
            _enderecoService.Ativar(id);
            return Ok();
        }

        [HttpPut("{id}/Inativar")]
        public IActionResult Inativar(int id)
        {
            _enderecoService.Inativar(id);
            return Ok();
        }
    }
}
