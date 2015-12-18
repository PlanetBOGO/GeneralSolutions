using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Collections.Generic;

namespace GeneralSolutions.Data.Test
{
    [TestClass]
    public class SqlTests
    {
        private static String ConnectionString {get; set;}


        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }
                
        [TestMethod]
        public void ReadListFromSQL()
        {
            // Arrange
            SqlListReaderModule<Item> db = new SqlListReaderModule<Item>();
            db.Context = ConnectionString;

            SqlQuery query = new SqlQuery();
            query.Query = "SELECT top 5 id, Number, Color FROM Item;";

            // Act
            List<Item> items = db.Read(query);

            // Assert
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count > 0);

            foreach(var item in items)
                Assert.IsNotNull(item.ID);

        }

        [TestMethod]
        public void ReadValueFromSQL()
        {
            // Arrange
            SqlValueReaderModule<int> db = new SqlValueReaderModule<int>();
            db.Context = ConnectionString;

            SqlQuery query = new SqlQuery();
            query.Query = "SELECT count(*) FROM Item;";

            // Act
            int count = db.Read(query);

            // Assert
            Assert.IsTrue(count > 0);

        }

        [TestMethod]
        public void ReadValueFromSQL_WithParameters()
        {
            // Arrange
            SqlValueReaderModule<int> db = new SqlValueReaderModule<int>();
            db.Context = ConnectionString;

            SqlQuery query = new SqlQuery();
            query.Query = "SELECT count(*) FROM Item WHERE Color = @color;";
            query.Parameters["@color"] = "Black";

            // Act
            int count = db.Read(query);

            // Assert
            Assert.IsTrue(count == 1);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void ReadValueFromSQL_InvalidCast()
        {
            // Arrange
            SqlValueReaderModule<string> db = new SqlValueReaderModule<string>();
            db.Context = ConnectionString;

            SqlQuery query = new SqlQuery();
            query.Query = "SELECT count(*) FROM Item;";

            // Act
            string count = db.Read(query);

            // Assert exception occured
        }

    }
}
