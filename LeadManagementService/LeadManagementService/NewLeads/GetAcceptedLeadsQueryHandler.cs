using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementService.NewLeads
{
    public class GetAcceptedLeadsQueryHandler
    {
        private readonly LeadsRepository _leadsRepository;
        
        public GetAcceptedLeadsQueryHandler(LeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task<GetAcceptedLeadsQueryResponse> Handle(GetAcceptedLeadsQuery getAcceptedLeadsQuery)
        {
            var getAcceptedLeadQueryResponses = await _leadsRepository.GetAcceptedLeads();
            
            var acceptedLeadsQueryResponse = new GetAcceptedLeadsQueryResponse
            {
                Leads = getAcceptedLeadQueryResponses.ToList()
            };

            return acceptedLeadsQueryResponse;
        }
    }
}