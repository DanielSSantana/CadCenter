using APICadCenter.Data;
using APICadCenter.Dominio;
using Microsoft.EntityFrameworkCore;

namespace APICadCenter.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly BancoContext _context;

        public PessoaRepository(BancoContext context)
        {
            _context = context;
        }

        public List<Pessoa> Get(int pagina, int tamanhoPagina)
        {
            return _context.Pessoa
                    .Skip((pagina - 1) * tamanhoPagina)
                    .Take(tamanhoPagina)
                    .ToList();
        }

        public Pessoa? Get(long Id)
        {
            return _context.Pessoa.Find(Id);
        }

        public void Delete(long Id)
        {
            var endereco = _context.Pessoa.Find(Id);

            if (endereco != null)
            {
                _context.Pessoa.Remove(endereco);
                _context.SaveChanges();
            }
        }

        public long Creat(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            return _context.SaveChanges();
        }

        public void Update(Pessoa pessoa)
        {
            _context.Pessoa.Update(pessoa);
            _context.SaveChanges();
        }
    }

}
