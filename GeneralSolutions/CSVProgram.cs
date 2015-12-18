using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    class CSVProgram
    {
        /// Requirement: App.Config has DefaultConnection connection string
        readonly static String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        /// Requirement: SQL database has "Item" table
        private const string SelectAllQuery = "SELECT * FROM Item";        
        readonly static SqlListReaderModule<Item> reader = new SqlListReaderModule<Item> { Context = connectionString };
        private const string SelectCountQuery = "SELECT count(*) FROM Item;";
                                
        /// Requirement: CSV will be stored in file named CSVFile
        const String CSVFile = "storage.csv";

        static void Main(string[] args)
        {
            PrintWelcomeMessage();            
            PrintNumberOfExpectedResults();
            var list = ReadListFromDatabase();
            WriteCSVToFile(list);
            list = ReadCSVFromFile();
            PrintCSVToScreen(list);

            Console.ReadKey();
        }

        private static void PrintWelcomeMessage()
        {
            String welcome =
                "General Solutions command line tool\n" +
                "Save table as CSV file\n\n";

            Console.Write(welcome);
        }

        private static void PrintNumberOfExpectedResults()
        {
            int n = GetRecordCount();
            Console.Write("{0} records in {1} table\n\n", n.ToString(), "dbo.[Item]");
        }

        private static List<Item> ReadListFromDatabase()
        {
            SqlQuery sql = new SqlQuery { Query = SelectAllQuery };

            return reader.Read(sql);
        }

        private static void WriteCSVToFile(List<Item> list)
        {
            using (TextWriter w = File.CreateText(CSVFile))
            {
                CSVWriterModule<Item> csv = new CSVWriterModule<Item>();
                csv.Context = w;
                csv.Write(list);
            }
        }

        private static List<Item> ReadCSVFromFile()
        {
            using (TextReader r = File.OpenText(CSVFile))
            {
                CSVReaderModule<Item> csvReader = new CSVReaderModule<Item>();
                csvReader.Context = r;
                List<Item> list = csvReader.Read().ToList();

                return list;
            }
        }

        private static void PrintCSVToScreen(List<Item> list)
        {                        
            CSVWriterModule<Item> csv = new CSVWriterModule<Item>();
            csv.Context = Console.Out;
            csv.Write(list);
            Console.Out.WriteLine();
        }

        private static int GetRecordCount()
        {
            SqlQuery sqlCount = new SqlQuery { Query = SelectCountQuery };
            SqlValueReaderModule<int> valueReader = new SqlValueReaderModule<int> { Context = connectionString };

            return valueReader.Read(sqlCount);
        }

    }
}
