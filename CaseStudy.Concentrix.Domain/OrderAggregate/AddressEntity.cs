using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Concentrix.Domain.OrderAggregate
{
    public class AddressEntity: BaseEntity
    {
        public AddressEntity()
        {

        }

        public AddressEntity(string firstName, string lastName, 
            string street, string city, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
