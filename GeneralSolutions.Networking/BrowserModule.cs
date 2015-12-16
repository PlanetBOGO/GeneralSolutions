using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class BrowserModule : ModuleBase<String>
    {
        public virtual void Open(String target)
        {
            Before("BrowserModule.Open()");

            System.Diagnostics.Process.Start(target);

            After("BrowserModule.Open()");
        }
    }
}
