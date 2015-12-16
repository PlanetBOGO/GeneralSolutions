using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GeneralSolutions
{
    public abstract class ModuleBase<ContextType>
    {
        public ContextType Context { get; set; }
        public static ITextWriter Logger { get; set; }

        public String Name { get; set; }
        public String Version { get; set; }

        protected virtual void Before(String action)
        {
            if(Logger != null)
            {
                Logger.Write(String.Format("{0} - Before {1}\n", DateTime.Now, action));
            }
        }

        protected virtual void After(String action)
        {
            if (Logger != null)
            {
                Logger.Write(String.Format("{0} - After {1}\n", DateTime.Now, action));
            }
        }
        
        public ModuleBase()
        {
            Name = GetTitle();
            Version = GetVersion();
        }        
        
        private static String GetTitle()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Attribute a = assembly.GetCustomAttribute(typeof(AssemblyTitleAttribute));

            AssemblyTitleAttribute ta = a as AssemblyTitleAttribute;
            return ta.Title;
        }

        private static String GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Version.ToString();
        }
    }
}

////////////////////////////////////////////////////////////////////////////////////
// Implemenation details in VS2013
// - All modules inherit custom confuration from the base class
