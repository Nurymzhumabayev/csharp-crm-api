using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Project.Api;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            ValidationException => (StatusCodes.Status400BadRequest, "Ошибка валидации"),
            ArgumentException => (StatusCodes.Status400BadRequest, "Некорректные данные"),
            InvalidOperationException => (StatusCodes.Status409Conflict, "Недопустимая операция"),
            _ => (StatusCodes.Status500InternalServerError, "Внутренняя ошибка сервера")
        };
        httpContext.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message
        };
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;

    }
}