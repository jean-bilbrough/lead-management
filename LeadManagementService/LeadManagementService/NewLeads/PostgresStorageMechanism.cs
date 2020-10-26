using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LeadManagementService.NewLeads
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
            // try
            // {
            //     var lead = new Lead
            //     {
            //         ContactFirstName = "Bill",
            //         DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
            //         Suburb = "Yanderra 2574",
            //         Category = "Painters",
            //         JobId = 5577421,
            //         Description = "Need to paint 2 aluminium windows and a sliding glass door",
            //         Price = 62
            //     };
            //     var leadDocument = new LeadDocument
            //     {
            //         Lead = lead
            //     };
            //     _dbContext.LeadDocuments.Add(leadDocument);
            //     await _dbContext.SaveChangesAsync();
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
            
            
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