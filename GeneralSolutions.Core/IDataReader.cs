using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralSolutions
{
    public interface IDataReader<DataType>
    {
        DataType Read();
    }
}
