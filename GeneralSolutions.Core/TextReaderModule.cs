using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class TextReaderModule : InputModuleBase<TextReader, int, List<String>>, ITextReader
    {
        public String Read()
        {
            StringBuilder sb = new StringBuilder();

            String line = Context.ReadLine();
            while (line != null)
            {
                sb.Append(line);
                line = Context.ReadLine();
            }        

            return sb.ToString();            
        }

        public override List<String> Read(int capacity)
        {
            List<String> list = new List<String>(capacity);

            String line = Context.ReadLine();
            while (line != null)
            {
                list.Add(line);
                line = Context.ReadLine();
            }

            return list;
        }

    }
}
