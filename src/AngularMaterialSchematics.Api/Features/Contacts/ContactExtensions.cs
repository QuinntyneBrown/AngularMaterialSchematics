using AngularMaterialSchematics.Api.Models;

namespace AngularMaterialSchematics.Api.Features
{
    public static class ContactExtensions
    {
        public static ContactDto ToDto(this Contact contact)
        {
            return new ()
            {
                ContactId = contact.ContactId,
                Name = contact.Name,
                Email = contact.Email
            };
        }
        
    }
}
