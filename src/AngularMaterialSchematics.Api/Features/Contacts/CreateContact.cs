using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AngularMaterialSchematics.Api.Models;
using AngularMaterialSchematics.Api.Core;
using AngularMaterialSchematics.Api.Interfaces;

namespace AngularMaterialSchematics.Api.Features
{
    public class CreateContact
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.Contact).NotNull();
                RuleFor(request => request.Contact).SetValidator(new ContactValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ContactDto Contact { get; set; }
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
                var contact = new Contact(request.Contact.Name, request.Contact.Email);
                
                _context.Contacts.Add(contact);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    Contact = contact.ToDto()
                };
            }
            
        }
    }
}
