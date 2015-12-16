using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public abstract class InputModuleBase<ContextType, InputType, OutputType> : ModuleBase<ContextType>
    {
        public abstract OutputType Read(InputType i);
    }
}
