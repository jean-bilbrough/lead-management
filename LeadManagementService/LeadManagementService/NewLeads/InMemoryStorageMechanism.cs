using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagementService.NewLeads
{
    public class InMemoryStorageMechanism : IStorageMechanism
    {
        private readonly List<LeadDocument> _leadDocuments;

        public InMemoryStorageMechanism()
        {
            _leadDocuments = new List<LeadDocument>();
        }

        public void Add(IEnumerable<LeadDocument> leadDocuments)
        {
            _leadDocuments.AddRange(leadDocuments);
        }
        
        public async Task<IEnumerable<LeadDocument>> GetLeadDocuments()
        {
            return await Task.FromResult(_leadDocuments);
        }

        public async Task<LeadDocument> GetLeadDocument(int jobId)
        {
            return await Task.FromResult(_leadDocuments.FirstOrDefault(l => l.Lead.JobId == jobId));
        }
        
        public Task SaveLeadDocument(LeadDocument leadDocument)
        { 
            // in-memory, changes are automatically saved
            return Task.CompletedTask;
        }
    }
}