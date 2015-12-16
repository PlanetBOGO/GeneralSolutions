using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class HTTPPostModule : ModuleBase<HTTPContext>
    {
        public HTTPStatus HTTPStatus { get; set; }

        private HttpWebRequest request;

        public virtual String Post(String URL, String data)
        {
            request = (HttpWebRequest) WebRequest.Create(URL);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (Context != null)
                InitContext();            

            WriteRequestBody(data);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                HTTPStatus = new HTTPStatus { HttpStatusCode = response.StatusCode, Description = response.StatusDescription };

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private void InitContext()
        {
            if (Context.Credentials != null)
                request.Credentials = Context.Credentials;

            if (Context.Accept != null)
                request.Accept = Context.Accept;
        }

        private void WriteRequestBody(String data)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(data);
            request.ContentLength = byte1.Length;
            request.AllowWriteStreamBuffering = true;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(byte1, 0, byte1.Length);
            }
        }

    }

}

//////////////////////////////////////////
// Continue from here
// http://nonsequiturs.com/articles/how-to-read-a-binary-file-over-http-and-write-to-disk-using-asp-net-and-c/