using System.Threading.Tasks;
using LeadManagementService.Interfaces.Data;

namespace LeadManagementService.NewLeads
{
    public class DeclineLeadCommandHandler
    {
        private readonly ILeadsRepository _leadsRepository;

        public DeclineLeadCommandHandler(ILeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task Handle(DeclineLeadCommand declineLeadCommand)
        {
            var leadDocument = await _leadsRepository.GetLeadDocument(declineLeadCommand.JobId);

            leadDocument.Lead.Decline();

            await _leadsRepository.Save(leadDocument);
        }
    }
}