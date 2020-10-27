using System;

namespace LeadManagementService.NewLeads
{
    public class Lead
    {
        private const decimal DiscountThreshold = 500;
        private const decimal DiscountPercent = (decimal) 0.1;
        
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public DateTime DateCreated { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public int JobId { get; set; }
        public string Description { get; set; }
        public decimal LeadPrice { get; set; }
        public LeadStatus Status { get; set;  }
        public decimal AcceptedPrice { get; set; }
        
        public void Accept()
        {
            Status = LeadStatus.Accepted;
            AcceptedPrice = LeadPrice > DiscountThreshold 
                ? Math.Round(LeadPrice - LeadPrice * DiscountPercent, 2, MidpointRounding.ToZero)
                : LeadPrice;
            // todo: raise LeadAcceptedEvent
        }

        public void Decline()
        {
            Status = LeadStatus.Declined;
        }
    }
}