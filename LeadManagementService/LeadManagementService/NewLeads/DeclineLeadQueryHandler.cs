using System.Threading.Tasks;

namespace LeadManagementService.NewLeads
{
    public class DeclineLeadQueryHandler
    {
        private readonly LeadsRepository _leadsRepository;

        public DeclineLeadQueryHandler(LeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task Handle(DeclineLeadQuery declineLeadQuery)
        {
            var leadDocument = await _leadsRepository.GetLeadDocument(declineLeadQuery.JobId);

            leadDocument.Lead.Decline();

            await _leadsRepository.Save(leadDocument);
        }
    }
}