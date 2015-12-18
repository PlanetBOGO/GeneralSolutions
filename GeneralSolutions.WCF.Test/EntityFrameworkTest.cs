using System;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace GeneralSolutions.WCF.Test
{
    [TestClass]
    public class EntityFrameworkTest
    {

        [TestMethod]
        public void CanRead()
        {
            using (NewDatabaseEntities db = new NewDatabaseEntities())
            {
                var items = db.Items.ToList();

                Assert.IsTrue(items.Count() > 0);
            }
        }

        [TestMethod]
        public void ItemIsModified_WhenDifferentColorIsAssigned()
        {
            using (NewDatabaseEntities db = new NewDatabaseEntities())
            {
                var items = db.Items.ToList();
                Item item0 = items.First();
                item0.Color = "Not a color";
                 
                DbEntityEntry<Item> item = db.ChangeTracker.Entries<Item>().FirstOrDefault();

                Assert.AreEqual(item.State, EntityState.Modified);
            }
        }

        [TestMethod]
        public void ItemIsUnchanged_WhenSaveValueUssigned()
        {
            using (NewDatabaseEntities db = new NewDatabaseEntities())
            {
                var items = db.Items.ToList();
                Item item0 = items.First();
                String color = (String)item0.Color.Clone();
                item0.Color = color;

                DbEntityEntry<Item> item = db.ChangeTracker.Entries<Item>().FirstOrDefault();

                Assert.AreEqual(item.State, EntityState.Unchanged);
            }
        }


    }
}
