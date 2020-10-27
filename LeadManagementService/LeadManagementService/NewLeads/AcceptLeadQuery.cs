namespace LeadManagementService.NewLeads
{
    public class AcceptLeadQuery
    {
        public int JobId { get; }

        public AcceptLeadQuery(int jobId)
        {
            JobId = jobId;
        }
    }
}