using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CaseStudy.Concentrix.Abstraction.Model
{
    public class Address: Base
    {

        [Required(ErrorMessage = "Please enter  first name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter street")]
        [StringLength(100)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter city")]
        [StringLength(100)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter state")]
        [StringLength(100)]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter zipcode")]
        [StringLength(100)]
        public string ZipCode { get; set; }
    }

}
