using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementService.NewLeads
{
    public class GetNewLeadsQueryHandler
    {
        private readonly LeadsRepository _leadsRepository;

        public GetNewLeadsQueryHandler(LeadsRepository leadsRepository)
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