namespace LeadManagementService.NewLeads
{
    public class DeclineLeadCommand
    {
        public int JobId { get; }

        public DeclineLeadCommand(int jobId)
        {
            JobId = jobId;
        }
    }
}