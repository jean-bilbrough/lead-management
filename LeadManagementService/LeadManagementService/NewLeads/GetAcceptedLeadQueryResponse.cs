namespace LeadManagementService.NewLeads
{
    public class GetAcceptedLeadQueryResponse
    {
        public string ContactFullName { get; set; }
        public string DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public int JobId { get; set; }
        public string Price { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Description { get; set; }

        public static GetAcceptedLeadQueryResponse FromLead(Lead lead)
        {
            var getAcceptedLeadQueryResponse = new GetAcceptedLeadQueryResponse
            {
                ContactFullName = $"{lead.ContactFirstName} {lead.ContactLastName}",
                DateCreated = $"{lead.DateCreated:MMMM d} @ {lead.DateCreated.ToString("h:mm tt").ToLower()}",
                Suburb = lead.Suburb,
                Category = lead.Category,
                JobId = lead.JobId,
                Price = $"${lead.AcceptedPrice:F} Lead Invitation",
                ContactPhoneNumber = lead.ContactPhoneNumber,
                ContactEmail= lead.ContactEmail,
                Description = lead.Description
            };

            return getAcceptedLeadQueryResponse;
        }
    }
}