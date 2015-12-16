using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GeneralSolutions.ADO.NET
{
    
    public partial class Form1 : Form
    {
        /// Requirement: Sql commands are stored as separate files
        const String FileNameForSelectCommand = "Select.sql";
        
        /// Requirement: App.Config to contain connection String named DefaultConnection
        readonly static String ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        
        static SqlDataAdapter adapter = null;
        static DataSet ds = new DataSet();

        const Boolean IsPrimaryKey = true; 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = ReadData();            
            dataGridView1.DataSource = ds.Tables[0];
        }

        private static DataSet ReadData()
        {            
            ITextReader fileReader = new TextFileReaderModule {Context = FileNameForSelectCommand};
            String selectQuery = fileReader.Read();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                adapter = new SqlDataAdapter(selectQuery, connection);
                adapter.Fill(ds, "Item");
                DataTable dt = ds.Tables["Item"];
                dt.Constraints.Add("PK_Item", dt.Columns["Number"], IsPrimaryKey);
            }

            return ds;
        }
    }
}
