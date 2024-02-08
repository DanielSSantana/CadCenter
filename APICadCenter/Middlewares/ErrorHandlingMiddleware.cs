using FluentValidation;
using System.Collections;
using System.Net;
using System.Text.Json;

namespace APICadCenter.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //Log.Error(exception, "Erro na aplicação");

            var code = HttpStatusCode.InternalServerError;

            if (exception is Exception) code = HttpStatusCode.BadRequest;
            // else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            // else if (exception is MyException)             code = HttpStatusCode.BadRequest;
            var result = JsonSerializer.Serialize(new { error = exception.Message });

            if (exception is ValidationException)
            {
                ValidationException validation = (ValidationException)exception;
                IList<string> erros = new List<string>();
                foreach (var error in validation.Errors)
                {
                    erros.Add(error.PropertyName + "\u0022 : \u0022" + error.ErrorMessage);
                }

                result = JsonSerializer.Serialize(new { erros });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
