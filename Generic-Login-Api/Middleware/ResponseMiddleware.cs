using Generic_Login_Api.Response;
using Newtonsoft.Json;
using System.Net;

namespace Generic_Login_Api.Middleware
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await CreateResponse(context);
            }
            catch (Exception ex)
            {
                await CreateException(context);
            }
        }

        private async Task CreateException(HttpContext context)
        {
            await CreateResponse(context, true);
        }

        private async Task CreateResponse(HttpContext context, bool isException = false)
        {
            using (var buffer = new MemoryStream())
            {
                var stream = context.Response.Body;
                context.Response.Body = buffer;
                await _next.Invoke(context);
                buffer.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(buffer);

                using (var bufferReader = new StreamReader(buffer))
                {
                    string body = await bufferReader.ReadToEndAsync();
                    var code = context.Response.StatusCode;

                    context.Response.Clear();

                    context.Response.StatusCode = isException ? (int)HttpStatusCode.InternalServerError : code;


                    var jsonString = await CreateResponseObject(body, (HttpStatusCode)context.Response.StatusCode);


                    await context.Response.WriteAsync(jsonString);


                    context.Response.Body.Seek(0, SeekOrigin.Begin);
                    await context.Response.Body.CopyToAsync(stream);

                    context.Response.Body = stream;
                }
            }
        }

        private async Task<string> CreateResponseObject(string body, HttpStatusCode code)
        {
            var message = code switch
            {
                HttpStatusCode.OK => "Ok",
                HttpStatusCode.NotFound => "Not found",
                HttpStatusCode.Unauthorized => "No permission",
                _ => "Something went wrong"
            };

            ResponseObject response = null;
            try
            {
                response = new ResponseObject(JsonConvert.DeserializeObject(body), (int)code, message);
            }
            catch (Exception ex)
            {
                response = new ResponseObject(body, (int)code, message);
            }

            return JsonConvert.SerializeObject(response);

        }
    }
}
