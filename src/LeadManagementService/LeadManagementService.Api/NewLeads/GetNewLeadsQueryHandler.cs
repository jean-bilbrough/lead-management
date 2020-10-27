using System.Linq;
using System.Threading.Tasks;
using LeadManagementService.Interfaces.Data;

namespace LeadManagementService.NewLeads
{
    public class GetNewLeadsQueryHandler
    {
        private readonly ILeadsRepository _leadsRepository;

        public GetNewLeadsQueryHandler(ILeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }
        
        public async Task<GetNewLeadsQueryResponse> Handle(GetNewLeadsQuery query)
        {
            var getNewLeadQueryResponses = await _leadsRepository.GetNewLeads();
            
            var newLeadsQueryResponse = new GetNewLeadsQueryResponse
            {
                Leads = getNewLeadQueryResponses.ToList()
            };

            return newLeadsQueryResponse;
        }
    }
}