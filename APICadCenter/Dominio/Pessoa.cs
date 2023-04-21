using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace APICadCenter.Dominio
{
    [Index(nameof(Cpf), IsUnique = true)]
    public class Pessoa
    {
        [Key]
        [Required]
        public long Id { get; private set; }
        [MaxLength(50)]
        public string Nome { get; private set; }
                
        [RegularExpression(@"^\d{3}.\d{3}.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        public string Cpf { get; private set; }

        [RegularExpression(@"^\d2\d2\s\d{4}-\d{4}$", ErrorMessage = "Telefone inválido")]
        public string? Telefone { get; private set; }
                
        [EmailAddress]
        public string Email { get; private set; }

        public List<Endereco> Enderecos { get; private set; }

        public bool Ativo { get; private set; }

        protected Pessoa() { }

        public Pessoa(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;

            Ativo= true;
        }

        public Pessoa(string nome, string cpf, string telefone, string email) : this(nome, cpf)
        {
            Telefone = telefone;
            Email = email;
        }

        public void SetTelefone(string telefone)
        {
            Telefone = telefone;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void AtivarPessoa()
        {
            Ativo = true;
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void InativarPessoa()
        {
            Ativo = false;
        }



    }
}
