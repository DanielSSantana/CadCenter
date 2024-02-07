using APICadCenter.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace APICadCenter.Dominio
{
    public class EnderecoModelValidator : AbstractValidator<Endereco>
    {
        private readonly BancoContext _context;

        public EnderecoModelValidator(BancoContext context)
        {
            _context = context;

            RuleFor(x => x.PessoaId)
                .NotEmpty()
                .Must(ContatoExiste)
                .WithMessage("Contato não exites");
        }

        private bool ContatoExiste(long pessoaId)
        {
            return _context.Pessoa.Any(x => x.Id == pessoaId);
        }
    }
}
