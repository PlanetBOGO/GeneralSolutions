using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneralSolutions
{
    class DataAccessProgram
    {
        static void Main(string[] args)
        {
            TextWriterModule writer = new TextWriterModule();
            writer.Context = Console.Out;
            writer.Write(GetWelcomeMessage());

            NewDatabaseEntities database = new NewDatabaseEntities();

            ReportDataModule dataProcessor = new ReportDataModule();
            dataProcessor.Context = database;
            List<Item> items = dataProcessor.Read();  

            ReportWriter reportWriter = new ReportWriter();
            reportWriter.Context = Console.Out;
            reportWriter.Write(items);
            
            int count = database.Items.Count();
            writer.Write(Environment.NewLine);

            writer.Write(String.Format("\nItems scanned: {0}", count), Environment.NewLine);

            Console.ReadKey();
        }

        static IEnumerable<String> GetWelcomeMessage()
        {
            yield return "General Solutions command line tool\n\n";
        }
    }
}
