using System;
using System.Linq;
using LeadManagementService.Domain;

namespace LeadManagementService.Data
{
    public class LeadDocumentSeeder
    {
        private readonly LeadDbContext _dbContext;

        public LeadDocumentSeeder(LeadDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            try
            {
                var leads = _dbContext.LeadDocuments.ToList();

                if (!leads.Exists(l => l.Lead.JobId == 5577421))
                {
                    _dbContext.LeadDocuments.Add(new LeadDocument
                    {
                        Lead = new Lead
                        {
                            ContactFirstName = "Bill",
                            ContactLastName = "Craig",
                            ContactPhoneNumber = "0411222333",
                            ContactEmail = "craig.barry@theorg.com",
                            DateCreated = new DateTime(2020, 1, 4, 14, 37, 0),
                            Suburb = "Yanderra 2574",
                            Category = "Painters",
                            JobId = 5577421,
                            Description = "Need to paint 2 aluminium windows and a sliding glass door",
                            LeadPrice = 62
                        }
                    });
                }

                if (!leads.Exists(l => l.Lead.JobId == 5588872))
                {
                    _dbContext.LeadDocuments.Add(new LeadDocument
                    {
                        Lead = new Lead
                        {
                            ContactFirstName = "Don",
                            ContactLastName = "Bayley",
                            ContactPhoneNumber = "0411333444",
                            ContactEmail = "don@another.com",
                            DateCreated = new DateTime(2020, 1, 4, 8, 15, 0),
                            Suburb = "Woolooware 2230",
                            Category = "Interior Painters",
                            JobId = 5588872,
                            Description = "interior walls 3 colours",
                            LeadPrice = 550
                        }
                    });
                }

                if (!leads.Exists(l => l.Lead.JobId == 5567834))
                {
                    _dbContext.LeadDocuments.Add(new LeadDocument
                    {
                        Lead = new Lead
                        {
                            ContactFirstName = "Jane",
                            ContactLastName = "Smith",
                            ContactPhoneNumber = "0422555666",
                            ContactEmail = "janesmith@theheights.com",
                            DateCreated = new DateTime(2020, 1, 4, 13, 47, 0),
                            Suburb = "Sydney 2000",
                            Category = "External Painters",
                            JobId = 5567834,
                            Description = "whole two storey house",
                            LeadPrice = 1400
                        }
                    });
                }

                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}