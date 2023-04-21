namespace APICadCenter.Controllers
{
    public class PaginaParametros
    {
        public int Pagina { get; set; } = 1;
        public int TamanhoPagina { get; set; } = 10;
        public string SortOrder { get; set; } = "asc";
    }
}
