
namespace ApiMediator.Response
{
    public class HttpResponseServerException
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}