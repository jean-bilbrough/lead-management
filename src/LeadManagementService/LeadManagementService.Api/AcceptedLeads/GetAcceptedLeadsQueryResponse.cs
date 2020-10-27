using System.Collections.Generic;
using LeadManagementService.Queries;

namespace LeadManagementService.AcceptedLeads
{
    public class GetAcceptedLeadsQueryResponse
    {
        public string Id => "acceptedleads";
        public List<GetAcceptedLeadQueryResponse> Leads { get; set; }
    }
}