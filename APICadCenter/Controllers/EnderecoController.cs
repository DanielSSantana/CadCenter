using Api.Controllers;
using APICadCenter.Data;
using APICadCenter.Servico;
using APICadCenter.Servico.DTO;
using APICadCenter.ViewModels;
using Application.Interfaces;
using AutoMapper;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Text.Json;

namespace APICadCenter.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EnderecoController : BaseController
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;
        public EnderecoController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator, IMapper mapper, IEnderecoService enderecoService) 
            : base(notifications, mediator)
        {
            _enderecoService = enderecoService;
            _mapper = mapper;
        }
         
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        { 
            var data =  _enderecoService.BuscarPorId(id);
            //Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(data.PaginationMetadata));
            var result = _mapper.Map<IEnumerable<EnderecoViewModel>>(data);//.ShapeData(parameters?.Fields);
            return ResponseAction(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(EnderecoCriarViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(EnderecoCriarViewModel endereco)
        {
            if (!ModelStateValid()) return ResponseAction(null); 
            _enderecoService.Criar(endereco);

            return ResponseAction(endereco); 
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoCriarViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   
            _enderecoService.Apagar(id);

            return ResponseAction(null);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoCriarViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}/Ativar")]
        public IActionResult Ativar(int id)
        {
            _enderecoService.Ativar(id);
            return ResponseAction(null);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EnderecoCriarViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}/Inativar")]
        public IActionResult Inativar(int id)
        {
            _enderecoService.Inativar(id);
            return ResponseAction(null);
        }
    }
}
