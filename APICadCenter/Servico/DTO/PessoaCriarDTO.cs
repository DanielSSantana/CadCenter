using System.ComponentModel.DataAnnotations;

namespace APICadCenter.Servico.DTO
{
    public class PessoaCriarDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string? Telefone { get; set; }
        public string? Email { get; set; }
    }
}
