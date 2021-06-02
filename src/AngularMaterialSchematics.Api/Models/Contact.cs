using System;

namespace AngularMaterialSchematics.Api.Models
{
    public class Contact
    {
        public Guid ContactId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Contact(string name, string email)
        {
            Name = name;
            Email = email;
        }

        private Contact()
        {

        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
