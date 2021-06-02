using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using AngularMaterialSchematics.Api.Extensions;
using AngularMaterialSchematics.Api.Core;
using AngularMaterialSchematics.Api.Interfaces;
using AngularMaterialSchematics.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AngularMaterialSchematics.Api.Features
{
    public class GetContactsPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<ContactDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IAngularMaterialSchematicsDbContext _context;
        
            public Handler(IAngularMaterialSchematicsDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from contact in _context.Contacts
                    select contact;
                
                var length = await _context.Contacts.CountAsync();
                
                var contacts = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = contacts
                };
            }
            
        }
    }
}
