using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace GeneralSolutions
{
    public class CacheTextFileReaderModule : ModuleBase<CacheTextFileReaderContext>, ITextReader  
    {                
        public CacheTextFileReaderStatus Status { get; private set; }

        public CacheTextFileReaderModule()
        {
            Context = new CacheTextFileReaderContext();
        }

        public string Read()
        {
            Status = CacheTextFileReaderStatus.FileNotFound;

            InitContext();
            
            ObjectCache cache = MemoryCache.Default;
            string fileContents = cache[Context.CacheKey] as string;
            if (fileContents == null)
            {                
                if (File.Exists(Context.AbsoluteFilePath))
                {
                    CacheItemPolicy policy = CreateCachePolicy();
                    fileContents = ReadFromFile();
                    cache.Set(Context.CacheKey, fileContents, policy);
                    Status = CacheTextFileReaderStatus.FileFromStorage;
                }                
            }
            else
            {
                Status = CacheTextFileReaderStatus.FileFromCache;
            }

            return fileContents;   
        }

        private void InitContext()
        {
            if (String.IsNullOrEmpty(Context.CacheKey))
                Context.CacheKey = Context.AbsoluteFilePath.GetHashCode().ToString();
        }

        private CacheItemPolicy CreateCachePolicy()
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now.AddSeconds(Context.ExparationInSeconds);
            List<string> filePaths = new List<string>() { Context.AbsoluteFilePath };
            policy.ChangeMonitors.Add(new HostFileChangeMonitor(filePaths));
            return policy;
        }

        private String ReadFromFile()
        {
            TextFileReaderModule fileReader = new TextFileReaderModule();
            fileReader.Context = Context.AbsoluteFilePath;
            return fileReader.Read();            
        }
    }

    public class CacheTextFileReaderContext
    {
        public String AbsoluteFilePath { get; set; }
        public int ExparationInSeconds { get; set; }
        public String CacheKey { get; set; }
    }

    public enum CacheTextFileReaderStatus
    {
        FileNotFound,
        FileFromCache,
        FileFromStorage
    }
}


////////////////////////////////////////////////////////////////////////////////////
// Monitor file changes
// Using Status property to analyze read operation result
// Absolute file path is required
