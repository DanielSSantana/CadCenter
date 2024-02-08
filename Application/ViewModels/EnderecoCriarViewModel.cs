
namespace APICadCenter.ViewModels
{
    public class EnderecoCriarViewModel
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
