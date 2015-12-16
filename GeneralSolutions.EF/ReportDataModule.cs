using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class ReportDataModule : ModuleBase<NewDatabaseEntities>
    {        
        public List<Item> Read()
        {
            var query = from item in Context.Items
                        orderby item.Number
                        select item;

            return query.ToList();
        }
    }
}
