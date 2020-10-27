using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeadManagementService.Domain;
using Microsoft.EntityFrameworkCore;

namespace LeadManagementService.Data
{
    public class PostgresStorageMechanism : IStorageMechanism
    {
        private readonly LeadDbContext _dbContext;

        public PostgresStorageMechanism(LeadDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<LeadDocument>> GetLeadDocuments()
        {
            return await _dbContext.LeadDocuments.ToListAsync();
        }

        public async Task<LeadDocument> GetLeadDocument(int jobId)
        {
            return await _dbContext.LeadDocuments.FirstOrDefaultAsync(l => l.Lead.JobId == jobId);
        }

        public async Task SaveLeadDocument(LeadDocument leadDocument)
        { 
            _dbContext.LeadDocuments.Update(leadDocument);
            await _dbContext.SaveChangesAsync();
        }
    }
}