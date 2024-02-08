namespace APICadCenter.ViewModels
{
    public class ResponseViewModel
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public IEnumerable<String> Errors { get; set; }
    }
}
