using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class SqlQuery
    {
        public String Query { get; set; }

        public Dictionary<String, String> Parameters = new Dictionary<string,string>();

        public Boolean IsStoredProcedure { get; set; }
    }
}
