using Microsoft.AspNetCore.Diagnostics;
using TheSecondTestSolution.Api.Models;
using TheSecondTestSolution.Domain.Seed;

namespace TheSecondTestSolution.Api.ExceptionHandlers
{
    public class DevExeptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ErrorModel error = new ErrorModel
            {
                Type = exception.GetType().Name

            };

            if (exception is RootExeption rootExeption)
            {
                error.Status = (int)rootExeption.StatusCode;
                error.Title = "Service error";
                error.Errors.Add("Details", rootExeption.Messages);
            }
            else
            {
                error.Status = 400;
                error.Title = "Service error";
                error.Errors.Add("Details", [exception.Message]);
            }

            error.Errors.Add("StackTrace", [exception.StackTrace ?? string.Empty]);

            httpContext.Response.StatusCode = error.Status;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(error);

            return true;
        }
    }
}
