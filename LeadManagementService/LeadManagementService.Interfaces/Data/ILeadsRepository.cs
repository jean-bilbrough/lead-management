using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManagementService.Domain;
using LeadManagementService.Queries;

namespace LeadManagementService.Interfaces.Data
{
    public interface ILeadsRepository
    {
        Task<IEnumerable<GetNewLeadQueryResponse>> GetNewLeads();
        Task<LeadDocument> GetLeadDocument(int jobId);
        Task Save(LeadDocument leadDocument);
        Task<IEnumerable<GetAcceptedLeadQueryResponse>> GetAcceptedLeads();
    }
}