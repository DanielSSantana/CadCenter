using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using Domain.Core.Models; 

namespace Domain.Models
{
    public class Endereco : Entity
    {
        protected Endereco() { }

        public Endereco(string logradouro, string numero, string municipio, string uf, string codigoPostal, TipoEndereco tipoEndereco, Guid pessoaId)
        {
            Logradouro = logradouro;
            Numero = numero;
            Municipio = municipio;
            Uf = uf;
            CodigoPostal = codigoPostal;
            TipoEndereco = tipoEndereco;
            PessoaId = pessoaId;

            Pais = "Brasil";
        }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Municipio { get; set; } 
        public string Uf { get; set; }
        public string? Complemento { get; set; }
        public string Pais { get; set; } 
        public string CodigoPostal { get; set; } 
        public TipoEndereco TipoEndereco { get; set; }
        public bool Ativo { get; set; } 
        public Guid PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }



    }
}
