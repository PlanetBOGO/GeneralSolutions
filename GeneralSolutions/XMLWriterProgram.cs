using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    class XMLWriterProgram
    {
        /// Requirement: App.Config to contain connection String named DefaultConnection
        readonly static String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

        /// Requirement: Read SQL query from external file
        const string FileNameForSQLQuery = "Select.sql";
        
        /// Requirement: Store results in XML Storage
        const string FileNameForXMLStorage = "Storage.xml";

        readonly static ITextWriter writer = new TextWriterModule { Context = Console.Out };

        static void Main(string[] args)
        {
            ITextReader textReader = new TextFileReaderModule { Context = FileNameForSQLQuery };
            SqlQuery query = new SqlQuery { Query = textReader.Read() }; 

            
            SqlListReaderModule<Item> sqlReader = new SqlListReaderModule<Item> { Context = connectionString };            
            List<Item> list = sqlReader.Read(query);
            List<Storage.Item> storageList = TransformData(list);


            XMLFileWriterModule<Storage.Item> xml = new XMLFileWriterModule<Storage.Item> { Context = FileNameForXMLStorage };
            xml.Write(storageList);


            TextFileReaderModule fileReader = new TextFileReaderModule { Context = FileNameForXMLStorage };
            String text = fileReader.Read();            
            writer.Write(text);
            

            Console.ReadKey();
        }

        private static List<Storage.Item> TransformData(List<Item> list)
        {
            List<Storage.Item> storageList = list
                .Select(i => new Storage.Item
                {
                    Number = i.Number,
                    Color = i.Color,
                    Weight = i.Weight,
                    IsAvailable = i.IsAvailable,
                    PurchaseDate = i.PurchaseDate,
                    Guid = i.Guid,
                    CategoryId = i.CategoryId,
                    FileName = i.FileName,
                    Price = i.Price,
                    Model = i.Model
                })
                .ToList();
            return storageList;
        }
    }
}
