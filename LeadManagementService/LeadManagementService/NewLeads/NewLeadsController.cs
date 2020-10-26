using System.Net;
using System.Threading.Tasks;
using LeadManagementService.NewLeads;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagementService.NewLeads
{
    [EnableCors("PublicPolicy")]
    [Route("/")]
    public class NewLeadsController : ControllerBase
    {
        private readonly LeadsRepository _leadsRepository;

        public NewLeadsController(LeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(GetNewLeadsQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetNewLeads()
        {
            var getNewLeadsQuery = new GetNewLeadsQuery();
            var getNewLeadsQueryHandler = new GetNewLeadsQueryHandler(_leadsRepository);
            var getNewLeadsQueryResponse = await getNewLeadsQueryHandler.Handle(getNewLeadsQuery);

            return Ok(getNewLeadsQueryResponse);
        }

        [HttpPut]
        [Route("/accept")]
        public async Task<IActionResult> AcceptLead([FromQuery(Name = "jobid")] int jobId)
        {
            var acceptLeadQuery = new AcceptLeadQuery(jobId);
            var acceptLeadQueryHandler = new AcceptLeadQueryHandler(_leadsRepository);
            await acceptLeadQueryHandler.Handle(acceptLeadQuery);
            return await Task.FromResult(Ok());
        }

        [HttpPut]
        [Route("/decline")]
        public async Task<IActionResult> DeclineLead([FromQuery(Name = "jobid")] int jobId)
        {
            var declineLeadQuery = new DeclineLeadQuery(jobId);
            var declineLeadQueryHandler = new DeclineLeadQueryHandler(_leadsRepository);
            await declineLeadQueryHandler.Handle(declineLeadQuery);
            return await Task.FromResult(Ok());
        }
    }

    public class DeclineLeadQuery
    {
        public int JobId { get; }

        public DeclineLeadQuery(int jobId)
        {
            JobId = jobId;
        }
    }
    
    public class DeclineLeadQueryHandler
    {
        private readonly LeadsRepository _leadsRepository;

        public DeclineLeadQueryHandler(LeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task Handle(DeclineLeadQuery declineLeadQuery)
        {
            var leadDocument = await _leadsRepository.GetLeadDocument(declineLeadQuery.JobId);

            leadDocument.Lead.Decline();

            await _leadsRepository.Save(leadDocument);
        }
    }

    public class AcceptLeadQueryHandler
    {
        private readonly LeadsRepository _leadsRepository;

        public AcceptLeadQueryHandler(LeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }

        public async Task Handle(AcceptLeadQuery acceptLeadQuery)
        {
            var leadDocument = await _leadsRepository.GetLeadDocument(acceptLeadQuery.JobId);

            leadDocument.Lead.Accept();

            await _leadsRepository.Save(leadDocument);
        }
    }

    public class AcceptLeadQuery
    {
        public int JobId { get; }

        public AcceptLeadQuery(int jobId)
        {
            JobId = jobId;
        }
    }
}