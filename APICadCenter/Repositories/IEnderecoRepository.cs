using APICadCenter.Dominio;

namespace APICadCenter.Repositories
{
    public interface IEnderecoRepository
    {
        List<Endereco> Get(int pagina, int tamanhoPagina);
        Endereco? Get(long Id);
        List<Endereco> GetByPessoa(long IdContato);
        int Creat(Endereco endereco);
        void Update(Endereco endereco);
        void Delete(long Id);
    }
}
