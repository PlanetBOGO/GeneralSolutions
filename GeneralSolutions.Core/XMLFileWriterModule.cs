using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GeneralSolutions
{
    public class XMLFileWriterModule<InputType> : ModuleBase<String>, IDataWriter<ICollection<InputType>>
    {
        public XMLFileWriterModule()
        {

        }

        public XMLFileWriterModule(String fileName) : this()
        {
            Context = fileName;
        }

        public void Write(ICollection<InputType> list)
        {
            if (Context != null)
            {
                InitContext();
                WriteToFile(list);
            }
        }

        private void InitContext()
        {
            String directory = Path.GetDirectoryName(Context);
            if (!String.IsNullOrEmpty(directory))
                Directory.CreateDirectory(directory);         
        }

        private void WriteToFile(ICollection<InputType> list)
        {
            using (TextWriter writer = new StreamWriter(Context))
            {
                XmlSerializer xs = new XmlSerializer(list.GetType());
                xs.Serialize(writer, list);
            }
        }

    }
}
