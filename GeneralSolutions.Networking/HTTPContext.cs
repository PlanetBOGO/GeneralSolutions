using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class HTTPContext
    {
        public String Accept;
        public ICredentials Credentials { get; set; }
        public IWebProxy Proxy { get; set; }
    }
}
