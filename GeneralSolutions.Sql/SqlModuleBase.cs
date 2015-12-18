using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public abstract class SqlModuleBase<OutputType> : InputModuleBase<String, SqlQuery, OutputType>
    {
        protected static SqlCommand GetSQLCommand(SqlQuery query, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(query.Query, connection);

            var parameters = query.Parameters;
            foreach (var name in parameters.Keys)
                command.Parameters.AddWithValue(name, parameters[name]);

            if (query.IsStoredProcedure)
                command.CommandType = System.Data.CommandType.StoredProcedure;

            return command;
        }

    }
}
