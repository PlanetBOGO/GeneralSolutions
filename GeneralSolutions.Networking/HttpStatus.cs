using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    [Serializable]
    public class HTTPStatus
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public String Description { get; set; }
    }
}
