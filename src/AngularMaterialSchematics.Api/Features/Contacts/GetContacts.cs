using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using AngularMaterialSchematics.Api.Core;
using AngularMaterialSchematics.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AngularMaterialSchematics.Api.Features
{
    public class GetContacts
    {
        public class Request: IRequest<Response> { }

        public class Response: ResponseBase
        {
            public List<ContactDto> Contacts { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAngularMaterialSchematicsDbContext _context;
        
            public Handler(IAngularMaterialSchematicsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                return new () {
                    Contacts = await _context.Contacts.Select(x => x.ToDto()).ToListAsync()
                };
            }
            
        }
    }
}
