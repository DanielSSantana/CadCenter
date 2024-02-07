using APICadCenter.Data;
using APICadCenter.Servico;
using APICadCenter.Servico.DTO;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace APICadCenter.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;
        public PessoaController(IPessoaService contatoService)
        {
            _pessoaService = contatoService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PaginaParametros paginaParametros)
        {
            var retorno = _pessoaService.Buscar(paginaParametros.Pagina, paginaParametros.TamanhoPagina);
            List<PessoaDTO> lista = new List<PessoaDTO>();

            foreach(var item in retorno)
            {
                lista.Add(new PessoaDTO { id = item.Id, nome = item.Nome, cpf = item.Cpf, ativo = item.Ativo ? "Sim" : "Não", email = item.Email, telefone = item.Telefone });
            }

            return Ok(lista);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var retorno = _pessoaService.BuscarPorId(id);

            if(retorno == null)
                return NotFound();

            PessoaDTO pessoa = new PessoaDTO { id = retorno.Id, nome = retorno.Nome, cpf = retorno.Cpf, ativo = retorno.Ativo ? "Sim" : "Não", email = retorno.Email, telefone = retorno.Telefone };

            return Ok(pessoa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PessoaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(PessoaDTO pessoa)
        {
            if (pessoa.id != 0)
            {
                _pessoaService.AtualizarPropriedade(pessoa.id, pessoa.nome, pessoa.telefone, pessoa.email);
                return Ok();
            }
            else
            {
                pessoa.id = _pessoaService.Criar(pessoa.nome, pessoa.cpf, pessoa.telefone, pessoa.email);
                return CreatedAtAction(nameof(Get), pessoa);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            _pessoaService.Exluir(id);
            return Ok();
        }
    }
}
