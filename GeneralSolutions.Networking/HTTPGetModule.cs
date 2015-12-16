using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class HTTPGetModule : ModuleBase<HTTPContext>
    {
        public Boolean IsSuccess { get { return Status.HttpStatusCode == System.Net.HttpStatusCode.OK; } }

        public HTTPStatus Status { get; set; }

        private HttpWebRequest request;

        public HTTPGetModule()
        {
            Context = new HTTPContext();
            Context.Credentials = CredentialCache.DefaultCredentials;
        }

        public virtual String Get(String URL)
        {
            using (HttpWebResponse response = GetResponse(URL))
            {
                Status = new HTTPStatus { HttpStatusCode = response.StatusCode, Description = response.StatusDescription };

                using (Stream dataStream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(dataStream))
                    return reader.ReadToEnd();
            }
        }

        public virtual byte[] GetBinary(String URL)
        {
            using (HttpWebResponse response = GetResponse(URL))
            {
                Status = new HTTPStatus { HttpStatusCode = response.StatusCode, Description = response.StatusDescription };

                using (Stream dataStream = response.GetResponseStream())
                using (var ms = new MemoryStream())
                {
                    dataStream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }

        private HttpWebResponse GetResponse(String URL)
        {
            request = (HttpWebRequest)WebRequest.Create(URL);
            request.Credentials = Context.Credentials;

            return (HttpWebResponse)request.GetResponse();            
        }            

    }

}

//////////////////////////////////////////
// Continue from here
// http://nonsequiturs.com/articles/how-to-read-a-binary-file-over-http-and-write-to-disk-using-asp-net-and-c/