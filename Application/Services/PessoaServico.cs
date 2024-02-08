using Application.Interfaces;
using Domain.Models;
using Domain.Repository;
using FluentValidation;

namespace APICadCenter.Servico
{

    public class PessoaServico : IPessoaService
    {
        private readonly IPessoaRepository _repositorio;
        private readonly IValidator<Pessoa> _validator;

        public PessoaServico(IPessoaRepository repositorio, IValidator<Pessoa> validator)
        {
            _repositorio = repositorio;
            _validator = validator;
        }

        public long Criar(string nome, string cpf, string telefone, string email)
        {
            Pessoa pessoa = new Pessoa(nome, cpf, telefone, email);
            if (!_validator.Validate(pessoa).IsValid)
                throw new ValidationException(_validator.Validate(pessoa).Errors);

            return _repositorio.Creat(pessoa);
        }

        public Pessoa BuscarPorId(long Id)
        {
            return _repositorio.Get(Id);
        }

        public List<Pessoa> Buscar(int pagina = 1, int tamanhoPagina = 10)
        {
            return _repositorio.Get(pagina, tamanhoPagina);
            
        }
        public void AtualizarPropriedade(long Id, string? nome = null, string? telefone = null, string? email = null)
        {
            var pessoa = _repositorio.Get(Id);

            if (pessoa == null)
                return;

            pessoa.SetNome(nome);

            pessoa.SetTelefone(telefone);

            pessoa.SetEmail(email);

            _repositorio.Update(pessoa);
        }

        public void Exluir(long Id)
        {
            var pessoa = _repositorio.Get(Id);

            if (pessoa == null)
                throw new Exception("Contato não encontrado");

            _repositorio.Delete(pessoa.Id);
        }

        public void Inativar(long Id)
        {
            var pessoa = _repositorio.Get(Id);

            if (pessoa == null)
                return;

            if(!pessoa.Ativo)
                return;

            pessoa.InativarPessoa();

            _repositorio.Update(pessoa);
        }

        public void Ativar(long Id)
        {
            var pessoa = _repositorio.Get(Id);

            if (pessoa == null)
                return;

            if(pessoa.Ativo)
                return;

            pessoa.InativarPessoa();

            _repositorio.Update(pessoa);
        }
    }
}
