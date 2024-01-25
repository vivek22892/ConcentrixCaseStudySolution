using CaseStudy.Concentrix.Abstraction.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Abstraction.Interface
{
    public interface IAuthenticateService
    {
        JwtToken AuthenticateUser(User userDTO);
    }
}
