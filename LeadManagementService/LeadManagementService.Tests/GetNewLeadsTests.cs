using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using LeadManagementService.Data;
using LeadManagementService.Domain;
using LeadManagementService.NewLeads;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace LeadManagementServiceTests
{
    public class GetNewLeadsTests
    {
        [Fact(Skip="local test server not working correctly yet")]
        public async Task Get_New_Leads_Should_Be_Successful()
        {
            using var testServer = LocalTestServer.CreateTestServer(services => { });
            var httpClient = testServer.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            
            var response = await httpClient.SendAsync(request);
            
            Assert.True(response.IsSuccessStatusCode);
        }
        
        [Fact]
        public async Task Get_New_Leads_Should_Return_New_Leads()
        {
            const string expectedJson = 
                "{" + 
                "\"id\":\"newleads\"," +
                "\"leads\":[{" +
                "\"contactFirstName\":\"Bill\"," +
                "\"dateCreated\":\"January 4 @ 2:37 pm\"," +
                "\"suburb\":\"Yanderra 2574\"," +
                "\"category\":\"Painters\"," +
                "\"jobId\":5577421," +
                "\"description\":\"Need to paint 2 aluminium windows and a sliding glass door\"," +
                "\"price\":\"$62.00 Lead Invitation\"" +
                "},{" +
                "\"contactFirstName\":\"Craig\"," +
                "\"dateCreated\":\"January 4 @ 1:15 pm\"," +
                "\"suburb\":\"Woolooware 2230\"," +
                "\"category\":\"Interior Painters\"," +
                "\"jobId\":5588872," +
                "\"description\":\"interior walls 3 colours\"," +
                "\"price\":\"$49.00 Lead Invitation\"" +
                "}]" +
                "}";
            
            var storage = new InMemoryStorageMechanism();
            storage.Add(new List<LeadDocument>
            {
                new LeadDocument
                {
                    Id = 1,
                    Lead = new Lead
                    {
                        ContactFirstName = "Bill",
                        DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
                        Suburb = "Yanderra 2574",
                        Category = "Painters",
                        JobId = 5577421,
                        Description = "Need to paint 2 aluminium windows and a sliding glass door",
                        LeadPrice = 62,
                        Status = LeadStatus.New
                    }},
                new LeadDocument
                {
                    Id = 2,
                    Lead = new Lead{
                        ContactFirstName = "Craig",
                        DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                        Suburb = "Woolooware 2230",
                        Category = "Interior Painters",
                        JobId = 5588872,
                        Description = "interior walls 3 colours",
                        LeadPrice = 49,
                        Status = LeadStatus.New
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            var result = await controller.GetNewLeads();

            result.Should().NotBeNull();
            result.GetType().Should().Be(typeof(OkObjectResult));
            ((OkObjectResult) result).StatusCode.Should().Be(200);
            JsonConvert.SerializeObject(((OkObjectResult) result).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(expectedJson);
        }
        
        [Fact]
        public async Task Get_New_Leads_Should_Not_Return_Accepted_Leads()
        {
            const string expectedJson = 
                "{" + 
                "\"id\":\"newleads\"," +
                "\"leads\":[{" +
                "\"contactFirstName\":\"Bill\"," +
                "\"dateCreated\":\"January 4 @ 2:37 pm\"," +
                "\"suburb\":\"Yanderra 2574\"," +
                "\"category\":\"Painters\"," +
                "\"jobId\":5577421," +
                "\"description\":\"Need to paint 2 aluminium windows and a sliding glass door\"," +
                "\"price\":\"$62.00 Lead Invitation\"" +
                "}]" +
                "}";
            
            var storage = new InMemoryStorageMechanism();
            storage.Add(new List<LeadDocument>
            {
                new LeadDocument
                {
                    Id = 1,
                    Lead = new Lead
                    {
                        ContactFirstName = "Bill",
                        DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
                        Suburb = "Yanderra 2574",
                        Category = "Painters",
                        JobId = 5577421,
                        Description = "Need to paint 2 aluminium windows and a sliding glass door",
                        LeadPrice = 62,
                        Status = LeadStatus.New
                    }},
                new LeadDocument
                {
                    Id = 2,
                    Lead = new Lead{
                        ContactFirstName = "Craig",
                        DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                        Suburb = "Woolooware 2230",
                        Category = "Interior Painters",
                        JobId = 5588872,
                        Description = "interior walls 3 colours",
                        LeadPrice = 49,
                        Status = LeadStatus.Accepted
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            var result = await controller.GetNewLeads();

            result.Should().NotBeNull();
            result.GetType().Should().Be(typeof(OkObjectResult));
            ((OkObjectResult) result).StatusCode.Should().Be(200);
            JsonConvert.SerializeObject(((OkObjectResult) result).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(expectedJson);
        }
        
        [Fact]
        public async Task Get_New_Leads_Should_Not_Return_Declined_Leads()
        {
            const string expectedJson = 
                "{" + 
                "\"id\":\"newleads\"," +
                "\"leads\":[{" +
                "\"contactFirstName\":\"Craig\"," +
                "\"dateCreated\":\"January 4 @ 1:15 pm\"," +
                "\"suburb\":\"Woolooware 2230\"," +
                "\"category\":\"Interior Painters\"," +
                "\"jobId\":5588872," +
                "\"description\":\"interior walls 3 colours\"," +
                "\"price\":\"$49.00 Lead Invitation\"" +
                "}]" +
                "}";
            
            var storage = new InMemoryStorageMechanism();
            storage.Add(new List<LeadDocument>
            {
                new LeadDocument
                {
                    Id = 1,
                    Lead = new Lead
                    {
                        ContactFirstName = "Bill",
                        DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
                        Suburb = "Yanderra 2574",
                        Category = "Painters",
                        JobId = 5577421,
                        Description = "Need to paint 2 aluminium windows and a sliding glass door",
                        LeadPrice = 62,
                        Status = LeadStatus.Declined
                    }},
                new LeadDocument
                {
                    Id = 2,
                    Lead = new Lead{
                        ContactFirstName = "Craig",
                        DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                        Suburb = "Woolooware 2230",
                        Category = "Interior Painters",
                        JobId = 5588872,
                        Description = "interior walls 3 colours",
                        LeadPrice = 49,
                        Status = LeadStatus.New
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            var result = await controller.GetNewLeads();

            result.Should().NotBeNull();
            result.GetType().Should().Be(typeof(OkObjectResult));
            ((OkObjectResult) result).StatusCode.Should().Be(200);
            JsonConvert.SerializeObject(((OkObjectResult) result).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(expectedJson);
        }
    }
}