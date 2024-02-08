using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPessoaService
    {        
        Pessoa BuscarPorId(Guid Id);
        List<Pessoa> Buscar(int pagina = 1, int tamanhoPagina = 10);
        void Criar(string nome, string cpf, string telefone, string email);
        void AtualizarPropriedade(Guid Id, string? nome = null, string? telefone = null, string? email = null);
        void Exluir(Guid Id);
        void Inativar(Guid Id);
        void Ativar(Guid Id);
    }
}
