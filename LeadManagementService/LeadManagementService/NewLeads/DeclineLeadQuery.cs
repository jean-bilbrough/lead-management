namespace LeadManagementService.NewLeads
{
    public class DeclineLeadQuery
    {
        public int JobId { get; }

        public DeclineLeadQuery(int jobId)
        {
            JobId = jobId;
        }
    }
}