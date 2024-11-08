using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspireTemplate.ApiService.Database;

namespace AspireTemplate.ApiService
{
    public interface IPersonService
    {
        Task<IResult> GetPerson(int id);
        Task<IResult> GetPeople();
        Task<IResult> CreatePerson(Person person);
        Task<IResult> UpdatePerson(int id, Person person);
        Task<IResult> DeletePerson(int id);
    }
}