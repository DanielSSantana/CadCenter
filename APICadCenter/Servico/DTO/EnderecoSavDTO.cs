using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using APICadCenter.Dominio;

namespace APICadCenter.Servico.DTO
{
    public class EnderecoSavDTO
    {
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string municipio { get; set; }
        public string uf { get; set; }
        public string? complemento { get; set; }
        public string pais { get; set; }
        public string codigoPostar { get; set; }
        public TipoEndereco tipoEndereco { get; set; }
        public long contatoId { get; set; }

        public EnderecoSavDTO() { }
        public EnderecoSavDTO(string Logradouro, string Numero, string Municipio, string UF, string Complemente, string Pais, string CondigoPostar, TipoEndereco TipoEndereco, long ContatoID)
        {
            logradouro = Logradouro; numero = Numero; municipio = municipio; uf = UF; complemento = Complemente; pais = Pais; codigoPostar = codigoPostar; tipoEndereco = TipoEndereco;
            contatoId = ContatoID;
        }
    }
}
