using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    class XMLProgram
    {
        /// Requirement: App.Config "DefaultConnection" connection string to NewDatabase
        readonly static String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        /// Requirement: SQL query is stored in external file. Select Items from NewDatabase 
        const string SQLQueryFile = "Select.sql";
        
        /// Requirement: Save items to XML file. 
        const string XMLFile = "Storage.xml";

        readonly static ITextWriter output = new TextWriterModule { Context = Console.Out };

        static void Main(string[] args)
        {
            List<Item> list = ReadListFromDatabase();            
            WriteListToXMLFile(list);
            PrintXMLFileToScreen();
            list = ReadListFromXMLFile();
            PrintReportToScreen(list);

            Console.ReadKey();
        }

        private static List<Item> ReadListFromDatabase()
        {
            ITextReader reader = new TextFileReaderModule(SQLQueryFile);
            String sqlQuery = reader.Read();
            SqlQuery query = new SqlQuery { Query = sqlQuery };

            SqlListReaderModule<Item> sqlReader = new SqlListReaderModule<Item> { Context = ConnectionString };
            List<Item> list = sqlReader.Read(query);
            return list;
        }

        private static void WriteListToXMLFile(List<Item> list)
        {
            var listOfDTOs = list.Select(i => new ItemDTO(i)).ToList();
            XMLFileWriterModule<ItemDTO> xmlWriter = new XMLFileWriterModule<ItemDTO>(XMLFile);
            xmlWriter.Write(listOfDTOs);
        }

        private static List<Item> ReadListFromXMLFile()
        {
            XMLFileReaderModule<ItemDTO> xmlReader = new XMLFileReaderModule<ItemDTO>(XMLFile);
            List<ItemDTO> listOfDTOs = xmlReader.Read();
            List<Item> list = listOfDTOs.Select(d => d.ToItem()).ToList();

            return list;
        }

        private static void PrintXMLFileToScreen()
        {
            ITextReader textReader = new TextFileReaderModule(XMLFile);
            String text = textReader.Read();
            output.Write(text);
            output.Write(Environment.NewLine);
            output.Write(Environment.NewLine);
        }

        private static void PrintReportToScreen(List<Item> list)
        {
            IDataWriter<IEnumerable<Item>> report = new ReportWriter(Console.Out);
            report.Write(list);
        }

    }

}
