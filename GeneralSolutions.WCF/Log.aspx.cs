using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeneralSolutions.WCF
{
    public partial class Log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsCallback)
                Reload();
        }

        protected void btnFromCache_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            CacheTextFileReaderModule fileReader = GetFileReader();
            String fileContent = fileReader.Read();                        
            RenderUI(fileContent, fileReader.Status);
        }

        private CacheTextFileReaderModule GetFileReader()
        {
            CacheTextFileReaderModule fileReader = new CacheTextFileReaderModule();            
            fileReader.Context.AbsoluteFilePath = Server.MapPath("~") + "\\cacheText.txt";
            fileReader.Context.ExparationInSeconds = 30;
            return fileReader;
        }

        private void RenderUI(String fileContent, CacheTextFileReaderStatus status)
        {
            if (!String.IsNullOrEmpty(fileContent))
            {
                txtLog.Text = fileContent;
                Label1.Text = (status == CacheTextFileReaderStatus.FileFromCache) ? "Loaded from cache" : "Loaded from storage";
                Label1.Text = Label1.Text + " " + DateTime.Now;
            }
        }


    }
}