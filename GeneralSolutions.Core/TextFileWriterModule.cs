using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class TextFileWriterModule : ModuleBase<TextFileWriterContext>, ITextWriter, ICollectionWriter
    {
        public TextFileWriterModule()
        {
            Context = new TextFileWriterContext();
        }

        public TextFileWriterModule(String fileName)
            : this()
        {
            Context.FileName = fileName;
        }

        public virtual void Write(String text)
        {
            InitContext();

            if (!String.IsNullOrEmpty(text))
            {
                using (StreamWriter stream = GetStreamWriter())
                    stream.Write(text);
            }                
        }

        public void Write(ICollection<string> list)
        {
            InitContext();

            if (list != null)
            {
                using (StreamWriter stream = GetStreamWriter())
                {
                    foreach(String text in list)
                        stream.Write(text);
                }
            }                            
        }

        public void Write(byte[] data)
        {
            InitContext();            
            File.WriteAllBytes(Context.FileName, data);                
        }

        private void InitContext()
        {
            String directory = Path.GetDirectoryName(Context.FileName);
            if(!String.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);
        }

        private StreamWriter GetStreamWriter()
        {
            if (Context.IsAppend)
                return File.AppendText(Context.FileName);

            return File.CreateText(Context.FileName);
        }


    }

    public class TextFileWriterContext
    {
        public String FileName { get; set; }
        public Boolean IsAppend { get; set; }
    }
}
