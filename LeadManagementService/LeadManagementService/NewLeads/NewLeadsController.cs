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
        
        [HttpGet]
        [Route("/accepted")]
        [ProducesResponseType(typeof(GetAcceptedLeadsQueryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAcceptedLeads()
        {
            var getAcceptedLeadsQuery = new GetAcceptedLeadsQuery();
            var getAcceptedLeadsQueryHandler = new GetAcceptedLeadsQueryHandler(_leadsRepository);
            var getAcceptedLeadsQueryResponse = await getAcceptedLeadsQueryHandler.Handle(getAcceptedLeadsQuery);

            return Ok(getAcceptedLeadsQueryResponse);
        } 
    }
}