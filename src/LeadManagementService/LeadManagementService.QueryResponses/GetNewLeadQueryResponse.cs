using LeadManagementService.Domain;

namespace LeadManagementService.Queries
{
    public class GetNewLeadQueryResponse
    {
        public string ContactFirstName { get; set; }
        public string DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public int JobId { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public static GetNewLeadQueryResponse FromLead(Lead lead)
        {
            var getNewLeadQueryResponse = new GetNewLeadQueryResponse
            {
                ContactFirstName = lead.ContactFirstName,
                DateCreated = $"{lead.DateCreated:MMMM d} @ {lead.DateCreated.ToString("h:mm tt").ToLower()}",
                Suburb = lead.Suburb,
                Category = lead.Category,
                JobId = lead.JobId,
                Description = lead.Description,
                Price = $"${lead.LeadPrice:0.00} Lead Invitation"
            };

            return getNewLeadQueryResponse;
        }
    }
}