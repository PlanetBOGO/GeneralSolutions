using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace GeneralSolutions
{
    public class SqlListReaderModule<OutputType> : SqlModuleBase<List<OutputType>>
    {
        static IEnumerable<PropertyInfo> properties = typeof(OutputType).GetProperties().Where(p => p.CanWrite);

        public override List<OutputType> Read(SqlQuery query)
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

        private static List<OutputType> ExecuteCommand(SqlCommand command)
        {
            List<OutputType> list = new List<OutputType>();
            
            using (SqlDataReader SqlReader = command.ExecuteReader())
            {
                if (SqlReader.HasRows)
                    ReadAllRows(list, SqlReader);

                SqlReader.Close();
            }

            return list;
        }

        private static void ReadAllRows(List<OutputType> list, SqlDataReader SqlReader)
        {            
            while (SqlReader.Read())
            {
                OutputType item = ReadOneRow(SqlReader);
                list.Add(item);
            }
        }

        private static OutputType ReadOneRow(SqlDataReader SqlReader)
        {
            OutputType item = (OutputType)Activator.CreateInstance(typeof(OutputType));

            for (int i = 0; i < SqlReader.FieldCount; i++)
            {
                String column = SqlReader.GetName(i);
                Type columnType = SqlReader.GetFieldType(i);

                PropertyInfo matchingProperty = properties.FirstOrDefault(
                    p => p.Name.Equals(column, StringComparison.InvariantCultureIgnoreCase) &&
                         p.PropertyType.IsAssignableFrom(columnType)
                );

                if (matchingProperty != null)
                {
                    if (!SqlReader.IsDBNull(i))
                    {
                        Object value = SqlReader.GetValue(i);
                        matchingProperty.SetValue(item, value);
                    }
                }
            }
            return item;
        }
    }

}
