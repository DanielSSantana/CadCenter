namespace WebApp.Models
{
    public class EnderecosPorPessoa
    {
        public long PessoaId { get; set; }
        public List<EnderecoModel> Enderecos { get; set; }
    }
}
