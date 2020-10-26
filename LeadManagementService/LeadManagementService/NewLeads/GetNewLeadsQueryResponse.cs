using System.Collections.Generic;

namespace LeadManagementService.NewLeads
{
    public class GetNewLeadsQueryResponse
    {
        public string Id => "newleads";
        public List<GetNewLeadQueryResponse> Leads { get; set; }
    }
}