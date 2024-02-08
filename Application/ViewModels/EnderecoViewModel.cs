
namespace APICadCenter.ViewModels
{
    public class EnderecoViewModel
    {
        public long id { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string municipio { get; set; }
        public string estadoFederacao { get; set; }
        public string? complemento { get; set; }
        public string pais { get; set; }
        public string cep { get; set; }
        public TipoEndereco tipoEndereco { get; set; }
        public string ativo { get; set; }
        public long contatoId { get; set; }
    }
}
