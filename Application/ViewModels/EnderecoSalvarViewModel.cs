namespace APICadCenter.ViewModels
{
    public class EnderecoSalvarViewModel
    {
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string municipio { get; set; }
        public string uf { get; set; }
        public string? complemento { get; set; }
        public string pais { get; set; }
        public string codigoPostar { get; set; }
        public TipoEndereco tipoEndereco { get; set; }
        public long contatoId { get; set; }

        public EnderecoSalvarViewModel() { }
        public EnderecoSalvarViewModel(string Logradouro, string Numero, string Municipio, string UF, string Complemente, string Pais, string CondigoPostar, TipoEndereco TipoEndereco, long ContatoID)
        {
            logradouro = Logradouro; numero = Numero; municipio = municipio; uf = UF; complemento = Complemente; pais = Pais; codigoPostar = codigoPostar; tipoEndereco = TipoEndereco;
            contatoId = ContatoID;
        }
    }
}
