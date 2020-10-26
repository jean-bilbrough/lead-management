using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementService.NewLeads
{
    public class LeadsRepository
    {
        private readonly IStorageMechanism _storageMechanism;

        public LeadsRepository(IStorageMechanism storageMechanism)
        {
            _storageMechanism = storageMechanism;
        }

        public async Task<IEnumerable<GetNewLeadQueryResponse>> GetNewLeads()
        {
            var results = await _storageMechanism.GetLeadDocuments();
            var leads = new List<GetNewLeadQueryResponse>();
            foreach (var result in results.Where(r => r.Lead.Status == LeadStatus.New))
            {
                leads.Add(GetNewLeadQueryResponse.FromLead(result.Lead));
            }

            return leads;
        }

        public async Task<LeadDocument> GetLeadDocument(int jobId)
        {
            return await _storageMechanism.GetLeadDocument(jobId);
        }

        public async Task Save(LeadDocument leadDocument)
        {
            await _storageMechanism.SaveLeadDocument(leadDocument);
        }
    }
}