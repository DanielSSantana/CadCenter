using APICadCenter.Dominio;

namespace APICadCenter.Repositories
{
    public interface IPessoaRepository
    {
        List<Pessoa> Get(int pagina, int tamanhoPagina);
        Pessoa? Get(long Id);
        long Creat(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(long Id);
    }

}
