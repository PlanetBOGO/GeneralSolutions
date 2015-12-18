using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Caching;
using System.IO;
using GeneralSolutions;

namespace GeneralSolutions.WCF
{
    public partial class Items : System.Web.UI.Page
    {
        private NewDatabaseEntities db = new NewDatabaseEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Item> items = db.Items.Include(c => c.Category).ToList();
                GridView1.DataSource = items;
                GridView1.DataBind();
            }
        }

        private void Expertiment(Item item)
        {
            String s = item.Color;
            String color = (String)s.Clone();
            item.Color = color;
            int result = db.SaveChanges();
        }
    }
}