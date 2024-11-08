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
            group.MapPost("/", async (IPersonService service, Person person) => await service.CreatePerson(person));
            group.MapPut("/{id}", async (IPersonService service, int id, Person person) => await service.UpdatePerson(id, person));            
            group.MapDelete("/{id}", async (IPersonService service, int id) => await service.DeletePerson(id));
            
            return group;
        }
    }
}