using APICadCenter.ViewModels;
using Application.Interfaces;
using Domain.Models;
using Domain.Repository;
using FluentValidation;

namespace Application.Services
{

    public class EnderecoServico : IEnderecoService
    {
        private readonly IEnderecoRepository _repositorio;
        private readonly IValidator<Endereco> _validator;

        public EnderecoServico(IEnderecoRepository repositorio, IValidator<Endereco> validator)
        {
            _repositorio = repositorio;
            _validator = validator;
        }

        public EnderecoCriarViewModel Criar(EnderecoCriarViewModel endereco)
        {
            Endereco enderecoModel = new Endereco(endereco.logradouro, endereco.numero, endereco.municipio, endereco.estadoFederacao, endereco.cep, TipoEndereco.Principal, endereco.pessoaId);

            var validationResult = _validator.Validate(enderecoModel);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return _repositorio.Create(enderecoModel);             

        }

        public List<EnderecoViewModel> Buscar(int pagina = 1, int tamanhoPaina = 10)
        {
            var retorno = _repositorio.GetAll();

            List<EnderecoViewModel> enderecoViewModels = new List<EnderecoViewModel>();

            if (retorno == null)
                return enderecoViewModels;

            foreach (var endereco in retorno)
            {
                EnderecoViewModel end = new EnderecoViewModel
                {
                    id = endereco.id,
                    ativo = endereco.Ativo == true ? "Sim" : "Não",
                    logradouro = endereco.Logradouro,
                    numero = endereco.Numero,
                    municipio = endereco.Municipio,
                    estadoFederacao = endereco.Uf,
                    complemento = endereco.Complemento,
                    pais = endereco.Pais,
                    cep = endereco.CodigoPostal,
                    tipoEndereco = endereco.TipoEndereco,
                    contatoId = endereco.PessoaId
                };
                enderecoViewModels.Add(end);
            }

            return enderecoViewModels;
        }

        public EnderecoViewModel BuscarPorId(int id)
        {
            var retorno = _repositorio.Get(id);
            EnderecoViewModel enderecoViewModel = new EnderecoViewModel();

            if (retorno == null)
                return enderecoViewModel;

            EnderecoViewModel endereco = new EnderecoViewModel
            {
                id = retorno.id,
                ativo = retorno.Ativo == true ? "Sim" : "Não",
                logradouro = retorno.Logradouro,
                numero = retorno.Numero,
                municipio = retorno.Municipio,
                estadoFederacao = retorno.Uf,
                complemento = retorno.Complemento,
                pais = retorno.Pais,
                cep = retorno.CodigoPostal,
                tipoEndereco = retorno.TipoEndereco,
                contatoId = retorno.PessoaId
            };

            return endereco;
        }

        public List<EnderecoViewModel> BuscarPorPessoa(int idPessoa, int pagina = 1, int tamanhoPaina = 10)
        {
            var retorno = _repositorio.GetByPessoa(idPessoa);

            List<EnderecoViewModel> enderecoViewModels = new List<EnderecoViewModel>();

            if (retorno == null)
                return enderecoViewModels;

            foreach (var endereco in retorno)
            {
                EnderecoViewModel end = new EnderecoViewModel
                {
                    id = endereco.id,
                    ativo = endereco.Ativo == true ? "Sim" : "Não",
                    logradouro = endereco.Logradouro,
                    numero = endereco.Numero,
                    municipio = endereco.Municipio,
                    estadoFederacao = endereco.Uf,
                    complemento = endereco.Complemento,
                    pais = endereco.Pais,
                    cep = endereco.CodigoPostal,
                    tipoEndereco = endereco.TipoEndereco,
                    contatoId = endereco.PessoaId
                };
                enderecoViewModels.Add(end);
            }
            return enderecoViewModels;
        }

        public void Apagar(long id)
        {
            _repositorio.Delete(id);
        }

        public void Ativar(long id)
        {
            var endereco = _repositorio.Get(id);

            if (endereco is null)
                return;

            endereco.AtivarEndereco();

            _repositorio.Update(endereco);

        }

        public void Inativar(long id)
        {
            var endereco = _repositorio.Get(id);

            if (endereco is null)
                return;

            endereco.InativarEndereco();

            _repositorio.Update(endereco);
        }
    }
}
