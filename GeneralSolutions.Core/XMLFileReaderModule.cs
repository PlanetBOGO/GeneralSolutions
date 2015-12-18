using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GeneralSolutions
{
    public class XMLFileReaderModule<OutputType> : ModuleBase<String>
    {        
        public XMLFileReaderModule()
        {

        }

        public XMLFileReaderModule(string XMLFile) : this()
        {            
            this.Context = XMLFile;
        }

        public List<OutputType> Read()
        {
            using (TextReader reader = new StreamReader(Context))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<OutputType>));
                Object o = xs.Deserialize(reader);

                return o as List<OutputType>;
            }
        }
    }
}
