using Cloud5.Domain;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace Cloud5.API.Middlewares
{
    public class CloudMiddleware : IMiddleware
    {
        public CloudMiddleware() { }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (CloudException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)ex.Status;
                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Message));
            }
            catch
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync("An internal server error occurred.");
            }
        }
    }
}
