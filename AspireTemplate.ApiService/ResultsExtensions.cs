using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.Replication;

namespace AspireTemplate.ApiService
{
    public static class ResultsExtensions
    {
        public static IResult ValidationProblems(this IResultExtensions result,string type,string title,string detail, IDictionary<string, string[]> errors, ILogger logger)
        {
            logger.LogError("Validation Problem: {type} {title} {detail} {errors}",type,title,detail,errors);
            return Results.ValidationProblem(
                errors:errors, 
                detail:detail, 
                statusCode:StatusCodes.Status400BadRequest, 
                title:title,
                type:type);
        }
        public static IResult NotFound(this IResultExtensions result,string type,string title,string detail, ILogger logger)
        {
            logger.LogWarning("Not Found: {type} {title} {detail}",type,title,detail);
            return Results.Problem(
                detail:detail, 
                statusCode:StatusCodes.Status404NotFound, 
                title:title,
                type:type);
        }
        public static IResult InternalServerError(this IResultExtensions result,string type,string title,string detail, ILogger logger)
        {
            logger.LogError("Internal Server Error: {type} {title} {detail}",type,title,detail);
            return Results.Problem(
                detail:detail, 
                statusCode:StatusCodes.Status500InternalServerError, 
                title:title,
                type:type);
        }
        
    }
}