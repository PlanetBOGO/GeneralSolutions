using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    class SqlReaderProgram
    {
        /// Requirement: App.Config to contain connection String named DefaultConnection
        readonly static String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        /// Requirement: Table "Item" in SQL database 
        private const string SelectAllQuery = "SELECT * FROM Item";        
        readonly static SqlListReaderModule<Item> reader = new SqlListReaderModule<Item> { Context = connectionString };

        private const string SelectCountQuery = "SELECT count(*) FROM Item;";
        readonly static SqlValueReaderModule<int> valueReader = new SqlValueReaderModule<int> { Context = connectionString };

        readonly static TextWriterModule writer = new TextWriterModule { Context = Console.Out };

        
        static void Main(string[] args)
        {
            PrintWelcomeMessage();            
            PrintNumberOfExpectedResults();

            var list = ReadListFromDatabase();                        
            PrintList(list);

            Console.ReadKey();
        }

        private static void PrintWelcomeMessage()
        {
            String welcome =
                "General Solutions command line tool\n" +
                "Save table as CSV file\n\n";

            writer.Write(welcome);
        }

        private static void PrintNumberOfExpectedResults()
        {
            int n = GetRecordCount();
            writer.Write(String.Format("{0} records in {1} table\n\n", n.ToString(), "dbo.[Item]"));
        }

        private static List<Item> ReadListFromDatabase()
        {
            SqlQuery sql = new SqlQuery { Query = SelectAllQuery };

            return reader.Read(sql);
        }

        private static void PrintList(List<Item> list)
        {                        
            CSVTextWriterModule<Item> csv = new CSVTextWriterModule<Item>();
            csv.Context = Console.Out;
            csv.Write(list);
        }

        private static int GetRecordCount()
        {
            SqlQuery sqlCount = new SqlQuery { Query = SelectCountQuery };
            return valueReader.Read(sqlCount);
        }

    }
}
