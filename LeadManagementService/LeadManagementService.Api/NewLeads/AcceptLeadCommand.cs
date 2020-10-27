namespace LeadManagementService.NewLeads
{
    public class AcceptLeadCommand
    {
        public int JobId { get; }

        public AcceptLeadCommand(int jobId)
        {
            JobId = jobId;
        }
    }
}