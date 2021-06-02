using System.Net;
using System.Threading.Tasks;
using AngularMaterialSchematics.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AngularMaterialSchematics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{contactId}", Name = "GetContactByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContactById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContactById.Response>> GetById([FromRoute]GetContactById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Contact == null)
            {
                return new NotFoundObjectResult(request.ContactId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetContactsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContacts.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContacts.Response>> Get()
            => await _mediator.Send(new GetContacts.Request());
        
        [HttpPost(Name = "CreateContactRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateContact.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateContact.Response>> Create([FromBody]CreateContact.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetContactsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetContactsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetContactsPage.Response>> Page([FromRoute]GetContactsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateContactRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateContact.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateContact.Response>> Update([FromBody]UpdateContact.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{contactId}", Name = "RemoveContactRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveContact.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveContact.Response>> Remove([FromRoute]RemoveContact.Request request)
            => await _mediator.Send(request);
        
    }
}
