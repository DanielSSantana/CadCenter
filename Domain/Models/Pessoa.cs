using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{ 
    public class Pessoa
    {
        protected Pessoa() { }

        public Pessoa(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;

        }

        public Pessoa(string nome, string cpf, string telefone, string email) : this(nome, cpf)
        {
            Telefone = telefone;
            Email = email;
        }

        public string Nome { get; set; } 
        public string Cpf { get; set; } 
        public string? Telefone { get; set; } 
        public string Email { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();

    }
}
