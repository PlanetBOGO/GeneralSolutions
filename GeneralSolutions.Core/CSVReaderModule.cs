using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GeneralSolutions
{
    public class CSVReaderModule<InputType> : ModuleBase<TextReader>, IDataReader<List<InputType>>
    {
        static IEnumerable<PropertyInfo> properties = typeof(InputType)
            .GetProperties()
            .Where( p => p.CanRead && p.MemberType == MemberTypes.Property && 
                    p.PropertyType.Namespace == "System" && !p.PropertyType.IsArray);

        public List<InputType> Read()
        {
            String[] header = ReadHeader();
            
            List<InputType> list = new List<InputType>();

            String line = Context.ReadLine();
            while(line != null)
            {
                InputType item = ReadRow(line);
                list.Add(item);
            }
                        
            return list;            
        }

        private InputType ReadRow(string line)
        {
            InputType item = Activator.CreateInstance<InputType>();

            return item;
        }

        private string[] ReadHeader()
        {
            String[] header = null;

            String line = Context.ReadLine();
            if (line != null)
                header = line.Split(',');

            return header;
        }


    }
}
