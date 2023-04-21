using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APICadCenter.Dominio;

namespace APICadCenter.Servico.DTO
{
    public class EnderecoCriarDTO
    {
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string municipio { get; set; }
        public string estadoFederacao { get; set; }
        public string? complemento { get; set; }
        public string cep { get; set; }
        public long pessoaId { get; set; }
    }
}
