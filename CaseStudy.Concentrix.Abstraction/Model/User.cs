using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Abstraction.Model
{
    public class User : Base
    {
        public int Id { get; set; } = 1;
        public string? FirstName { get; set; } = "Vivek";
        public string? LastName { get; set; } = "Sharma";
        public string? UserName { get; set; } = "Vivek Sharma";
        public string? Email { get; set; } = "vivek.22892@gmail.com";
        public bool? IsActive { get; set; } = true;

    }
}
