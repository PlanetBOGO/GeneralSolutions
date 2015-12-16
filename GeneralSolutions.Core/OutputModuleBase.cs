using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public abstract class OutputModuleBase<ContextType, InputType> : ModuleBase<ContextType>
    {
        public abstract void Write(InputType i);
    }
}
