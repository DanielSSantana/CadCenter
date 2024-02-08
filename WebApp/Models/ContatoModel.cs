namespace WebApp.Models;
{
    public class ContatoModel
    {
       public  long id { get; set; }
       public  string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string errorMessage { get; set; }

    }
}
