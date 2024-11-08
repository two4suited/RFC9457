using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspireTemplate.ApiService
{
    [Serializable]
    public class ProblemException: Exception
    {
        public string Error { get; set; }
        //public string Message { get; set; }
        public ProblemException(string error,string message): base(message)
        {
            Error = error;
            //Message = message;
        }
    }
    public class ProblemExceptionHandler : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;
        public ProblemExceptionHandler(IProblemDetailsService problemDetailsService)
        {
            _problemDetailsService = problemDetailsService;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, 
            Exception exception, 
            CancellationToken cancellationToken)
        {
            if (exception is ProblemException problemException)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = problemException.Error,
                    Detail = problemException.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "Bad Request"                    
                };
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext{
                    HttpContext = httpContext,
                    ProblemDetails = problemDetails
                });            
            }
            return true;
        }
    }
}