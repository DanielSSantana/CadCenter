using Data.SqlServer.Context;
using Domain.Models;
using Domain.Repository;

namespace Data.SqlServer.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        private readonly CadCenterContext _context;

        public EnderecoRepository(CadCenterContext context) : base(context)
        {
            _context = context;
        }

    }
}
