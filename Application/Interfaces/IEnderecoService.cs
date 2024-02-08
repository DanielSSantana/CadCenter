
using APICadCenter.ViewModels;

namespace Application.Interfaces
{
    public interface IEnderecoService
    {
        long Criar(EnderecoCriarViewModel endereco);
        List<EnderecoViewModel> Buscar(int pagina = 1, int tamanhoPaina = 10);
        EnderecoViewModel BuscarPorId(int id);
        List<EnderecoViewModel> BuscarPorPessoa(int idPessoa, int pagina = 1, int tamanhoPaina = 10);
        void Apagar(long id);
        void Inativar(long id);
        void Ativar(long id);
    }
}
