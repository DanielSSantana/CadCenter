using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using APICadCenter.Data;
using APICadCenter.Dominio;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace APICadCenter.Dominio
{
    public class Endereco
    {
        [Key]
        [Required]
        public long id { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Municipio { get; private set; }
        [Column(TypeName = "Char(2)")]
        public string Uf { get; private set; }
        public string? Complemento { get; private set; }
        public string Pais { get; private set; }
        [RegularExpression("[0-9](9)", ErrorMessage = "Codigo Postal Invalido")]
        public string CodigoPostal { get; private set; }
        [Required]
        public TipoEndereco TipoEndereco { get; private set; }
        public bool Ativo { get; private set; }
        [ForeignKey("Contato")]
        public long PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }

        protected Endereco() { }

        public Endereco(string logradouro, string numero, string municipio, string uf, string codigoPostal, TipoEndereco tipoEndereco,long pessoaId)
        {
            this.id = id;
            Logradouro = logradouro;
            Numero = numero;
            Municipio = municipio;
            Uf = uf;
            CodigoPostal = codigoPostal;
            TipoEndereco = tipoEndereco;
            PessoaId = pessoaId;

            Pais = "Brasil";
        }

        public void SetComplemento(string complemento)
        {
            Complemento = complemento;
        }

        public void AtivarEndereco()
        {
            Ativo = true;
        }

        public void InativarEndereco()
        {
            Ativo = false;
        }

        public void SetTipoEndereco(TipoEndereco tipoEndereco)
        {
            TipoEndereco = tipoEndereco;
        }

    }
}
