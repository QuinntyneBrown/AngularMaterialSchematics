using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using AngularMaterialSchematics.Api.Core;
using AngularMaterialSchematics.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularMaterialSchematics.Api.Features
{
    public class GetContactById
    {
        public class Request: IRequest<Response>
        {
            public Guid ContactId { get; set; }
        }

        public class Response: ResponseBase
        {
            public ContactDto Contact { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAngularMaterialSchematicsDbContext _context;
        
            public Handler(IAngularMaterialSchematicsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Contact = (await _context.Contacts.SingleOrDefaultAsync(x => x.ContactId == request.ContactId)).ToDto()
                };
            }
            
        }
    }
}
