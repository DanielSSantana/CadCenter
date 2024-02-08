using Data.SqlServer.Context;
using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.SqlServer.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    { 
        public PessoaRepository(CadCenterContext context) : base(context)
        {
            
        }

    }

}
