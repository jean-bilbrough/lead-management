using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using LeadManagementService.NewLeads;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace LeadManagementServiceTests
{
    public class GetAcceptedLeadsTests
    {
        [Fact]
        public async Task Get_Accepted_Leads_Should_Return_Accepted_Leads()
        {
            const string expectedJson = 
                "{" + 
                "\"id\":\"acceptedleads\"," +
                "\"leads\":[{" +
                "\"contactFullName\":\"Bill Hunter\"," +
                "\"dateCreated\":\"January 4 @ 2:37 pm\"," +
                "\"suburb\":\"Yanderra 2574\"," +
                "\"category\":\"Painters\"," +
                "\"jobId\":5577421," +
                "\"price\":\"$62.00 Lead Invitation\"," +
                "\"contactPhoneNumber\":\"0411222333\"," +
                "\"contactEmail\":\"bill@myorg.com\"," +
                "\"description\":\"Need to paint 2 aluminium windows and a sliding glass door\"" +
                "},{" +
                "\"contactFullName\":\"Craig Barry\"," +
                "\"dateCreated\":\"January 4 @ 1:15 pm\"," +
                "\"suburb\":\"Woolooware 2230\"," +
                "\"category\":\"Interior Painters\"," +
                "\"jobId\":5588872," +
                "\"price\":\"$49.00 Lead Invitation\"," +
                "\"contactPhoneNumber\":\"0411444555\"," +
                "\"contactEmail\":\"craig@anotherorg.com\"," +
                "\"description\":\"interior walls 3 colours\"" +
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
                        ContactLastName = "Hunter",
                        ContactPhoneNumber = "0411222333",
                        ContactEmail = "bill@myorg.com",
                        DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
                        Suburb = "Yanderra 2574",
                        Category = "Painters",
                        JobId = 5577421,
                        Description = "Need to paint 2 aluminium windows and a sliding glass door",
                        LeadPrice = 62,
                        AcceptedPrice = 62,
                        Status = LeadStatus.Accepted
                    }},
                new LeadDocument
                {
                    Id = 2,
                    Lead = new Lead{
                        ContactFirstName = "Craig",
                        ContactLastName = "Barry",
                        ContactPhoneNumber = "0411444555",
                        ContactEmail = "craig@anotherorg.com",
                        DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                        Suburb = "Woolooware 2230",
                        Category = "Interior Painters",
                        JobId = 5588872,
                        Description = "interior walls 3 colours",
                        LeadPrice = 49,
                        AcceptedPrice = 49,
                        Status = LeadStatus.Accepted
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            var result = await controller.GetAcceptedLeads();

            result.Should().NotBeNull();
            result.GetType().Should().Be(typeof(OkObjectResult));
            ((OkObjectResult) result).StatusCode.Should().Be(200);
            JsonConvert.SerializeObject(((OkObjectResult) result).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(expectedJson);
        }
        
        [Fact]
        public async Task Get_Accepted_Leads_Should_Not_Return_New_Leads()
        {
            const string expectedJson = 
                "{" + 
                "\"id\":\"acceptedleads\"," +
                "\"leads\":[{" +
                "\"contactFullName\":\"Bill Hunter\"," +
                "\"dateCreated\":\"January 4 @ 2:37 pm\"," +
                "\"suburb\":\"Yanderra 2574\"," +
                "\"category\":\"Painters\"," +
                "\"jobId\":5577421," +
                "\"price\":\"$62.00 Lead Invitation\"," +
                "\"contactPhoneNumber\":\"0411222333\"," +
                "\"contactEmail\":\"bill@myorg.com\"," +
                "\"description\":\"Need to paint 2 aluminium windows and a sliding glass door\"" +
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
                        ContactLastName = "Hunter",
                        ContactPhoneNumber = "0411222333",
                        ContactEmail = "bill@myorg.com",
                        DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
                        Suburb = "Yanderra 2574",
                        Category = "Painters",
                        JobId = 5577421,
                        Description = "Need to paint 2 aluminium windows and a sliding glass door",
                        LeadPrice = 62,
                        AcceptedPrice = 62,
                        Status = LeadStatus.Accepted
                    }},
                new LeadDocument
                {
                    Id = 2,
                    Lead = new Lead{
                        ContactFirstName = "Craig",
                        ContactLastName = "Barry",
                        ContactPhoneNumber = "0411444555",
                        ContactEmail = "craig@anotherorg.com",
                        DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                        Suburb = "Woolooware 2230",
                        Category = "Interior Painters",
                        JobId = 5588872,
                        Description = "interior walls 3 colours",
                        LeadPrice = 49,
                        Status = LeadStatus.New
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            var result = await controller.GetAcceptedLeads();

            result.Should().NotBeNull();
            result.GetType().Should().Be(typeof(OkObjectResult));
            ((OkObjectResult) result).StatusCode.Should().Be(200);
            JsonConvert.SerializeObject(((OkObjectResult) result).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(expectedJson);
        }
        
        [Fact]
        public async Task Get_Accepted_Leads_Should_Not_Return_Declined_Leads()
        {
            const string expectedJson = 
                "{" + 
                "\"id\":\"acceptedleads\"," +
                "\"leads\":[{" +
                "\"contactFullName\":\"Craig Barry\"," +
                "\"dateCreated\":\"January 4 @ 1:15 pm\"," +
                "\"suburb\":\"Woolooware 2230\"," +
                "\"category\":\"Interior Painters\"," +
                "\"jobId\":5588872," +
                "\"price\":\"$49.00 Lead Invitation\"," +
                "\"contactPhoneNumber\":\"0411444555\"," +
                "\"contactEmail\":\"craig@anotherorg.com\"," +
                "\"description\":\"interior walls 3 colours\"" +
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
                        ContactLastName = "Hunter",
                        ContactPhoneNumber = "0411222333",
                        ContactEmail = "bill@myorg.com",
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
                        ContactLastName = "Barry",
                        ContactPhoneNumber = "0411444555",
                        ContactEmail = "craig@anotherorg.com",
                        DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                        Suburb = "Woolooware 2230",
                        Category = "Interior Painters",
                        JobId = 5588872,
                        Description = "interior walls 3 colours",
                        LeadPrice = 49,
                        AcceptedPrice = 49,
                        Status = LeadStatus.Accepted
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            var result = await controller.GetAcceptedLeads();

            result.Should().NotBeNull();
            result.GetType().Should().Be(typeof(OkObjectResult));
            ((OkObjectResult) result).StatusCode.Should().Be(200);
            JsonConvert.SerializeObject(((OkObjectResult) result).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(expectedJson);
        }
        
        [Fact]
        public async Task Get_Accepted_Leads_Should_Display_Accepted_Price()
        {
            const string expectedJson = 
                "{" + 
                "\"id\":\"acceptedleads\"," +
                "\"leads\":[{" +
                "\"contactFullName\":\"Craig Barry\"," +
                "\"dateCreated\":\"January 4 @ 1:15 pm\"," +
                "\"suburb\":\"Woolooware 2230\"," +
                "\"category\":\"Interior Painters\"," +
                "\"jobId\":5588872," +
                "\"price\":\"$495.00 Lead Invitation\"," +
                "\"contactPhoneNumber\":\"0411444555\"," +
                "\"contactEmail\":\"craig@anotherorg.com\"," +
                "\"description\":\"interior walls 3 colours\"" +
                "}]" +
                "}";
            
            var storage = new InMemoryStorageMechanism();
            storage.Add(new List<LeadDocument>
            {
                new LeadDocument
                {
                    Id = 2,
                    Lead = new Lead{
                        ContactFirstName = "Craig",
                        ContactLastName = "Barry",
                        ContactPhoneNumber = "0411444555",
                        ContactEmail = "craig@anotherorg.com",
                        DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                        Suburb = "Woolooware 2230",
                        Category = "Interior Painters",
                        JobId = 5588872,
                        Description = "interior walls 3 colours",
                        LeadPrice = 550,
                        Status = LeadStatus.New
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            await controller.AcceptLead(5588872);

            var result = await controller.GetAcceptedLeads();

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