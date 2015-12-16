using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneralSolutions
{
    public class AssemblyExaminerModule : InputModuleBase<String, Assembly, List<String>>
    {
        public override List<String> Read(Assembly assembly)
        {
            List<String> list = new List<string>();

            Attribute a = assembly.GetCustomAttribute(typeof(AssemblyTitleAttribute));
            AssemblyTitleAttribute ta = a as AssemblyTitleAttribute;
            list.Add(ta.Title);

            list.Add(assembly.GetName().FullName);
            list.Add(assembly.GetName().Name);
            list.Add(assembly.GetName().Version.ToString());
            list.Add(assembly.GetName().CultureName);

            return list;
        }
    }
}
