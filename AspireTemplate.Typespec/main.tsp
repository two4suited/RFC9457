import "@typespec/http";
import "@typespec/rest";
import "@typespec/openapi3";
import "./models.tsp";
import "./responses.tsp";

using TypeSpec.Http;
using TypeSpec.Rest;

/** This is a pet store service. */
@service({
  title: "Person API",
})
@server("https://localhost:7425", "Local development server")
namespace PersonAPI;

@route("/persons")
interface PersonOperations {
    @get @route("/") listPersons(): Person[] | ApiErrors;
    
    @get @route("/{id}") getPerson(id: int32): Person | ApiErrors;
    
    @post createPerson(person: Person): Person | Forbidden | ApiErrors;
    
    @put @route("/{id}") updatePerson(id: int32, person: Person): Person | ApiErrors;
    
    @delete @route("/{id}") deletePerson(id: int32): {} | ApiErrors;
}


