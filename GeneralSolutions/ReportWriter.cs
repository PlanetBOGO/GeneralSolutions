using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class ReportWriter : ModuleBase<TextWriter> , IDataWriter<IEnumerable<Item>>
    {
        public ReportWriter()
        {

        }

        public ReportWriter(TextWriter writer)
        {
            this.Context = writer;
        }

        public void Write(IEnumerable<Item> items)
        {
            String format = "\t{0:8}\t\t{1:8}\t\t{2:8}\t\t{3,8:d}";

            Context.WriteLine(format, "id", "Number", "Color", "Category");
            Context.WriteLine("\t----------------------------------------------------------");
            
            foreach(var i in items)
                Context.WriteLine(format, i.Id.ToString(), i.Number.ToString(), i.Color, (i.Category != null? i.Category.Name : ""));

            Context.WriteLine("\t----------------------------------------------------------");
            Context.WriteLine("\tCount: {0}", items.Count().ToString());
        }
    }
}
