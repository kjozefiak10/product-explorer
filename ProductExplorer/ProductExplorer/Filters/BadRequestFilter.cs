using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ProductExplorer.Filters
{
    /// <summary>
    /// Ten filtr jest oczywiście uproszczeniem, bo lądują tu wszystkie wyjątki typu ArgumentException.
    /// TODO:
    ///     dodać logowanie wyjątku.
    /// </summary>
    public class BadRequestFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception != null && context.Exception.GetType() == typeof(ArgumentException))
            {
                context.Result = new NotFoundResult();
                context.ExceptionHandled = true;
            }
        }
    }
}
