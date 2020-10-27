using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManagementService.Domain;

namespace LeadManagementService.Data
{
    public interface IStorageMechanism
    {
        Task<IEnumerable<LeadDocument>> GetLeadDocuments();
        Task<LeadDocument> GetLeadDocument(int jobId);
        Task SaveLeadDocument(LeadDocument lead);
    }
}