using System.Net;
using System.Threading.Tasks;
using LeadManagementService.Interfaces.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagementService.AcceptedLeads
{
    [EnableCors("PublicPolicy")]
    [Route("/accepted")]
    public class AcceptedLeadsController : ControllerBase
    {
        private readonly ILeadsRepository _leadsRepository;

        public AcceptedLeadsController(ILeadsRepository leadsRepository)
        {
            _leadsRepository = leadsRepository;
        }
        
        [HttpGet]
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