using System.ComponentModel.DataAnnotations;

namespace APICadCenter.Servico.DTO
{
    public class PessoaDTO
    {
        public long id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string? telefone { get; set; }
        public string? email { get; set; }
        public string? ativo { get; set; }

    }
}
