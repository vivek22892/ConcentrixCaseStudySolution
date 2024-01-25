using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Concentrix.Abstraction.Model
{
    public class JwtToken
    {
        public JwtToken()
        {
            Authenticated = false;

        }
        public string Token { get; set; }
        public bool Authenticated { get; set; }
    }
}
