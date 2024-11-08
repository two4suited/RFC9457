using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspireTemplate.ApiService.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.Replication;

namespace AspireTemplate.ApiService.Endpoints
{
    public static class PersonEndpoints
    {
        public static RouteGroupBuilder MapPersonEndpoints(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IPersonService service) => await service.GetPeople());
            group.MapGet("/{id}", async (IPersonService service, int id) => await service.GetPerson(id));
            

            group.MapPost("/person", async (DatabaseContext db, Person person) =>
            {
                db.People.Add(person);
                await db.SaveChangesAsync();
                return person;
            });

            group.MapPut("/person/{id}", async (DatabaseContext db, int id, Person person) =>
            {
                var existingPerson = await db.People.FindAsync(id);
                if (existingPerson == null)
                {
                    throw new ProblemException("Person not found", $"Person with id {id} not found.");
                }

                existingPerson.Age = person.Age;
                existingPerson.Name = person.Name;
                await db.SaveChangesAsync();
                return existingPerson;
            });

            group.MapDelete("/person/{id}", async (DatabaseContext db, int id) =>
            {
                var person = await db.People.FindAsync(id);
                if (person == null)
                {
                    throw new ProblemException("Person not found", $"Person with id {id} not found.");
                }

                db.People.Remove(person);
                await db.SaveChangesAsync();
                return person;
            });

            return group;
        }
    }
}