using System.Collections.Generic;

namespace LeadManagementService.NewLeads
{
    public class GetAcceptedLeadsQueryResponse
    {
        public string Id => "acceptedleads";
        public List<GetAcceptedLeadQueryResponse> Leads { get; set; }
    }
}