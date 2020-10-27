using System.Collections.Generic;
using LeadManagementService.Queries;

namespace LeadManagementService.NewLeads
{
    public class GetNewLeadsQueryResponse
    {
        public string Id => "newleads";
        public List<GetNewLeadQueryResponse> Leads { get; set; }
    }
}