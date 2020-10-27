using System.Linq;
using System.Threading.Tasks;
using LeadManagementService.Interfaces.Data;

namespace LeadManagementService.AcceptedLeads
{
    public class GetAcceptedLeadsQueryHandler
    {
        private readonly ILeadsRepository _leadsRepository;
        
        public GetAcceptedLeadsQueryHandler(ILeadsRepository leadsRepository)
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