using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    class ProgramNorthwind
    {
        /// Requirement: App.Config to contain connection String named DefaultConnection
        readonly static String connectionString = ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString();

        static void Main(string[] args)
        {

        }
    }
}
