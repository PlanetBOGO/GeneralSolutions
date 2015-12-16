using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GeneralSolutions.Partial_Classes
{
    public class ItemMetadata
    {
        [XmlIgnoreAttribute]
        public virtual Category Category { get; set; }
    }
}
