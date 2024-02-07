using APICadCenter.Data;
using APICadCenter.Dominio;
using Microsoft.EntityFrameworkCore;

namespace APICadCenter.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly BancoContext _context;

        public EnderecoRepository(BancoContext context)
        {
            _context = context;
        }

        public List<Endereco> Get(int pagina, int tamanhoPagina)
        {
            return _context.Endereco
                    .Skip((pagina - 1) * tamanhoPagina)
                    .Take(tamanhoPagina)
                    .ToList();
        }

        public List<Endereco> GetByPessoa(long IdContato)
        {
            return _context.Endereco.Where(x => x.PessoaId == IdContato).ToList();
        }

        public Endereco? Get(long Id)
        {
            return _context.Endereco.First(x => x.id == Id);
        }

        public void Delete(long Id)
        {
            var endereco = _context.Endereco.Find(Id);

            if (endereco != null)
            {
                _context.Endereco.Remove(endereco);
                _context.SaveChanges();
            }
        }

        public int Creat(Endereco endereco)
        {
            _context.Endereco.Add(endereco);
            return _context.SaveChanges();
        }

        public void Update(Endereco endereco)
        {
            _context.Endereco.Update(endereco);
            _context.SaveChanges();
        }

    }
}
