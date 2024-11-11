using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;
using PersonAPI.Service.Models;

namespace AspireTemplate.ApiService
{
    public static class ResultsExtensions
    {
        public static IResult ValidationProblems(this IResultExtensions result,string type,string title,string detail, IDictionary<string, string[]> errors, ILogger logger)
        {
            var errorDetails = errors.Select(e => $"{e.Key}: [{string.Join(", ", e.Value)}]").ToArray();
            logger.LogError("Validation Problem: {type} {title} {detail} {errors}",type,title,detail,string.Join("; ", errorDetails));


            var validation = new ValidationError()
            {               
                Title = title,
                Detail = detail,
                Type = type,
                Errors = errors.Select(e => new ErrorDetail()
                {
                    Key = e.Key,
                    Messages = e.Value
                }).ToArray()
            };

            return Results.BadRequest<ValidationError>(validation);
        }
        public static IResult NotFound(this IResultExtensions result,string type,string title,string detail, ILogger logger)
        {
            logger.LogWarning("Not Found: {type} {title} {detail}",type,title,detail);
            var notFound = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Title = title,
                Detail = detail,
                Type = type
            };
            return Results.NotFound(notFound);
        }
        public static IResult InternalServerError(this IResultExtensions result,string type,string title,string detail, ILogger logger)
        {
            logger.LogError("Internal Server Error: {type} {title} {detail}",type,title,detail);
          
            var problem = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = title,
                Detail = detail,
                Type = type
            };

            return Results.Problem(problem);
        }
        
    }
}