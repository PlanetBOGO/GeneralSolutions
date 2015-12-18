using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GeneralSolutions
{
    public class CSVWriterModule<OutputType> : ModuleBase<TextWriter>, IDataWriter<IEnumerable<OutputType>>
    {
        static IEnumerable<PropertyInfo> properties =typeof(OutputType)
            .GetProperties()
            .Where( p => p.CanRead && p.MemberType == MemberTypes.Property && 
                    p.PropertyType.Namespace == "System" && !p.PropertyType.IsArray);

        public void Write(IEnumerable<OutputType> items)
        {
            WriteHeaderRow();
            
            foreach(var item in items)
            {
                Context.Write(Environment.NewLine);
                WriteRow(item);                    
            }
        }

        private void WriteHeaderRow()
        {
            PropertyInfo lastProperty = properties.LastOrDefault();

            foreach (PropertyInfo p in properties)
            {
                Context.Write(p.Name);

                if (p != lastProperty)
                    Context.Write(",");
            }            
        }

        private void WriteRow(OutputType item)
        {
            PropertyInfo lastProperty = properties.LastOrDefault();

            foreach (PropertyInfo p in properties)
            {
                WriteColumn(item, p);
                
                if(p != lastProperty)
                    Context.Write(",");
            }
        }

        private void WriteColumn(OutputType item, PropertyInfo p)
        {
            Object o = p.GetValue(item);
            String value = (o != null) ? o.ToString() : "";

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\r") || value.Contains("\n"))
                value = string.Format("\"{0}\"", value);

            Context.Write(value);
        }

    }
}
