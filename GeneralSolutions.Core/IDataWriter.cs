using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public interface IDataWriter<DataType>
    {
        void Write(DataType t);
    }
}
