using Domain.Models;
using FluentValidation; 

namespace Domain.Validations
{
    public class PessoaValidator : AbstractValidator<Pessoa>
    {

        public PessoaValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .MaximumLength(50);
             
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email não pode ser nulo/Vazion");

            RuleFor(x => x.Telefone).NotNull().NotEmpty().WithMessage("Telefone não pode ser nulo/Vazion");


        }


    }

}
