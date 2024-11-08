using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspireTemplate.ApiService.Database;

namespace AspireTemplate.ApiService
{
    public class PersonService(ILogger<PersonService> logger, DatabaseContext db) : IPersonService
    {
        public Task<IResult> CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> GetPeople()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> GetPerson(int id)
        {
            try {
                    var person = await db.People.FindAsync(id);
                    if (person == null)
                    {
                        return Results.Extensions.NotFound("PersonNotFound", "Person not found", $"Person with id {id} not found.",logger);
                    }
                    return Results.Ok(person);
                } catch (Exception e) {
                    return Results.Extensions.InternalServerError("PersonError", "Error getting person", e.Message,logger);
                }  
        }

        public Task<IResult> UpdatePerson(int id, Person person)
        {
            throw new NotImplementedException();
        }
    }
}