using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using AngularMaterialSchematics.Api.Models;
using AngularMaterialSchematics.Api.Core;
using AngularMaterialSchematics.Api.Interfaces;

namespace AngularMaterialSchematics.Api.Features
{
    public class RemoveContact
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
                var contact = await _context.Contacts.SingleAsync(x => x.ContactId == request.ContactId);
                
                _context.Contacts.Remove(contact);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    Contact = contact.ToDto()
                };
            }
            
        }
    }
}
