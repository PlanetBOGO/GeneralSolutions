using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GeneralSolutions
{
    public class CSVTextWriterModule<OutputType> : OutputModuleBase<TextWriter, ICollection<OutputType>>
    {
        public override void Write(ICollection<OutputType> items)
        {
            var lastItem = items.LastOrDefault();
            
            foreach(var item in items)
            {
                WriteRow(item);

                if(!item.Equals(lastItem))
                    Context.Write(Environment.NewLine);
            }
        }

        static IEnumerable<PropertyInfo> properties = 
            typeof(OutputType)
            .GetProperties()
            .Where(p => p.CanRead && p.MemberType == MemberTypes.Property && p.PropertyType.Namespace == "System" && !p.PropertyType.IsArray);

        PropertyInfo lastProperty = properties.LastOrDefault();

        private void WriteRow(OutputType item)
        {
            foreach (PropertyInfo p in properties)
            {
                Object o = p.GetValue(item);
                String value = (o != null) ? o.ToString() : "";

                if (value.Contains(",") || value.Contains("\"") || value.Contains("\r") || value.Contains("\n"))
                    value = string.Format("\"{0}\"", value);

                Context.Write(value);
                
                if(p != lastProperty)
                    Context.Write(",");
            }
        }

    }
}
