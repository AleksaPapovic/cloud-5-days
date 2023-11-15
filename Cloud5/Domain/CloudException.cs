using System.Net;

namespace Cloud5.Domain
{
    public class CloudException : Exception
    {
        public HttpStatusCode Status { get; private set; }

        public CloudException(string message, HttpStatusCode status) : base(message)
        {
            Status = status;
        }
    }
}
