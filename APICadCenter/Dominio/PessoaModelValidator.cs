using APICadCenter.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace APICadCenter.Dominio
{
    public class PessoaModelValidator : AbstractValidator<Pessoa>
    {
        private readonly BancoContext _context;

        public PessoaModelValidator(BancoContext context)
        {    _context = context;

            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Cpf)
                    .NotEmpty()
                    .Must(CpfExistente)
                    .WithMessage("Cpf já exite");

            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email não pode ser nulo/Vazion");

            RuleFor(x => x.Telefone).NotNull().NotEmpty().WithMessage("Telefone não pode ser nulo/Vazion");


        }

        private bool CpfExistente(string cpf)
        {
            return !_context.Pessoa.Any(x => x.Cpf == cpf);
        }

    }

}
