using Api.Controllers;
using APICadCenter.Servico;
using APICadCenter.ViewModels;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APICadCenter.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PessoaController : BaseController
    {
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper; 
        public PessoaController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IMapper mapper, IPessoaService pessoaService)
            : base(notifications, mediator)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] PaginaParametros paginaParametros)
        {
            var retorno = _pessoaService.Buscar(paginaParametros.Pagina, paginaParametros.TamanhoPagina);
            var dados = _mapper.Map<IEnumerable<PessoaViewModel>>(retorno);
            return ResponseAction(dados);

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var data = _pessoaService.BuscarPorId(id);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(data.PaginationMetadata));
            var result = _mapper.Map<IEnumerable<EnderecoViewModel>>(data);//.ShapeData(parameters?.Fields);
            return ResponseAction(result);
        }
         

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PessoaViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(PessoaViewModel pessoa)
        { 
            _pessoaService.Criar(pessoa.nome, pessoa.cpf, pessoa.telefone, pessoa.email);
            return ResponseAction(pessoa);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            _pessoaService.Exluir(id);
            return ResponseAction(null);
        }
    }
}
