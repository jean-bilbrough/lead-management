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
    public class DeclineLeadTests
    {
        [Fact]
        public async Task Decline_Lead_Should_Return_Ok()
        {
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
                    }}});
            
            var controller = new NewLeadsController(new LeadsRepository(storage));

            var declineResponse = await controller.DeclineLead(5577421);

            declineResponse.Should().NotBeNull();
            declineResponse.GetType().Should().Be(typeof(OkResult));
        }
        
        [Fact]
        public async Task Decline_Lead_Should_Remove_Lead_From_New_Leads()
        {
            const string initialExpectedJson = 
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
            
            const string expectedJsonAfterAccept = 
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

            var initialNewLeads = await controller.GetNewLeads();
            var declineResponse = await controller.DeclineLead(5577421);
            var newLeadsAfterDecline = await controller.GetNewLeads();

            initialNewLeads.Should().NotBeNull();
            initialNewLeads.GetType().Should().Be(typeof(OkObjectResult));
            JsonConvert.SerializeObject(((OkObjectResult) initialNewLeads).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(initialExpectedJson);
            
            declineResponse.Should().NotBeNull();
            declineResponse.GetType().Should().Be(typeof(OkResult));
            
            newLeadsAfterDecline.Should().NotBeNull();
            newLeadsAfterDecline.GetType().Should().Be(typeof(OkObjectResult));
            JsonConvert.SerializeObject(((OkObjectResult) newLeadsAfterDecline).Value, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver{ NamingStrategy = new CamelCaseNamingStrategy() },
            }).Should().Be(expectedJsonAfterAccept);
        }
    }
}