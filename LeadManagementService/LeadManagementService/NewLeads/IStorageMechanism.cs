using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeadManagementService.NewLeads
{
    public interface IStorageMechanism
    {
        Task<IEnumerable<LeadDocument>> GetLeadDocuments();
        Task<LeadDocument> GetLeadDocument(int jobId);
        Task SaveLeadDocument(LeadDocument lead);
    }
}