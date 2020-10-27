using System.Threading.Tasks;

namespace LeadManagementService.NewLeads
{
    public class AcceptLeadQueryHandler
    {
        private readonly LeadsRepository _leadsRepository;

        public AcceptLeadQueryHandler(LeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task Handle(AcceptLeadQuery acceptLeadQuery)
        {
            var leadDocument = await _leadsRepository.GetLeadDocument(acceptLeadQuery.JobId);

            leadDocument.Lead.Accept();

            await _leadsRepository.Save(leadDocument);
        }
    }
}