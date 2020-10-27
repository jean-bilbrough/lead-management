using System;
using FluentAssertions;
using LeadManagementService.Domain;
using LeadManagementService.NewLeads;
using Xunit;

namespace LeadManagementServiceTests
{
    public class LeadTests
    {
        [Fact]
        public void Accept_Should_Set_Status_To_Accepted()
        {
            var lead = new Lead
            {
                ContactFirstName = "Craig",
                ContactLastName = "Barry",
                ContactPhoneNumber = "0411444555",
                ContactEmail = "craig@anotherorg.com",
                DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                Suburb = "Woolooware 2230",
                Category = "Interior Painters",
                JobId = 5588872,
                Description = "interior walls 3 colours",
                LeadPrice = 50,
                Status = LeadStatus.New
            };
            
            lead.Accept();

            lead.Status.Should().Be(LeadStatus.Accepted);
        }
        
        [Fact]
        public void Accept_Should_Set_AcceptedPrice_To_LeadPrice_When_Less_Than_500()
        {
            var lead = new Lead
            {
                ContactFirstName = "Craig",
                ContactLastName = "Barry",
                ContactPhoneNumber = "0411444555",
                ContactEmail = "craig@anotherorg.com",
                DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                Suburb = "Woolooware 2230",
                Category = "Interior Painters",
                JobId = 5588872,
                Description = "interior walls 3 colours",
                LeadPrice = 50,
                Status = LeadStatus.New
            };
            
            lead.Accept();

            lead.AcceptedPrice.Should().Be(50);
        }
        
        [Fact]
        public void Accept_Should_Set_AcceptedPrice_To_LeadPrice_When_Equals_500()
        {
            var lead = new Lead
            {
                ContactFirstName = "Craig",
                ContactLastName = "Barry",
                ContactPhoneNumber = "0411444555",
                ContactEmail = "craig@anotherorg.com",
                DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                Suburb = "Woolooware 2230",
                Category = "Interior Painters",
                JobId = 5588872,
                Description = "interior walls 3 colours",
                LeadPrice = 500,
                Status = LeadStatus.New
            };
            
            lead.Accept();

            lead.AcceptedPrice.Should().Be(500);
        }
        
        [Fact]
        public void Accept_Should_Set_AcceptedPrice_To_LeadPrice_Less_10_Percent_When_Greater_Than_500()
        {
            var lead = new Lead
            {
                ContactFirstName = "Craig",
                ContactLastName = "Barry",
                ContactPhoneNumber = "0411444555",
                ContactEmail = "craig@anotherorg.com",
                DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                Suburb = "Woolooware 2230",
                Category = "Interior Painters",
                JobId = 5588872,
                Description = "interior walls 3 colours",
                LeadPrice = 501,
                Status = LeadStatus.New
            };
            
            lead.Accept();

            lead.AcceptedPrice.Should().Be(450.9M);
        }
        
        [Fact]
        public void Decline_Should_Set_Status_To_Declined()
        {
            var lead = new Lead
            {
                ContactFirstName = "Craig",
                ContactLastName = "Barry",
                ContactPhoneNumber = "0411444555",
                ContactEmail = "craig@anotherorg.com",
                DateCreated = new DateTime(2020, 1, 4, 13, 15, 0),
                Suburb = "Woolooware 2230",
                Category = "Interior Painters",
                JobId = 5588872,
                Description = "interior walls 3 colours",
                LeadPrice = 50,
                Status = LeadStatus.New
            };
            
            lead.Decline();

            lead.Status.Should().Be(LeadStatus.Declined);
        }
    }
}