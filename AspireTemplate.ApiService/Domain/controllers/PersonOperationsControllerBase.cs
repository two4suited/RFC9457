// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// <auto-generated />

using System;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using PersonAPI.Service.Models;
using PersonAPI.Service;

namespace PersonAPI.Service.Controllers
{
    [ApiController]
    public abstract partial class PersonOperationsControllerBase : ControllerBase
    {

        internal abstract IPersonOperations PersonOperationsImpl { get; }


        [HttpGet]
        [Route("/persons/")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        public virtual async Task<IActionResult> ListPersons()
        {
            await PersonOperationsImpl.ListPersonsAsync();
            return Ok();
        }


        [HttpGet]
        [Route("/persons/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Person))]
        public virtual async Task<IActionResult> GetPerson(int id)
        {
            var result = await PersonOperationsImpl.GetPersonAsync(id);
            return Ok(result);
        }


        [HttpPost]
        [Route("/persons")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Person))]
        public virtual async Task<IActionResult> CreatePerson(Person body)
        {
            var result = await PersonOperationsImpl.CreatePersonAsync(body);
            return Ok(result);
        }


        [HttpPut]
        [Route("/persons/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Person))]
        public virtual async Task<IActionResult> UpdatePerson(int id, Person body)
        {
            var result = await PersonOperationsImpl.UpdatePersonAsync(id, body);
            return Ok(result);
        }


        [HttpDelete]
        [Route("/persons/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(void))]
        public virtual async Task<IActionResult> DeletePerson(int id)
        {
            await PersonOperationsImpl.DeletePersonAsync(id);
            return Ok();
        }

    }
}
