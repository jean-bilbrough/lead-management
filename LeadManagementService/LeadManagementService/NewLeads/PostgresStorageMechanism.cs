using System;
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
            // await InsertData();
            
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

        private async Task InsertData()
        {
            try
            {
                var lead = new Lead
                {
                    ContactFirstName = "Bill",
                    ContactLastName = "Craig",
                    ContactPhoneNumber = "0411222333",
                    ContactEmail = "craig.barry@theorg.com",
                    DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
                    Suburb = "Yanderra 2574",
                    Category = "Painters",
                    JobId = 0,
                    Description = "Need to paint 2 aluminium windows and a sliding glass door",
                    LeadPrice = 62
                };
                var leadDocument = new LeadDocument
                {
                    Lead = lead
                };
                _dbContext.LeadDocuments.Add(leadDocument);
                await _dbContext.SaveChangesAsync();
                leadDocument.Lead.JobId = leadDocument.Id;
                _dbContext.Update(leadDocument);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}