using AspireTemplate.ApiService.Database;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AspireTemplate.ApiService
{
    public class PersonService(ILogger<PersonService> logger, DatabaseContext db, PersonValidator validator) : IPersonService
    {
        public async Task<IResult> CreatePerson(Person person)
        {
            var validationResult = await validator.ValidateAsync(person);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToDictionary();
                return Results.Extensions.ValidationProblems("ValidationError", "Validation error", "One or more validation errors occurred.", errors, logger);
            }
            try
            {
                db.People.Add(person);
                await db.SaveChangesAsync();
                return Results.Ok(person);
            }
            catch (Exception e)
            {
                return Results.Extensions.InternalServerError("PersonError", "Error creating person", e.Message, logger);
            }
        }

        public async Task<IResult> DeletePerson(int id)
        {
            var person = await db.People.FindAsync(id);
            if (person == null)
            {
                return Results.Extensions.NotFound("PersonNotFound", "Person not found", $"Person with id {id} not found.", logger);
            }

            try
            {
                db.People.Remove(person);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (Exception e)
            {
                return Results.Extensions.InternalServerError("PersonError", "Error deleting person", e.Message, logger);
            }
        }

        public async Task<IResult> GetPeople()
        {
            try
            {
                var people = await db.People.ToListAsync();
                return Results.Ok(people);
            }
            catch (Exception e)
            {
                return Results.Extensions.InternalServerError("PersonError", "Error getting people", e.Message, logger);
            }
        }

        public async Task<IResult> GetPerson(int id)
        {
            try
            {
                var person = await db.People.FindAsync(id);
                if (person == null)
                {
                    return Results.Extensions.NotFound("PersonNotFound", "Person not found", $"Person with id {id} not found.", logger);
                }
                return Results.Ok(person);
            }
            catch (Exception e)
            {
                return Results.Extensions.InternalServerError("PersonError", "Error getting person", e.Message, logger);
            }
        }

        public async Task<IResult> UpdatePerson(int id, Person person)
        {
            var findPerson = await db.People.FindAsync(id);
            if (findPerson == null)
            {
                return Results.Extensions.NotFound("PersonNotFound", "Person not found", $"Person with id {id} not found.", logger);
            }

            var validationResult = await validator.ValidateAsync(person);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ToDictionary();
                return Results.Extensions.ValidationProblems("ValidationError", "Validation error", "One or more validation errors occurred.", errors, logger);
            }
            try
            {
                findPerson.Age = person.Age;
                findPerson.Name = person.Name;
                await db.SaveChangesAsync();
                return Results.Ok(findPerson);
            }
            catch (Exception e)
            {
                return Results.Extensions.InternalServerError("PersonError", "Error updating person", e.Message, logger);
            }
        }
    }
}