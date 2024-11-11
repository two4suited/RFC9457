using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspireTemplate.ApiService.Database;
using Newtonsoft.Json;

namespace AspireTemplate.Tests
{
    public class APITests
    {
        
        [Fact]
        public async Task GetAPIResourceRootReturnsOkStatusCode()
        {
            var appHost = await DistributedApplicationTestingBuilder
                .CreateAsync<Projects.AspireTemplate_AppHost>();
        
            appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler();
            });
            await using var app = await appHost.BuildAsync();
            var resourceNotificationService = app.Services
                .GetRequiredService<ResourceNotificationService>();

            await app.StartAsync();
            
            // Act
            var httpClient = app.CreateHttpClient("apiservice");

            await resourceNotificationService.WaitForResourceAsync(
                    "apiservice",
                    KnownResourceStates.Running
                )
                .WaitAsync(TimeSpan.FromSeconds(30));
          
            // Assert
            var response = await httpClient.GetAsync("/");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task Person_Post_ReturnPerson()
        {
            var person = new Person()
            {
                Name = "John Doe",
                Age = 30
            };
            
            
            var appHost = await DistributedApplicationTestingBuilder
                .CreateAsync<Projects.AspireTemplate_AppHost>();
        
            appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler();
            });
            await using var app = await appHost.BuildAsync();
            var resourceNotificationService = app.Services
                .GetRequiredService<ResourceNotificationService>();

            await app.StartAsync();
            
            // Act
            var httpClient = app.CreateHttpClient("apiservice");

            await resourceNotificationService.WaitForResourceAsync(
                    "apiservice",
                    KnownResourceStates.Running
                )
                .WaitAsync(TimeSpan.FromSeconds(30));
          
            // Assert
            var response = await httpClient.PostAsync("/people", new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var returnPerson = JsonConvert.DeserializeObject<Person>(await response.Content.ReadAsStringAsync());
            Assert.Equal(person.Name, returnPerson.Name);
            Assert.Equal(person.Age, returnPerson.Age);
        }

        [Fact]
        public async Task Person_GetById_NotFound()
        {
            var appHost = await DistributedApplicationTestingBuilder
                .CreateAsync<Projects.AspireTemplate_AppHost>();
        
            appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
            {
                clientBuilder.AddStandardResilienceHandler();
            });
            await using var app = await appHost.BuildAsync();
            var resourceNotificationService = app.Services
                .GetRequiredService<ResourceNotificationService>();

            await app.StartAsync();
            
            // Act
            var httpClient = app.CreateHttpClient("apiservice");

            await resourceNotificationService.WaitForResourceAsync(
                    "apiservice",
                    KnownResourceStates.Running
                )
                .WaitAsync(TimeSpan.FromSeconds(30));
          
            // Assert
            var response = await httpClient.GetAsync("/people/1000");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
    }
    
}