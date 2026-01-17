namespace ASTDOTNET.Models.Response
{
    public class ExternalApiResponse
    {
        public string url { get; set; }
        public string method { get; set; }
        public object response { get; set; }
    }
}
