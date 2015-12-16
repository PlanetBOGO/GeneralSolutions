using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class DownloadModule : ModuleBase<HTTPContext>
    {
        private WebClient webClient;

        public void Download(String URL, String file)
        {
            using (webClient = new WebClient())
            {
                webClient.Credentials = CredentialCache.DefaultCredentials;
                if (Context != null)
                    InitContext();

                webClient.DownloadFile(URL, file);
            }
        }

        private void InitContext()
        {
            if (Context.Credentials != null)
                webClient.Credentials = Context.Credentials;
        }
    }
}

/////////////////////////////////////////
// Continue from here:
// http://www.csharp-examples.net/download-files/
