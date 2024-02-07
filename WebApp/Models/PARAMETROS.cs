namespace WebApp.Models
{
    public static class PARAMETROS
    {
        public static string URL_API { get; set; }

        public static string MontarUrl(string url)
        {
            return URL_API + url;
        }
    }
}
