using System.Threading.Tasks;
using LeadManagementService.Interfaces.Data;

namespace LeadManagementService.NewLeads
{
    public class AcceptLeadCommandHandler
    {
        private readonly ILeadsRepository _leadsRepository;

        public AcceptLeadCommandHandler(ILeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task Handle(AcceptLeadCommand acceptLeadCommand)
        {
            var leadDocument = await _leadsRepository.GetLeadDocument(acceptLeadCommand.JobId);

            leadDocument.Lead.Accept();

            await _leadsRepository.Save(leadDocument);
        }
    }
}