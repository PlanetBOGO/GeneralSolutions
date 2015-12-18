using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace GeneralSolutions
{
    public class SqlValueReaderModule<OutputType> : SqlModuleBase<OutputType>
    {
        readonly static Type resultType = typeof(OutputType);

        public override OutputType Read(SqlQuery query)
        {
            using (SqlConnection connection = new SqlConnection(Context))
            {
                using (SqlCommand command = GetSQLCommand(query, connection))
                {
                    connection.Open();

                    return ExecuteCommand(command);
                }
            }            
        }        

        private static OutputType ExecuteCommand(SqlCommand command)
        {
            Object o = command.ExecuteScalar();
            Type columnType = o.GetType();

            if (!resultType.IsAssignableFrom(columnType))                            
                throw new InvalidCastException("Cannot cast result to type " + resultType.Name);

            return (OutputType)o;
        }

    }

}
