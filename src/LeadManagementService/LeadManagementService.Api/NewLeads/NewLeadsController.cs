using System.Net;
using System.Threading.Tasks;
using LeadManagementService.Interfaces.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagementService.NewLeads
{
    [EnableCors("PublicPolicy")]
    [Route("/")]
    public class NewLeadsController : ControllerBase
    {
        private readonly ILeadsRepository _leadsRepository;

        public NewLeadsController(ILeadsRepository leadsRepository)
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
            var acceptLeadQuery = new AcceptLeadCommand(jobId);
            var acceptLeadQueryHandler = new AcceptLeadCommandHandler(_leadsRepository);
            await acceptLeadQueryHandler.Handle(acceptLeadQuery);
            return await Task.FromResult(Ok());
        }

        [HttpPut]
        [Route("/decline")]
        public async Task<IActionResult> DeclineLead([FromQuery(Name = "jobid")] int jobId)
        {
            var declineLeadQuery = new DeclineLeadCommand(jobId);
            var declineLeadQueryHandler = new DeclineLeadCommandHandler(_leadsRepository);
            await declineLeadQueryHandler.Handle(declineLeadQuery);
            return await Task.FromResult(Ok());
        }
    }
}