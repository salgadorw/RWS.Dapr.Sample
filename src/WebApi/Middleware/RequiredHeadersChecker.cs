using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using API.Options;

namespace API.Middleware
{
    public class RequiredHeadersChecker
    {

        private readonly RequestDelegate _next;

        public RequiredHeadersChecker(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context, IOptions<RequiredHeadersOptions> options)
        {
            if (!options.Value.RequiredHeaders.All(h=> context.Request.Headers.Keys.Contains(h)))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                var bodyString = $"Please send the required header(s):{string.Join(",",options.Value.RequiredHeaders)}" ;
                byte[] data = Encoding.UTF8.GetBytes(bodyString);
                context.Response.ContentType = "application/text";
                await context.Response.Body.WriteAsync(data, 0, data.Length);
            }
            else
                await _next.Invoke(context);
        }
    }
}
